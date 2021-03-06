﻿using DAN_XLIX_Milica_Karetic.Commands;
using DAN_XLIX_Milica_Karetic.Model;
using DAN_XLIX_Milica_Karetic.View;
using System.Collections.Generic;
using System.Linq;
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

            Owner owner = service.getOwner();

            if (User.Username == owner.Username && password == owner.Password)
            {
                AddUser add = new AddUser();
                view.Close();
                add.Show();
            }
            else if (UserList.Any())
            {
                for (int i = 0; i < UserList.Count; i++)
                {
                    if (User.Username == UserList[i].Username && password == UserList[i].Password)
                    {
                        LoggedInUser.CurrentUser = new tblUser()
                        {
                            UserID = UserList[i].UserID,
                            Name = UserList[i].Name,
                            DateOfBirth = UserList[i].DateOfBirth,
                            Email = UserList[i].Email,
                            Username = UserList[i].Username,
                            Password = UserList[i].Password
                        };

                        LabelInfo = "Logged in";
                        found = true;

                        int id = service.getUserId(User.Username);


                        if (service.IsManager(id))
                        {
                            Manager man = new Manager();
                            view.Close();
                            man.Show();
                        }
                        else if (service.IsEmployee(id))
                        {
                            Employee emp = new Employee();
                            view.Close();
                            emp.Show();
                        }
                        break;

                    }
                }

                if (found == false)
                {
                    LabelInfo = "Wrong Username or Password";
                }


            }

            #endregion
        }
    }
}