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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        Doctor doctor = new Doctor();
        public LoginPage()
        {
            InitializeComponent();
            DataContext = doctor;
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            string fileName = $"D_{doctor.ID.ToString().PadLeft(5, '0')}.json";
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);

                Doctor temp = JsonSerializer.Deserialize<Doctor>(jsonString);

                if (temp.Password == doctor.Password)
                {
                    doctor.Name = temp.Name;
                    doctor.Password = temp.Password;
                    doctor.MiddleName = temp.MiddleName;
                    doctor.LastName = temp.LastName;
                    doctor.Specialisation = temp.Specialisation;
                    NavigationService.Navigate(new MainPage(doctor));
                }
                else
                {
                    MessageBox.Show("Неверный пароль");
                }
            }
            else
            {
                MessageBox.Show("Такого ID нет");
            }
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
