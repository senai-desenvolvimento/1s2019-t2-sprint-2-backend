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
    public class InstituicoesController : ControllerBase
    {
        private IInstituicaoRepository InstituicaoRepository { get; set; }

        public InstituicoesController()
        {
            InstituicaoRepository = new InstituicaoRepository();
        }

        /// <summary>
        /// Retorna uma lista de Instituições
        /// </summary>
        /// <returns>Retorna uma List de Instituições</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(InstituicaoRepository.Listar());
        }

        /// <summary>
        /// Retorna uma instituição
        /// </summary>
        /// <param name="id">Id da Instituição</param>
        /// <returns>Retorna uma Instituição</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            InstituicaoDomain instituicao = InstituicaoRepository.BuscarPorId(id);

            if(instituicao == null)
            {
                return NotFound();
            }

            return Ok(instituicao);
        }

        /// <summary>
        /// Cadastra uma nova instituição
        /// </summary>
        /// <param name="instituicao">Recebe uma instituição</param>
        /// <returns>Retorna um status code</returns>
        [HttpPost]
        public IActionResult Post(InstituicaoDomain instituicao)
        {
            try
            {
                
                InstituicaoRepository.Cadastrar(instituicao);
                return Ok();
            }
            catch
            {
                // IActionResult é top
                // api é mais top ainda
                return BadRequest("Deu bem ruim.");
            }
        }

        /// <summary>
        /// Altera uma instituição
        /// </summary>
        /// <param name="id">Id da instituição</param>
        /// <param name="instituicao">Dados da instituição</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, InstituicaoDomain instituicao)
        {
            InstituicaoDomain instituicaoBuscada = InstituicaoRepository.BuscarPorId(id);
            if (instituicaoBuscada == null)
            {
                return NotFound(
                    new
                    {
                        mensagem = "A instituição não foi encontrada.",
                        erro = true
                    }
                    );
            }

            try
            {
                InstituicaoRepository.Alterar(instituicao, id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            InstituicaoDomain instituicaoBuscada = InstituicaoRepository.BuscarPorId(id);
            if (instituicaoBuscada == null)
            {
                return NotFound(
                        new 
                        {
                            mensagem = "A instituição não foi encontrada.",
                            erro = true
                        }
                    );
            }

            try
            {
                InstituicaoRepository.Deletar(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}