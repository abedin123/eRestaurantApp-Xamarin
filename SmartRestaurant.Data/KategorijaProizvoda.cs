﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartRestaurant.Data
{
    public class KategorijaProizvoda
    {
        [Key]
        public int KategorijaProizvodaID { get; set; }

        public string NazivKategorije { get; set; }
    }
}
