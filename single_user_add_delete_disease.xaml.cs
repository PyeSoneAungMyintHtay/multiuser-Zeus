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

namespace Project_Zeus
{
    /// <summary>
    /// Interaction logic for single_user_add_delete_disease.xaml
    /// </summary>
    public partial class single_user_add_delete_disease : Page
    {
        public single_user_add_delete_disease()
        {
            InitializeComponent();
            load_disease();
            hidden();
        }
        public MySqlConnection conn = DBConnect.connectToDb();
        void load_disease()
        {
            try
            {
                string Query = "select distinct disease_name from hopedatabase.disease;";
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

        void hidden()
        {
            new_Disease_txtBOX.Visibility = Visibility.Hidden;
            Add_New_Disease_Label.Visibility = Visibility.Hidden;
            Add_new_disease.Visibility = Visibility.Hidden;
            Add_New_Disease_Label_Copy.Visibility = Visibility.Hidden;
            new_Disease_type_txtBOx.Visibility = Visibility.Hidden;
        }

        private void comboboxDisease_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboboxDisease.SelectedItem.Equals("new_disease"))
            //if(comboboxDisease.SelectedIndex.Equals("new_disease"))
            {
                new_Disease_txtBOX.Visibility = Visibility.Visible;
                Add_New_Disease_Label.Visibility = Visibility.Visible;
                Add_new_disease.Visibility = Visibility.Visible;
                Add_New_Disease_Label_Copy.Visibility = Visibility.Visible;
                new_Disease_type_txtBOx.Visibility = Visibility.Visible;
            }
            else
            {
                new_Disease_txtBOX.Visibility = Visibility.Hidden;
                Add_New_Disease_Label.Visibility = Visibility.Hidden;
                Add_new_disease.Visibility = Visibility.Hidden;
                Add_New_Disease_Label_Copy.Visibility = Visibility.Hidden;
                new_Disease_type_txtBOx.Visibility = Visibility.Hidden;
            }

        }
    }
}
