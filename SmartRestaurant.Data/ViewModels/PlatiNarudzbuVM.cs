﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Data.ViewModels
{
    public class PlatiNarudzbuVM
    {
        public int NarudzbaID { get; set; }
        public string NazivNarudzbe { get; set; }
        public double Cijena { get; set; }
        public string ImeNarucioca { get; set; }
    }
}
