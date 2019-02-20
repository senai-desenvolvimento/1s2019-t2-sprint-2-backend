using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using Senai.SviGufo.WebApi.Repositories;

namespace Senai.SviGufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public IUsuarioRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuario">UsuarioDomain</param>
        /// <returns>Retorna um Status Code</returns>
        [HttpPost]
        public IActionResult Post(UsuarioDomain usuario)
        {
            try
            {
                //Chama o repositorio para efetuar o cadastro do usuário
                UsuarioRepository.Cadastrar(usuario);

                //Retorna um status code 200 informando que o usuário foi cadastrado
                return Ok(new {
                    mensagem = "Usuário Cadastrado"
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}