using System;
using System.ComponentModel.DataAnnotations;
using TaskManager.Domain.Entities;

namespace TaskManager.Application.DTOs
{
    public class TarefaDTO
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório.")]
        [MinLength(3, ErrorMessage = "O título deve ter no mínimo 3 caracteres.")]
        [MaxLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres.")]
        public string? Title { get; set; }

        [MaxLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        [Required(ErrorMessage = "O status é obrigatório.")]
        public TarefaStatus Status { get; set; }
    }
}
