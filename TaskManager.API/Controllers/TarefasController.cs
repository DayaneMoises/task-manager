using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Data.Repositories;
using TaskManager.API.Models;
using TaskManager.API.Models.InputModels;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private ITarefasRepository _tarefasRepository;
        //não entendi!
        public TarefasController(ITarefasRepository tarefasRepository)
        {
            _tarefasRepository = tarefasRepository;
        }


        // GET: api/tarefas>
        [HttpGet]
        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/
        public IActionResult Get()
        {
            var tarefas = _tarefasRepository.Buscar();
            return Ok(tarefas);
        }

        // GET api/tarefas/{id}
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {

            var tarefa = _tarefasRepository.Buscar(id);

            if (tarefa == null)
                return NotFound();

            return Ok(tarefa);
        }

        // POST api/tarefas
        [HttpPost]
        public IActionResult Post([FromBody] TarefaInputModel novaTarefa)
        {
            var tarefa = new Tarefa(novaTarefa.Nome, novaTarefa.Detalhes);

            _tarefasRepository.Adicionar(tarefa);
            //return Created();
            return Created("", tarefa);
        }

        // PUT api/tarefas/{id}
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] TarefaInputModel tarefaAtualizada)
        {
            var tarefaExistente = _tarefasRepository.Buscar(id);

            if (tarefaExistente == null)
                return NotFound();

            tarefaExistente.AtualizarTarefa(tarefaAtualizada.Nome, tarefaAtualizada.Detalhes, tarefaAtualizada.Concluido);

            _tarefasRepository.Atualizar(id, tarefaExistente);

            return Ok(tarefaExistente);
        }

        // DELETE api/tarefas/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var tarefa = _tarefasRepository.Buscar();
            if (tarefa == null)
                return NotFound();
            _tarefasRepository.Remover(id);

            return NoContent();

        }
    }
}
