using AnyThingYouNeed.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyThingYouNeed.Entities.Concrate
{
    public class User:IEntity
    {
        public int UserID { get; set; }
        public string UserName  { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
        public string PHoneNumber { get; set; }
    }

   
}
