

using Ejercicio4Modulo3.Repository;
using Ejercicio4Modulo3.Service.interfaces;
using Microsoft.EntityFrameworkCore;

public static class Dependency
{
  public static void AddDependencyCustom(this IServiceCollection services, ConfigurationManager builder)
    {
        services.AddDbContext<Ejercicio4Modulo3Context>
            (options => options.UseSqlServer(builder.GetConnectionString("DefaulConnection")));

        services.AddScoped<IProveedorService, ProveedorService>();
        services.AddScoped<ILogsService, LogsService>();
        services.AddScoped<GlobalExceptionHandler>();

       
    }
}