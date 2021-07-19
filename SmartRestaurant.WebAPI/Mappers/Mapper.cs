using AutoMapper;
using SmartRestaurant.Data;
using SmartRestaurant.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.WebAPI
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Korisnici, KorisniciVM>().ReverseMap();
            CreateMap<Korisnici, InsertNovogKorisnikaVM>().ReverseMap();
            CreateMap<Narudzba, IspisNarudzbi>().ReverseMap();
        }
    }
}
