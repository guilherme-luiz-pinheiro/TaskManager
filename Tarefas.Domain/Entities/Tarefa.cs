using System;
using TaskManager.Domain.Validation;

namespace TaskManager.Domain.Entities
{
    public sealed class Tarefa
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public DateTime? DueDate { get; private set; }
        public TarefaStatus Status { get; private set; }

        // Construtor com ID fornecido
        public Tarefa(Guid id, string title, string? description, DateTime? dueDate, TarefaStatus status)
        {
            ValidateDomainId(id);
            Id = id;
            ValidateDomain(title, description, dueDate, status);
        }

        // Construtor com ID gerado automaticamente
        public Tarefa(string title, string? description, DateTime? dueDate, TarefaStatus status)
        {
            Id = Guid.NewGuid();
            ValidateDomain(title, description, dueDate, status);
        }

        private void ValidateDomain(string title, string? description, DateTime? dueDate, TarefaStatus status)
        {
            ValidateDomainTitle(title);
            ValidateDomainDescription(description);
            ValidateDomainDueDate(dueDate);
            ValidateDomainStatus(status);

            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = status;
        }

        private void ValidateDomainId(Guid id)
        {
            DomainExceptionValidation.When(id == Guid.Empty, "Invalid ID: GUID cannot be empty.");
        }

        private void ValidateDomainTitle(string title)
        {
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(title), "Title is required.");
        }

        private void ValidateDomainDescription(string? description)
        {
            if (!string.IsNullOrEmpty(description))
            {
                DomainExceptionValidation.When(description.Length > 500, "Description too long (max 500 characters).");
            }
        }

        private void ValidateDomainDueDate(DateTime? dueDate)
        {
            if (dueDate.HasValue)
            {
                DomainExceptionValidation.When(dueDate.Value < DateTime.Today, "Due date cannot be in the past.");
            }
        }

        private void ValidateDomainStatus(TarefaStatus status)
        {
            bool isValidStatus = Enum.IsDefined(typeof(TarefaStatus), status);
            DomainExceptionValidation.When(!isValidStatus, "Invalid task status.");
        }

        public void Update(string title, string? description, DateTime? dueDate, TarefaStatus status)
        {
            ValidateDomain(title, description, dueDate, status);

            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = status;
        }
    }
}
