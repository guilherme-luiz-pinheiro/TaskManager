using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Interfaces;

namespace TaskManager.Application.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IMapper _mapper;

        public TarefaService(ITarefaRepository tarefaRepository, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TarefaDTO>> GetTarefasAsync()
        {
            var tarefasEntity = await _tarefaRepository.GetTarefasAsync();
            return _mapper.Map<IEnumerable<TarefaDTO>>(tarefasEntity);
        }

        public async Task<TarefaDTO?> GetByIdAsync(Guid id)
        {
            var tarefaEntity = await _tarefaRepository.GetByIdAsync(id);
            return _mapper.Map<TarefaDTO?>(tarefaEntity);
        }

        public async Task<IEnumerable<TarefaDTO>> GetByStatusAsync(TarefaStatus status)
        {
            var tarefasEntity = await _tarefaRepository.GetByStatusAsync(status);
            return _mapper.Map<IEnumerable<TarefaDTO>>(tarefasEntity);
        }

        public async Task<IEnumerable<TarefaDTO>> GetByDueDateAsync(DateTime dueDate)
        {
            var tarefasEntity = await _tarefaRepository.GetByDueDateAsync(dueDate);
            return _mapper.Map<IEnumerable<TarefaDTO>>(tarefasEntity);
        }

        public async Task<TarefaDTO> CreateAsync(TarefaDTO tarefaDto)
        {
            var tarefaEntity = _mapper.Map<Tarefa>(tarefaDto);
            var createdEntity = await _tarefaRepository.CreateAsync(tarefaEntity);
            return _mapper.Map<TarefaDTO>(createdEntity);
        }

        public async Task<TarefaDTO> UpdateAsync(TarefaDTO tarefaDto)
        {
            var tarefaEntity = _mapper.Map<Tarefa>(tarefaDto);
            var updatedEntity = await _tarefaRepository.UpdateAsync(tarefaEntity);
            return _mapper.Map<TarefaDTO>(updatedEntity);
        }

        public async Task<TarefaDTO> DeleteAsync(Guid id)
        {
            var tarefaEntity = await _tarefaRepository.GetByIdAsync(id);
            if (tarefaEntity == null)
                return null;

            var deletedEntity = await _tarefaRepository.DeleteAsync(tarefaEntity);
            return _mapper.Map<TarefaDTO>(deletedEntity);
        }
    }
}
