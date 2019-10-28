using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class BILLS_DB : I_BILLS_DB
    {
        public IConfiguration Config { get; }

        public BILLS_DB(IConfiguration config)
        {
            Config = config;
        }

        public BILLS AddBILLS(BILLS bills)
        {
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO BILLS (Billing_Date, Amount, Created_At) VALUES (GETDATE(), @Amount, GETDATE()); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Amount", bills.Amount);
                    cn.Open();

                    bills.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return bills;
        }


        public BILLS GetBILLS(int Id)
        {
            BILLS bills = null;
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM BILLS WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", Id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            bills = new BILLS();

                            if (dr["Id"] != DBNull.Value)
                                bills.Id = (int)dr["Id"];

                            if (dr["Billing_Date"] != DBNull.Value)
                                bills.Billing_Date = (DateTime)dr["Billing_Date"];

                            if (dr["Payment_Date"] != DBNull.Value)
                                bills.Payment_Date = (DateTime)dr["Payment_Date"];

                            if (dr["Amount"] != DBNull.Value)
                                bills.Amount = (double)dr["Amount"];

                            if (dr["Created_At"] != DBNull.Value)
                                bills.Created_At = (DateTime)dr["Created_At"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return bills;
        }

        public BILLS UpdateBILLS_Payment_Date(BILLS bills)
        {
            string connectionString = Config.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE BILLS SET Payment_Date=GETDATE() WHERE Id=@Id;";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Id", bills.Id);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return bills;
        }
    }
}
