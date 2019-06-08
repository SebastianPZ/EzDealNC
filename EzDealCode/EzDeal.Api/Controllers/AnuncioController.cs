using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EzDeal.Service;
using EzDeal.Domain;

namespace EzDeal.Api.Controllers
{
    [Route("api/anuncios")]
    [ApiController]
    public class AnuncioController : ControllerBase
    {
        private IAnuncioService anuncioService;

        public AnuncioController(IAnuncioService anuncioService){
            this.anuncioService = anuncioService;
        }

        [HttpGet]
        public ActionResult Get(){
             return Ok(
                anuncioService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Anuncio anuncio)
        {
            return Ok(anuncioService.Save(anuncio));
        
        }
    }
}