using Senai.SviGufo.WebApi.Domains.Enums;

namespace Senai.SviGufo.WebApi.Domains
{
    public class ConviteDomain
    {
        public int Id { get; set; }

        public int EventoId { get; set; }
        public EventoDomain Evento { get; set; }

        public int UsuarioId { get; set; }
        public UsuarioDomain Usuario { get; set; }

        public EnSituacaoConvite Situacao { get; set; }
    }
}
