using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class HospitalEmployee 
    {
        [Key]
        public int HospitalEmployeeID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Mission { get; set; }

       

    }
}
