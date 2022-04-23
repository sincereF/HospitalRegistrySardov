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
using System.Windows.Shapes;

namespace HospitalRegistry
{
    /// <summary>
    /// Логика взаимодействия для HospitalRegistryWindow.xaml
    /// </summary>
    public partial class HospitalRegistryWindow : Window
    {
        public HospitalRegistryWindow()
        {
            InitializeComponent();
        }

        private void hospitalRegistryBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void hospitalRegistryCloseButton_Click(object sender, RoutedEventArgs e)
        {
            base.OnClosed(e);
            App.Current.Shutdown();
        }

        private void hospitalRegistryExitButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mwin = new MainWindow();
            mwin.Show();
            this.Close();
        }

        private void recordButton_Click(object sender, RoutedEventArgs e)
        {
            patientsListView.Visibility = Visibility.Hidden;
            patientsDeleteButton.Visibility = Visibility.Hidden;
            hospitalRegistryInfoBorder.Visibility = Visibility.Visible;
        }

        private void patientsButton_Click(object sender, RoutedEventArgs e)
        {
            hospitalRegistryInfoBorder.Visibility = Visibility.Hidden;
            patientsListView.Visibility = Visibility.Visible;
            patientsDeleteButton.Visibility = Visibility.Visible;

            Classes.LoadPatients loadPatients = new Classes.LoadPatients();
            loadPatients.loadPatients(this);
        }

        private void homePageButton_Click(object sender, RoutedEventArgs e)
        {
            hospitalRegistryInfoBorder.Visibility = Visibility.Hidden;
            patientsListView.Visibility = Visibility.Hidden;
            patientsDeleteButton.Visibility = Visibility.Hidden;
        }

        private void insertButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.RecordPatients recordPatients = new Classes.RecordPatients();
            recordPatients.recordPatients(this);

            surnameTextBox.Clear();
            nameTextBox.Clear();
            patronymicTextBox.Clear();
            dateOfBirthTextBox.Clear();
            genderTextBox.Clear();
            policyTextBox.Clear();
            regionTextBox.Clear();
            complaintsTextBox.Clear();
            timeTextBox.Clear();

            MessageBox.Show("Пациент записан");
        }

        private void patientsDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            dynamic itemSelectList = patientsListView.SelectedItem;
            if (itemSelectList != null)
            {
                Classes.DeletePatients deletePatients = new Classes.DeletePatients();
                deletePatients.deletePatients(this);
            }
        }
    }
}
