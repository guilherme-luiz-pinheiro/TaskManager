using FluentAssertions;
using System;
using TaskManager.Domain.Entities;
using TaskManager.Domain.Validation;
using Xunit;

namespace TaskManager.Domain.Tests
{
    public class TarefaUnitTest1
    {
        [Fact]
        public void CreateTarefa_WithValidParameters_ShouldCreateSuccessfully()
        {
            // Arrange
            var title = "Estudar para prova";
            var description = "Estudar os capítulos 4 a 7";
            var dueDate = DateTime.Today.AddDays(3);
            var status = TarefaStatus.Pendente;

            // Act
            Action action = () => new Tarefa(title, description, dueDate, status);

            // Assert
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateTarefa_WithEmptyTitle_ShouldThrowDomainException()
        {
            // Arrange
            var title = "";
            var description = "Descrição válida";
            var dueDate = DateTime.Today.AddDays(3);
            var status = TarefaStatus.EmProgresso;

            // Act
            Action action = () => new Tarefa(title, description, dueDate, status);

            // Assert
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Title is required.");
        }

        [Fact]
        public void CreateTarefa_WithPastDueDate_ShouldThrowDomainException()
        {
            // Arrange
            var title = "Tarefa com data passada";
            var description = "Descrição qualquer";
            var dueDate = DateTime.Today.AddDays(-1);
            var status = TarefaStatus.Pendente;

            // Act
            Action action = () => new Tarefa(title, description, dueDate, status);

            // Assert
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Due date cannot be in the past.");
        }

        [Fact]
        public void CreateTarefa_WithLongDescription_ShouldThrowDomainException()
        {
            // Arrange
            var title = "Título válido";
            var longDescription = new string('a', 501);
            var dueDate = DateTime.Today.AddDays(1);
            var status = TarefaStatus.Pendente;

            // Act
            Action action = () => new Tarefa(title, longDescription, dueDate, status);

            // Assert
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Description too long (max 500 characters).");
        }

        [Fact]
        public void CreateTarefa_WithEmptyGuid_ShouldThrowDomainException()
        {
            // Arrange
            var id = Guid.Empty;
            var title = "Título válido";
            var description = "Descrição válida";
            var dueDate = DateTime.Today.AddDays(1);
            var status = TarefaStatus.Pendente;

            // Act
            Action action = () => new Tarefa(id, title, description, dueDate, status);

            // Assert
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid ID: GUID cannot be empty.");
        }
    }
}
