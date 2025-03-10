﻿using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Project_Zeus
{
    /// <summary>
    /// Interaction logic for AdmitPatientPage.xaml
    /// </summary>
    public partial class AdmitPatientPage : Page
    {
        public AdmitPatientPage()
        {
            InitializeComponent();
            load_blood_group();
            load_doctor_name();
            load_disease();

            DateTime dt1;
            dt1 = DateTime.Now.Date;
            time_of_admission.Text = dt1.ToString("yyyy-MM-dd");
        }

        public string docDept = "";
        public string docId = "";

        public MySqlConnection conn = DBConnect.connectToDb();

        void load_disease()
        {
            try
            {
                string Query = "select distinct disease_name from hope.medicine_name;";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                    string name = MyReader2.GetString(0);
                    comboboxDisease.Items.Add(name);
                }
                MyReader2.Close();
            }
            catch { }
        }

        void load_blood_group()
        {
            try
            {
                string Query = "select * from hope.blood_group;";
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

        void load_doctor_name()
        {
            try
            {
                string Query = "select name from hope.doctor;";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();
                while (MyReader2.Read())
                {
                    string name = MyReader2.GetString(0);
                    this.comboboxDoctorName.Items.Add(name);
                }
                MyReader2.Close();
            }
            catch { }
        }

        private void comboboxDoctorName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ///////Loading Doctor Department Value
            try
            {
                string Query = "select id,department from hope.doctor where name='" + comboboxDoctorName.SelectedItem.ToString() + "';";
                MySqlCommand MyCommand2 = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader2;
                MyReader2 = MyCommand2.ExecuteReader();

                while (MyReader2.Read())
                {

                    docId = MyReader2.GetString(0);
                    docDept = MyReader2.GetString(1);
                    textboxDoctorDept.Text = docDept;
                }
                MyReader2.Close();

                string Query1 = "select department from hope.doctor where name='" + comboboxDoctorName.SelectedItem.ToString() + "';";
                MySqlCommand MyCommand = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
                MyReader.Close();
                assd.IsEnabled = true;

            }
            catch { }

        }

        private void patient_age_TextChanged(object sender, TextChangedEventArgs e)
        {
            comboboxBloodGroup.IsEnabled = true;
        }

        private void patient_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            patient_age.IsEnabled = true;
        }

        private void comboboxBloodGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            patient_address.IsEnabled = true;
        }

        private void patient_address_TextChanged(object sender, TextChangedEventArgs e)
        {
            comboboxDisease.IsEnabled = true;
        }

        private void patient_contact_no_TextChanged(object sender, TextChangedEventArgs e)
        {
            patient_name.IsEnabled = true;
        }

        private void comboboxDisease_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboboxDoctorName.IsEnabled = true;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Query = "insert into hope.admitted_patient values('" + patient_name.Text + "','" + patient_age.Text + "','" + patient_contact_no.Text + "','" + comboboxBloodGroup.SelectedItem.ToString() + "','" + patient_address.Text + "','" + comboboxDisease.SelectedItem.ToString() + "','" + comboboxDoctorName.SelectedItem.ToString() + "','" + docId + "','" + textboxDoctorDept.Text + "','" + time_of_admission.Text + "','" + this.textboxWard.Text + "', '" + "Admitted" + "');";
                MySqlCommand MyCommand = new MySqlCommand(Query, conn);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
                MyReader.Close();

                string Query1 = "DROP TABLE hope.ward_bed;";
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
                MyReader4.Close();


                MessageBox.Show("Patient Addmitted!");

                patient_name.Text = ""; patient_address.Text = ""; patient_age.Text = ""; patient_contact_no.Text = "";
                comboboxBloodGroup.Items.Clear(); comboboxDoctorName.Items.Clear(); comboboxDisease.Items.Clear();
                textboxBed.Text = ""; textboxBedType.Text = ""; textboxWard.Text = ""; textboxDoctorDept.Text = "";
                load_blood_group(); load_disease(); load_doctor_name();

                patient_name.IsEnabled = false; patient_address.IsEnabled = false; patient_age.IsEnabled = false; patient_contact_no.IsEnabled = false;
                comboboxBloodGroup.IsEnabled = false; comboboxDoctorName.IsEnabled = false; comboboxDisease.IsEnabled = false;
                textboxBed.IsEnabled = false; textboxBedType.IsEnabled = false; textboxWard.IsEnabled = false; textboxDoctorDept.IsEnabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void assd_Click(object sender, RoutedEventArgs e)
        {
            this.textboxWard.Text = null;
            this.textboxBed.Text = null;
            this.textboxBedType.Text = null;
            AllocateBedWindow objAllocateBedWindow = new AllocateBedWindow(this);
            objAllocateBedWindow.contact = patient_contact_no.Text.ToString();
            objAllocateBedWindow.Show();
            btnExit.IsEnabled = false;
        }

        
    }
}
