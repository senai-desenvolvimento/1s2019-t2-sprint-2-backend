using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Senai.ECommerce.WebApi.ViewModels
{
    public class CadastroProdutoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto")]
        public string Nome { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Informe o preço do produto")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Informe a imagem")]
        public IFormFile Imagem { get; set; }
    }
}
