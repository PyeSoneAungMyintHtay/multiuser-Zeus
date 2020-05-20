using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace Project_Zeus
{

    public class DoctorSchedule
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public string Dept { get; set; }

        public string Specialist_In { get; set; }

        public string Counciling_Hour { get; set; }
    }

    /// <summary>
    /// Interaction logic for ViewDoctorsSchedulePage.xaml
    /// </summary>
    public partial class ViewDoctorsSchedulePage : Page
    {
        public ViewDoctorsSchedulePage()
        {
            InitializeComponent();
            DocSchedule();
        }
        //public MySqlConnection con = DBConnect.connectToDb();

        public void DocSchedule()
        {
            //MySqlConnection con = DBConnect.connectToDb(); 
            try
            {

                string sql = "select name,id,department,specialist_in,counsiling_hour from hope.doctor;";
                DataTable dt = DataAccess.GetDataTable(sql);

                int t = dt.Rows.Count;

                List<DoctorSchedule> users = new List<DoctorSchedule>();

                for (int i = 0; i < t; i++)
                {
                    users.Add(new DoctorSchedule() { Name = (dt.Rows[i]["name"].ToString()), Id = (dt.Rows[i]["id"].ToString()), Dept = (dt.Rows[i]["department"].ToString()), Specialist_In = (dt.Rows[i]["specialist_in"].ToString()), Counciling_Hour = (dt.Rows[i]["counsiling_hour"].ToString()) });

                }
                datagridDocSchedule.ItemsSource = users;

            }
            catch (Exception eddddd)
            {
                MessageBox.Show(eddddd.Message.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
