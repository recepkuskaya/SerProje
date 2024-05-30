using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace SerProje.Repository
{
    public interface IGenericRepository<T> where T:class
    {
        T GetById(int EntityId);
        IEnumerable<T> Select(Expression<Func<T, bool>> Filter = null);
        void Insert(T Entity);
        void Update(T Entity);
        //void Delete(object EntityId);
        void Delete(T Entity);

        //void GetAll(T Entity);
        IEnumerable<T> GetAll();
        List<T> GetAllList();

    }
}
