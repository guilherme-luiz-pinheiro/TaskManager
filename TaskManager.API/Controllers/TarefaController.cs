using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        // GET: api/Tarefa
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tarefas = await _tarefaService.GetTarefasAsync();
            return Ok(tarefas); // 200
        }

        // GET: api/Tarefa/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var tarefa = await _tarefaService.GetByIdAsync(id);
            if (tarefa == null)
                return NotFound(); // 404

            return Ok(tarefa); // 200
        }

        // POST: api/Tarefa
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TarefaDTO tarefaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // 400

            tarefaDto.Id = Guid.NewGuid();
            await _tarefaService.CreateAsync(tarefaDto);

            return CreatedAtAction(nameof(GetById), new { id = tarefaDto.Id }, tarefaDto); // 201
        }

        // PUT: api/Tarefa/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TarefaDTO tarefaDto)
        {
            if (id != tarefaDto.Id)
                return BadRequest("ID inválido."); // 400

            var tarefaExistente = await _tarefaService.GetByIdAsync(id);
            if (tarefaExistente == null)
                return NotFound(); // 404

            await _tarefaService.UpdateAsync(tarefaDto);
            return NoContent(); // 204
        }

        // DELETE: api/Tarefa/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var tarefa = await _tarefaService.GetByIdAsync(id);
            if (tarefa == null)
                return NotFound(); // 404

            await _tarefaService.DeleteAsync(id);
            return NoContent(); // 204
        }
    }
}
