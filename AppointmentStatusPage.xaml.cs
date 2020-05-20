using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Project_Zeus
{
    /// <summary>
    /// Interaction logic for AppointmentStatusPage.xaml
    /// </summary>
    public partial class AppointmentStatusPage : Page
    {

        public AppointmentStatusPage()
        {
            InitializeComponent();
            load_table();
        }

        void load_table()
        {
            try
            {
                string sql = "select * from hope.appointment;";
                MySqlConnection con = DBConnect.connectToDb();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                da.Fill(ds);
                datagridAppointmentStatus.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message.ToString());
            }
        }
        private void datagridAppointmentStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)datagridAppointmentStatus.SelectedItems[0];
                textBox.Text = row["pat_name"].ToString();
                textBox2.Text = row["pat_contact_no"].ToString();
                status.Text = row["appointment_status"].ToString();
            }
            catch { }
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBox2.Text.Equals(""))
            {
                textBox.Text = "";
                status.Text = "";
            }
            else
            {
                MySqlConnection conn = DBConnect.connectToDb();
                try
                {

                    string q = "select * from hope.appointment where pat_contact_no='" + textBox2.Text + "';";

                    MySqlCommand MyCommand2 = new MySqlCommand(q, conn);
                    MySqlDataReader MyReader2;

                    MyReader2 = MyCommand2.ExecuteReader();

                    while (MyReader2.Read())
                    {
                        textBox.Text = MyReader2.GetValue(0).ToString();
                        status.Text = MyReader2.GetValue(8).ToString();
                        textBox.Focus();
                        status.Focus();

                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message.ToString());
                }
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            load_table();
        }
    }
}
