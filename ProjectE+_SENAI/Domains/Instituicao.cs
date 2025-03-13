using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ProjectE__SENAI.Domains
{
    [Table("Instituicao")]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicao
    {
        [Key]
        public Guid IdInstituição { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O endereço da Istituição é obrigatório!")]
        public string? Local { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O Estilo de Vestimenta é obrigatório!")]
        public string? Vestimenta { get; set; }
        
        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "O Estilo de Vestimenta é obrigatório!")]
        [StringLength(14)]
        public string? CNPJ { get; set; }
    }
}
