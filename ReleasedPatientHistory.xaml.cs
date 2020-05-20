using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Project_Zeus
{
    /// <summary>
    /// Interaction logic for ReleasedPatientHistory.xaml
    /// </summary>
    public partial class ReleasedPatientHistory : Page
    {
        public ReleasedPatientHistory()
        {
            InitializeComponent();
            load_table();
        }
        public MySqlConnection conn = DBConnect.connectToDb();

        void load_table()
        {
            try
            {
                string sql = "select * from hope.release_patient;";
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(ds);
                dataGrid.ItemsSource = ds.Tables[0].DefaultView;

            }
            catch (Exception exce)
            {
                MessageBox.Show(exce.Message.ToString() + " Exceptiom");
            }
        }
    }
}
