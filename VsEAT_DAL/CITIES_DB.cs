using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class CITIES_DB : I_CITIES_DB
    {
        public IConfiguration Config { get; }

        public CITIES_DB(IConfiguration config)
        {
            Config = config;
        }

        public List<CITIES> GetCITIES()
        {
            List<CITIES> cities = null;
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM CITIES";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (cities == null)
                                cities = new List<CITIES>();

                            CITIES city = new CITIES();

                            if (dr["Id"] != DBNull.Value)
                                city.Id = (int)dr["Id"];

                            if (dr["Name"] != DBNull.Value)
                                city.Name = (string)dr["Name"];

                            if (dr["Zip_Code"] != DBNull.Value)
                                city.Zip_Code = (int)dr["Zip_Code"];

                            if (dr["Country"] != DBNull.Value)
                                city.Country = (string)dr["Country"];

                            if (dr["Created_At"] != DBNull.Value)
                                city.Created_At = (DateTime)dr["Created_At"];


                            cities.Add(city);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return cities;
        }

        public int getCITIES(string[] stab)
        {
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id " +
                        "FROM CITIES " +
                        "WHERE Name = @Name " +
                        "AND Zip_Code = @Zip_Code";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Name", stab[1]);
                    cmd.Parameters.AddWithValue("@Zip_Code", stab[0]);

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

        public int addCITIES(string[] stab)
        {
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO CITIES VALUES(@Name, @Zip_Code, 'Suisse', GETDATE()); ; SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Name", stab[1]);
                    cmd.Parameters.AddWithValue("@Zip_Code", stab[0]);

                    cn.Open();

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }


}
