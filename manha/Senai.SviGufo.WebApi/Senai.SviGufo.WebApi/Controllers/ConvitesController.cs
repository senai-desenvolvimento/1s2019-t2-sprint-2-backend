using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Domains.Enums;
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

        /// <summary>
        /// Lista todos os convites
        /// </summary>
        /// <returns>Retorna uma lista de Convites</returns>
        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {

                return Ok(ConviteRepository.Listar());
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpGet]
        [Route("meus")]
        public IActionResult ListarMeusConvites()
        {
            try
            {
                int usuarioid = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                //string teste = HttpContext.User.Claims.First(c => c.Type == "teste").Value;

                return Ok(ConviteRepository.ListarMeusConvites(usuarioid));
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost("inscricao/{eventoid}")]
        public IActionResult Inscricao(int eventoid)
        {
            try
            {
                ConviteDomain convite = new ConviteDomain();
                convite.EventoId = eventoid;
                convite.UsuarioId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                convite.Situacao = EnSituacaoConvite.AGUARDANDO;

                ConviteRepository.Cadastrar(convite);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost("convidar")]
        public IActionResult Convidar(ConviteDomain convite)
        {
            try
            {
                ConviteRepository.Cadastrar(convite);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}