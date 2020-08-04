using DAN_XLIX_Milica_Karetic.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            
            //string text = "";
            //if (txtJMBG.Text.Length >= 7)
            //{
            //    text = iv.CountDateOfBirth(txtJMBG.Text).ToString("dd.MM.yyy.");
            //}
            //else
            //{
            //    text = "";
            //}

            //txtDateOfBirth.Text = text;
        }
    }
}
