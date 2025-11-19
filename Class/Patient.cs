using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace trpo7_voroshilov_pr.Class
{
    public class Patient : INotifyPropertyChanged
    {
        private string _name;
        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        private string _lastname;
        public string LastName
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
                OnPropertyChanged();
            }
        }
        private string _middlename;
        public string MiddleName
        {
            get
            {
                return _middlename;
            }
            set
            {
                _middlename = value;
                OnPropertyChanged();
            }
        }
        private string _birthday;
        public string Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                _birthday = value;
                OnPropertyChanged();
            }
        }
        private string _phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }
        private string _diagnosis;
        [JsonIgnore]
        public string Diagnosis
        {
            get
            {
                return _diagnosis;
            }
            set
            {
                _diagnosis = value;
                OnPropertyChanged();
            }
        }
        private string _recomendations;
        [JsonIgnore]
        public string Recomendations
        {
            get
            {
                return _recomendations;
            }
            set
            {
                _recomendations = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Appointment> AppointmentStories { get; set; } = new ObservableCollection<Appointment>();

        private int _id = 0; 
        [JsonIgnore]
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public Appointment SelectedAppointment {  get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
