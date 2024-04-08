using AnyThingYouNeed.DataAccess.Abstract;
using AnyThingYouNeed.Entities.Concrate;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AnyThingYouNeed.DataAccess.Concrate
{
    public class RequestDal : IRequestDal
    {
        private readonly AnyThingYouNeedContext _context;

        public RequestDal(AnyThingYouNeedContext context)
        {
            _context = context;
        }
        public Request Add(Request entity)
        {

            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
            return entity;

        }

        public void Delete(Request entity)
        {

            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();

        }

        public Request Get(Expression<Func<Request, bool>> filter)
        {

            return _context.Set<Request>().SingleOrDefault(filter);

        }

        public List<Request> GetAll(Expression<Func<Request, bool>> filter = null)
        {

            return filter == null
                ? _context.Set<Request>().ToList()
                : _context.Set<Request>().Where(filter).ToList();

        }

        public Request Update(Request entity)
        {

            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
            return entity;

        }
    }
}
