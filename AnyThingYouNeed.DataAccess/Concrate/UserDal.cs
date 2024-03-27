using AnyThingYouNeed.DataAccess.Abstract;
using AnyThingYouNeed.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnyThingYouNeed.DataAccess.Concrate
{
    public class UserDal : IUserDal
    {
        public User Get(Expression<Func<User, bool>> filter)
        {
            using (AnyThingYouNeedContext context = new AnyThingYouNeedContext())
            {
                return context.Set<User>().SingleOrDefault(filter);
            }

        }
    }
}
