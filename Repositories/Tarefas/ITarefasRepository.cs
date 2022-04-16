using crud.usuario.Model;

namespace crud.usuario.Repositories.Tarefas
{
    public interface ITarefasRepository
    {
        Task<IEnumerable<Tarefa>> BuscaTarefas();
        Task<Tarefa> BuscaTarefa(int id);
        void AdicionaTarefa(Tarefa tarefa);
        void AtualizaTarefa(Tarefa tarefa);
        void DeletaTarefa(Tarefa tarefa);

        Task<bool> SaveChangesAsync();
    }
}