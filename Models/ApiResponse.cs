namespace WebApp1.Models
{
    public class ApiResponse
    {
        public object Data
        {
            get;
            set;
        }

        public bool Status
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }
    }

    public class SqlCommandString
    {
        private string _connectionString = @"Data Source=.;Initial Catalog=NORTHWIND;User ID=sa;Password=sa@1234"; //Connection string is defined.
        private string _getCustomerOrdersCount = @"SELECT DISTINCT CustomerID, COUNT(OrderID) AS OrderCount FROM Orders GROUP BY CustomerID";
        public string connectionString
        {
            get 
            {
                return _connectionString;
            }
            set { }
        }

        public string getCustomerOrdersCount
        {
            get
            {
                return _getCustomerOrdersCount;
            }
            set  {  }
        }
    }

    public class CustomerOrderCountData
    {
        public string CustomerID
        {
            get;
            set;
        }

        public int OrderCount
        {
            get;
            set;
        }
    }
}