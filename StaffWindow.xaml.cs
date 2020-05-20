using System.Windows;

namespace Project_Zeus
{
    /// <summary>
    /// Interaction logic for StaffWindow.xaml
    /// </summary>
    public partial class StaffWindow : Window
    {
        public StaffWindow()
        {
            InitializeComponent();

        }

        public static string ward = "";
        public static string bed = "";
        public static string bed_type = "";

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow objMainWindow = new MainWindow();
            objMainWindow.Show();
            this.Close();
        }

        private void btnAdmitPatient_Click(object sender, RoutedEventArgs e)
        {
            AdmitPatientPage objAdmitPatient = new AdmitPatientPage();
            staffFrame.NavigationService.Navigate(objAdmitPatient);
        }

        private void btnReleasePatient_Click(object sender, RoutedEventArgs e)
        {
            ReleasePatientPage objReleasePatient = new ReleasePatientPage();
            staffFrame.NavigationService.Navigate(objReleasePatient);
        }

        private void btnPatientDetails_Click(object sender, RoutedEventArgs e)
        {
            AddmittedPatientHistoryPage obj = new AddmittedPatientHistoryPage();
            staffFrame.NavigationService.Navigate(obj);
        }

        private void btnViewSchedule_Click(object sender, RoutedEventArgs e)
        {
            ViewDoctorsSchedulePage objViewDoctorsSchedulePage = new ViewDoctorsSchedulePage();
            staffFrame.NavigationService.Navigate(objViewDoctorsSchedulePage);
        }

        private void btnTakeAppointment_Click(object sender, RoutedEventArgs e)
        {
            TakeAppointmentPage objTakeAppointment = new TakeAppointmentPage();
            staffFrame.NavigationService.Navigate(objTakeAppointment);
        }

        private void btnAppointmentStatus_Click(object sender, RoutedEventArgs e)
        {
            AppointmentStatusPage objAppointmentStatus = new AppointmentStatusPage();
            staffFrame.NavigationService.Navigate(objAppointmentStatus);
        }

        private void btnAddView_Click(object sender, RoutedEventArgs e)
        {
            SupplierPage objSupplier = new SupplierPage();
            staffFrame.NavigationService.Navigate(objSupplier);
        }

        private void btnDispensary_Click(object sender, RoutedEventArgs e)
        {
            DispensaryPage objDispensary = new DispensaryPage();
            staffFrame.NavigationService.Navigate(objDispensary);
        }

        private void btnBloodBank_Click(object sender, RoutedEventArgs e)
        {
            BloodBankPage objBloodBank = new BloodBankPage();
            staffFrame.NavigationService.Navigate(objBloodBank);
        }

        private void btnUpdateInfo_Click(object sender, RoutedEventArgs e)
        {
            UpdateStaffPage objUpdateStaff = new UpdateStaffPage();
            objUpdateStaff.textBox1.Text = loginAsStaff.Text.ToString();
            objUpdateStaff.loadStaff();
            staffFrame.NavigationService.Navigate(objUpdateStaff);
        }
    }
}
