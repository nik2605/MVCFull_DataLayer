using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace OrderManagement_MVC_DataLayer
{
    public class Order : DataObject
    {
        public Order(): base()
        {

        }

        public Order(SqlTransaction transaction) : base(transaction)
        {
            
        }

        public Guid OrderId { get; set; }

        public string OrderName { get; set; }

        public DateTime OrderDate { get; set; }

        public string OrderStatus { get; set; }


        public Order GetOrder(string orderid)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            var cmd = Transaction != null 
                ? new SqlCommand("GetOrder", connection) { CommandType = CommandType.StoredProcedure } 
                : new SqlCommand("GetOrder", connection, Transaction) { CommandType = CommandType.StoredProcedure };
            
            cmd.Parameters.AddWithValue("@OrderId", orderid);
            

            connection.Open();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

            //transform the dataset to entities
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                return new Order()
                {
                    OrderId = new Guid(orderid),
                    OrderDate = Convert.ToDateTime(dataRow["OrderDate"].ToString()),
                    OrderName = dataRow["Name"].ToString(),
                    OrderStatus = "Active"
                };
            }

            return new Order();
        }

        public Order UpdateOrder(Order order)
        {
            return new Order();
        }

        public void DeleteOrder(Guid orderid)
        {

        }

        public Order CreateOrder(Order order)
        {
            return new Order();
        }

        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT TOP (1000) [Id]     ,[Number]      ,[Qty]      ,[Price]      ,[Name]      ,[OrderDate]  FROM [OrderManagement].[dbo].[Orders] ");

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
            conn.Open();
            SqlDataAdapter sa = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            try
            {
                sa.Fill(ds);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            //transform the dataset to entities
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                orders.Add(new Order()
                {
                    OrderId = new Guid(dataRow["Id"].ToString()),
                    OrderDate = Convert.ToDateTime(dataRow["OrderDate"].ToString()),
                    OrderName = dataRow["Name"].ToString(),
                    OrderStatus = "Active"
                });
            }


            return orders;
        }

    }
}