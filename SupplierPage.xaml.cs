using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Project_Zeus
{
    /// <summary>
    /// Interaction logic for SupplierPage.xaml
    /// </summary>
    public partial class SupplierPage : Page
    {
        public SupplierPage()
        {
            InitializeComponent();
            load_table();
            fill_combo();
        }

        void load_table()
        {
            try
            {
                string sql = "select company_name,contact_no,product_name,product_type,purchased_date,quantity from hope.supplier;";
                MySqlConnection con = DBConnect.connectToDb();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                da.Fill(ds);
                datagridSupplier.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }


        }

        void fill_combo()
        {
            MySqlConnection conn = DBConnect.connectToDb();
            try
            {
                string Query = "select * from hope.product_type;";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                    string name = MyReader2.GetString(0);
                    comboBox.Items.Add(name);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void btnAddSupplier_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text.Equals("") || textBox1.Text.Equals("") || textBox2.Text.Equals("") || comboBox.SelectedItem.ToString().Equals("") ||
                textBox3.Text.Equals("") || textBox4.Text.Equals("") || textBox5.Text.Equals("")) { MessageBox.Show("Please fill all fields"); }
            else
            {
                MySqlConnection conn = DBConnect.connectToDb();
                try
                {
                    string Query = "insert into hope.supplier values('" + textBox.Text + "', '" + textBox1.Text + "', '" + textBox2.Text + "', '" + comboBox.Text + "', '" + datepicker.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "');";

                    MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                    MySqlDataReader MyReader2;

                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Data Added . . .");

                    textBox.Text = ""; textBox1.Text = ""; textBox2.Text = "";
                    textBox3.Text = ""; textBox4.Text = ""; datepicker.Text = "";
                    textBox5.Text = "";

                    load_table();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        int i = 1;

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            if (i == 1)
            {
                load_table();
                i = 0;
            }
            else
            {
                load_table();
                i = 1;
            }
        }
    }
}
