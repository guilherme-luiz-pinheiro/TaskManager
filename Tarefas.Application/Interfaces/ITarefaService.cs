using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Application.DTOs;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces
{
    public interface ITarefaService
    {
        Task<IEnumerable<TarefaDTO>> GetTarefasAsync();
        Task<TarefaDTO?> GetByIdAsync(Guid id);
        Task<IEnumerable<TarefaDTO>> GetByStatusAsync(TarefaStatus status);
        Task<IEnumerable<TarefaDTO>> GetByDueDateAsync(DateTime dueDate);
        Task<TarefaDTO> CreateAsync(TarefaDTO tarefaDto);
        Task<TarefaDTO> UpdateAsync(TarefaDTO tarefaDto);
        Task<TarefaDTO> DeleteAsync(Guid id);
    }
}
