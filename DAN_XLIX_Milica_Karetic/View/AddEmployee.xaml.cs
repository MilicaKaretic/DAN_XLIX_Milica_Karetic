using DAN_XLIX_Milica_Karetic.ViewModel;
using System.Windows;

namespace DAN_XLIX_Milica_Karetic.View
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public AddEmployee()
        {
            InitializeComponent();
            this.DataContext = new AddEmployeeViewModel(this);
        }
    }
}
