using System.Windows;




namespace Project_Zeus
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            objMainWindow.Show();
            this.Close();
        }

        private void btnAddStaff_Click_1(object sender, RoutedEventArgs e)
        {
            //AddStaffPage objAddStaff = new AddStaffPage();
            //adminFrame.NavigationService.Navigate(objAddStaff);
            AddStaffPage objAddStaff_1 = new AddStaffPage();
            adminFrame.NavigationService.Navigate(objAddStaff_1);
        }

        private void btnUpdateDeleteStaff_Click(object sender, RoutedEventArgs e)
        {
            UpdateDeleteStaffPage objUpdateDeleteStaff = new UpdateDeleteStaffPage();
            adminFrame.NavigationService.Navigate(objUpdateDeleteStaff);
        }

        private void btnAddDoctor_Click(object sender, RoutedEventArgs e)
        {
            AddDoctorPage objAddDoctor = new AddDoctorPage();
            adminFrame.NavigationService.Navigate(objAddDoctor);
        }

        private void btnUpdateDeleteDoctor_Click(object sender, RoutedEventArgs e)
        {
            UpdateDeleteDoctorPage objUpdateDeleteDoctor = new UpdateDeleteDoctorPage();
            adminFrame.NavigationService.Navigate(objUpdateDeleteDoctor);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddMedicinePage objAddMedicinePage = new AddMedicinePage();
            adminFrame.NavigationService.Navigate(objAddMedicinePage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddTestByAdminPage p2 = new AddTestByAdminPage();
            adminFrame.NavigationService.Navigate(p2);
        }

        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            ReleasedPatientHistory r = new ReleasedPatientHistory();
            adminFrame.NavigationService.Navigate(r);
        }
    }
}
