using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ManagementPacientiMedicFam.Models
{
    public class CommonFn
    {
        public class Commonfnx
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MedicCS"].ConnectionString);
            public void Query(string query, Dictionary<string, object> parameters = null)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Adăugați parametrii dacă există
                    if (parameters != null)
                    {
                        foreach (KeyValuePair<string, object> parameter in parameters)
                        {
                            // Aici puteți verifica tipul parametrului și seta tipul de date corespunzător
                            SqlParameter param = new SqlParameter(parameter.Key, SqlDbType.VarChar); // Schimbați tipul de date dacă este necesar
                            param.Value = parameter.Value;
                            cmd.Parameters.Add(param);
                        }
                    }

                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }


            public DataTable Fetch(string query, Dictionary<string, object> parameters = null)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        foreach (KeyValuePair<string, object> parameter in parameters)
                        {
                            // Aici puteți verifica tipul parametrului și seta tipul de date corespunzător
                            SqlParameter param = new SqlParameter(parameter.Key, SqlDbType.VarChar); // Schimbați tipul de date dacă este necesar
                            param.Value = parameter.Value;
                            cmd.Parameters.Add(param);
                        }
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }



            public void Update(string query, SqlParameter[] parameters)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddRange(parameters);
                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }

            public void Delete(string query, SqlParameter[] parameters)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddRange(parameters);
                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }

            public void Insert(string query, SqlParameter[] parameters)
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddRange(parameters);
                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
            
        }
    }
}