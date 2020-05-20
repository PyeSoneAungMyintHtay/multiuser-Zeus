using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Project_Zeus
{
    /// <summary>
    /// Interaction logic for DispensaryPage.xaml
    /// </summary>
    public partial class DispensaryPage : Page
    {
        public DispensaryPage()
        {
            InitializeComponent();
            datagrid();
        }

        void datagrid()
        {
            try
            {
                string sql = "select product_name,quantity,selling_price,company_name from hope.supplier where product_type='Medicine';";
                MySqlConnection con = DBConnect.connectToDb();
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, con);
                da.Fill(ds);
                datagridDispensary.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message.ToString());
            }
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            //datagrid();
            this.Visibility = Visibility.Hidden;
        }
    }
}
