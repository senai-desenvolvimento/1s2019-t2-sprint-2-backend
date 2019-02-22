using Senai.SviGufo.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.SviGufo.WebApi.Interfaces
{
    public interface IConviteRepository
    {
        /// <summary>
        /// Listar todos os convites
        /// </summary>
        /// <returns>A lista com todos os convites</returns>
        List<ConviteDomain> Listar();

        /// <summary>
        /// Listar somente os convites do usuário
        /// </summary>
        /// <param name="usuarioId">id</param>
        /// <returns>Lista de Convites do Usuário</returns>
        List<ConviteDomain> ListarMeusConvites(int usuarioId);

        /// <summary>
        /// Cadastrar um novo convite
        /// </summary>
        /// <param name="convite"></param>
        void Cadastrar(ConviteDomain convite);

    }
}
