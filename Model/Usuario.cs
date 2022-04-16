namespace crud.usuario.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<Tarefa> tarefas { get; set; }

    }
}