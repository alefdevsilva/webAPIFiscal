using System.IO.Compression;
using System.Text.Json.Serialization;
using APIOmni.Repositories;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Options;
using Serilog;
using WebApiFiscal.Configurations;
using WebApiFiscal.Data.Context;
using WebApiFiscal.Data.Repositorio;
using WebApiFiscal.Dominio.Contracts.Repositorios;
using WebApiFiscal.Service.Contracts;
using WebApiFiscal.Service.Services;

using Webbsys.Framework.MultiTenancy.Filters;
using Webbsys.Framework.MultiTenancy.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

builder.Services.AddApplicationInsightsTelemetry();

builder.Services.AddSerilog(builder.Configuration);

builder.Services.AddControllers()
    .AddMvcOptions(setupAction =>
    {
        // Filtro para configuração do Tenant da requisição.
        setupAction.Filters.Add(typeof(TenantConfigurationFilter));
        setupAction.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.Converters.Add(new ConversorDeDatasJson("dd/MM/yyyy"));
    });

builder.Services.Configure<GzipCompressionProviderOptions>(options =>
    options.Level = CompressionLevel.Optimal);

builder.Services.AddResponseCompression();

builder.Services.AddHealthChecks();

RegisterServices(builder.Services, builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapHealthChecks("/hc");

app.MapControllers();

app.Run();

static void RegisterServices(IServiceCollection services, IConfiguration configuration)
{
    // TenantOptions.
    services.Configure<TenantOptions>(configuration);
    services.AddScoped(serviceType => serviceType.GetService<IOptionsSnapshot<TenantOptions>>()?.Value);

    // Databases.
    services.AddScoped<EcommerceContext>();

    // Repositories.
    services.AddScoped<IFiscalRepositorio, FiscalRepositorio>();
    services.AddScoped<IEmpresaRepositorio, RepositoryEmpresa>();
    services.AddScoped<ITblICMSRepositorio, RepositoryTblICMSUF>();
    services.AddScoped<IProdutoRepositorio, RepositoryRCT>();
    services.AddScoped<IIVALojaRepositorio, RepositoryIvaLojaX>();
    services.AddScoped<IFiscalCFOPRepositorio, RepositoryViewFiscalCFOP>();
    services.AddScoped<IFiscalNCM, RepositoryFiscalncmMonofasico>();
    services.AddScoped<IVwUFFCPPadraoRepositorio, RepositoryVwUFFCPPadrao>();
    //IFiscalNCM


    // Services.
    services.AddScoped<IFiscalService, FiscalService>();
}
