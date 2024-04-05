using AnyThingYouNeed.Bussiness.Concrate.ResultModel;
using AnyThingYouNeed.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyThingYouNeed.Bussiness.Abstract
{
    public interface IRequestService
    {
        public ResultModelClas AddRequest(Request request);
        public List<Request> GetAllRequest();
        public Request GetRequest(int id);
        public ResultModelClas UpdateRequest(Request request);
        public ResultModelClas DeleteRequest(Request request);
    }
}
