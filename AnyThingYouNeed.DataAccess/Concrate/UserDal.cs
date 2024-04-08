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
        private readonly AnyThingYouNeedContext _context;

        public UserDal(AnyThingYouNeedContext context)
        {
            _context = context;
        }
        public User Get(Expression<Func<User, bool>> filter)
        {

            return _context.Set<User>().SingleOrDefault(filter);

        }
    }
}
