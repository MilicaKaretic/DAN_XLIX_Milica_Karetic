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
    class AddEmployeeViewModel : BaseViewModel
    {
        AddEmployee addEmployee;
        Service service = new Service();


        #region Constructor
        /// <summary>
        /// Constructor with the add employee info window opening
        /// </summary>
        /// <param name="addEmployeeOpen">opends the add employee window</param>
        public AddEmployeeViewModel(AddEmployee addEmployeeOpen)
        {
            employee = new vwEmployee();
            addEmployee = addEmployeeOpen;
            //bgWorker.DoWork += WorkerOnDoWork;
            EmployeeList = service.GetAllEmployees().ToList();
        }
        #endregion

        #region Property
        private vwEmployee employee;
        public vwEmployee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");
            }
        }

        private List<tblEmployee> employeeList;
        public List<tblEmployee> EmployeeList
        {
            get
            {
                return employeeList;
            }
            set
            {
                employeeList = value;
                OnPropertyChanged("EmployeeList");
            }
        }

        /// <summary>
        /// Cheks if its possible to execute the add and edit commands
        /// </summary>
        private bool isUpdateEmployee;
        public bool IsUpdateEmployee
        {
            get
            {
                return isUpdateEmployee;
            }
            set
            {
                isUpdateEmployee = value;
            }
        }
        #endregion


        #region Commands
        /// <summary>
        /// Command that tries to save the new employee
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
                if (service.AddEmployee(Employee) != null)
                {
                    IsUpdateEmployee = true;

                    addEmployee.Close();
                    adminView.Show();
                }

               
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        /// <summary>
        /// Checks if its possible to save the employee
        /// </summary>
        protected bool CanSaveExecute
        {
            get
            {
                //return Employee.IsValid;
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
                addEmployee.Close();
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
