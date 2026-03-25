using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace library
{
    public class CADCategory
    {
        private string constring;

        public CADCategory()
        {
            constring = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
        }

        // Lee una categoría específica por su ID
        public bool read(ENCategory en)
        {
            bool success = false;
            try
            {
                using (SqlConnection c = new SqlConnection(constring))
                {
                    c.Open();
                    string sql = "SELECT name FROM Categories WHERE id = @id";
                    SqlCommand com = new SqlCommand(sql, c);
                    com.Parameters.AddWithValue("@id", en.Id);

                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        en.Name = dr["name"].ToString();
                        success = true;
                    }
                    dr.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Category operation has failed. Error: {0}", ex.Message);
                success = false;
            }
            return success;
        }

        public List<ENCategory> readAll()
        {
            List<ENCategory> lista = new List<ENCategory>();
            try
            {
                using (SqlConnection c = new SqlConnection(constring))
                {
                    c.Open();
                    string sql = "SELECT id, name FROM Categories";
                    SqlCommand com = new SqlCommand(sql, c);
                    SqlDataReader dr = com.ExecuteReader();

                    while (dr.Read())
                    {
                        ENCategory cat = new ENCategory();
                        cat.Id = int.Parse(dr["id"].ToString());
                        cat.Name = dr["name"].ToString();
                        lista.Add(cat);
                    }
                    dr.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Category operation has failed. Error: {0}", ex.Message);
            }
            return lista;
        }
    }
}