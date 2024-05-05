using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Patient 
    {
        [Key]
        public int PatientID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Gender { get; set; }
        public string? Image { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Years { get; set; }
        public string? City { get; set; }
        public string? Town { get; set; }
        public string? Quarter { get; set; }


        public string? Adress
        {
            get { return $"{City} {Town} {Quarter}"; }
        }


        public List<Appointment> Appointments { get; set; }
        public List<Room> Rooms { get; set; }

    }
}
