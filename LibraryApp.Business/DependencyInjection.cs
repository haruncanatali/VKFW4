using LibraryApp.Business.Abstract;
using LibraryApp.Business.Concrete;
using LibraryApp.Business.Validations;
using LibraryApp.DataAccess;
using LibraryApp.DataAccess.Abstract;
using LibraryApp.DataAccess.Common.Concrete;
using LibraryApp.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryApp.Business;

public static class DependencyInjection
{
    public static IServiceCollection AddBusiness(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SQLServer_Dev")));

        services.AddOptions();
        services.AddDataAccess();

        services.AddTransient<IAuthorService, AuthorManager>();
        services.AddTransient<IAuthorDal, AuthorDal>();
        
        services.AddTransient<IBookService, BookManager>();
        services.AddTransient<IBookDal, BookDal>();
        
        services.AddTransient<IGenreService, GenreManager>();
        services.AddTransient<IGenreDal, GenreDal>();

        services.AddTransient<AuthorValidator>();
        services.AddTransient<BookValidator>();
        services.AddTransient<GenreValidator>();

        return services;
    }
}