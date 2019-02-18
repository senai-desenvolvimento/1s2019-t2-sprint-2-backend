using System.ComponentModel.DataAnnotations;

namespace Senai.SviGufo.WebApi.Domains
{
    /// <summary>
    /// Classe que representa a tabela Instituições no banco de dados
    /// </summary>
    public class InstituicaoDomain
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Informe o Cnpj")]
        public string Cnpj { get; set; }
        public string Logradouro { get; set; }
        public string Cep { get; set; }

        [StringLength(2, MinimumLength = 2, ErrorMessage = "Oh querido a uf deve conter 2 caracteres")]
        [Required(ErrorMessage = "Oh querido eu estou falando que a uf é obrigatória")]
        public string Uf { get; set; }
        public string Cidade { get; set; }
    }
}
