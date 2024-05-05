using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Doctor 
    {
        [Key]
        public int DoctorID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Image { get; set; }
        public string? Concact { get; set; }

        public bool Status { get; set; }
        public string? Branch { get; set; }
        public List<Appointment> Appointments { get; set; }
        public List<Patient> Patients { get; set; }
    }

}
