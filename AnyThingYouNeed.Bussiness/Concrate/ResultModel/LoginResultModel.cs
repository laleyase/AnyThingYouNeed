using AnyThingYouNeed.Bussiness.Concrate.Security;
using AnyThingYouNeed.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyThingYouNeed.Bussiness.Concrate.ResultModel
{
    public class LoginResultModel:ResultModelClas
    {

            public Token Token { get; set; }
            public User User { get; set; }


        
    }
}
