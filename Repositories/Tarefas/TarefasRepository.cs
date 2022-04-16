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
            _context.Update(tarefa);
        }

        public async Task<Tarefa> BuscaTarefa(int id)
        {
            return await _context
                        .Tarefas
                        .Where(x => x.IdTarefa == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Tarefa>> BuscaTarefas()
        {
            return await _context.Tarefas.ToListAsync();
        }

        public void DeletaTarefa(Tarefa tarefa)
        {
            _context.Remove(tarefa);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}