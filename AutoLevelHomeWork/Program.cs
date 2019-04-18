using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLevelHomeWork
{
    //Orders, Customers, Employees, OrderDetails, Products
    class Program
    {
        static void Main(string[] args)
        {
            DataSet dataSet = new DataSet("ShopDB");

            List<DataTable> tables = new List<DataTable>();

            #region Orders Table
            tables.Add(new DataTable());
            tables[0].TableName = "Orders";
            tables[0].Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                ColumnName = "Id",
                DataType = typeof(int),
                Unique = true
            });
            tables[0].PrimaryKey = new DataColumn[] { tables[0].Columns["Id"] };
            tables[0].Columns.Add("Time", typeof(DateTime));
            tables[0].Columns.Add("CustomerId", typeof(int));
            tables[0].Columns.Add("EmployeeId", typeof(int));
            #endregion

            #region Customers Table

            tables.Add(new DataTable());
            tables[1].TableName = "Customers";
            tables[1].Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                ColumnName = "Id",
                DataType = typeof(int),
                Unique = true
            });
            tables[1].PrimaryKey = new DataColumn[] { tables[1].Columns["Id"] };
            tables[1].Columns.Add("Name", typeof(string));

            #endregion

            #region Employees Table

            tables.Add(new DataTable());
            tables[2].TableName = "Employees";
            tables[2].Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                ColumnName = "Id",
                DataType = typeof(int),
                Unique = true
            });
            tables[2].PrimaryKey = new DataColumn[] { tables[2].Columns["Id"] };
            tables[2].Columns.Add("Name", typeof(string));
            tables[2].Columns.Add("Salary", typeof(int));

            #endregion

            #region OrderDetails Table

            tables.Add(new DataTable());
            tables[3].TableName = "OrderDetails";
            tables[3].Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                ColumnName = "Id",
                DataType = typeof(int),
                Unique = true
            });
            tables[3].PrimaryKey = new DataColumn[] { tables[3].Columns["Id"] };
            tables[3].Columns.Add("OrderId", typeof(int));
            tables[3].Columns.Add("ProductId", typeof(int));

            #endregion

            #region Products Table

            tables.Add(new DataTable());
            tables[4].TableName = "Products";
            tables[4].Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                ColumnName = "Id",
                DataType = typeof(int),
                Unique = true
            });
            tables[4].PrimaryKey = new DataColumn[] { tables[4].Columns["Id"] };
            tables[4].Columns.Add("Name", typeof(string));
            tables[4].Columns.Add("Cost", typeof(int));

            #endregion

            foreach (var table in tables)
            {
                dataSet.Tables.Add(table);
            }

            #region Relations

            dataSet.Relations.Add("employees_orders_FK", dataSet.Tables["Employees"].Columns["Id"], dataSet.Tables["Orders"].Columns["EmployeeId"]);
            dataSet.Relations.Add("customers_orders_FK", dataSet.Tables["Customers"].Columns["Id"], dataSet.Tables["Orders"].Columns["CustomerId"]);

            dataSet.Relations.Add("orders_orderDetails_FK", dataSet.Tables["Orders"].Columns["Id"], dataSet.Tables["OrderDetails"].Columns["OrderId"]);
            dataSet.Relations.Add("product_orderDetails_FK", dataSet.Tables["Products"].Columns["Id"], dataSet.Tables["OrderDetails"].Columns["ProductId"]);

            #endregion
        }
    }
}
