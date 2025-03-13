using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectE__SENAI.Domains
{
    [Table("Presença")]
    public class Presenca
    {
        [Key]
        public Guid IdPresenca { get; set; }

        public string? comentário { get; set; }
        [Column(TypeName = "VARCHAR(120)")]
        [Required(ErrorMessage = "O feedback do evento é obrigatório!")]

        //Falta o exibe
        public bool Exibe { get; set; }
        [Column(TypeName = "Bit")]
        [Required(ErrorMessage = "O feedback do evento é obrigatório!")]

        [ForeignKey("IdUsuario")]
        public Evento? evento { get; set; }

        [ForeignKey("IdEvento")]
        public Instituicao? Local { get; set; }

    }
}