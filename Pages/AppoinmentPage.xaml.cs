using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для AppoinmentPage.xaml
    /// </summary>
    public partial class AppoinmentPage : Page
    {
        Patient patient;
        Doctor doctor;
        public AppoinmentPage(Patient _patient, Doctor _doctor)
        {
            InitializeComponent();
            patient = _patient;
            doctor = _doctor;
            if (patient.AppointmentStories != null)
            {
                for (int i = 0; i < patient.AppointmentStories.Count; i++)
                {
                    string fileName = $"D_{patient.AppointmentStories[i].DoctorID.ToString().PadLeft(5, '0')}.json";
                    string jsonString = File.ReadAllText(fileName);
                    patient.AppointmentStories[i].DoctorObj = JsonSerializer.Deserialize<Doctor>(jsonString);
                }
            }
            DataContext = patient;
        }

        private void RegisterAppointment(object sender, RoutedEventArgs e)
        {
            if (patient.Diagnosis.Trim() == "" || patient.Recomendations.Trim() == "")
            {
                MessageBox.Show("Заполните все поля!");
                return;
            } 

            patient.AppointmentStories.Add(new Appointment() { DoctorID = doctor.ID, Date = DateTime.Now.ToString(), Diagnosis = patient.Diagnosis, Recomendations = patient.Recomendations, DoctorObj = doctor});
            string jsonString = JsonSerializer.Serialize(patient);
            string fileName = $"P_{patient.ID.ToString().PadLeft(7, '0')}.json";
            File.WriteAllText(fileName, jsonString);
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void EditInfo(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditInfoPage(patient));
        }

        private void DeleteAppointment(object sender, RoutedEventArgs e)
        {
            patient.AppointmentStories.Remove(patient.SelectedAppointment);
            string jsonString = JsonSerializer.Serialize(patient);
            string fileName = $"P_{patient.ID.ToString().PadLeft(7, '0')}.json";
            File.WriteAllText(fileName, jsonString);
        }
    }
}
