using Senai.SviGufo.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.SviGufo.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório da Instituição
    /// </summary>
    public interface IInstituicaoRepository
    {
        /// <summary>
        /// Listar as instituições
        /// </summary>
        /// <returns></returns>
        List<InstituicaoDomain> Listar();

        /// <summary>
        /// Busca uma instituição pelo Id
        /// </summary>
        /// <param name="id">Id da instituição</param>
        /// <returns>Retorna uma instituição</returns>
        InstituicaoDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra uma nova instituição
        /// </summary>
        /// <param name="instituicao">Recebe uma instituição</param>
        void Cadastrar(InstituicaoDomain instituicao);

        /// <summary>
        /// Altera uma instituição
        /// </summary>
        /// <param name="instituicao">Instituição</param>
        /// <param name="id">Id da instituição</param>
        void Alterar(InstituicaoDomain instituicao, int id);

        /// <summary>
        /// Deleta uma instituição
        /// </summary>
        /// <param name="id">Id da instituição</param>
        void Deletar(int id);
    }
}
