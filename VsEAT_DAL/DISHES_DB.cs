using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class DISHES_DB : I_DISHES_DB
    {
        public IConfiguration Config { get; }

        public DISHES_DB(IConfiguration config)
        {
            Config = config;
        }

        public List<DISHES> GetDISHES(int IdRestaurant)
        {
            List<DISHES> dishes = null;
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM DISHES WHERE Fk_Id_Restaurants = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", IdRestaurant);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (dishes == null)
                                dishes = new List<DISHES>();

                            DISHES dish = new DISHES();

                            if (dr["Id"] != DBNull.Value)
                                dish.Id = (int)dr["Id"];
                            
                            if (dr["Name"] != DBNull.Value)
                                dish.Name = (string)dr["Name"];
                            
                            if (dr["Designation"] != DBNull.Value)
                                dish.Designation = (string)dr["Designation"];
                            
                            if (dr["Price"] != DBNull.Value)
                                dish.Price = (double) dr["Price"];
                            
                            if (dr["Status"] != DBNull.Value)
                                dish.Status = (int)dr["Status"];
                            
                            if (dr["Created_At"] != DBNull.Value)
                                dish.Created_At = (DateTime)dr["Created_At"];

                            if (dr["Fk_Id_Restaurants"] != DBNull.Value)
                                dish.Fk_Id_Restaurants = (int)dr["Fk_Id_Restaurants"];
                      
                            dishes.Add(dish);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dishes;
        }
    }
}
