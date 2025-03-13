using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectE__SENAI.Domains
{
    [Table("TiposEventos")]
    public class TiposEventos
    {
        [Key]
        public Guid IdTiposEventos { get; set; }
        public string? TituloTiposEventos { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        [Required(ErrorMessage = "O tipo do evento é obrigatório!")]
        public object Descricao { get; internal set; }
        [Column(TypeName = "VARCHAR(30)")]
        [Required(ErrorMessage = "O tipo do evento é obrigatório!")]
    }
}
