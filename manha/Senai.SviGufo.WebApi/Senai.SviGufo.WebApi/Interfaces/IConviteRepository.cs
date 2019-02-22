using Senai.SviGufo.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.SviGufo.WebApi.Interfaces
{
    public interface IConviteRepository
    {
        /// <summary>
        /// Lista todos os convites
        /// </summary>
        /// <returns></returns>
        List<ConviteDomain> Listar();

        List<ConviteDomain> ListarMeusConvites(int id);

        /// <summary>
        /// Cadastra um convite
        /// </summary>
        /// <param name="convite">ConviteDomain</param>
        void Cadastrar(ConviteDomain convite);
    }
}
