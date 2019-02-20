using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using Senai.SviGufo.WebApi.Repositories;

namespace Senai.SviGufo.WebApi.Controllers
{
    [Produces("application/json")] // Retorna formato Json
    [Route("api/[controller]")] 
    [ApiController] //Implementa funcionalidades no Controller
    public class InstituicoesController : ControllerBase
    {
        //Declara a Interface que será utilizada
        private IInstituicaoRepository InstituicaoRepository { get; set; }

        
        public InstituicoesController()
        {
            //Instância o Repositorio
            InstituicaoRepository = new InstituicaoRepository();
        }

        /// <summary>
        /// Lista todas as Instituições
        /// </summary>
        /// <returns>Retorna uma Lista de Instituições</returns>
        [HttpGet]
        // mas era para acontecer amanhã, johny
        // pode johny, se vocÊ colocar uma vírgula, fica topson
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult Get()
        {
            return Ok(InstituicaoRepository.Listar());
        }

        /// <summary>
        /// Busca uma instituição pelo Id
        /// </summary>
        /// <param name="id">Id da instituição</param>
        /// <returns>Retorna uma instituição</returns>
        [HttpGet("{id}")] //Recebe como parametro o id da instituicao
        public IActionResult GetById(int id)
        {
            //Busca a instituição
            InstituicaoDomain instituicaoBuscada = InstituicaoRepository.BuscarPorId(id);

            //Verifica se retornou uma instituição
            if(instituicaoBuscada == null)
            {
                //Caso não encontre retorna status 404
                return NotFound();
            }

            //Caso encontre retorna status 200 e a instituição
            return Ok(instituicaoBuscada);
        }

        /// <summary>
        /// Cadastra uma nova instituição
        /// </summary>
        /// <param name="instituicao">Instituição que será cadastrada</param>
        /// <returns>Retorna um status code</returns>
        [HttpPost]
        public IActionResult Post(InstituicaoDomain instituicao)
        {
            try //tenta
            { 
                //Efetua o cadastro da instituição
                InstituicaoRepository.Cadastrar(instituicao);
                //Retorna status 200
                return Ok();
            }
            catch //Ocorreu um erro
            {
                //Retorna status 500
                return BadRequest();
            }
        }

        /// <summary>
        /// Altera uma Instituição
        /// </summary>
        /// <param name="id">Id da Instituição</param>
        /// <param name="instituicao">Dados da instituição</param>
        /// <returns>Retorna um status code</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, InstituicaoDomain instituicao)
        {
            InstituicaoDomain instituicaoBuscada = InstituicaoRepository.BuscarPorId(id);

            if(instituicaoBuscada == null)
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
                InstituicaoRepository.Alterar(id, instituicao);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Exclui uma instituição
        /// </summary>
        /// <param name="id">Id da instituição</param>
        /// <returns>Retorna um status code</returns>
        [HttpDelete("{ID}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Exclui uma instituição do banco
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