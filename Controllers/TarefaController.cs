using crud.usuario.Repositories.Tarefas;
using Microsoft.AspNetCore.Mvc;

namespace crud.usuario.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefasRepository _repository;

        public TarefaController(ITarefasRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var tarefas = await _repository.BuscaTarefas();
            return tarefas.Any()
            ? Ok(tarefas)
            : NoContent();
        }


    }
}