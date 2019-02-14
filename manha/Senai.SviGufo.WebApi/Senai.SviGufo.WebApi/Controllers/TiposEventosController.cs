using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using Senai.SviGufo.WebApi.Repositories;
using System.Collections.Generic;

namespace Senai.SviGufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController] // Implementa funcionalidades em nosso controller
    public class TiposEventosController : ControllerBase
    {
        List<TipoEventoDomain> tiposEventos = new List<TipoEventoDomain>()
        {
            new TipoEventoDomain{ Id = 1, Nome = "Tecnologia"},
            new TipoEventoDomain{ Id = 2, Nome = "Redes"},
            new TipoEventoDomain{ Id = 3, Nome = "Desenvolvimento"},
            new TipoEventoDomain{ Id = 4, Nome = "Design"}
        };

        //Cria um objeto do tipo ITipoEventoRepository
        private ITipoEventoRepository TipoEventoRepository { get; set; }

        public TiposEventosController()
        {
            //Cria uma instancia de tipoeventorepository
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

        [HttpPost] //Verbo para inserir 
        //[FromBody] Pega os dados enviados para a api
        public IActionResult Post(TipoEventoDomain tipoEventoRecebido)
        {
            //Adiciona o tipo de evento recebido na Api
            //tiposEventos.Add(new TipoEventoDomain
            //{
            //    Id = tiposEventos.Count + 1,                                     
            //    Nome = tipoEventoRecebido.Nome
            //});

            TipoEventoRepository.Cadastrar(tipoEventoRecebido);

            //Retorna Ok e a lista com os tipos de eventos
            return Ok();
        }

        [HttpPut] //Verbo para Atualizar
        public IActionResult Put(TipoEventoDomain tipoEventoRecebido)
        {
            TipoEventoRepository.Alterar(tipoEventoRecebido);

            return Ok();
        }

        //[HttpPut("{id}")] //verbo para alterar, passa o id no recurso
        //public IActionResult Put(int id, TipoEventoDomain tipoEventoRecebido)
        //{
        //    return Ok();
        //}


        [HttpDelete("{id}")]//Verbo para deletar um registro
        public IActionResult Delete(int id)
        {
            TipoEventoRepository.Deletar(id);

            return Ok();
        }
    }
}