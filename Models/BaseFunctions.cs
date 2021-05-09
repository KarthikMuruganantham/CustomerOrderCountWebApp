using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebApp1.Models
{
    public class BaseFunctions
    {
        public string GetOrdersWithEntityData() 
        {
            OrdersDbContext dbContext = new OrdersDbContext();
            List<Order> orders = dbContext.Orders?.ToList();
            var result = from order in orders
                         group order by order.CustomerID into groupTable
                         select new 
                         {
                             CustomerID = groupTable.First().CustomerID,
                             OrderCount = groupTable.Count()
                         };
            return JsonConvert.SerializeObject(result.ToList());
        }
    }
}