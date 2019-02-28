using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Senai.InLock.DatabaseFirst.WebApi.Tarde.Domains;
using System;
using System.Linq;

namespace Senai.InLock.DatabaseFirst.WebApi.Tarde.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        [HttpGet]
        public IActionResult ListarEstudios()
        {
            try
            {
                using (InLockContext ctx = new InLockContext())
                {
                    return Ok(ctx.Estudios.ToList());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "Deu ruim :(" });
            }
        }
        // GET - api/estudios/estudiosComJogos
        [HttpGet("estudiosComJogos")]
        public IActionResult BuscarEstudiosComJogos()
        {
            try
            {
                using (InLockContext ctx = new InLockContext())
                {
                    // return Ok(ctx.Estudios.Include("Jogos").ToList());
                    return Ok(ctx.Estudios.Include(x => x.Jogos).ToList());
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "Deu ruim :(" });
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Estudios estudio)
        {
            try
            {
                using (InLockContext ctx = new InLockContext())
                {
                    ctx.Estudios.Add(estudio);
                    ctx.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message + "Deu ruim :(" });
            }
        }
    }
}