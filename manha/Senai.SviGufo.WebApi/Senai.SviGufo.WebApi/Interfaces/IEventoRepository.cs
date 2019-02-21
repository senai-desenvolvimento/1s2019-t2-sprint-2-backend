using Senai.SviGufo.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.SviGufo.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo Repositorio de eventos
    /// </summary>
    public interface IEventoRepository
    {
        /// <summary>
        /// Lista os eventos
        /// </summary>
        /// <returns>Retornar uma lista de eventos</returns>
        List<EventoDomain> Listar();

        /// <summary>
        /// Cadastra um novo evento
        /// </summary>
        /// <param name="evento">EventoDomain</param>
        void Cadastrar(EventoDomain evento);

        /// <summary>
        /// Atualiza um Evento
        /// </summary>
        /// <param name="id">Id do Evento</param>
        /// <param name="evento">EventoDomain</param>
        void Atualizar(int id, EventoDomain evento);
    }
}
