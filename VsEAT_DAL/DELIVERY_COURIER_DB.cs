using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class DELIVERY_COURIER_DB : I_DELIVERY_COURIER_DB
    {
        public IConfiguration Config { get; }

        public DELIVERY_COURIER_DB(IConfiguration config)
        {
            Config = config;
        }

        public DELIVERY_COURIER GetDELIVERY_COURIER(string login)
        {
            DELIVERY_COURIER delivery_courier = null;
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM DELIVERY_COURIER where Login = @login";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@login", login);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            delivery_courier = new DELIVERY_COURIER();

                            if (dr["Id"] != DBNull.Value)
                                delivery_courier.Id = (int)dr["Id"];

                            if (dr["FirstName"] != DBNull.Value)
                                delivery_courier.FirstName = (string)dr["FirstName"];

                            if (dr["LastName"] != DBNull.Value)
                                delivery_courier.LastName = (string)dr["LastName"];

                            if (dr["Phone_Number"] != DBNull.Value)
                                delivery_courier.Phone_Number = (string)dr["Phone_Number"];

                            if (dr["Address"] != DBNull.Value)
                                delivery_courier.Address = (string)dr["Address"];

                            if (dr["Login"] != DBNull.Value)
                                delivery_courier.Login = (string)dr["Login"];

                            if (dr["Password"] != DBNull.Value)
                                delivery_courier.Password = (string)dr["Password"];

                            if (dr["Created_At"] != DBNull.Value)
                                delivery_courier.Created_At = (DateTime)dr["Created_At"];

                            if (dr["Fk_Id_Cities"] != DBNull.Value)
                                delivery_courier.Fk_Id_Cities = (int)dr["Fk_Id_Cities"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return delivery_courier;
        }

        public DELIVERY_COURIER GetFreeDELIVERY_COURIER(int restaurantsId, int deliveryId)
        {
            int dtm1, delivery_time, dtp1, maxdt, citiesId;

            DELIVERY_DB ddb = new DELIVERY_DB(Config);
            delivery_time = ddb.GetDELIVERY(deliveryId).Fk_Id_Delivery_Time;

            DELIVERY_TIME_DB dtdb = new DELIVERY_TIME_DB(Config);
            maxdt = dtdb.GetMaximumDeliveryTimeId();
            if (delivery_time == 0)
                dtm1 = delivery_time;
            else
                dtm1 = delivery_time - 1;

            if (delivery_time == maxdt)
                dtp1 = delivery_time;
            else
                dtp1 = delivery_time + 1;

            RESTAURANTS_DB rdb = new RESTAURANTS_DB(Config);
            citiesId = rdb.GetCITIES(restaurantsId);

            DELIVERY_COURIER delivery_courier = null;
            string connectionString = Config.GetConnectionString("DefaultConnection");
 
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT TOP (1) * " +
                        "FROM DELIVERY_COURIER WHERE Fk_Id_Cities = @restaurantCitiesId " +
                        "AND Id NOT IN(SELECT DELIVERY_COURIER.Id " +
                                            "FROM DELIVERY, DELIVERY_COURIER, STATUS " +
                                            "WHERE DELIVERY.Fk_Id_Delivery_Courier = DELIVERY_COURIER.Id  " +
                                            "AND DELIVERY.Fk_Id_Delivery_Status = STATUS.Id  " +
                                            "AND DELIVERY.Fk_Id_Delivery_Time IN(@dtidm1, @dtid, @dtidp1)  " +
                                            "AND STATUS.Designation = 'Pending'  " +
                                            "GROUP BY DELIVERY_COURIER.Id " +
                                            "HAVING COUNT(DELIVERY.Id) > 4);";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@restaurantCitiesId", citiesId);
                    cmd.Parameters.AddWithValue("@dtidm1", dtm1);
                    cmd.Parameters.AddWithValue("@dtid", delivery_time);
                    cmd.Parameters.AddWithValue("@dtidp1", dtp1);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            delivery_courier = new DELIVERY_COURIER();

                            if (dr["Id"] != DBNull.Value)
                                delivery_courier.Id = (int)dr["Id"];

                            if (dr["FirstName"] != DBNull.Value)
                                delivery_courier.FirstName = (string)dr["FirstName"];

                            if (dr["LastName"] != DBNull.Value)
                                delivery_courier.LastName = (string)dr["LastName"];

                            if (dr["Phone_Number"] != DBNull.Value)
                                delivery_courier.Phone_Number = (string)dr["Phone_Number"];

                            if (dr["Address"] != DBNull.Value)
                                delivery_courier.Address = (string)dr["Address"];

                            if (dr["Login"] != DBNull.Value)
                                delivery_courier.Login = (string)dr["Login"];

                            if (dr["Password"] != DBNull.Value)
                                delivery_courier.Password = (string)dr["Password"];

                            if (dr["Created_At"] != DBNull.Value)
                                delivery_courier.Created_At = (DateTime)dr["Created_At"];

                            if (dr["Fk_Id_Cities"] != DBNull.Value)
                                delivery_courier.Fk_Id_Cities = (int)dr["Fk_Id_Cities"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return delivery_courier;

        }
    }
}
