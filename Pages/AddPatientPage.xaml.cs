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

namespace trpo7_voroshilov_pr.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddPatient.xaml
    /// </summary>
    public partial class AddPatient : Page
    {
        Patient patient = new Patient();
        public AddPatient()
        {
            InitializeComponent();
            DataContext = patient;
        }

        private void AddNewPatient(object sender, RoutedEventArgs e)
        {
            if (patient.Name.Trim() != "" && patient.LastName.Trim() != "" && patient.MiddleName.Trim() != "" && patient.Birthday.Trim() != "")
            {
                patient.ID = Convert.ToInt32(GenerateUniqueId(7, 'P'));

                string jsonString = JsonSerializer.Serialize(patient);
                string fileName = $"P_{patient.ID.ToString().PadLeft(7, '0')}.json";
                File.WriteAllText(fileName, jsonString);

                MessageBox.Show("Успешно сохранен");
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private string GenerateUniqueId(int countNums, char symbol)
        {
            int i = 1;
            int maxValue = Convert.ToInt32(9.ToString().PadLeft(countNums, '9'));
            while (i <= maxValue)
            {
                if (!File.Exists($"{symbol}_{i.ToString().PadLeft(countNums, '0')}.json"))
                {
                    return i.ToString().PadLeft(countNums, '0');
                }
                i++;
            }
            return "";
        }
    }
}
