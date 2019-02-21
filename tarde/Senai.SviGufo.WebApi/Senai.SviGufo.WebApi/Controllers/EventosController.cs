using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Interfaces;
using Senai.SviGufo.WebApi.Repositories;

namespace Senai.SviGufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private IEventoRepository EventoRepository { get; set; }

        public EventosController()
        {
            EventoRepository = new EventoRepository();
        }

        /// <summary>
        /// Lista todos os eventos
        /// </summary>
        /// <returns>Retorna o Status Code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok();
            }
            catch 
            {
                return BadRequest();
            }
        }
    }
}