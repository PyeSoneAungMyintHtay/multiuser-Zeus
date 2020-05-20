using MySql.Data.MySqlClient;
using System;
using System.Windows;

namespace Project_Zeus
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        CheckPatientPage p1;
        public TestWindow(CheckPatientPage p)
        {
            InitializeComponent();

            p1 = p;
            this.disease = p.testingprocess.Text.ToString();
            if (p.check().Equals("Accepted"))
            {
                Query = "select test_name from hope.test_name where disease_type='" + this.disease + "';";
            }
            else if (p.check().Equals("Admitted"))
            {
                Query = "select test_name from hope.test_name where disease_name='" + this.disease + "';";
            }
            loadtest();
        }

        public string disease = "";
        public string Query = "";

        public MySqlConnection conn = DBConnect.connectToDb();

        public void loadtest()
        {

            try
            {
                //Query = "select test_name from hope.test_name where disease_name='" + disease + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                    string name = MyReader2.GetString(0);
                    this.comboboxTestName.Items.Add(name);
                }
                MyReader2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void add_test()
        {
            try
            {
                string Query1 = "insert into hope.test values('" + this.medwindowContactNumberT.Text.ToString() + "','" + this.medwindowDateT.Text.ToString() + "', '" + this.doc_idT.Text.ToString() + "','" + this.diseaseT.Text.ToString() + "','" + this.comboboxTestName.SelectedItem.ToString() + "');";
                MySqlCommand MyCommand2 = new MySqlCommand(Query1, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Test Added . . .");
                MyReader2.Close();
                p1.btnExit.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            add_test();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            add_test();
            this.Close();
            p1.see_test();
            p1.Submit.IsEnabled = true;
        }
    }
}
