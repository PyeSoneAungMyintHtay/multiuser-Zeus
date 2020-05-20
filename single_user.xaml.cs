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

namespace Project_Zeus
{
    /// <summary>
    /// Interaction logic for single_user.xaml
    /// </summary>
    public partial class single_user : Window
    {
        public single_user()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            objMainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ChangeAdminPasswordPage psw = new ChangeAdminPasswordPage();            
            adminFrame.NavigationService.Navigate(psw);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            single_AdmitPatientPage sAPP = new single_AdmitPatientPage();
            adminFrame.NavigationService.Navigate(sAPP);
        }
    }
}
