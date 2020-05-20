using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace Project_Zeus
{
    /// <summary>
    /// Interaction logic for UpdateDeleteDoctorPage.xaml
    /// </summary>
    public partial class UpdateDeleteDoctorPage : Page
    {
        public UpdateDeleteDoctorPage()
        {
            InitializeComponent();
            load();
        }

        public MySqlConnection con = DBConnect.connectToDb();
        public void load()
        {
            try
            {
                string sql = "SELECT id,name,age,department,specialist_in,address,counsiling_hour from doctor;";
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                da.Fill(ds);
                DataGridDoc.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void DataGridDoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)DataGridDoc.SelectedItems[0];
                txtDocId.Text = row["id"].ToString();
                txtDocName.Text = row["name"].ToString();
                txtDocAge.Text = row["age"].ToString();
                txtDocDept.Text = row["department"].ToString();
                txtDocSpecialist.Text = row["specialist_in"].ToString();
                txtDocAddress.Text = row["address"].ToString();
                txtDocCouncilingHour.Text = row["counsiling_hour"].ToString();
            }
            catch { }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void btnDeleteDoctor_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "delete from hope.doctor where id='" + txtDocId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Doctor Deleted");
                txtDocId.Text = "";
                txtDocName.Text = "";
                txtDocAge.Text = "";
                txtDocDept.Text = "";
                txtDocSpecialist.Text = "";
                txtDocAddress.Text = "";
                txtDocCouncilingHour.Text = "";

                load();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void btnUpdateName_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update hope.doctor set name='" + txtDocName.Text + "' where id='" + txtDocId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Name Updated Succesfully");
                txtDocId.Text = "";
                txtDocName.Text = "";
                txtDocAge.Text = "";
                txtDocDept.Text = "";
                txtDocSpecialist.Text = "";
                txtDocAddress.Text = "";
                txtDocCouncilingHour.Text = "";
                load();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void btnUpdateAge_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update hope.doctor set age='" + txtDocAge.Text + "' where id='" + txtDocId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Name Updated Succesfully");
                txtDocId.Text = "";
                txtDocName.Text = "";
                txtDocAge.Text = "";
                txtDocDept.Text = "";
                txtDocSpecialist.Text = "";
                txtDocAddress.Text = "";
                txtDocCouncilingHour.Text = "";
                load();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void btnUpdateDept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update hope.doctor set department='" + txtDocDept.Text + "' where id='" + txtDocId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Name Updated Succesfully");
                txtDocId.Text = "";
                txtDocName.Text = "";
                txtDocAge.Text = "";
                txtDocDept.Text = "";
                txtDocSpecialist.Text = "";
                txtDocAddress.Text = "";
                txtDocCouncilingHour.Text = "";
                load();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void btnUpdateSpeciality_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update hope.doctor set specialist_in='" + txtDocSpecialist.Text + "' where id='" + txtDocId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Name Updated Succesfully");
                txtDocId.Text = "";
                txtDocName.Text = "";
                txtDocAge.Text = "";
                txtDocDept.Text = "";
                txtDocSpecialist.Text = "";
                txtDocAddress.Text = "";
                txtDocCouncilingHour.Text = "";
                load();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void btnUpdateAddress_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update hope.doctor set address='" + txtDocAddress.Text + "' where id='" + txtDocId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Address Updated Succesfully");
                txtDocId.Text = "";
                txtDocName.Text = "";
                txtDocAge.Text = "";
                txtDocDept.Text = "";
                txtDocSpecialist.Text = "";
                txtDocAddress.Text = "";
                txtDocCouncilingHour.Text = "";
                load();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void btnUpdateCouncilingHour_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update hope.doctor set counsiling_hour ='" + txtDocCouncilingHour.Text + "' where id='" + txtDocId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Councilling Hour Changed Succesfully");
                txtDocId.Text = "";
                txtDocName.Text = "";
                txtDocAge.Text = "";
                txtDocDept.Text = "";
                txtDocSpecialist.Text = "";
                txtDocAddress.Text = "";
                txtDocCouncilingHour.Text = "";
                load();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }
    }
}
