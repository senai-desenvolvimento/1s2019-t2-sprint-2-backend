using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senai.InLock.CodeFirst.WebApi.Tarde.Domains
{
    [Table("Estudios")]
    public class EstudioDomain
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EstudioId { get; set; }

        [Column("NomeEstudio", TypeName = "varchar(150)")]
        // [Index(IsUnique=True)]
        [Required]
        public string NomeEstudio { get; set; }

        public List<JogoDomain> Jogos { get; set; }
    }
}
