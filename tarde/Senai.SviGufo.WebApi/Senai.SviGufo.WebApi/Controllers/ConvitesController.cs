using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Interfaces;
using Senai.SviGufo.WebApi.Repositories;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Senai.SviGufo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConvitesController : ControllerBase
    {

        private IConviteRepository ConviteRepository { get; set; }

        public ConvitesController()
        {
            ConviteRepository = new ConviteRepository();
        }

        // vocês são tão fofinhos <3
        /// <summary>
        /// Somente os administradores terão acesso a todos os convites
        /// </summary>
        [Authorize(Roles = "ADMINISTRADOR")]
        // é a mesma regra que será autorizada a realizar as atividades
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(ConviteRepository.Listar());
            }
            catch (System.Exception ex)
            {

                return BadRequest(new { mensagem = "Eita, deu ruim." });
            }
        }

        // agora precisamos listar apenas os convites do usuário comum (meus convites)
        [Authorize]
        [HttpGet]
        // posso definir uma rota pra ele
        [Route("meus")]
        // ====> /api/convites/meus
        public IActionResult MeusConvites()
        {
            try
            {
                // aonde estão as informações do usuário?
                int usuarioId = 
                    Convert.ToInt32(HttpContext.User.Claims.First
                    (c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                //string teste =
                //    HttpContext.User.Claims.First
                //    (lambda => lambda.Type == "teste").Value;
                
                return Ok(ConviteRepository.ListarMeusConvites(usuarioId));
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita, deu ruim de novo." });
            }
        }

        [Authorize]
        // /api/convites/1
        [HttpPost("inscricao/{eventoId}")]
        public IActionResult Inscricao(int eventoId)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}