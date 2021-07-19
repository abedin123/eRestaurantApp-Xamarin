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
    [Authorize(Roles = "Vlasnik")]
    public class IzvjestajController : ControllerBase
    {
        private readonly IIzvjestajService _izvjestajservice;
        public IzvjestajController(IIzvjestajService izvjestajservice)
        {
            _izvjestajservice = izvjestajservice;
    
        }

        [HttpGet]
        public UkupniIzvjestajVM Get(DateTime OD, DateTime DO, string naziv)
        {
            var list = _izvjestajservice.Get(OD, DO, naziv);

            return list;
        }
    }
}
