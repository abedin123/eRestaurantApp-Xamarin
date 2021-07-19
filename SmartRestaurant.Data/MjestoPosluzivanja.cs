using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartRestaurant.Data
{
    public class MjestoPosluzivanja
    {
        [Key]
        public int MjestoPosluzivanjaID { get; set; }

        public int BrojMjestaPosluzivanja { get; set; }
    }
}
