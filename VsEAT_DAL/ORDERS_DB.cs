using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class ORDERS_DB : I_ORDERS_DB
    {
        public IConfiguration Config { get; }

        public ORDERS_DB(IConfiguration config)
        {
            Config = config;
        }

        public int AddORDERS(int customerNumber)
        {
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO ORDERS (Created_At, Fk_Id_Customers) VALUES(GETDATE(), @Fk_Id_Customers); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Fk_Id_Customers", customerNumber);
                    cn.Open();

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ORDERS GetORDERS(int Id)
        {
            ORDERS orders = null;
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM ORDERS WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", Id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            orders = new ORDERS();

                            if (dr["Id"] != DBNull.Value)
                                orders.Id = (int)dr["Id"];

                            if (dr["Created_At"] != DBNull.Value)
                                orders.Created_At = (DateTime)dr["Created_At"];

                            if (dr["Fk_Id_Bills"] != DBNull.Value)
                                orders.Fk_Id_Bills = (int)dr["Fk_Id_Bills"];

                            if (dr["Fk_Id_Delivery"] != DBNull.Value)
                                orders.Fk_Id_Delivery = (int)dr["Fk_Id_Delivery"];

                            if (dr["Fk_Id_Customers"] != DBNull.Value)
                                orders.Fk_Id_Customers = (int)dr["Fk_Id_Customers"];

                            if (dr["Fk_Id_Order_Status"] != DBNull.Value)
                                orders.Fk_Id_Order_Status = (int)dr["Fk_Id_Order_Status"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orders;
        }

        public ORDERS GetORDERS(string[] stab)
        {
            ORDERS orders = null;
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT o.Id, o.Created_At, o.Fk_Id_Bills, o.Fk_Id_Delivery, o.Fk_Id_Customers, o.Fk_Id_Order_Status " +
                        "FROM ORDERS o, CUSTOMERS c " +
                        "WHERE o.Fk_Id_Customers = c.Id " +
                        "AND c.FirstName = @FirstName " +
                        "AND c.LastName = @LastName " +
                        "AND o.Id = @Id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(stab[0]));
                    cmd.Parameters.AddWithValue("@FirstName", stab[1]);
                    cmd.Parameters.AddWithValue("@LastName", stab[2]);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            orders = new ORDERS();

                            if (dr["Id"] != DBNull.Value)
                                orders.Id = (int)dr["Id"];

                            if (dr["Created_At"] != DBNull.Value)
                                orders.Created_At = (DateTime)dr["Created_At"];

                            if (dr["Fk_Id_Bills"] != DBNull.Value)
                                orders.Fk_Id_Bills = (int)dr["Fk_Id_Bills"];

                            if (dr["Fk_Id_Delivery"] != DBNull.Value)
                                orders.Fk_Id_Delivery = (int)dr["Fk_Id_Delivery"];

                            if (dr["Fk_Id_Customers"] != DBNull.Value)
                                orders.Fk_Id_Customers = (int)dr["Fk_Id_Customers"];

                            if (dr["Fk_Id_Order_Status"] != DBNull.Value)
                                orders.Fk_Id_Order_Status = (int)dr["Fk_Id_Order_Status"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orders;
        }

        public ORDERS UpdateORDERS_Fk_Id_Bills(ORDERS orders)
        {
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE ORDERS SET Fk_Id_Bills=@Fk_Id_Bills WHERE Id=@Id;";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Id", orders.Id);
                    cmd.Parameters.AddWithValue("@Fk_Id_Bills", orders.Fk_Id_Bills);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orders;
        }
        public ORDERS UpdateORDERS_Fk_Id_Delivery(ORDERS orders)
        {
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE ORDERS SET Fk_Id_Delivery=@Fk_Id_Delivery WHERE Id=@Id;";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Id", orders.Id);
                    cmd.Parameters.AddWithValue("@Fk_Id_Delivery", orders.Fk_Id_Delivery);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orders;
        }
        public ORDERS UpdateORDERS_Fk_Id_Order_Status(ORDERS orders)
        {
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE ORDERS SET Fk_Id_Order_Status=@Fk_Id_Order_Status WHERE Id=@Id;";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Id", orders.Id);
                    cmd.Parameters.AddWithValue("@Fk_Id_Order_Status", orders.Fk_Id_Order_Status);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orders;
        }
        public List<ORDERS> GetORDERSForCustomer(int customerNumber)
        {
            List<ORDERS> orders = null;
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT ORDERS.Id, ORDERS.Created_At, Fk_Id_Bills, Fk_Id_Delivery, ORDERS.Fk_Id_Customers, Fk_Id_Order_Status FROM ORDERS, DELIVERY WHERE Fk_Id_Delivery = DELIVERY.Id AND Fk_Id_Customers = @Fk_Id_Customers AND Fk_Id_Order_Status = 4 AND Fk_Id_Delivery_Time > (SELECT MIN(Id) FROM DELIVERY_TIME WHERE DATEDIFF(minute, CAST( CONVERT(TIME(7),GETDATE()) as datetime ), CAST( Time_Zone as datetime )) > 179);";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Fk_Id_Customers", customerNumber);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (orders == null)
                                orders = new List<ORDERS>();

                            ORDERS order = new ORDERS();

                            if (dr["Id"] != DBNull.Value)
                                order.Id = (int)dr["Id"];

                            if (dr["Created_At"] != DBNull.Value)
                                order.Created_At = (DateTime)dr["Created_At"];

                            if (dr["Fk_Id_Bills"] != DBNull.Value)
                                order.Fk_Id_Bills = (int)dr["Fk_Id_Bills"];

                            if (dr["Fk_Id_Delivery"] != DBNull.Value)
                                order.Fk_Id_Delivery = (int)dr["Fk_Id_Delivery"];

                            if (dr["Fk_Id_Customers"] != DBNull.Value)
                                order.Fk_Id_Customers = (int)dr["Fk_Id_Customers"];

                            if (dr["Fk_Id_Order_Status"] != DBNull.Value)
                                order.Fk_Id_Order_Status = (int)dr["Fk_Id_Order_Status"];

                            orders.Add(order);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orders;
        }
    }
}
