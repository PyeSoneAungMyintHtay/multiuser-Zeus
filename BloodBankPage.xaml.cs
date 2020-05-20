using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Project_Zeus
{
    /// <summary>
    /// Interaction logic for BloodBankPage.xaml
    /// </summary>
    public partial class BloodBankPage : Page
    {
        public BloodBankPage()
        {
            InitializeComponent();
            LoadBloodBank();
            BloodGroup();
        }
        public MySqlConnection conn = DBConnect.connectToDb();
        public string test = "";
        void BloodGroup()
        {
            comboBox.Items.Add("A+");
            comboBox.Items.Add("B+");
            comboBox.Items.Add("O+");
            comboBox.Items.Add("AB+");
            comboBox.Items.Add("A-");
            comboBox.Items.Add("B-");
            comboBox.Items.Add("O-");
            comboBox.Items.Add("AB-");
        }

        void LoadBloodBank()
        {
            try
            {
                string sql = "select * from blood_bank;";
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(ds);
                DataGrid.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception accept)
            {
                MessageBox.Show(accept.Message.ToString());
            }
        }
        public int result;
        public bool testing()
        {

            if (result == 0)
                return true; //is empty
            else
                return false;//is not empty
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.SelectedItem.ToString().Equals("") || textBox.Text.Equals("") || textBox1.Text.Equals("")) { MessageBox.Show(("Please Fill All Fields.")); }
            else
            {
                try
                {
                    string Query1 = "SELECT COUNT(*) from hope.blood_bank where group_name='" + comboBox.SelectedItem.ToString() + "';";

                    MySqlCommand MyCommand = new MySqlCommand(Query1, conn);
                    result = int.Parse(MyCommand.ExecuteScalar().ToString());
                    //MessageBox.Show(testing().ToString());

                    if (testing().ToString().Equals("True"))
                    {
                        string Query = "insert into hope.blood_bank values ('" + comboBox.SelectedItem + "','" + textBox.Text + "','" + textBox1.Text + "');";

                        MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                        MySqlDataReader MyReader2;

                        MyReader2 = MyCommand2.ExecuteReader();
                        MessageBox.Show("Blood Added . . .");
                        MyReader2.Close();
                        textBox.Text = ""; textBox1.Text = "";
                        comboBox.Text = "";
                        LoadBloodBank();
                    }
                    else if (testing().ToString().Equals("False"))
                    {
                        string v = "";
                        int j = 0;
                        string Query01 = "SELECT quantity from hope.blood_bank where group_name='" + comboBox.SelectedItem + "';";
                        MySqlCommand MyCommand01 = new MySqlCommand(Query01, conn);
                        MySqlDataReader MyReader01;
                        MyReader01 = MyCommand01.ExecuteReader();
                        while (MyReader01.Read())
                        {
                            v = MyReader01.GetString(0);
                            j = Int32.Parse(MyReader01.GetString(0));
                            MessageBox.Show(j.ToString());
                        }
                        MyReader01.Close();

                        int i = Int32.Parse(textBox.Text);
                        j = j + i;
                        v = j.ToString();
                        string Query = "update hope.blood_bank set quantity='" + v + "',storage_date='" + textBox1.Text + "' where group_name='" + comboBox.SelectedItem + "';";

                        MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                        MySqlDataReader MyReader2;

                        MyReader2 = MyCommand2.ExecuteReader();
                        MessageBox.Show("Blood Updated . . .");

                        MyReader2.Close();
                        textBox.Text = ""; textBox1.Text = "";
                        comboBox.Text = "";
                        LoadBloodBank();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
