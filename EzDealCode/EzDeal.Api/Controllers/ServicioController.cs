using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EzDeal.Service;
using EzDeal.Domain;

namespace EzDeal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {

        private IServicioService servicioService;

        public ServicioController(IServicioService servicioService)
        {
            this.servicioService = servicioService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                servicioService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Servicio servicio)
        {
            return Ok(
                servicioService.Save(servicio)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Servicio servicio)
        {
            return Ok(
                servicioService.Update(servicio)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                servicioService.Delete(id)
            );
        }

    }
}