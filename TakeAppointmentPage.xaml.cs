using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Project_Zeus
{
    /// <summary>
    /// Interaction logic for TakeAppointmentPage.xaml
    /// </summary>
    public partial class TakeAppointmentPage : Page
    {
        public TakeAppointmentPage()
        {
            InitializeComponent();
            load_table();
        }

        public MySqlConnection conn = DBConnect.connectToDb();

        void load_table()
        {
            try
            {
                string sql = "select name,id,department,specialist_in,counsiling_hour from hope.doctor;";
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(ds);
                datagridDocSchedule.ItemsSource = ds.Tables[0].DefaultView;

            }
            catch (Exception exce)
            {
                MessageBox.Show(exce.Message.ToString() + " Exceptiom");
            }
        }

        private void datagridDocSchedule_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)datagridDocSchedule.SelectedItems[0];
                doc_id.Text = row["id"].ToString();
                doc_name.Text = row["name"].ToString();
                doc_dept.Text = row["department"].ToString();
            }
            catch { }
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            MySqlConnection conn = DBConnect.connectToDb();
            try
            {
                string q = "select * from hope.appointment where pat_contact_no='" + pat_contact_no.Text + "';";

                MySqlCommand MyCommand2 = new MySqlCommand(q, conn);
                MySqlDataReader MyReader2;

                MyReader2 = MyCommand2.ExecuteReader();

                while (MyReader2.Read())
                {
                    pat_name.Text = MyReader2.GetValue(0).ToString();
                    pat_age.Text = MyReader2.GetValue(1).ToString();
                    pat_address.Text = MyReader2.GetValue(2).ToString();
                }
                MyReader2.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void btnAddAppointment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Query = "insert into hope.appointment(pat_name,pat_age,pat_contact_no,pat_address,doc_id,doc_name,doc_dept,appointment_date,appointment_status) values('" + pat_name.Text + "', '" + pat_age.Text + "', '" + pat_contact_no.Text + "', '" + pat_address.Text + "', '" + doc_id.Text + "', '" + doc_name.Text + "', '" + doc_dept.Text + "','" + datepicker7.Text + "', '" + "pending" + "');";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Appointment Added . . .");
                MyReader2.Close();

                pat_address.Text = ""; pat_age.Text = ""; pat_contact_no.Text = "";
                pat_name.Text = ""; doc_name.Text = ""; doc_dept.Text = "";
                doc_id.Text = "";

                load_table();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Hello");
            }
        }
    }
}
