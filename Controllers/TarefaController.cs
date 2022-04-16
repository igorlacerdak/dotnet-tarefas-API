using crud.usuario.Model;
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
        public async Task<IActionResult> GetAllTarefas()
        {
            var tarefas = await _repository.BuscaTarefas();
            return tarefas.Any()
            ? Ok(tarefas)
            : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTarefasById(int id)
        {
            var tarefas = await _repository.BuscaTarefa(id);
            return tarefas != null
            ? Ok(tarefas)
            : NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> Post(Tarefa tarefas)
        {

            if (!ModelState.IsValid) return BadRequest();

            _repository.AdicionaTarefa(tarefas);
            return await _repository.SaveChangesAsync()
            ? Ok("Tarefa adicionado com sucesso!")
            : BadRequest("Erro ao inserir usuário");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Tarefa tarefas)
        {
            var AtualizaTarefa = await _repository.BuscaTarefa(id);

            if (AtualizaTarefa == null) return NotFound("Usuário não encontrado!");

            AtualizaTarefa.Titulo = tarefas.Titulo ?? AtualizaTarefa.Titulo;
            AtualizaTarefa.Descricao = tarefas.Descricao ?? AtualizaTarefa.Descricao;

            AtualizaTarefa.Done = tarefas.Done != false ? AtualizaTarefa.Done = true : AtualizaTarefa.Done = false;

            AtualizaTarefa.DataFinalizacao = tarefas.DataFinalizacao != new DateTime()
                                            ? tarefas.DataFinalizacao
                                            : AtualizaTarefa.DataFinalizacao;

            _repository.AtualizaTarefa(AtualizaTarefa);

            return await _repository.SaveChangesAsync()
            ? Ok("Tarefa atualizado com sucesso!")
            : BadRequest("Erro ao atualizar a tarefa");

        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var DeletaTarefa = await _repository.BuscaTarefa(id);
            if (DeletaTarefa == null) return NotFound("Usuário não encontrado!");

            _repository.DeletaTarefa(DeletaTarefa);

            return await _repository.SaveChangesAsync()
            ? Ok("Tarefa deletado com sucesso!")
            : BadRequest("Erro ao deletar a tarefa");

        }


    }
}