using System.ComponentModel.DataAnnotations;

namespace Senai.SviGufo.WebApi.Domains
{
    public class InstituicaoDomain
    {
        public int Id { get; set; }
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage ="Informe a Razão Social")]
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Logradouro { get; set; }
        public string Cep { get; set; }

        [StringLength(2, MinimumLength = 2,ErrorMessage = "O campo tem que ter 2 caracteres")]
        public string Uf { get; set; }
        public string Cidade { get; set; }
    }
}
