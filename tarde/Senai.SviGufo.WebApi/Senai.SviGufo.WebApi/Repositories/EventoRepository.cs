using Senai.SviGufo.WebApi.Domains;
using Senai.SviGufo.WebApi.Interfaces;
using System;
using System.Collections.Generic;

namespace Senai.SviGufo.WebApi.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress; initial catalog= SENAI_SVIGUFO_TARDE_BACKEND; integrated security=true";

        public List<EventoDomain> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
