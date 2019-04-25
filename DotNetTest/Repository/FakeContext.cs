using DotNet.Data;
using DotNet.Models;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTest.Repository
{
    public class FakeContext : IApplicationDbContext
    {
        private readonly SetMap _map = new SetMap();

        public IQueryable<Book> Books
        {
            get { return _map.Get<Book>().AsQueryable(); }
            set { _map.Use<Book>(value); }
        }
        public IQueryable<Author> Authors
        {
            get { return _map.Get<Author>().AsQueryable(); }
            set { _map.Use<Author>(value); }
        }

        public bool ChangesSaved { get; set; }

        public void Add<T>(T entity) where T : class
        {
            _map.Get<T>().Add(entity);

        }

        public Book FindBookById(int id)
        {
            try
            {
                var item = (from c in Books
                            where c.ID == id
                            select c).First();
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public Author FindAuthorById(int id)
        {
            try
            {
                var item = (from c in Authors
                            where c.ID == id
                            select c).First();
                return item;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public void Delete<T>(T entity) where T : class
        {
            _map.Get<T>().Remove(entity);
        }

        Task<int> IApplicationDbContext.SaveChanges()
        {
            ChangesSaved = true;
            return Task.FromResult<int>(0);
        }

        public void Update<T>(T entity) where T : class
        {
            _map.Get<T>().Remove(entity);
            _map.Get<T>().Add(entity);
        }
    }

    class SetMap : KeyedCollection<Type, object>
    {

        public HashSet<T> Use<T>(IEnumerable<T> sourceData)
        {
            var set = new HashSet<T>(sourceData);
            if (Contains(typeof(T)))
            {
                Remove(typeof(T));
            }
            Add(set);
            return set;
        }

        public HashSet<T> Get<T>()
        {
            return (HashSet<T>)this[typeof(T)];
        }

        protected override Type GetKeyForItem(object item)
        {
            return item.GetType().GetGenericArguments().Single();
        }
    }
}
