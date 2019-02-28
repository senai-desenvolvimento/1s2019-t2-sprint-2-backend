using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Senai.InLock.DatabaseFirst.Solution.Domains;
using System;
using System.Linq;

namespace Senai.InLock.DatabaseFirst.Solution.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {

        // SqlConnection (conexao) + SqlCommand (comando select)
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // dentro do inlock, há tudo o que precisamos - string, domínios, etc
                using (InLockContext ctx = new InLockContext())
                {
                    return Ok(ctx.Estudios.ToList());
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("estudioComJogos")]
        public IActionResult GetEstudioComJogos()
        {
            try
            { 
                using (InLockContext ctx = new InLockContext())
                {
                    return Ok(ctx.Estudios.Include("Jogos").ToList());
                }
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Post(Estudios estudio)
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
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put(Estudios estudio)
        {
            try
            {
                using (InLockContext ctx = new InLockContext())
                {

                    Estudios estudioExiste = ctx.Estudios.Find(estudio.EstudioId);

                    if (estudioExiste == null)
                    {
                        return NotFound();
                    }

                    estudioExiste.NomeEstudio = estudio.NomeEstudio;
                    ctx.Estudios.Update(estudioExiste);
                    ctx.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                using (InLockContext ctx = new InLockContext())
                {
                    Estudios estudioProcurado = ctx.Estudios.Find(id);

                    if (estudioProcurado == null)
                    {
                        return NotFound();
                    }

                    ctx.Estudios.Remove(estudioProcurado);
                    ctx.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            
        }
    }
}