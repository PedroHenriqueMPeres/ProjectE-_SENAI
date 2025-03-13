using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectE__SENAI.Domains
{
    [Table("Feedback")]
    public class Feedback
    {
        [Key]
        public Guid IdFeedback { get; set; }

        [Column(TypeName = "VARCHAR(120)")]
        [Required(ErrorMessage = "O feedback do evento é obrigatório!")]
        public string? Comentario { get; set; }  

       
        [ForeignKey("IdEvento")]
        public Guid IdEvento { get; set; }  
        public Evento? Evento { get; set; }  

        
        [ForeignKey("IdUsuario")]
        public Guid IdUsuario { get; set; }  
        public Usuario? Usuario { get; set; }  

        
        [ForeignKey("IdInstituicao")]
        public Guid? IdInstituicao { get; set; }  
        public Instituicao? Local { get; set; }  
    }
}
