using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senai.ECommerce.WebApi.Domains
{
    [Table("Produtos")]
    public class ProdutoDomain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Nome", TypeName = "varchar(250)")]
        public string Nome { get; set; }

        [Column("Preco", TypeName = "decimal(5,2)")]
        public decimal Preco { get; set; }

        [Column("Imagem", TypeName = "varchar(255)")]
        public string Imagem { get; set; }
    }
}
