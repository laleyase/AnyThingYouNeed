using AnyThingYouNeed.DataAccess.Abstract;
using AnyThingYouNeed.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnyThingYouNeed.DataAccess.Concrate
{
    public class RequestDal : IRequestDal
    {
        public Request Add(Request entity)
        {
            using (AnyThingYouNeedContext context = new AnyThingYouNeedContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return entity;
            }
        }

        public void Delete(Request entity)
        {
            using (AnyThingYouNeedContext context = new AnyThingYouNeedContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();                      
            }
        }

        public Request Get(Expression<Func<Request, bool>> filter)
        {
            using(AnyThingYouNeedContext context = new AnyThingYouNeedContext())
            {
                return context.Set<Request>().SingleOrDefault(filter);
            }
            
        }

        public List<Request> GetAll(Expression<Func<Request, bool>> filter = null)
        {
            using (AnyThingYouNeedContext context = new AnyThingYouNeedContext())
            {
                return filter == null
                ? context.Set<Request>().ToList()
                : context.Set<Request>().Where(filter).ToList();
            }
        }
        

        public Request Update(Request entity)
        {
            using (AnyThingYouNeedContext context = new AnyThingYouNeedContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }
    }
}
