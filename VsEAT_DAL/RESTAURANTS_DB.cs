using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class RESTAURANTS_DB : I_RESTAURANTS_DB
    {
        public IConfiguration Config { get; }

        public RESTAURANTS_DB(IConfiguration config)
        {
            Config = config;
        }

        public List<RESTAURANTS> GetRESTAURANTS()
        {
            List<RESTAURANTS> restaurants = null;
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM RESTAURANTS";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (restaurants == null)
                                restaurants = new List<RESTAURANTS>();

                            RESTAURANTS restaurant = new RESTAURANTS();

                            if (dr["Id"] != DBNull.Value)
                                restaurant.Id = (int)dr["Id"];

                            if (dr["Merchant_Name"] != DBNull.Value)
                                restaurant.Merchant_Name = (string)dr["Merchant_Name"];

                            if (dr["Address"] != DBNull.Value)
                                restaurant.Address = (string)dr["Address"];

                            if (dr["Phone_Number"] != DBNull.Value)
                                restaurant.Phone_Number = (string)dr["Phone_Number"];

                            if (dr["Created_At"] != DBNull.Value)
                                restaurant.Created_At = (DateTime)dr["Created_At"];

                            if (dr["Fk_Id_Cities"] != DBNull.Value)
                                restaurant.Fk_Id_Cities = (int)dr["Fk_Id_Cities"];

                            restaurants.Add(restaurant);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restaurants;
        }

        public int GetCITIES(int Id)
        {
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Fk_Id_Cities FROM RESTAURANTS WHERE Id = @Id; ";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Id", Id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        { 
                            if (dr["Fk_Id_Cities"] != DBNull.Value)
                                return (int)dr["Fk_Id_Cities"];

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
