using DAN_XLIX_Milica_Karetic.Commands;
using DAN_XLIX_Milica_Karetic.Model;
using DAN_XLIX_Milica_Karetic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DAN_XLIX_Milica_Karetic.ViewModel
{
    class LoginViewModel : BaseViewModel
    {
        Login view;
        Service service = new Service();

        #region Constructors

        public LoginViewModel(Login view)
        {
            this.view = view;
            user = new tblUser();
            UserList = service.GetAllUsers().ToList();
        }
        #endregion

        #region Property
        private tblUser user;

        public tblUser User
        {
            get { return user; }
            set
            {
                user = value;
                OnPropertyChanged("User");
            }
        }

        private List<tblUser> userList;

        public List<tblUser> UserList
        {
            get { return userList; }
            set
            {
                userList = value;
                OnPropertyChanged("UserList");
            }
        }

        private string labelInfo;

        public string LabelInfo
        {
            get { return labelInfo; }
            set
            {
                labelInfo = value;
                OnPropertyChanged("LabelInfo");
            }
        }



        #endregion

        #region Commands
        private ICommand login;

        public ICommand Login
        {
            get
            {
                if (login == null)
                {
                    login = new RelayCommand(LoginExecute);
                }
                return login;
            }
            set { login = value; }
        }

        /// <summary>
        /// Checks if its possible to login depending on the given username and password and saves the logged in user to a list
        /// </summary>
        /// <param name="obj"></param>
        private void LoginExecute(object obj)
        {
            string password = (obj as PasswordBox).Password;
            bool found = false;
            bool correct = false;

            Owner owner = service.getOwner();

            //if (UserList.Any())
            //{
            //    for (int i = 0; i < UserList.Count; i++)
            //    {
            //        if (User.JMBG == UserList[i].JMBG && password == "Gost")
            //        {
            //            Service.loggedUser.Add(UserList[i]);
            //            Service.currentUser = UserList[i];

            //            if (service.CheckOrderStatus(UserList[i].UserID))
            //            {
            //                MessageBox.Show("Your order is pending.");
            //                Login log = new Login();
            //                log.Show();
            //                view.Close();
            //            }
            //            else
            //            {
            //                if (service.GetOrderStatus(UserList[i].UserID) == "approved")
            //                {
            //                    MessageBox.Show("Your order has been approved");
            //                    Thread.Sleep(2000);
            //                }
            //                else if (service.GetOrderStatus(UserList[i].UserID) == "denied")
            //                {
            //                    MessageBox.Show("Your order has been denied");
            //                    Thread.Sleep(2000);
            //                }
            //                MainWindow mw = new MainWindow();
            //                LabelInfo = "Logged in";
            //                found = true;
            //                view.Close();
            //                mw.Show();
            //                break;
            //            }
            //            correct = true;
            //            found = true;
            //        }
            //    }

            //    if (found == false)
            //    {
            //        if (ValidJMBG(User.JMBG) && password == "Gost")
            //        {
            //            tblUser user = new tblUser();
            //            user.JMBG = User.JMBG;
            //            service.AddUser(user);

            //            Service.currentUser = service.GetUser(User.JMBG);

            //            MainWindow mw = new MainWindow();
            //            LabelInfo = "Logged in";
            //            found = true;
            //            correct = true;
            //            view.Close();
            //            mw.Show();
            //        }
            //    }
            //    if (correct == false)
            //    {
            //        LabelInfo = "Wrong Username or Password";
            //    }

            //}
            //else
            //{
            //    LabelInfo = "Database is empty";
            //}

            if (User.Username == owner.Username && password == owner.Password)
            {
                MainWindow main = new MainWindow();
                view.Close();
                main.Show();
            }
        }

        #endregion
    }
}
