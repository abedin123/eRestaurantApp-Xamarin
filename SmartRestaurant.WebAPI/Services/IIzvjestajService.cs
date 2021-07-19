using SmartRestaurant.Data;
using SmartRestaurant.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.WebAPI
{
    public interface IIzvjestajService
    {
       UkupniIzvjestajVM Get(DateTime OD,DateTime DO,string naziv);
    }
}
