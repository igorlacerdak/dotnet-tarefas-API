using crud.usuario.Database;
using crud.usuario.Model;
using Microsoft.EntityFrameworkCore;


namespace crud.usuario.Repositories.Tarefas
{
    public class TarefasRepository : ITarefasRepository
    {

        private readonly TarefaContext _context;

        public TarefasRepository(TarefaContext context)
        {
            _context = context;
        }
        public void AdicionaTarefa(Tarefa tarefa)
        {
            _context.Add(tarefa);
        }

        public void AtualizaTarefa(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

        public async Task<Tarefa> BuscaTarefa(int id)
        {
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<Tarefa>> BuscaTarefas()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public void DeletaTarefa(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}