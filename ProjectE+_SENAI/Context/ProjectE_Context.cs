using ProjectE__SENAI.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;


namespace ProjectE__SENAI.Context
{
    public class ProjectE_Context : DbContext
    {

        public  ProjectE_Context(){  }
        public ProjectE_Context(DbContextOptions<ProjectE_Context> options) : base(options)
        {  } 


        // define que as classes se transformarao em tabelas no BD

        public DbSet<Evento> Evento { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Instituicao> Instituição { get; set; }
        public DbSet<Presenca> Presença { get; set; }
        public DbSet<TiposEventos> TipoEvento { get; set; }
        public DbSet<TiposUsuarios> TiposUsuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = NOTE46-S28; DataBase = ProjectE_; User = sa; Pwd = Senai@134; TrustServerCertificate=true;");
            }

        }
    }
}

