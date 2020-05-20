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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using MySql.Data.MySqlClient;

namespace Project_Zeus
{
    /// <summary>
    /// Interaction logic for ChangeAdminPassword.xaml
    /// </summary>
    public partial class ChangeAdminPasswordPage : Page
    {
        public ChangeAdminPasswordPage()
        {
            InitializeComponent();
        }
        public MySqlConnection con = DBConnect.connectToDb();
        private void btnPass_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //con.Open();
                string sql1 = "update hope.admin set PASSWORD='" + DocPass.Text + "' where NAME='admin';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql1, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Password Updated Succesfully");
                DocPass.Text = "";
                con.Close();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }
    }
}
