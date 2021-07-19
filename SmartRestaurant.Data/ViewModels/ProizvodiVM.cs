using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Data.ViewModels
{
    public class ProizvodiVM
    {
        public int ProizvodID { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }
        public byte[] Slika { get; set; }
        public double ProcenatProfitabilnosti { get; set; }
    }
}
