using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartRestaurant.Data
{
    public class NarudzbaDetalji
    {
        [Key]
        public int NarudzbaDetaljiID { get; set; }

        public string Količina { get; set; }

        public double Cijena { get; set; }

        public bool Placena { get; set; }

    }
}
