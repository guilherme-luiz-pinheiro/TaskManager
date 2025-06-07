using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;
using TaskManager.Infra.Data.Context;

namespace TaskManager.Infra.Data.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly ApplicationDbContext _tarefaContext;

        public TarefaRepository(ApplicationDbContext context)
        {
            _tarefaContext = context;
        }

        public async Task<Tarefa> CreateAsync(Tarefa tarefa)
        {
            _tarefaContext.Tarefas.Add(tarefa);
            await _tarefaContext.SaveChangesAsync();
            return tarefa;
        }

        public async Task<Tarefa?> GetByIdAsync(Guid id)
        {
            return await _tarefaContext.Tarefas.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<Tarefa>> GetTarefasAsync()
        {
            return await _tarefaContext.Tarefas.ToListAsync();
        }

        public async Task<IEnumerable<Tarefa>> GetByStatusAsync(TarefaStatus status)
        {
            return await _tarefaContext.Tarefas
                .Where(t => t.Status == status)
                .ToListAsync();
        }

        public async Task<IEnumerable<Tarefa>> GetByDueDateAsync(DateTime dueDate)
        {
            return await _tarefaContext.Tarefas
                .Where(t => t.DueDate.HasValue && t.DueDate.Value.Date == dueDate.Date)
                .ToListAsync();
        }

        public async Task<Tarefa> UpdateAsync(Tarefa tarefa)
        {
            _tarefaContext.Tarefas.Update(tarefa);
            await _tarefaContext.SaveChangesAsync();
            return tarefa;
        }

        public async Task<Tarefa> DeleteAsync(Tarefa tarefa)
        {
            _tarefaContext.Tarefas.Remove(tarefa);
            await _tarefaContext.SaveChangesAsync();
            return tarefa;
        }
    }
}
