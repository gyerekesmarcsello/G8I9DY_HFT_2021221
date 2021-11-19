using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Logic
{
    public abstract class Logic<T> : ILogic<T> where T : class
    {
        protected DbContext context;
        public Logic(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }
        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }
        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }
        public abstract T GetOne(int id);
    }
}
