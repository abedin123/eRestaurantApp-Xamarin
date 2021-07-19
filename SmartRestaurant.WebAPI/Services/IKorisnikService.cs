using SmartRestaurant.Data;
using SmartRestaurant.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.WebAPI
{
    public interface IKorisnikService
    {
        IList<IspisNarudzbi> Get(PretragaNarudzbiVM request);
        IList<Uloge> GetUloge();
        Korisnici Insert(InsertNovogKorisnikaVM request);
        Korisnici Autentifikacija(string username, string password);
    }
}
