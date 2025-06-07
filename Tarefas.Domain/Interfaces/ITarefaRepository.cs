using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Domain.Entities;

namespace TaskManager.Domain.Interfaces
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> GetTarefasAsync();
        Task<Tarefa?> GetByIdAsync(Guid id);
        Task<IEnumerable<Tarefa>> GetByStatusAsync(TarefaStatus status);
        Task<IEnumerable<Tarefa>> GetByDueDateAsync(DateTime dueDate);
        Task<Tarefa> CreateAsync(Tarefa tarefa); 
        Task<Tarefa> UpdateAsync(Tarefa tarefa);
        Task<Tarefa> DeleteAsync(Tarefa tarefa);


    }
}
