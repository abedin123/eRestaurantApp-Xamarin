﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartRestaurant.Data
{
    public class StatusNarudzbe
    {
        [Key]
        public int StatusNarudzbeID { get; set; }

        public string NazivStatusa { get; set; }
    }
}
