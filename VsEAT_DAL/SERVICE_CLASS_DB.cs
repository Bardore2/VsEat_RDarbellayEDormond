using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class SERVICE_CLASS_DB : I_SERVICE_CLASS_DB
    {
        public IConfiguration Config { get; }

        public SERVICE_CLASS_DB(IConfiguration config)
        {
            Config = config;
        }
        public double GetAmount(DELIVERY delivery)
        {
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Price " +
                        "FROM DELIVERY d, SERVICE_CLASS sc " +
                        "WHERE d.Fk_Id_Delivery_Status = sc.Id " +
                        "AND d.Id = @deliveryNumber; ";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@deliveryNumber", delivery.Id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            if (dr["Price"] != DBNull.Value)
                                return (double)dr["Price"];
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

        public List<SERVICE_CLASS> GetSERVICE_CLASS()
        {

            List<SERVICE_CLASS> service_classes = null;
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM SERVICE_CLASS";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (service_classes == null)
                                service_classes = new List<SERVICE_CLASS>();

                            SERVICE_CLASS sc = new SERVICE_CLASS();

                            if (dr["Id"] != DBNull.Value)
                                sc.Id = (int)dr["Id"];

                            if (dr["Designation"] != DBNull.Value)
                                sc.Designation = (string)dr["Designation"];

                            if (dr["Price"] != DBNull.Value)
                                sc.Price = (double)dr["Price"];

                            if (dr["Created_At"] != DBNull.Value)
                                sc.Created_At = (DateTime)dr["Created_At"];

                            service_classes.Add(sc);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return service_classes;
        }
    }
}
