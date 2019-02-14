using Senai.SviGufo.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.SviGufo.WebApi.Interfaces
{
    public interface ITipoEventoRepository
    {
        /// <summary>
        /// Lista todos os tipos de eventos
        /// </summary>
        /// <returns>Retorna uma lista de tipo de eventos</returns>
        List<TipoEventoDomain> Listar();

        /// <summary>
        /// Cadastrar um novo evento
        /// </summary>
        /// <param name="tipoEvento">Objeto TipoEvento</param>
        void Cadastrar(TipoEventoDomain tipoEvento);

        /// <summary>
        /// Altera um tipo de evento
        /// </summary>
        /// <param name="tipoEvento">TipoEventoDomain</param>
        void Alterar(TipoEventoDomain tipoEvento);

        /// <summary>
        /// Deleta um tipo de evento
        /// </summary>
        /// <param name="id">id do tipo evento</param>
        void Deletar(int id);
        
    }
}
