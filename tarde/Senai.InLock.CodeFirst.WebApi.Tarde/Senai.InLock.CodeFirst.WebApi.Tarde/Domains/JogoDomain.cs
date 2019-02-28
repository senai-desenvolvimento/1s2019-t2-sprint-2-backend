using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senai.InLock.CodeFirst.WebApi.Tarde.Domains
{
    public class JogoDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JogoId { get; set; }

        [Column(TypeName = "varchar(150)")]
        [Required]
        public string NomeJogo { get; set; }

        [Column("Descricao", TypeName = "Text")]
        [Required]
        public string Descricao { get; set; }
        
        [DataType(DataType.Date)]
        [Required]
        public DateTime DataLancamento { get; set; }

        // decimal
        [DataType(DataType.Currency)]
        [Required]
        public Decimal Valor { get; set; }

        [Required]
        // Gravação
        public int EstudioId { get; set; }

        [ForeignKey("EstudioId")]
        // Leitura
        public EstudioDomain Estudio { get; set; }
    }
}
