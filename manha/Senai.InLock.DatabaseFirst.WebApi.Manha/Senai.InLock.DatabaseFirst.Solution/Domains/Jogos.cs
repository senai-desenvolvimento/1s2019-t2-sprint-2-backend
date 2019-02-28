using System;

namespace Senai.InLock.DatabaseFirst.Solution.Domains
{
    public partial class Jogos
    {
        public int JogoId { get; set; }
        public string NomeJogo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataLancamento { get; set; }
        // Frankllliiiiiiiiiin
        // o campo pode ser nulo
        public decimal? Valor { get; set; }
        public int? EstudioId { get; set; }

        public Estudios Estudio { get; set; }
    }
}
