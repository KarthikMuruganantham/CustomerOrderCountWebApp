using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp1.Models;
using System.Data;
using Newtonsoft.Json;

namespace WebApp1.Controllers
{
    public class OrderDataController : ApiController
    {
        [System.Web.Http.HttpHead]
        [System.Web.Http.HttpPost]
        [System.Web.Http.HttpGet]
        // Api to get all customer order count.
        [System.Web.Http.Route("api/get-orders-data")]
        public ApiResponse GetCustomerCount()
        {
            ApiResponse response = new ApiResponse()
            {
                Status = true,
                Data = null,
                Message = ""
            };
            try
            {
                BaseFunctions functions = new BaseFunctions();
                response.Data = functions.GetOrdersWithEntityData();
                response.Message = "Api Successfully triggered.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();

            }
            return response;
        }
    }
}
