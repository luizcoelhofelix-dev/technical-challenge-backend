using Books.Application.Author.Commands;
using Books.Application.Author.CommandsValidation;
using Books.Application.Author.DTOs;
using Books.Application.Author.Handlers;
using Books.Application.Author.Queries;
using Books.Application.Book.Commands;
using Books.Application.Book.CommandsValidation;
using Books.Application.Book.DTOs;
using Books.Application.Book.Handlers;
using Books.Application.Book.Queries;
using Books.Application.Genre.Commands;
using Books.Application.Genre.CommandsValidation;
using Books.Application.Genre.DTOs;
using Books.Application.Genre.Handlers;
using Books.Application.Genre.Queries;
using Books.Application.Mapping;
using Books.Domain.Interfaces;
using Books.Domain.Services;
using Books.Infrastructure;
using Books.Infrastructure.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Books.CrossCutting.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddCrossCutting(
            this IServiceCollection services)
        {
            // MediatR
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(
                    typeof(IMediator).Assembly));

            services.AddTransient<
                IRequestHandler<CreateAuthorCommand, AuthorDto>,
                CreateAuthorCommandHandler>();
            services.AddTransient<
                IRequestHandler<UpdateAuthorCommand, AuthorDto>,
                UpdateAuthorCommandHandler>();
            services.AddTransient<
                IRequestHandler<DeleteAuthorCommand, bool>,
                DeleteAuthorCommandHandler>();
            services.AddTransient<
                IRequestHandler<CreateBookCommand, BookDto>,
                CreateBookCommandHandler>();
            services.AddTransient<
                IRequestHandler<UpdateBookCommand, BookDto>,
                UpdateBookCommandHandler>();
            services.AddTransient<
                IRequestHandler<DeleteBookCommand, bool>,
                DeleteBookCommandHandler>();
            services.AddTransient<
                IRequestHandler<CreateGenreCommand, GenreDto>,
                CreateGenreCommandHandler>();
            services.AddTransient<
                IRequestHandler<UpdateGenreCommand, GenreDto>,
                UpdateGenreCommandHandler>();
            services.AddTransient<
                IRequestHandler<DeleteGenreCommand, bool>,
                DeleteGenreCommandHandler>();
            services.AddTransient<
                IRequestHandler<GenreComplexFilter, IEnumerable<GenreDto>>,
                GenreQueries>();
            services.AddTransient<
                IRequestHandler<BookComplexFilter, IEnumerable<BookDto>>,
                BookQueries>();
            services.AddTransient<
                IRequestHandler<AuthorComplexFilter, IEnumerable<AuthorDto>>,
                AuthorQueries>();

            services.AddTransient<ICreateBookCommandValidation, CreateBookCommandValidation>();
            services.AddTransient<IUpdateBookCommandValidation, UpdateBookCommandValidation>();
            services.AddTransient<ICreateGenreCommandValidation, CreateGenreCommandValidation>();
            services.AddTransient<IUpdateGenreCommandValidation, UpdateGenreCommandValidation>();
            services.AddTransient<ICreateAuthorCommandValidation, CreateAuthorCommandValidation>();
            services.AddTransient<IUpdateAuthorCommandValidation, UpdateAuthorCommandValidation>();

            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IAuthorService, AuthorService>();

            services.AddTransient<IUpdateAuthorCommandValidation, UpdateAuthorCommandValidation>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();

            return services;
        }

        public static IServiceCollection AddEntityFrameworkConfig(this IServiceCollection services, string connectionString) {

            //services.AddEntityFrameworkMySql()
            //   .AddDbContext<BooksDbContext>(options =>
            //   {
            //       options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 4, 0)), options => {
            //           options.CommandTimeout(1800);
            //           options.EnableRetryOnFailure(
            //                   maxRetryCount: 10,
            //                   maxRetryDelay: TimeSpan.FromSeconds(30),
            //                   errorNumbersToAdd: null);
            //       });                   
            //   },
            //       ServiceLifetime.Scoped  //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
            //   );

            



            //var connection = new MySqlConnection(connectionString);

            //try
            //{
            //    connection.Open();
            //    Console.WriteLine("Conexão MySQL OK!");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
            //}
            //finally
            //{
            //    connection.Dispose();
            //}


            return services;
        }
    }
}
