namespace crud.usuario.Model
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int idTarefa { get; set; }
        public List<Tarefa> Tarefas { get; set; }

    }
}