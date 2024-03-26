using AnyThingYouNeed.Entities.Concrate;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Request = AnyThingYouNeed.Entities.Concrate.Request;

namespace AnyThingYouNeed.DataAccess.Concrate
{
    public class AnyThingYouNeedContext:DbContext
    {   


        public AnyThingYouNeedContext() 
        {
            
         Database.SetInitializer<AnyThingYouNeedContext>(null);
            
        }
        public DbSet<Request> Requests { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
