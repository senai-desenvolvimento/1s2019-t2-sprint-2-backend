using Senai.SviGufo.WebApi.Domains;

namespace Senai.SviGufo.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório usuário
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Cadastra um novo usuário
        /// </summary>
        /// <param name="usuario">UsuarioDomain</param>
        void Cadastrar(UsuarioDomain usuario);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        UsuarioDomain BuscarPorEmailSenha(string email, string senha);
    }
}
