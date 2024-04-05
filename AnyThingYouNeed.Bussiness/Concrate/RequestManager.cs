using AnyThingYouNeed.Bussiness.Abstract;
using AnyThingYouNeed.Bussiness.Concrate.FluentValidition;
using AnyThingYouNeed.Bussiness.Concrate.ResultModel;
using AnyThingYouNeed.Bussiness.Concrate.Utilities;
using AnyThingYouNeed.DataAccess.Abstract;
using AnyThingYouNeed.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyThingYouNeed.Bussiness.Concrate
{
    public class RequestManager : IRequestService
    {

        private readonly IRequestDal _requestDal;
        public RequestManager(IRequestDal requestDal)
        {
            _requestDal = requestDal;
        }

        public List<Request> GetAllRequest()
        {
            return _requestDal.GetAll();
        }
        public Request GetRequest(int id)
        {
            return _requestDal.Get(p => p.ID == id);
        }
        public ResultModelClas UpdateRequest(Request request)
        {
            ResultModelClas resultModele = new ResultModelClas();
            resultModele.Success = false;
            resultModele.Message = "";
            try
            {
                ValidationTool.Validate(new RequestValidator(), request);
                _requestDal.Update(request);
                resultModele.Message = "Your request is sent. We will be contacting you asp.";
                resultModele.Success = true;
            }
            catch (Exception ex)
            {
                resultModele.Message = ex.Message;
                resultModele.Success = false;

            }
            return resultModele;


        }
        public ResultModelClas AddRequest(Request request)
        {

            ResultModelClas resultModele = new ResultModelClas();
            resultModele.Success = false;
            resultModele.Message = "";
            try
            {
                ValidationTool.Validate(new RequestValidator(), request);
                _requestDal.Add(request);
                resultModele.Message = "Your request is sent. We will be contacting you asp.";
                resultModele.Success = true;
            }
            catch (Exception ex)
            {
                resultModele.Message = ex.Message;
                resultModele.Success = false;

            }
            return resultModele;
        }

        public ResultModelClas DeleteRequest(Request request)
        {
            throw new NotImplementedException();
        }
    }
}
