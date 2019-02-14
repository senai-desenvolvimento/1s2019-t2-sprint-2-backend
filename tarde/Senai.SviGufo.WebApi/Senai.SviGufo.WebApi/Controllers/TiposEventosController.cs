using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using Senai.SviGufo.WebApi.Repositories;
using System.Collections.Generic;

namespace Senai.SviGufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController] //Implementa funcionalidades no controller
    public class TiposEventosController : ControllerBase
    {
        List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>()
        {
            new TipoEventoDomain{ Id = 1, Nome = "Tecnologia"},
            new TipoEventoDomain{ Id = 2, Nome = "Redes"},
            new TipoEventoDomain{ Id = 3, Nome = "Desenvolvimento"},
            new TipoEventoDomain{ Id = 4, Nome = "Design"}
        };

        private ITipoEventoRepository TipoEventoRepository { get; set; }

        public TiposEventosController()
        {
            TipoEventoRepository = new TipoEventoRepository();
        }

        //[HttpGet]
        //public string Get()
        //{
        //    return "Recebi sua requisição";
        //}

        /// <summary>
        /// Retorna uma lista de tipos de eventos
        /// </summary>
        /// <returns>Lista de Eventos</returns>
        
        [HttpGet]
        public IEnumerable<TipoEventoDomain> Get()
        {
            return TipoEventoRepository.Listar();
        }

        /// <summary>
        /// Busca o tipo de evento pelo Id
        /// </summary>
        /// <param name="id">Id do tipo de evento</param>
        /// <returns>Retorn um Tipo de evento</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //Busca um tipo de evento pelo seu id
            TipoEventoDomain tipoEvento = tiposEventos.Find(x => x.Id == id);

            //Verifica se foi encontrado na lista o tipo de evento
            if(tipoEvento == null)
            {
                //retorna não encontrado
                return NotFound();
            }

            //retorna ok e o tipo de evento
            return Ok(tipoEvento);
        }

        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="tipoEvento">TipoEventoDomain</param>
        /// <returns>Retorna um Status Code</returns>
        [HttpPost]
        public IActionResult Post(TipoEventoDomain tipoEvento)
        {
            TipoEventoRepository.Cadastrar(tipoEvento);
            return Ok();
        }

        /// <summary>
        /// Atualiza um tipo de evento
        /// </summary>
        /// <param name="tipoEvento">Tipo Evento a ser atualizado</param>
        /// <returns>Retorna um status code</returns>
        [HttpPut]
        public IActionResult Put(TipoEventoDomain tipoEvento)
        {
            TipoEventoRepository.Alterar(tipoEvento);

            return Ok();
        }

        /// <summary>
        /// Altera um tipo de evento passando o id
        /// </summary>
        /// <param name="id">Id do Tipo de evento</param>
        /// <param name="tipoEvento">TipoEventoDomain</param>
        /// <returns>retorna o status code</returns>
        [HttpPut("{id}")]
        public IActionResult PutById(int id, TipoEventoDomain tipoEvento)
        {
            return Ok();
        }

        /// <summary>
        /// Deleta um registro
        /// </summary>
        /// <param name="id">Id do tipo de evento</param>
        /// <returns>Retorna status code</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            TipoEventoRepository.Deletar(id);

            return Ok();
        }
    }
}