using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyThingYouNeed.Bussiness.Concrate.Security
{
    public class TokenPayload
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public DateTime ValidityDatetime { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public bool Success { get; set; }
    }
}
