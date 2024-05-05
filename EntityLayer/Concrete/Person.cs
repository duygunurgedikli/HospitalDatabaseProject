using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public  class Person 
    {
        [Key]
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }


        

    }
   

}
