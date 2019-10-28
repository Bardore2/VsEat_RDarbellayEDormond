using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class STATUS_DB : I_STATUS_DB
    {
        public IConfiguration Config { get; }

        public STATUS_DB(IConfiguration config)
        {
            Config = config;
        }

        public STATUS GetSTATUS(int Id)
        {
            STATUS status = null;
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM STATUS WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", Id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            status = new STATUS();

                            if (dr["Id"] != DBNull.Value)
                                status.Id = (int)dr["Id"];

                            if (dr["Designation"] != DBNull.Value)
                                status.Designation = (string)dr["Designation"];

                            if (dr["Created_At"] != DBNull.Value)
                                status.Created_At = (DateTime)dr["Created_At"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return status;
        }
    }
}
