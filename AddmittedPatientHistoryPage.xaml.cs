﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Project_Zeus
{
    /// <summary>
    /// Interaction logic for AddmittedPatientHistoryPage.xaml
    /// </summary>

    public class ShowHistory1
    {
        public string Patient_Name { get; set; }
        public string Contact_No { get; set; }
        public string Age { get; set; }
        public string Ward_Name { get; set; }
        public string Bed_No { get; set; }
    }
    public partial class AddmittedPatientHistoryPage : Page
    {
        public AddmittedPatientHistoryPage()
        {
            InitializeComponent();
            show_all();
        }
        public MySqlConnection conn = DBConnect.connectToDb();

        void show_all()
        {
            try
            {
                string sql = "select patient_name,patient_contact_no,patient_age,ward_name,bed_no from hope.allocate_patient_bed where bed_status='" + "Occupied" + "' ;";
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                da.Fill(ds);
                Dgrid1.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (Exception exce)
            {
                MessageBox.Show(exce.Message.ToString() + " Exceptiom");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (txtPhn.Text.Equals(""))
            {
                txtBed.Text = "";
                txtWard.Text = "";
            }
            try
            {
                string sql = "select ward_name,bed_no from hope.allocate_patient_bed where bed_status='" + "Occupied" + "' and patient_contact_no='" + txtPhn.Text + "' ;";

                MySqlCommand MyCommand2 = new MySqlCommand(sql, conn);
                MySqlDataReader MyReader2;

                MyReader2 = MyCommand2.ExecuteReader();

                while (MyReader2.Read())
                {
                    txtWard.Text = MyReader2.GetValue(0).ToString();
                    txtBed.Text = MyReader2.GetValue(1).ToString();
                }
                MyReader2.Close();
            }
            catch (Exception exc) { MessageBox.Show(exc.Message.ToString()); }
        }
    }
}
