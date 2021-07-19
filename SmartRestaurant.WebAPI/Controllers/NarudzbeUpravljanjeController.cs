using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Data;
using SmartRestaurant.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator,Vlasnik")]
    public class NarudzbeUpravljanjeController : ControllerBase
    {
        private readonly INarudzbeService _narudzbeService;

        public NarudzbeUpravljanjeController(INarudzbeService narudzbeService)
        {
            _narudzbeService = narudzbeService;
        }

        [HttpGet]
        public IList<PregledVM> PregledNarudzbi([FromQuery] FilterPregledVM request)
        {
            var list = _narudzbeService.PregledNarudzbi(request);

            return list;
        }

        [HttpGet("{idnarudzbe}")]
        public UrediNarudzbuVM GetNarudzba(int idnarudzbe)
        {
            var obj = _narudzbeService.GetNarudzba(idnarudzbe);

            return obj;
        }

        [HttpPatch]
        public Narudzba UrediNarudzbu(IzvrsiUredjivanjeNarudzbeVM objekat)
        {
            var obj = _narudzbeService.UrediNarudzbu(objekat);

            return obj;
        }
    }
}
