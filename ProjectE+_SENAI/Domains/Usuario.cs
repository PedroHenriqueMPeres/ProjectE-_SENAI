using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ProjectE__SENAI.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "O email é obrigatório!")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        [Required(ErrorMessage = "A senha é obrigatória!")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "A senha deve ter no mínimo 5 caracteres e no máximo 30")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "O tipo do usuario e obrigatorio")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey("TiposUsuarios")]

        public TiposUsuarios? TipoUsuario { get; set; }
    }
}

