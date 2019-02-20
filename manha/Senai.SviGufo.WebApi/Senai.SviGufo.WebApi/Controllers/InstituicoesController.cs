using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using Senai.SviGufo.WebApi.Repositories;
using System;

namespace Senai.SviGufo.WebApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referente a Instituicao
    /// </summary>
    [Authorize(Roles = "ADMINISTRADOR")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController] //Implementa funcionalidades ao Controller 
    public class InstituicoesController : ControllerBase
    {
        //Declaração do objeto 
        private IInstituicaoRepository InstituicaoRepository { get; set; }

        public InstituicoesController()
        {
            //Instância o repositório referente a instituição
            InstituicaoRepository = new InstituicaoRepository();
        }

        /// <summary>
        /// Retorna uma lista de Instituições
        /// </summary>
        /// <returns>Retorna uma List de Instituições</returns>
        [HttpGet]
        
        public IActionResult Get()
        {
            //Retorna a lista de Instituições com o Status Code Ok
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
            //Busca uma instituição pelo seu id
            InstituicaoDomain instituicao = InstituicaoRepository.BuscarPorId(id);

            //Verifica se a instituição buscada é nula
            if(instituicao == null)
            {
                //Retorna com o status code 404 Not Found
                return NotFound();
            }

            //Retorna a instituição com o status code 200
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
            
            try //Tenta fazer uma operação
            {              
                //Cadastra ujma instituição
                InstituicaoRepository.Cadastrar(instituicao);

                //Retorna o status code 200
                return Ok();
            }
            catch //Caso de erro 
            {
                // IActionResult é top
                // api é mais top ainda
                //Retorna o status code com uma mensagem
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
            //Busca uma instituição pelo seu id
            InstituicaoDomain instituicaoBuscada = InstituicaoRepository.BuscarPorId(id);

            //Verifica se a instituição buscada é nula
            if (instituicaoBuscada == null)
            {
                //Retorna com o status code 404 Not Found passando um json na resposta
                return NotFound(new
                {
                    mensagem = "A instituição não foi encontrada.",
                    erro = true
                });
            }

            try //Tenta
            {
                //Altera uma instituição passando como parametro seus dados e o id da instituição
                InstituicaoRepository.Alterar(instituicao, id);
                return Ok();
            }
            catch //Caso de erro
            {
                //Retorna um status code 500
                return BadRequest();
            }
            
        }

        /// <summary>
        /// Exclui uma instituição pelo seu Id
        /// </summary>
        /// <param name="id">Id da instituição</param>
        /// <returns>Retorna um status code</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            //Busca uma instituição pelo seu id
            InstituicaoDomain instituicaoBuscada = InstituicaoRepository.BuscarPorId(id);

            //Verifica se a instituição buscada é nula
            if (instituicaoBuscada == null)
            {
                //Retorna com o status code 404 Not Found passando um json na resposta
                return NotFound(new
                {
                    mensagem = "A instituição não foi encontrada.",
                    erro = true
                });
            }

            try
            {
                //Exclui uma instituição
                InstituicaoRepository.Deletar(id);
                //Retorna um status code 200
                return Ok();
            }
            catch
            {
                //Retorna um status code 500
                return BadRequest();
            }
        }

    }
}