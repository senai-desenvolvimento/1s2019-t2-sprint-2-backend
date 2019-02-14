using Senai.SviGufo.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.SviGufo.WebApi.Interfaces
{
    public interface ITipoEventoRepository
    {
        /// <summary>
        /// Lista todos os tipos de eventos
        /// </summary>
        /// <returns>Retorna uma lista de tipo evento</returns>
        List<TipoEventoDomain> Listar();

        /// <summary>
        /// Cadastra um tipo de evento
        /// </summary>
        /// <param name="tipoEvento">Objeto do tipo evento domain</param>
        void Cadastrar(TipoEventoDomain tipoEvento);

        void Deletar(int id);

        void Alterar(TipoEventoDomain tipoEvento);
    }
}
