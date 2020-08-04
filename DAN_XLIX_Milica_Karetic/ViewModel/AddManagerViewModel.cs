using DAN_XLIX_Milica_Karetic.Commands;
using DAN_XLIX_Milica_Karetic.Model;
using DAN_XLIX_Milica_Karetic.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DAN_XLIX_Milica_Karetic.ViewModel
{
    class AddManagerViewModel :  BaseViewModel
    {
        AddManager addManager;
        Service service = new Service();


        #region Constructor
        /// <summary>
        /// Constructor with the add manager info window opening
        /// </summary>
        /// <param name="addManagerOpen">opends the add manager window</param>
        public AddManagerViewModel(AddManager addManagerOpen)
        {
            manager = new vwManager();
            addManager = addManagerOpen;
            //bgWorker.DoWork += WorkerOnDoWork;
            ManagerList = service.GetAllManagers().ToList();
        }
        #endregion

        #region Property
        private vwManager manager;
        public vwManager Manager
        {
            get
            {
                return manager;
            }
            set
            {
                manager = value;
                OnPropertyChanged("Manager");
            }
        }

        private List<tblManager> managerList;
        public List<tblManager> ManagerList
        {
            get
            {
                return managerList;
            }
            set
            {
                managerList = value;
                OnPropertyChanged("ManagerList");
            }
        }

        /// <summary>
        /// Cheks if its possible to execute the add and edit commands
        /// </summary>
        private bool isUpdateManager;
        public bool IsUpdateManager
        {
            get
            {
                return isUpdateManager;
            }
            set
            {
                isUpdateManager = value;
            }
        }
        #endregion


        #region Commands
        /// <summary>
        /// Command that tries to save the new manager
        /// </summary>
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => this.CanSaveExecute);
                }
                return save;
            }
        }

        /// <summary>
        /// Tries the execute the save command
        /// </summary>
        private void SaveExecute()
        {
            try
            {
                AddUser adminView = new AddUser();
                service.AddManager(Manager);
                IsUpdateManager = true;

                //if (!bgWorker.IsBusy)
                //{
                //    // This method will start the execution asynchronously in the background
                //    bgWorker.RunWorkerAsync();
                //}
                addManager.Close();
                adminView.Show();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Checks if its possible to save the manager
        /// </summary>
        protected bool CanSaveExecute
        {
            get
            {
                //return Manager.IsValid;
                return true;
            }
        }

        /// <summary>
        /// Command that closes the add user or edit user window
        /// </summary>
        private ICommand cancel;
        public ICommand Cancel
        {
            get
            {
                if (cancel == null)
                {
                    cancel = new RelayCommand(param => CancelExecute(), param => CanCancelExecute());
                }
                return cancel;
            }
        }

        /// <summary>
        /// Executes the close command
        /// </summary>
        private void CancelExecute()
        {
            try
            {
                AddUser adminView = new AddUser();
                addManager.Close();
                adminView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Checks if its possible to execute the close command
        /// </summary>
        /// <returns>true</returns>
        private bool CanCancelExecute()
        {
            return true;
        }
        #endregion
    }
}
