using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace Project_Zeus
{
    /// <summary>
    /// Interaction logic for UpdateDeleteStaffPage.xaml
    /// </summary>
    public partial class UpdateDeleteStaffPage : Page
    {
        public UpdateDeleteStaffPage()
        {
            InitializeComponent();
            load();
        }
        public MySqlConnection con = DBConnect.connectToDb();

        public void load()
        {
            try
            {
                string sql = "SELECT staff_id,name,age,post,address FROM hope.staff;";
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                da.Fill(ds);
                DataGridStaff.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void DataGridStaff_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataRowView row = (DataRowView)DataGridStaff.SelectedItems[0];
                txtStaffId.Text = row["staff_id"].ToString();
                txtStaffName.Text = row["name"].ToString();
                txtStaffAge.Text = row["age"].ToString();
                txtSTaffPost.Text = row["post"].ToString();
                txtStaffAddress.Text = row["address"].ToString();

            }
            catch { }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update hope.staff set name='" + txtStaffName.Text + "' where staff_id='" + txtStaffId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Name Updated Succesfully");
                txtStaffId.Text = "";
                txtStaffName.Text = "";
                txtStaffAge.Text = "";
                txtSTaffPost.Text = "";
                txtStaffAddress.Text = "";
                load();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void btnDeleteStaff_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "delete from hope.staff where staff_id='" + txtStaffId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Staff Deleted");
                txtStaffId.Text = "";
                txtStaffName.Text = "";
                txtStaffAge.Text = "";
                txtSTaffPost.Text = "";
                txtStaffAddress.Text = "";
                load();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update hope.staff set age='" + txtStaffAge.Text + "' where staff_id='" + txtStaffId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Age Updated Succesfully");
                txtStaffId.Text = "";
                txtStaffName.Text = "";
                txtStaffAge.Text = "";
                txtSTaffPost.Text = "";
                txtStaffAddress.Text = "";
                load();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update hope.staff set post='" + txtSTaffPost.Text + "' where staff_id='" + txtStaffId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Post Updated Succesfully");
                txtStaffId.Text = "";
                txtStaffName.Text = "";
                txtStaffAge.Text = "";
                txtSTaffPost.Text = "";
                txtStaffAddress.Text = "";
                load();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sql = "update hope.staff set address='" + txtStaffAddress.Text + "' where staff_id='" + txtStaffId.Text + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(sql, con);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MyReader2.Close();
                MessageBox.Show("Address Updated Succesfully");
                txtStaffId.Text = "";
                txtStaffName.Text = "";
                txtStaffAge.Text = "";
                txtSTaffPost.Text = "";
                txtStaffAddress.Text = "";
                load();
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }


    }
}
