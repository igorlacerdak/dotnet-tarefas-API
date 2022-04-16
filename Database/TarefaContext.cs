using crud.usuario.Model;
using Microsoft.EntityFrameworkCore;

namespace crud.usuario.Database
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options)
        {

        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseNpgsql(connectionString: "User Id=postgres; Password=123456; Host=localhost; Port=5432; Database=dbUsuario");
        // }

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var tarefas = modelBuilder.Entity<Tarefa>();
            tarefas.ToTable("tb_tarefas");
            tarefas.HasKey(x => x.Id);
            tarefas.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            tarefas.Property(x => x.Titulo).HasColumnName("titulo").IsRequired();
            tarefas.Property(x => x.Descricao).HasColumnName("descricao");
            tarefas.Property(x => x.Done).HasColumnName("concluido");
            tarefas.Property(x => x.DataCriacao).HasColumnName("dtCriacao");
            tarefas.Property(x => x.DataFinalizacao).HasColumnName("dtFinalizacao");
        }

    }
}