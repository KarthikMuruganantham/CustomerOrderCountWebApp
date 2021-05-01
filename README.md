# CustomerOrderCountWebApp
Web application to return customer order count.

The web application returs the customer Id with their order count for Northwind database.

Api Details:

`HostUrl/api/get-customer-order-count` - This will return all customer Id with order count

`HostURL/api/get-customer-order-count/Customer_Id` - This will return customer Id with order count for the specific customer.

Note:
1. Modify the local database connection details in `connectionString` property in the `ApiResponse.cs` file in `Method` folder.
