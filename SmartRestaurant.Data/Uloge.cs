﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartRestaurant.Data
{
    public class Uloge
    {
        [Key]
        public int UlogaID { get; set; }

        public string NazivUloge { get; set; }
    }
}
