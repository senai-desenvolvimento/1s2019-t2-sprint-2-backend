using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using Senai.SviGufo.WebApi.Repositories;
using System;

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
        /// <returns>Retorna uma lista de eventos</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(EventoRepository.Listar());
            }
            catch
            {

                return BadRequest();
            }
        }

        /// <summary>
        /// Cadastra um novo evento
        /// </summary>
        /// <param name="evento">EventoDomain</param>
        /// <returns>Retorna o Status Code</returns>
        [HttpPost]
        public IActionResult Post(EventoDomain evento)
        {
            try
            {
                EventoRepository.Cadastrar(evento);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Atualiza um evento
        /// </summary>
        /// <param name="id">Id do evento</param>
        /// <param name="evento">EventoDomain</param>
        /// <returns>Retorna Status Code</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, EventoDomain evento)
        {
            try
            {
                EventoRepository.Atualizar(id, evento);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}