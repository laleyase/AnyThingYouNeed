using AnyThingYouNeed.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyThingYouNeed.Bussiness.Concrate.Security
{
    public class Token:User 
    {
        public string JWT { get; set; }
        public DateTime ValidityDatetime { get; set; }
        public int ValidMinute { get; set; }
    }
}
