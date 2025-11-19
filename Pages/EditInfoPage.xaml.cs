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
    /// Логика взаимодействия для EditInfoPage.xaml
    /// </summary>
    public partial class EditInfoPage : Page
    {
        Patient patient = new Patient();
        public EditInfoPage(Patient _patient)
        {
            InitializeComponent();
            patient = _patient;
            DataContext = _patient;
        }

        private void ResetPatient(object sender, RoutedEventArgs e)
        {
            string fileName = $"P_{patient.ID.ToString().PadLeft(7, '0')}.json";
            string jsonString = File.ReadAllText(fileName);

            Patient temp = JsonSerializer.Deserialize<Patient>(jsonString);

            patient.Name = temp.Name;
            patient.LastName = temp.LastName;
            patient.MiddleName = temp.MiddleName;
            patient.Birthday = temp.Birthday;
            patient.PhoneNumber = temp.PhoneNumber;
        }

        private void SaveChanges(object sender, RoutedEventArgs e)
        {
            string fileName = $"P_{patient.ID.ToString().PadLeft(7, '0')}.json";
            string jsonString = JsonSerializer.Serialize(patient);
            File.WriteAllText(fileName, jsonString);
        }
        
        private void Back(object sender, RoutedEventArgs e)
        {
            ResetPatient(sender, e);
            NavigationService.GoBack();
        }
    }
}
