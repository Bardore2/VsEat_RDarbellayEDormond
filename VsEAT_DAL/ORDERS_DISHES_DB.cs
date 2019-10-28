using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class ORDERS_DISHES_DB : I_ORDERS_DISHES_DB
    {
        public IConfiguration Config { get; }

        public ORDERS_DISHES_DB(IConfiguration config)
        {
            Config = config;
        }

        public ORDERS_DISHES AddORDERS_DISHES(ORDERS_DISHES orders_dishes)
        {
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO ORDERS_DISHES VALUES(@Quantity, GETDATE(), @Fk_Id_Dishes, @Fk_Id_Orders); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Quantity", orders_dishes.Quantity);
                    cmd.Parameters.AddWithValue("@Fk_Id_Dishes", orders_dishes.Fk_Id_Dishes);
                    cmd.Parameters.AddWithValue("@Fk_Id_Orders", orders_dishes.Fk_Id_Orders);

                    cn.Open();

                    orders_dishes.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orders_dishes;
        }

        public double GetAmount(ORDERS orders)
        {
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT SUM(Quantity*Price) AS PRICE " +
                        "FROM ORDERS_DISHES od, DISHES d " +
                        "WHERE od.Fk_Id_Dishes = d.Id " +
                        "AND od.Fk_Id_Orders = @orderNumber; ";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@orderNumber", orders.Id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            if (dr["PRICE"] != DBNull.Value)
                                return (double)dr["PRICE"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return 0.0;
        }
    }
}
