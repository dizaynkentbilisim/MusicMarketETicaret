using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MusicMarketETicaret.DataAccess.IMainRepository
{
    public interface IRepository<T> where T : class
    {

        // id göre getir
        T Get(int id);

        // verileri getir çoklu
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null);

        //ilk veri getir
        T GetFirsOrDefault(Expression<Func<T, bool>> filter = null,
            string includeProperties = null);

        //veri silme-ekleme
        void Add(T entity);
        void Remove(int id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
