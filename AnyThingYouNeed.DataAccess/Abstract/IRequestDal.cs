using AnyThingYouNeed.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnyThingYouNeed.DataAccess.Abstract
{
    public interface IRequestDal
    {
        List<Request> GetAll(Expression<Func<Request, bool>> filter = null);
        Request Get(Expression<Func<Request, bool>> filter);
        Request Add(Request entity);
        Request Update(Request entity);
        void Delete(Request entity);
    }
}
