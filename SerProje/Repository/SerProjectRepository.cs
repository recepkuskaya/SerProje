using SerProje.ContextSer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SerProje.Repository
{
    public class SerProjectRepository<T> : IGenericRepository<T> where T:class
    {
        private SerProjeDB serContext_;
        private DbSet<T> dbSet_;

        public SerProjectRepository(SerProjeDB serDbContext)
        {
            serContext_ = serDbContext;
            dbSet_ = serContext_.Set<T>();
        }

        public T GetById(int id)
        {
            return dbSet_.Find(id);
        }

        /*public IEnumerable<T> GetAll()
        {
            return dbSet_.ToList();
        }*/

        public List<T> GetAllList()
        {
            return dbSet_.ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet_.ToList();
        }

        public virtual IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null)
        {
            if (Filter != null)
            {
                return dbSet_.Where(Filter);
            }
            return dbSet_;
        }

        public void Insert(T entity)
        {
            dbSet_.Add(entity);
        }

        public void Update(T entity)
        {
            serContext_.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            
            dbSet_.Remove(entity);
        }


    }
}
