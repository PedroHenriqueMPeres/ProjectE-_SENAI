using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace ProjectE__SENAI.Domains
{
    [Table("TiposUsuarios")]
    public class TiposUsuarios
    {
        [Key]
        public Guid IdTiposUsuarios { get; set; }

         
        [Column(TypeName = "Varchar(100)")]
        [Required(ErrorMessage = "O Tipo do usuario é obrigatório!")]
        public string? TituloTiposUsuarios { get; set; }
        
        
    }
}
