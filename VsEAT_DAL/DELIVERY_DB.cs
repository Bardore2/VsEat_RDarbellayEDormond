using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class DELIVERY_DB : I_DELIVERY_DB
    {
        public IConfiguration Config { get; }

        public DELIVERY_DB(IConfiguration config)
        {
            Config = config;
        }

        public int AddDELIVERY()
        {
            int deliveryNumber;
            DELIVERY d = new DELIVERY();

            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO DELIVERY (Created_At) VALUES (GETDATE()); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    deliveryNumber = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return deliveryNumber;
        }

        public DELIVERY GetDELIVERY(int Id)
        {
            DELIVERY delivery = null;
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM DELIVERY WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", Id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            delivery = new DELIVERY();

                            if (dr["Id"] != DBNull.Value)
                                delivery.Id = (int)dr["Id"];

                            if (dr["Start_Time"] != DBNull.Value)
                                delivery.Start_Time = (TimeSpan)dr["Start_Time"];

                            if (dr["Finish_Time"] != DBNull.Value)
                                delivery.Finish_Time = (TimeSpan)dr["Finish_Time"];

                            if (dr["Created_At"] != DBNull.Value)
                                delivery.Created_At = (DateTime)dr["Created_At"];

                            if (dr["Fk_Id_Service_Class"] != DBNull.Value)
                                delivery.Fk_Id_Service_Class = (int)dr["Fk_Id_Service_Class"];

                            if (dr["Fk_Id_Delivery_Status"] != DBNull.Value)
                                delivery.Fk_Id_Delivery_Status = (int)dr["Fk_Id_Delivery_Status"];

                            if (dr["Fk_Id_Delivery_Time"] != DBNull.Value)
                                delivery.Fk_Id_Delivery_Time = (int)dr["Fk_Id_Delivery_Time"];

                            if (dr["Fk_Id_Delivery_Courier"] != DBNull.Value)
                                delivery.Fk_Id_Delivery_Courier = (int)dr["Fk_Id_Delivery_Courier"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return delivery;
        }

        public List<DELIVERY> GetDELIVERYforCourier(int deliveryCourierNumber)
        {
            List<DELIVERY> deliveries = null;
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM DELIVERY WHERE Fk_Id_Delivery_Courier = @deliveryCourierNumber AND Fk_Id_Delivery_Status=4";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@deliveryCourierNumber", deliveryCourierNumber);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (deliveries == null)
                                deliveries = new List<DELIVERY>();

                            DELIVERY delivery = new DELIVERY();

                            if (dr["Id"] != DBNull.Value)
                                delivery.Id = (int)dr["Id"];

                            if (dr["Start_Time"] != DBNull.Value)
                                delivery.Start_Time = (TimeSpan)dr["Start_Time"];

                            if (dr["Finish_Time"] != DBNull.Value)
                                delivery.Finish_Time = (TimeSpan)dr["Finish_Time"];

                            if (dr["Created_At"] != DBNull.Value)
                                delivery.Created_At = (DateTime)dr["Created_At"];

                            if (dr["Fk_Id_Service_Class"] != DBNull.Value)
                                delivery.Fk_Id_Service_Class = (int)dr["Fk_Id_Service_Class"];

                            if (dr["Fk_Id_Delivery_Status"] != DBNull.Value)
                                delivery.Fk_Id_Delivery_Status = (int)dr["Fk_Id_Delivery_Status"];

                            if (dr["Fk_Id_Delivery_Time"] != DBNull.Value)
                                delivery.Fk_Id_Delivery_Time = (int)dr["Fk_Id_Delivery_Time"];

                            if (dr["Fk_Id_Delivery_Courier"] != DBNull.Value)
                                delivery.Fk_Id_Delivery_Courier = (int)dr["Fk_Id_Delivery_Courier"];

                            deliveries.Add(delivery);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return deliveries;
        }

        public DELIVERY UpdateDELIVERY_Start_Time(DELIVERY delivery)
        {
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE DELIVERY SET Start_Time = CONVERT(TIME(7),GETDATE()) WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", delivery.Id);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return delivery;
        }
        public DELIVERY UpdateDELIVERY_Finish_Time(DELIVERY delivery)
        {
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE DELIVERY SET Finish_Time = CONVERT(TIME(7),GETDATE()) WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", delivery.Id);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return delivery;
        }
        public DELIVERY UpdateDELIVERY_Fk_Id_Service_Class(DELIVERY delivery)
        {
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE DELIVERY SET Fk_Id_Service_Class = @Fk_Id_Service_Class WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", delivery.Id);
                    cmd.Parameters.AddWithValue("@Fk_Id_Service_Class", delivery.Fk_Id_Service_Class);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return delivery;
        }
        public DELIVERY UpdateDELIVERY_Fk_Id_Delivery_Status(DELIVERY delivery)
        {
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE DELIVERY SET Fk_Id_Delivery_Status = @Fk_Id_Delivery_Status WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", delivery.Id);
                    cmd.Parameters.AddWithValue("@Fk_Id_Delivery_Status", delivery.Fk_Id_Delivery_Status);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return delivery;
        }
        public DELIVERY UpdateDELIVERY_Fk_Id_Delivery_Time(DELIVERY delivery)
        {
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE DELIVERY SET Fk_Id_Delivery_Time = @Fk_Id_Delivery_Time WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", delivery.Id);
                    cmd.Parameters.AddWithValue("@Fk_Id_Delivery_Time", delivery.Fk_Id_Delivery_Time);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return delivery;
        }
        public DELIVERY UpdateDELIVERY_Fk_Id_Delivery_Courier(DELIVERY delivery)
        {
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE DELIVERY SET Fk_Id_Delivery_Courier = @Fk_Id_Delivery_Courier WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", delivery.Id);
                    cmd.Parameters.AddWithValue("@Fk_Id_Delivery_Courier", delivery.Fk_Id_Delivery_Courier);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return delivery;
        }

        public int GetORDERSid(int deliveryNumber)
        {
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT ORDERS.Id " +
                        "FROM DELIVERY, ORDERS " +
                        "WHERE DELIVERY.Id = ORDERS.Fk_Id_Delivery " +
                        "AND DELIVERY.Id = @deliveryNumber;";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@deliveryNumber", deliveryNumber);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            if (dr["Id"] != DBNull.Value)
                                return (int)dr["Id"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return 0;
        }
    }
}
