using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApp1.Models;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace WebApp1.Controllers
{
    public class DataController : ApiController
    {
        [System.Web.Http.HttpHead]
        [System.Web.Http.HttpPost]
        [System.Web.Http.HttpGet]
        // Api to get all customer order count.
        [System.Web.Http.Route("api/get-customer-order-count")]
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
                SqlCommandString commandString = new SqlCommandString();
                response.Data = ProcessQuery(commandString.getCustomerOrdersCount);
                response.Message = "Api Successfully triggered.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();

            }
            return response;
        }

        [System.Web.Http.HttpHead]
        [System.Web.Http.HttpPost]
        [System.Web.Http.HttpGet]
        // Api to get customer order count based on the customer Id provided.
        [System.Web.Http.Route("api/get-customer-order-count/{name}")]
        public ApiResponse GetCustomerCountOnCustomerName(string name)
        {
            ApiResponse response = new ApiResponse()
            {
                Status = true,
                Data = null,
                Message = ""
            };
            try
            {
                SqlCommandString commandString = new SqlCommandString();
                string queryString = commandString.getCustomerOrdersCount + (String.IsNullOrWhiteSpace(name) ? "" : " HAVING CustomerID = '" + name + "'");
                response.Data = ProcessQuery(queryString);
                response.Message = "Api Successfully triggered.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message.ToString();

            }
            return response;
        }

        // Method to process the given query.
        private string ProcessQuery(string queryString)
        {
            SqlCommandString commandString = new SqlCommandString();
            SqlConnection connection;
            DataTable dataTable = new DataTable();
            connection = new SqlConnection(commandString.connectionString);
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(queryString, connection);
            dataAdapter.Fill(dataTable);
            connection.Close();

            //Dictionary<string, string> orderData = new Dictionary<string, string>();
            //foreach (DataRow rows in dataTable.Rows)
            //{
            //    orderData.Add(rows[dataTable.Columns[0].ColumnName]?.ToString(), rows[dataTable.Columns[1].ColumnName]?.ToString());
            //}

            return JsonConvert.SerializeObject(dataTable).ToString();
        }
    }
}
