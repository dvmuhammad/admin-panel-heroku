using AdminPanel.DataBase;
using Microsoft.EntityFrameworkCore;
namespace AdminPanel.Extensions;

public static class DatabaseExtensions
{
    public static IServiceCollection AddDataLite(this IServiceCollection services,
        IConfiguration configuration)
    {
        var environmentConnectionString = Environment.GetEnvironmentVariable("connectionString");
        services.AddDbContext<DataContext>(options =>
            options.UseNpgsql(environmentConnectionString ??
                                                      "Server=dpg-ccslhoun6mptlbr1uv90-a.oregon-postgres.render.com;Port=5432;Userid=iftikhor;Password=imqmgXl1k8EhcuZwpvzcmnXbpfjXEdkR;Database=dbnimbus"));
        return services;
    }
}