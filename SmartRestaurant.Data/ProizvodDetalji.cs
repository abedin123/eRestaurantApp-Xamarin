using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartRestaurant.Data
{
    public class ProizvodDetalji
    {
        [Key]
        public int ProizvodDetaljiID { get; set; }

        public string Opis { get; set; }

        public int KolicinaNaSkladistu { get; set; }
    }
}
