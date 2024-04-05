using AnyThingYouNeed.Bussiness.Concrate.RequestModel;
using AnyThingYouNeed.Bussiness.Concrate.ResultModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyThingYouNeed.Bussiness.Abstract
{
    public interface IUserService
    {
        LoginResultModel Login(LoginRequestModel loginRequest);
        
    }
}
