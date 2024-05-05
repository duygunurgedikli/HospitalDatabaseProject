using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }
        public int RoomNumber { get; set; }
        public int BedCount { get; set; }

        public List<Patient> Patients { get; set; }
    }
}
