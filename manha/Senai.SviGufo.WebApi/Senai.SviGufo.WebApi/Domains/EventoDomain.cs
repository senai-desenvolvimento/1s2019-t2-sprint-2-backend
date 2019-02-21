using System;
using System.ComponentModel.DataAnnotations;

namespace Senai.SviGufo.WebApi.Domains
{
    /// <summary>
    /// Classe que faz referencia a tabela Eventos
    /// </summary>
    public class EventoDomain
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Informe a Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe a Data Evento")]
        [DataType(DataType.Date)]
        public DateTime DataEvento { get; set; }

        [Required(ErrorMessage = "Informe o Acesso Livre")]
        public bool AcessoLivre { get; set; }

        [Required(ErrorMessage = "Informe o Tipo Evento Id")]
        public int TipoEventoId { get; set; }
        public TipoEventoDomain TipoEvento { get; set; }

        [Required(ErrorMessage = "Informe o Instituição Id")]
        public int InstituicaoId { get; set; }
        public InstituicaoDomain Instituicao { get; set; }
    }
}
