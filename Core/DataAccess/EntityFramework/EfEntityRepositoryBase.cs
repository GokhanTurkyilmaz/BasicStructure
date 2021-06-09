using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity:class,IEntity, new()
        where TContext:DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext dBContext = new TContext())
            {
                var addedEmployee = dBContext.Entry(entity);
                addedEmployee.State = EntityState.Added;
                dBContext.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext dBContext = new TContext())
            {
                var deletedEmployee = dBContext.Entry(entity);
                deletedEmployee.State = EntityState.Deleted;
                dBContext.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext dBContext = new TContext())
            {
                return dBContext.Set<TEntity>().SingleOrDefault(filter);
            }

        }

        public List<TEntity> GetAll()
        {
            using (TContext dBContext = new TContext())
            {
                return dBContext.Set<TEntity>().ToList();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext dBContext = new TContext())
            {
                return filter == null ? dBContext.Set<TEntity>().ToList() : dBContext.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext dBContext = new TContext())
            {
                var updatedEmployee = dBContext.Entry(entity);
                updatedEmployee.State = EntityState.Modified;
                dBContext.SaveChanges();
            }
        }
    }
}
