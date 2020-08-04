using DAN_XLIX_Milica_Karetic.ViewModel;
using System.Windows;



namespace DAN_XLIX_Milica_Karetic.View
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
        {
            InitializeComponent();

            this.DataContext = new AddUserViewModel(this);
        }
    }
}
