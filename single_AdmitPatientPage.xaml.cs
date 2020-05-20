using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;

namespace Project_Zeus
{
    /// <summary>
    /// Interaction logic for single_AdmitPatientPage.xaml
    /// </summary>
    public partial class single_AdmitPatientPage : Page
    {
        public single_AdmitPatientPage()
        {
            InitializeComponent();
            load_patient_id();
            load();
            load_blood_group();
            
            DateTime dt1;
            dt1 = DateTime.Now.Date;
            time_of_admission.Text = dt1.ToString("yyyy-MM-dd");
        }
        public MySqlConnection conn = DBConnect.connectToDb();

        
        public void load()
        {
            try
            {
                string sql = "SELECT * from hopedatabase.patient_data;";
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
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
                patient_ID.Text = row["patient_id"].ToString();
                patient_name.Text = row["patient_name"].ToString();
                patient_age.Text = row["patient_age"].ToString();
                patient_contact_no.Text = row["patient_contact_no"].ToString();
                comboboxBloodGroup.SelectedItem = row["patient_blood_group"];
                patient_address.Text = row["patient_address"].ToString();
                time_of_admission.Text = row["time_of_admission"].ToString();
                
            }
            catch { }
        }

        void load_patient_id()
        {
            try
            {
                string Query = "select LAST_INSERT_ID() from hopedatabase.patient_data;";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                    
                    string name = MyReader2.GetString(0);
                    patient_ID.Text = name;

                }
                MyReader2.Close();
            }
            catch { }
        }
            

        void load_blood_group()
        {
            try
            {
                string Query = "select * from hopedatabase.blood_group;";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                    string name = MyReader2.GetString(0);
                    comboboxBloodGroup.Items.Add(name);
                }
                MyReader2.Close();
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
                string Query = "insert into hopedatabase.patient_data values('" + patient_ID.Text + "','" + patient_name.Text + "','" + patient_age.Text + "','" + patient_contact_no.Text + "','" + comboboxBloodGroup.SelectedItem.ToString() + "','" + patient_address.Text + "','"  +  time_of_admission.Text + "');";
                MySqlCommand MyCommand = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
                MyReader.Close();

                /* string Query1 = "DROP TABLE hope.ward_bed;";
                 MySqlCommand MyCommand1 = new MySqlCommand(Query1, conn);
                 MySqlDataReader MyReader1;
                 MyReader1 = MyCommand1.ExecuteReader();
                 MyReader1.Close();

                 string Query2 = "CREATE TABLE ward_bed AS SELECT ward.ward_name,bed.pat_contact_no,bed.bed_no,bed.bed_type,bed.bed_cost,bed.bed_status FROM ward,bed WHERE ward.ward_id=bed.ward_id;";
                 MySqlCommand MyCommand2 = new MySqlCommand(Query2, conn);
                 MySqlDataReader MyReader2;
                 MyReader2 = MyCommand2.ExecuteReader();
                 MyReader2.Close();

                 string Query3 = "DROP TABLE hope.allocate_patient_bed;";
                 MySqlCommand MyCommand3 = new MySqlCommand(Query3, conn);
                 MySqlDataReader MyReader3;
                 MyReader3 = MyCommand3.ExecuteReader();
                 MyReader3.Close();

                 string Query4 = "CREATE TABLE allocate_patient_bed AS SELECT admitted_patient.patient_name,admitted_patient.patient_age,admitted_patient.patient_contact_no,ward_bed.ward_name,ward_bed.bed_no,ward_bed.bed_type,ward_bed.bed_cost,ward_bed.bed_status FROM admitted_patient,ward_bed WHERE admitted_patient.patient_contact_no=ward_bed.pat_contact_no AND admitted_patient.ward_name=ward_bed.ward_name;";
                 MySqlCommand MyCommand4 = new MySqlCommand(Query4, conn);
                 MySqlDataReader MyReader4;
                 MyReader4 = MyCommand4.ExecuteReader();
                 MyReader4.Close();*/


                MessageBox.Show("Patient Registered");

                patient_name.Text = ""; patient_address.Text = ""; patient_age.Text = ""; patient_contact_no.Text = "";
                comboboxBloodGroup.Items.Clear();  
              
                load_blood_group(); 
                

                patient_name.IsEnabled = false; patient_address.IsEnabled = false; patient_age.IsEnabled = false; patient_contact_no.IsEnabled = false;
                comboboxBloodGroup.IsEnabled = false;  
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void patient_contact_no_TextChanged(object sender, TextChangedEventArgs e)
        {
            patient_name.IsEnabled = true;
        }

        private void patient_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            patient_age.IsEnabled = true;
        }

        private void patient_age_TextChanged(object sender, TextChangedEventArgs e)
        {
            comboboxBloodGroup.IsEnabled = true;
        }

        private void comboboxBloodGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            patient_address.IsEnabled = true;
        }

        

       

        private void Add_new_disease_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Query = "insert into hope.patient_data values('" + patient_name.Text + "','" + patient_age.Text + "','" + patient_contact_no.Text + "','" + comboboxBloodGroup.SelectedItem.ToString() + "','" + patient_address.Text +  "','" + time_of_admission.Text + "');";
                MySqlCommand MyCommand = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
                MyReader.Close();
                                             
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
