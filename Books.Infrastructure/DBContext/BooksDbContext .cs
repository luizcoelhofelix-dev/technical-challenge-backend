using Books.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Books.Infrastructure.DBContext
{
    public  class BooksDbContext : DbContext
    {
        public BooksDbContext(
            DbContextOptions<BooksDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.HasKey(b => b.Id);

                entity.Property(b => b.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(b => b.Title)
                    .HasMaxLength(120)
                    .IsRequired();

                entity.Property(b => b.Price)
                    .HasPrecision(10, 2);

                entity.HasOne(b => b.Author)
                    .WithMany(a => a.Books)
                    .HasForeignKey(b => b.AuthorId);

                entity.HasOne(b => b.Genre)
                    .WithMany(g => g.Books)
                    .HasForeignKey(b => b.GenreId);
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.HasKey(a => a.Id);

                entity.Property(a => a.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(a => a.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(a => a.Country)
                    .HasMaxLength(70)
                    .IsRequired();
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genre");

                entity.HasKey(g => g.Id);

                entity.Property(g => g.Id)
                    .ValueGeneratedOnAdd();

                entity.Property(g => g.Name)
                    .HasMaxLength(100)
                    .IsRequired();
            });
        }
    }
}
