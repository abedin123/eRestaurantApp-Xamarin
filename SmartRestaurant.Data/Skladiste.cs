﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartRestaurant.Data
{
    public class Skladiste
    {
        [Key]
        public int SkladisteID { get; set; }

        public string NazivSkladista { get; set; }
    }
}
