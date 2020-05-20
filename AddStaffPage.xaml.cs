using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Controls;


namespace Project_Zeus
{
    /// <summary>
    /// Interaction logic for AddStaffPage.xaml
    /// </summary>
    public partial class AddStaffPage : Page
    {
        public AddStaffPage()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void btnAddStaff_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Equals("") || textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals("") || datepicker.Text.Equals("") || textBox5.Text.Equals("") || textBox7.Text.Equals("") || textBox8.Text.Equals(""))
            {
                MessageBox.Show("Please Fill All the fields");
            }

            else
            {
                MySqlConnection conn = DBConnect.connectToDb();
                try
                {
                    string Query = "insert into hope.staff(name,age,contact_num,post,blood_group,join_date,address,staff_id,staff_password) values('" + textBox.Text + "', '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + datepicker.Text + "', '" + textBox5.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "');";

                    MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                    MySqlDataReader MyReader2;

                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Data Added . . .");

                    conn.Close();

                    textBox.Text = ""; textBox1.Text = ""; textBox2.Text = "";
                    textBox3.Text = ""; textBox4.Text = ""; datepicker.Text = "";
                    textBox5.Text = ""; textBox7.Text = ""; textBox8.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
