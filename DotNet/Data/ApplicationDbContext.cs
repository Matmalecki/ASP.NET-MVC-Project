using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using DotNet.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet.Data
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        IQueryable<Author> IApplicationDbContext.Authors
        {
            get { return Author; }
        }
        IQueryable<Book> IApplicationDbContext.Books
        {
            get { return Book; }
        }

        public void Delete<T>(T entity) where T : class
        {
            Set<T>().Remove(entity);
        }

        public Author FindAuthorById(int ID)
        {
            return Author.Find(ID);
        }

        public Book FindBookById(int ID)
        {
            return Book.Find(ID);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<Author>().HasData(
                    new Author { ID = 1, FirstName = "Ernest", LastName = "Hemingway", DateOfBirth = new DateTime(1899,07,21), Email = null },
                    new Author { ID = 2, FirstName = "John", LastName = "Steinbeck", DateOfBirth = new DateTime(1902,02,27), Email = null },
                    new Author { ID = 3, FirstName = "Stephen", LastName = "King", DateOfBirth = new DateTime(1947,09,21), Email = "sking@mail.com" },
                    new Author { ID = 4, FirstName = "Albert", LastName = "Camus", DateOfBirth = new DateTime(1913,11,07), Email = null }
                );
            
            builder.Entity<Book>().HasData(
                    new Book { ID = 1, Title = "East of Eden", YearOfRelease = 1952, Isbn = "0-7832-3901-7", Genre = "Drama", AuthorID = 2 , Country="Usa"},
                    new Book { ID = 2, Title = "A Farewell To Arms", YearOfRelease = 1929, Isbn = "0-9631-9574-3", Genre = "Drama", AuthorID = 1, Country = "Usa" },
                    new Book { ID = 3, Title = "It", YearOfRelease = 1980, Isbn = "0-8400-7082-9", Genre = "Horror", AuthorID = 3, Country = "Usa" },
                    new Book { ID = 4, Title = "The Rebel", YearOfRelease = 1951, Isbn = "0-9101-3138-4", Genre = "Philosophy", AuthorID = 4, Country = "France" },
                    new Book { ID = 5, Title = "For Whom The Bell Tolls ", YearOfRelease = 1940, Isbn = "0-8886-5105-8", Genre = "Drama", AuthorID = 1, Country = "Usa" }
                );
                
        }

        void IApplicationDbContext.Add<T>(T entity)
        {
            Set<T>().Add(entity);
            
        }
        Task<int> IApplicationDbContext.SaveChanges()
        {
            return SaveChangesAsync();
        }

        void IApplicationDbContext.Update<T>(T entity)
        {
            Set<T>().Update(entity);
        }
    }
}
