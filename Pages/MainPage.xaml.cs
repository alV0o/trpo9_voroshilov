using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

using trpo7_voroshilov_pr.Class;

namespace trpo7_voroshilov_pr.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    /// 
    public partial class MainPage : Page
    {
        public ObservableCollection<Patient> Patients { get; set; } = new();
        public Patient SelectedPatient { get; set; }
        Doctor doctor = new Doctor();
        JSONs jsons = new JSONs();

        public MainPage(Doctor _doctor)
        {
            doctor = _doctor;

            for (int i = 1; i <= 9999999; i++)
            {
                if (File.Exists($"P_{i.ToString().PadLeft(7, '0')}.json"))
                {
                    string jsonString = File.ReadAllText($"P_{i.ToString().PadLeft(7, '0')}.json");
                    Patient patient = JsonSerializer.Deserialize<Patient>(jsonString);
                    patient.ID = i;
                    Patients.Add(patient);
                }
                else break;
            }

            InitializeComponent();

            DataContext = this;
            InfoDoctor.DataContext = doctor;
            
            for (int i = 1; i <= 99999; i++)
            {
                if (File.Exists($"D_{i.ToString().PadLeft(5, '0')}.json"))
                {
                    jsons.CountDoctors++;
                }
                else break;
            }
            for (int i = 1; i <= 9999999; i++)
            {
                if (File.Exists($"P_{i.ToString().PadLeft(7, '0')}.json"))
                {
                    jsons.CountPatients++;
                }
                else break;
            }
            jsons.CountAll = jsons.CountDoctors + jsons.CountPatients;
            StatusBar.DataContext = jsons;

        }

        private void AddPatient(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPatient());
        }

        private void StartAppointment(object sender, RoutedEventArgs e)
        {
            if (SelectedPatient == null)
            {
                MessageBox.Show("Пациент не выбран");
            }
            else NavigationService.Navigate(new AppoinmentPage(SelectedPatient, doctor));
        }

        private void EditInfo(object sender, RoutedEventArgs e)
        {
            if (SelectedPatient == null)
            {
                MessageBox.Show("Пациент не выбран");
            }
            else NavigationService.Navigate(new EditInfoPage(SelectedPatient));
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void DeletePatient(object sender, RoutedEventArgs e)
        {
            File.Delete($"P_{SelectedPatient.ID.ToString().PadLeft(7, '0')}.json");
            Patients.Remove(SelectedPatient);
        }
    }
}
