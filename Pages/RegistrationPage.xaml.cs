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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        Doctor doctor = new Doctor();
        public RegistrationPage()
        {
            InitializeComponent();
            DataContext = doctor;
        }

        private void RegisterNewDoctor(object sender, RoutedEventArgs e)
        {
            if (doctor.Password.Trim() != "" && doctor.Name.Trim() != "" && doctor.LastName.Trim() != "" && doctor.Specialisation.Trim() != "" && doctor.MiddleName.Trim() != "")
            {
                if (doctor.Password == doctor.RepeatPassword)
                {

                    doctor.ID = Convert.ToInt32(GenerateUniqueId(5, 'D'));
                    string jsonString = JsonSerializer.Serialize(doctor);
                    string fileName = $"D_{doctor.ID.ToString().PadLeft(5, '0')}.json";
                    File.WriteAllText(fileName, jsonString);

                    MessageBox.Show("Успешно сохранен");
                }
                else
                {
                    MessageBox.Show("Неверный пароль!");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
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

        private void Back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
