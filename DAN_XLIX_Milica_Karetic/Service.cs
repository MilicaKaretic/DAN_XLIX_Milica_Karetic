using DAN_XLIX_Milica_Karetic.Model;
using System;
using System.Collections.Generic;
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
    }
}
