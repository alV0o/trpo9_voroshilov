using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace trpo7_voroshilov_pr.Class
{
    public class Appointment
    {
        public string Date { get; set; }
        public int DoctorID { get; set; }
        public string Diagnosis { get; set; }
        public string Recomendations { get; set; }
        [JsonIgnore]
        public Doctor DoctorObj {  get; set; }
    }
}
