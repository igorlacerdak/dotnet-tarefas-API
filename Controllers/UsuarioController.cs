using crud.usuario.Model;
using crud.usuario.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace crud.usuario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _repository.BuscaUsuarios();
            return usuarios.Any()
            ? Ok(usuarios)
            : NoContent();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            var usuario = await _repository.BuscaUsuario(id);
            return usuario != null
            ? Ok(usuario)
            : NotFound("Usuário não encontrado!");
        }



        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {

            _repository.AdicionaUsuario(usuario);
            return await _repository.SaveChangesAsync()
            ? Ok("Usuário adicionado com sucesso!")
            : BadRequest("Erro ao inserir usuário");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuario usuario)
        {
            var AtualizaUsuario = await _repository.BuscaUsuario(id);

            if (AtualizaUsuario == null) return NotFound("Usuário não encontrado!");

            AtualizaUsuario.Nome = usuario.Nome ?? AtualizaUsuario.Nome;
            AtualizaUsuario.DataNascimento = usuario.DataNascimento != new DateTime()
                                            ? usuario.DataNascimento
                                            : AtualizaUsuario.DataNascimento;

            _repository.AtualizaUsuario(AtualizaUsuario);

            return await _repository.SaveChangesAsync()
            ? Ok("Usuário atualizado com sucesso!")
            : BadRequest("Erro ao atualizar usuário");

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var DeletaUsuario = await _repository.BuscaUsuario(id);
            if (DeletaUsuario == null) return NotFound("Usuário não encontrado!");

            _repository.DeletaUsuario(DeletaUsuario);

            return await _repository.SaveChangesAsync()
            ? Ok("Usuário deletado com sucesso!")
            : BadRequest("Erro ao deletar usuário");

        }

    }
}