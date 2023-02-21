using System;
using Backoffice.Data;
using Backoffice.Data.Repositories;
using Backoffice.Domain.Interfaces;
using Backoffice.Services;
using Backoffice.Services.Interfaces;
using Backoffice.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Backoffice.IoC.DependencyInjection;

public class Bindings
{
    public static void ConfigureDependencies(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped(typeof(IBaseServices<>), typeof(BaseServices<>));
        serviceCollection.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

        serviceCollection.AddScoped<IPessoaServices, PessoaServices>();
        serviceCollection.AddScoped<IQualificacaoServices, QualificacaoServices>();        
        serviceCollection.AddScoped<IEnderecoServices, EnderecoServices>();
        serviceCollection.AddScoped<IDepartamentoServices, DepartamentoServices>();
        serviceCollection.AddScoped<IExternalServices, ExternalServices.Services.ExternalServices>();

        serviceCollection.AddScoped<IPessoaQualificacaoServices, PessoaQualificacaoServices>();
        serviceCollection.AddScoped<IPessoaQualificacaoRepository, PessoaQualificacaoRepository>();
        serviceCollection.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
        serviceCollection.AddScoped<IPessoaRepository, PessoaRepository>();

        var connectionString = "Server=localhost; Database=Backoffice; User Id=userBackoffice; Password=!Backoffice@7;TrustServerCertificate=true;";
        serviceCollection.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));
    }
}

