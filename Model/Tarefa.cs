namespace crud.usuario.Model
{
    public class Tarefa

    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public bool Done { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataFinalizacao { get; set; }


    }
}