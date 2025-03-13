using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectE__SENAI.Domains
{
    [Table("TiposEventos")]
    public class TiposEventos
    {
        [Key]
        public Guid IdTiposEventos { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        [Required(ErrorMessage = "O tipo do evento é obrigatório!")]
        public string? TituloTiposEventos { get; set; }
    }
}
