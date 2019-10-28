using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class DELIVERY_TIME_DB : I_DELIVERY_TIME_DB
    {
        public IConfiguration Config { get; }

        public DELIVERY_TIME_DB(IConfiguration config)
        {
            Config = config;
        }

        public List<DELIVERY_TIME> GetDELIVERY_TIME()
        {
            List<DELIVERY_TIME> delivery_times = null;
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM DELIVERY_TIME WHERE CAST( Time_Zone as datetime ) > CAST( CONVERT(TIME(7),GETDATE()) as datetime );";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (delivery_times == null)
                                delivery_times = new List<DELIVERY_TIME>();

                            DELIVERY_TIME dt = new DELIVERY_TIME();

                            if (dr["Id"] != DBNull.Value)
                                dt.Id = (int)dr["Id"];

                            if (dr["Time_Zone"] != DBNull.Value)
                                dt.Time_Zone = (string)dr["Time_Zone"];

                            if (dr["Created_At"] != DBNull.Value)
                                dt.Created_At = (DateTime)dr["Created_At"];

                            delivery_times.Add(dt);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return delivery_times;
        }

        public int GetMaximumDeliveryTimeId()
        {
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT MAX(Id) AS Id FROM DELIVERY_TIME";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
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
