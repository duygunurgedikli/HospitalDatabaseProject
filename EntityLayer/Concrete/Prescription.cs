using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Prescription
    {
        [Key]
        public int PrescriptionID { get; set; }
        public string? Treatment { get; set; }


        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
