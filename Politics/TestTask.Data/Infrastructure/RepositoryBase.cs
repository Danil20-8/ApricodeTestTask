using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Politics.Data.Infrastructure
{
    public class RepositoryBase<T> where T : class
    {
        PoliticsEntities dataContext;
        readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory { get; private set; }
        protected PoliticsEntities DbContext => dataContext ?? (dataContext = DbFactory.Init());

        public RepositoryBase(IDbFactory dbFactory)
        {
            this.DbFactory = dbFactory;
            this.dbSet = DbContext.Set<T>();
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            var objects = dbSet.Where(where).AsEnumerable();
            foreach (var obj in objects)
                dbSet.Remove(obj);
        }

        public virtual T GetByID(int id)
        {
            return dbSet.Find(id);
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }
    }
}
