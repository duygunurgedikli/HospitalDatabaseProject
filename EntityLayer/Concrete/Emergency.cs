﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Emergency
    {
        [Key]
        public string? Region { get; set; }//sari kırmızı yesil
    }
}
