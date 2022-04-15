using crud.usuario.Database;
using crud.usuario.Model;
using Microsoft.EntityFrameworkCore;

namespace crud.usuario.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly UsuarioContext _context;

        public UsuarioRepository(UsuarioContext context)
        {
            _context = context;
        }

        public void AdicionaUsuario(Usuario usuario)
        {
            _context.Add(usuario);
        }

        public void AtualizaUsuario(Usuario usuario)
        {
            _context.Update(usuario);
        }
        public async Task<IEnumerable<Usuario>> BuscaUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }
        public async Task<Usuario> BuscaUsuario(int id)
        {
            return await _context
                        .Usuarios
                         .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public void DeletaUsuario(Usuario usuario)
        {
            _context.Remove(usuario);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}