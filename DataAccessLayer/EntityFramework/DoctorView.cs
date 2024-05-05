using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class DoctorView
    {
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string DoctorImage { get; set; }
        
        public string DoctorContact { get; set; }
        public bool DoctorStatus { get; set; }
        public string DoctorBranch { get; set; }
    }
}
