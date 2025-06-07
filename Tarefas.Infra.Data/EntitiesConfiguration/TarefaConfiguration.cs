using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.Domain.Entities;

namespace TaskManager.Infra.Data.EntitiesConfiguration
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Description)
                .HasMaxLength(500); // opcional, mas com limite

            builder.Property(t => t.DueDate)
                .HasColumnType("datetime");

            builder.Property(t => t.Status)
                .IsRequired()
                .HasConversion<int>(); // armazena como int no banco

            builder.ToTable("Tarefas"); // nome da tabela
        }
    }
}
