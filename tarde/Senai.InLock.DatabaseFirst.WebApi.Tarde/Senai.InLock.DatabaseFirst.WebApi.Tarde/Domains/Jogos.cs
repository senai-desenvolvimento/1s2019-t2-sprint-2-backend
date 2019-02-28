using System;

namespace Senai.InLock.DatabaseFirst.WebApi.Tarde.Domains
{
    public partial class Jogos
    {
        public int JogoId { get; set; }
        public string NomeJogo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        public decimal? Valor { get; set; }
        public int? EstudioId { get; set; }

        public Estudios Estudio { get; set; }
    }
}
