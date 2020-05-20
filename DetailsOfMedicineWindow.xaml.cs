using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;

namespace Project_Zeus
{
    /// <summary>
    /// Interaction logic for DetailsOfMedicineWindow.xaml
    /// </summary>
    public partial class DetailsOfMedicineWindow : Window
    {
        AppointmentPatientHistoryPage obj;
        public DetailsOfMedicineWindow(AppointmentPatientHistoryPage p)
        {
            InitializeComponent();

            obj = p;
            contact_no = obj.b.ToString();
            date = obj.c.ToString();
            load_details();

        }

        public string contact_no = "";
        public string date = "";
        public void load_details()
        {
            MySqlConnection con = DBConnect.connectToDb();
            try
            {
                string sql = "select * from hope.appointment_medicine where pat_contact_no='" + contact_no + "' and appointment_date='" + date + "';";
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                da.Fill(ds);
                detailsDatagrid.ItemsSource = ds.Tables[0].DefaultView;
                con.Close();

                con.Open();
                //string sql2 = "select * from hope.appointment_test where pat_contact_no='" + contact_no + "' and appointment_date='" + date + "';";
                string sql2 = "SELECT * FROM hope.appointment_test WHERE pat_contact_no='" + contact_no + "' AND appointment_date='" + date + "';";
                DataSet ds2 = new DataSet();
                MySqlDataAdapter da2 = new MySqlDataAdapter(sql2, con);
                da2.Fill(ds2);
                detailsDatagrid2.ItemsSource = ds2.Tables[0].DefaultView;
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message.ToString());
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
