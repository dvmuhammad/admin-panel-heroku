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
                                                      "Server=ec2-44-207-253-50.compute-1.amazonaws.com;Port=5432;Userid=pnjelfrrvyopaa;Password=2767213fcefaa69499fe846df7535ef5421431e678d449a8165e80b45a9f31ac;Database=d8c75prrfnedph"));
        return services;
    }
}