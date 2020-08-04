using DAN_XLIX_Milica_Karetic.ViewModel;
using System;
using System.Windows;

namespace DAN_XLIX_Milica_Karetic.View
{
    /// <summary>
    /// Interaction logic for AddManager.xaml
    /// </summary>
    public partial class AddManager : Window
    {
        public AddManager()
        {
            InitializeComponent();

            this.DataContext = new AddManagerViewModel(this);
        }


        /// <summary>
        /// Calcualtes the birth date and places it in the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            
           
        }
    }
}
