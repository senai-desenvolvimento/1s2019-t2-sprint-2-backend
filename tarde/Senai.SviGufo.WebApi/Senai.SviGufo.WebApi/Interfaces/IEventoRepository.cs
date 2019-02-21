using Senai.SviGufo.WebApi.Domains;
using System.Collections.Generic;

namespace Senai.SviGufo.WebApi.Interfaces
{
    public interface IEventoRepository
    {
        List<EventoDomain> Listar();
    }
}
