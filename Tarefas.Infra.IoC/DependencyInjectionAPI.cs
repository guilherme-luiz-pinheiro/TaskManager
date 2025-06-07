using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Application.Interfaces;
using TaskManager.Application.Mappings;
using TaskManager.Application.Services;
using TaskManager.Domain.Interfaces;
using TaskManager.Infra.Data.Context;
using TaskManager.Infra.Data.Repositories;

namespace TaskManager.Infra.IoC
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
    IConfiguration configuration)
        {
            // Configuração do EF Core com InMemory
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("TaskManagerInMemoryDb"));

            // Registro de repositórios
            services.AddScoped<ITarefaRepository, TarefaRepository>();

            // Registro de serviços de aplicação
            services.AddScoped<ITarefaService, TarefaService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }

    }
}
