using System.ComponentModel.DataAnnotations;

namespace Senai.SviGufo.WebApi.Domains
{
    /// <summary>
    /// Classe responsável pela tabela Usuarios
    /// </summary>
    public class UsuarioDomain
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe o tipo de usuário")]
        public string TipoUsuario { get; set; }
    }
}
