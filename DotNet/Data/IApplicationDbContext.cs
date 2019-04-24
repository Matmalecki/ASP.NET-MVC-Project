using DotNet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNet.Data
{
    public interface IApplicationDbContext
    {
        IQueryable<Author> Authors { get; }
        IQueryable<Book> Books { get; }

        void Add<T>(T entity) where T : class;
        Author FindAuthorById(int ID);
        Book FindBookById(int ID);
        void Delete<T>(T entity) where T : class;
        Task<int> SaveChanges();
        void Update<T>(T entity) where T : class;
    }
}
