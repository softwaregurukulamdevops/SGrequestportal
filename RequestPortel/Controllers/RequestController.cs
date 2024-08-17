using Microsoft.AspNetCore.Mvc;
using RequestPortel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RequestPortel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : Controller
    {
        public readonly TrainingDBContext trainingDBContext;
        public RequestController(TrainingDBContext _trainingDBContext)
        {
            trainingDBContext = _trainingDBContext;
        }
        [HttpGet("GetRequestDetails")]
        public List<Request> GetRequestDetails()
        {
            List<Request> lstRequest = new List<Request>();
            try
            {
                lstRequest = trainingDBContext.Request.ToList();
                return lstRequest;
            }
            catch (Exception ex)
            {
                lstRequest = new List<Request>();
                return lstRequest;
            }
        }
        [HttpPost("AddRequest")]
        public string AddRequest(Request request)
        {
            string message = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(request.RequestName))
                {
                    trainingDBContext.Add(request);
                    trainingDBContext.SaveChanges();
                    message = "Request added successfully";
                }
                else
                    message = "Request Name required.";

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
    }
}
