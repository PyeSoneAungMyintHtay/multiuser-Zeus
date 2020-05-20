using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Project_Zeus
{
    /// <summary>
    /// Interaction logic for UpdateDoctorPage.xaml
    /// </summary>
    public partial class UpdateDoctorPage : Page
    {
        public UpdateDoctorPage()
        {
            InitializeComponent();
        }

        public MySqlConnection con = DBConnect.connectToDb();

        public void loadDoctor()
        {
            try
            {
                string sql = "SELECT name,password,contact_no,address from doctor where id='" + docid.Text + "';";
                MySqlCommand MyCommand = new MySqlCommand(sql, con);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
                while (MyReader.Read())
                {
                    DocName.Text = MyReader.GetString(0).ToString();
                    DocPass.Text = MyReader.GetString(1).ToString();
                    DocPhone.Text = MyReader.GetString(2).ToString();
                    DocAddress.Text = MyReader.GetString(3).ToString();

                }
                MyReader.Close();
                con.Close();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }


    }
}
