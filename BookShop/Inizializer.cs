using Microsoft.AspNetCore.Cors.Infrastructure;
using NuGet.ContentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using BookShop.DataBaseLogic.Interfaces;
using BookShop.DataBaseLogic.Repositories;
using BookShop.Domain.Entities;
using BookShop.Services.Implementations;
using BookShop.Services.Interfaces;

namespace BookShop
{
    public static class Inizializer
    {
        public static void InitializeRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepository<User>, UserRepository>();

            services.AddScoped<IBaseRepository<Author>, AuthorRepository>();

            services.AddScoped<IBaseRepository<Book>, BookRepository>();

            services.AddScoped<IBaseRepository<Authorship>, AuthorshipRepository>();

            services.AddScoped<IBaseRepository<Operationship>, OperationshipRepository>();

            services.AddScoped<IBaseRepository<Operation>, OperationRepository>();
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();

            services.AddScoped<IBookService, BookService>();
        }
    }
}
