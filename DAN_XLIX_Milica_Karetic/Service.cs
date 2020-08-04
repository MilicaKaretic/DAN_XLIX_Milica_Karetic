using DAN_XLIX_Milica_Karetic.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIX_Milica_Karetic
{
    class Service
    {

        public static List<tblUser> loggedUser = new List<tblUser>();
        //public static List<tblItem> items = new List<tblItem>();
        public static tblUser currentUser = new tblUser();
        //public static tblOrder currentOrder = new tblOrder();

        /// <summary>
        /// get all users from database
        /// </summary>
        /// <returns></returns>
        public List<tblUser> GetAllUsers()
        {
            try
            {
                using (HotelDBEntities context = new HotelDBEntities())
                {
                    List<tblUser> users = new List<tblUser>();
                    users = context.tblUsers.ToList();
                    return users;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Get owner from file
        /// </summary>
        /// <returns></returns>
        public Owner getOwner()
        {
            string location = @"..\..\OwnerAccess.txt";
            try
            {
                Owner owner = new Owner();
                StreamReader sr = new StreamReader(location);
                using (sr)
                {
                    
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] lines = line.Split(':', ' ');
                        owner.Username = lines[1];
                        owner.Password = lines[3];                      
                    }
                }
                return owner;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Gets all information about managers
        /// </summary>
        /// <returns>a list of found managers</returns>
        public List<tblManager> GetAllManagers()
        {
            try
            {
                using (HotelDBEntities context = new HotelDBEntities())
                {
                    List<tblManager> list = new List<tblManager>();
                    list = (from x in context.tblManagers select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Gets all information about employees
        /// </summary>
        /// <returns>a list of found employees</returns>
        public List<tblEmployee> GetAllEmployees()
        {
            try
            {
                using (HotelDBEntities context = new HotelDBEntities())
                {
                    List<tblEmployee> list = new List<tblEmployee>();
                    list = (from x in context.tblEmployees select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public int getUserId(string username)
        {
            try
            {
                using (HotelDBEntities context = new HotelDBEntities())
                {

                    tblUser user = context.tblUsers.FirstOrDefault(c => c.Username == username);

                    int id = user.UserID;
                    return id;
                }
            }

            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Creates or edits a manager
        /// </summary>
        /// <param name="manager">manager to add or edit</param>
        /// <returns>a new or edited manager</returns>
        public vwManager AddManager(vwManager manager)
        {
            //InputCalculator iv = new InputCalculator();
            try
            {
                using (HotelDBEntities context = new HotelDBEntities())
                {
                    //if (manager.UserID == 0)
                    //{
                        //manager.DateOfBirth = iv.CountDateOfBirth(manager.JMBG);

                        manager.DateOfBirth = manager.DateOfBirth;

                        //user
                        tblUser newManager = new tblUser();
                        newManager.Name = manager.Name;
                        newManager.DateOfBirth = manager.DateOfBirth;
                        newManager.Email = manager.Email;
                        newManager.Username = manager.Username;
                        newManager.Password = manager.Password;

                        context.tblUsers.Add(newManager);
                        context.SaveChanges();

                        //manager
                        int id = getUserId(manager.Username);

                        tblManager man = new tblManager();
                        man.Floor = manager.Floor;
                        man.Experience = manager.Experience;
                        man.QualificationsLevel = manager.QualificationsLevel;
                        man.UserID = id;

                        context.tblManagers.Add(man);
                        context.SaveChanges();

                        manager.UserID = newManager.UserID;

                        return manager;
                    //}
                    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
