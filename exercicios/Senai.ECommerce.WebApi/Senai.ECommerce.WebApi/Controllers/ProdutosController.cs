using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Senai.ECommerce.WebApi.Context;
using Senai.ECommerce.WebApi.Domains;
using Senai.ECommerce.WebApi.ViewModels;
using System;
using System.IO;
using System.Linq;

namespace Senai.ECommerce.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post([FromForm] CadastroProdutoViewModel produto)
        {
            try
            {
                //Verifica se a imagem foi passada
                if (produto.Imagem != null && produto.Imagem.Length > 0)
                {
                    //Defini o nome do arquivo
                    var NomeArquivo = Guid.NewGuid().ToString().Replace("-","") + Path.GetExtension(produto.Imagem.FileName);

                    //Defini o caminho do arquivo
                    var CaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads\\imgs", NomeArquivo);

                    //Salva a imagem no caminho informado acima
                    using (var StreamImagem = new FileStream(CaminhoArquivo, FileMode.Create))
                    {
                        produto.Imagem.CopyTo(StreamImagem);
                    }

                    //Defini os valores do Objeto ProdutoDomain
                    ProdutoDomain produtoTemp = new ProdutoDomain
                    {
                        Nome = produto.Nome,
                        Preco = Convert.ToDecimal(produto.Preco),
                        Imagem = "/uploads/imgs/" + NomeArquivo
                    };

                    //Salva as informações no banco
                    using(ECommerceContext ctx = new ECommerceContext())
                    {
                        ctx.Produtos.Add(produtoTemp);
                        ctx.SaveChanges();
                    }
                    
                    //retorna o status code Ok
                    return Ok();
                }

                return BadRequest();
            }
            catch (System.Exception ex)
            {
                return BadRequest();
            }
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (ECommerceContext ctx = new ECommerceContext())
                {
                    return Ok(ctx.Produtos.ToList());
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}