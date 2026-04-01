using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiapCoreX.Models
{
    [Table("tbAluno")]
    public class Aluno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idAluno")]
        public int Id { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
    }
}
