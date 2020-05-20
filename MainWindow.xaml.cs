#define single_user
using MySql.Data.MySqlClient;
using System;
using System.Windows;


namespace Project_Zeus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            
#if (single_user)
            combobox.Items.Add("Single_User");
#else
            combobox.Items.Add("Adminstrator");
            combobox.Items.Add("Doctor");
            combobox.Items.Add("Staff");
#endif
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (combobox.SelectedItem == null)
            {
                MessageBox.Show("Please choose an option");
            }
            else if (combobox.SelectedItem.Equals("Adminstrator"))
            {

                MySqlConnection conn = DBConnect.connectToDb();
                try
                {
                    string q = "select * from hope.admin where username='" + textboxUsername.Text + "' and password='" + textboxPassword.Password + "';";
                    MySqlCommand MyCommand2 = new MySqlCommand(q, conn);
                    MySqlDataReader MyReader2;
                    MyReader2 = MyCommand2.ExecuteReader();
                    if (MyReader2.Read())
                    {
                        MessageBox.Show("You have succesfully logged in");
                        AdminWindow objAdminWindow = new AdminWindow();
                        objAdminWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username or password do not match");
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (combobox.SelectedItem.Equals("Doctor"))
            {
                MySqlConnection conn = DBConnect.connectToDb();
                try
                {
                    string q = "select * from hope.doctor where id='" + textboxUsername.Text + "' and password='" + textboxPassword.Password + "';";
                    MySqlCommand MyCommand2 = new MySqlCommand(q, conn);
                    MySqlDataReader MyReader2;
                    MyReader2 = MyCommand2.ExecuteReader();
                    if (MyReader2.Read())
                    {
                        MessageBox.Show("You have succesfully logged in");
                        DoctorWindow objDoctorWindow = new DoctorWindow();
                        objDoctorWindow.loginAsDoctor.Text = textboxUsername.Text;
                        objDoctorWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username or password do not match");
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (combobox.SelectedItem.Equals("Staff"))
            {
                MySqlConnection conn = DBConnect.connectToDb();
                try
                {
                    string q = "select * from hope.staff where staff_id='" + textboxUsername.Text + "' and staff_password='" + textboxPassword.Password + "';";
                    MySqlCommand MyCommand2 = new MySqlCommand(q, conn);
                    MySqlDataReader MyReader2;
                    MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
                    if (MyReader2.Read())
                    {
                        MessageBox.Show("You have succesfully logged in");
                        StaffWindow objStaffWindow = new StaffWindow();
                        objStaffWindow.Show();
                        objStaffWindow.loginAsStaff.Text = textboxUsername.Text;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username or password do not match");
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (combobox.SelectedItem.Equals("Single_User"))
            {
                MySqlConnection conn = DBConnect.connectToDb();
                try
                {
                    string q = "select * from hopedatabase.admin where NAME='" + textboxUsername.Text + "' and PASSWORD='" + textboxPassword.Password + "';";
                    MySqlCommand MyCommand2 = new MySqlCommand(q, conn);
                    MySqlDataReader MyReader2;
                    MyReader2 = MyCommand2.ExecuteReader();
                    if (MyReader2.Read())
                    {
                        MessageBox.Show("You have succesfully logged in");
                        single_user objSingleWindow = new single_user();
                        objSingleWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username or password do not match");
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}
