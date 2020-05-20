using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Project_Zeus
{
    /// <summary>
    /// Interaction logic for ViewConsultationRequestPage.xaml
    /// </summary>
    public partial class ViewConsultationRequestPage : Page
    {
        string contact_no = "";
        string textField = "";
        public ViewConsultationRequestPage()
        {
            InitializeComponent();
        }

        private void datagridAllRequest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)datagridAllRequest.SelectedItem;
                contact_no = row["pat_contact_no"].ToString();
                textField = row["appointment_date"].ToString();
            }
            catch (Exception exepti)
            {
                MessageBox.Show(exepti.Message.ToString());
            }
        }

        void accept_table()
        {
            try
            {
                string sql = "select pat_name,pat_age,pat_contact_no,pat_address,appointment_date,appointment_status from hope.appointment where appointment_status='" + "Accepted" + "' and doc_id='" + ulala.Text + "';";
                MySqlConnection con = DBConnect.connectToDb();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                da.Fill(ds);
                datagridAccepted.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception accept)
            {
                MessageBox.Show(accept.Message.ToString());
            }

        }

        void show_all()
        {
            try
            {
                string sql1 = "select pat_name,pat_age,pat_contact_no,pat_address,appointment_date,appointment_status from hope.appointment where doc_id='" + ulala.Text + "' and appointment_status='" + "pending" + "';";
                MySqlConnection con1 = DBConnect.connectToDb();
                DataSet ds1 = new DataSet();
                MySqlDataAdapter da1 = new MySqlDataAdapter(sql1, con1);
                da1.Fill(ds1);
                datagridAllRequest.ItemsSource = ds1.Tables[0].DefaultView;
            }
            catch (Exception show)
            {
                MessageBox.Show(show.Message.ToString());
            }
        }

        void delete_request()
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection conn = DBConnect.connectToDb();
            try
            {
                string q = "update hope.appointment set appointment_status='" + "Accepted" + "' where pat_contact_no='" + contact_no + "' and appointment_date='" + textField + "';";////
                MySqlCommand MyCommand2 = new MySqlCommand(q, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Appointment Accepted Succesfully . . .");
                conn.Close();
                accept_table();
                show_all();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection con = DBConnect.connectToDb();
                string q1 = "delete from hope.appointment where pat_contact_no='" + contact_no + "' and appointment_date='" + textField + "';";
                MySqlCommand MyCommand5 = new MySqlCommand(q1, con);
                MySqlDataReader MyReader5;
                MyReader5 = MyCommand5.ExecuteReader();
                MessageBox.Show("Appointment Rejected");
                MyReader5.Close();


                delete_request();//Remove that patient because appointment is rejected
                show_all();/// Refreshing Request Table
                           /// 
                con.Close();
            }
            catch (Exception ee) { MessageBox.Show(ee.Message.ToString()); }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
