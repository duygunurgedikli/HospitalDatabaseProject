using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class PatientHistory
    {
        [Key]
        public int PatientHistoryID { get; set; }
        public string? Notes { get; set; }

        [ForeignKey("Patient")]
        public int PatientID { get; set; } // Dış anahtar
        public Patient Patient { get; set; }

    }
}
