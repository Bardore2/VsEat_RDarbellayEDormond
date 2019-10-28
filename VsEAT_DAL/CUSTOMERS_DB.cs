using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class CUSTOMERS_DB : I_CUSTOMERS_DB
    {
        public IConfiguration Config { get; }

        public CUSTOMERS_DB(IConfiguration config)
        {
            Config = config;
        }

        public CUSTOMERS AddCUSTOMERS(CUSTOMERS customers)
        {
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO CUSTOMERS VALUES (@FirstName, @LastName, @Phone_Number, @Address, @Login, @Password, GETDATE(), @Fk_Id_Cities); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@FirstName", customers.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", customers.LastName);
                    cmd.Parameters.AddWithValue("@Phone_Number", customers.Phone_Number);
                    cmd.Parameters.AddWithValue("@Address", customers.Address);
                    cmd.Parameters.AddWithValue("@Login", customers.Login);
                    cmd.Parameters.AddWithValue("@Password", customers.Password);
                    cmd.Parameters.AddWithValue("@Fk_Id_Cities", customers.Fk_Id_Cities);

                    cn.Open();

                    customers.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customers;
        }

        public byte CheckExistingCUSTOMERS(string login)
        {
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM CUSTOMERS where Login = @login";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@login", login);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            if (dr["Id"] != DBNull.Value)
                                return 0;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return 1;
        }

        public CUSTOMERS GetCUSTOMERS(string login)
        {
            CUSTOMERS customers = null;
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM CUSTOMERS where Login = @login";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@login", login);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            customers = new CUSTOMERS();

                            if (dr["Id"] != DBNull.Value)
                                customers.Id = (int)dr["Id"];

                            if (dr["FirstName"] != DBNull.Value)
                                customers.FirstName = (string)dr["FirstName"];

                            if (dr["LastName"] != DBNull.Value)
                                customers.LastName = (string)dr["LastName"];

                            if (dr["Phone_Number"] != DBNull.Value)
                                customers.Phone_Number = (string)dr["Phone_Number"];

                            if (dr["Address"] != DBNull.Value)
                                customers.Address = (string)dr["Address"];

                            if (dr["Login"] != DBNull.Value)
                                customers.Login = (string)dr["Login"];

                            if (dr["Password"] != DBNull.Value)
                                customers.Password = (string)dr["Password"];

                            if (dr["Created_At"] != DBNull.Value)
                                customers.Created_At = (DateTime)dr["Created_At"];

                            if (dr["Fk_Id_Cities"] != DBNull.Value)
                                customers.Fk_Id_Cities = (int)dr["Fk_Id_Cities"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customers;
        }
    }

}
