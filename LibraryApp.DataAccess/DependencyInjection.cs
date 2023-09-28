using System.Reflection;
using LibraryApp.DataAccess.Common.Abstract;
using LibraryApp.DataAccess.Common.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApp.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddTransient<ApplicationContext>();
        services.AddTransient<IApplicationContext, ApplicationContext>();

        return services;
    }
}