using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectE__SENAI.Domains
{
    [Table("Evento")]
    public class Evento
    {
        [Key]
        public Guid IdEvento { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O título do Evento é obrigatório!")]
        public string Titulo { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A data do Evento é obrigatória!")]
        public DateTime Data { get; set; }

        [Column(TypeName = "DATETIME")]
        [Required(ErrorMessage = "Data do Evento é obrigatória!")]
        public DateTime DataHora { get; set; } 

        
        [ForeignKey("IdTiposEventos")]
        public TiposEventos TiposEventos { get; set; }

        
        [ForeignKey("IdInstituicao")]
        public Instituicao Local { get; set; }

        
        [ForeignKey("IdPresenca")]
        public Presenca Presenca { get; set; }

        
        [ForeignKey("IdTiposEventos")]
        public Guid IdTiposEventos { get; set; } 

        
        [ForeignKey("IdInstituicao")]
        public Guid? IdInstituicao { get; set; } 

        
        [ForeignKey("IdPresenca")]
        public Guid? IdPresenca { get; set; } 
    }
}