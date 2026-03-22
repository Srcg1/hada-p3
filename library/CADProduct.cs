using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class CADProduct
    {
        private string constring;

        public CADProduct()
        {
            // Carga la cadena de conexión desde el Web.config del proyecto proWeb
            // El nombre "DatabaseConnectionString" tiene que coincidir con el de Web.config
            constring = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ToString();
        }

        public bool create(ENProduct en)
        {
            bool success = false;
            try
            {
                using (SqlConnection c = new SqlConnection(constring))
                {
                    c.Open();
                    // Usamos parámetros (@) para evitar inyecciones SQL
                    string sql = "INSERT INTO Products (name, code, amount, price, category, creationDate) VALUES (@name, @code, @amount, @price, @category, @creationDate)";
                    SqlCommand com = new SqlCommand(sql, c);

                    com.Parameters.AddWithValue("@name", en.Name);
                    com.Parameters.AddWithValue("@code", en.Code);
                    com.Parameters.AddWithValue("@amount", en.Amount);
                    com.Parameters.AddWithValue("@price", en.Price);
                    com.Parameters.AddWithValue("@category", en.Category);
                    com.Parameters.AddWithValue("@creationDate", en.CreationDate);

                    com.ExecuteNonQuery();
                    success = true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                success = false;
            }
            return success;
        }

        public bool read(ENProduct en)
        {
            bool success = false;
            try
            {
                using (SqlConnection c = new SqlConnection(constring))
                {
                    c.Open();
                    string sql = "SELECT * FROM Products WHERE code = @code";
                    SqlCommand com = new SqlCommand(sql, c);
                    com.Parameters.AddWithValue("@code", en.Code);

                    SqlDataReader dr = com.ExecuteReader();
                    if (dr.Read())
                    {
                        en.Name = dr["name"].ToString();
                        en.Amount = int.Parse(dr["amount"].ToString());
                        en.Price = float.Parse(dr["price"].ToString());
                        en.Category = int.Parse(dr["category"].ToString());
                        en.CreationDate = DateTime.Parse(dr["creationDate"].ToString());
                        success = true;
                    }
                    dr.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                success = false;
            }
            return success;
        }

        // Implementar update(), delete(), readFirst(), readNext(), readPrev()
        // siguiendo esta misma estructura de try-catch y SqlConnection.

        public bool update(ENProduct en) { throw new NotImplementedException(); }
        public bool delete(ENProduct en) { throw new NotImplementedException(); }
        public bool readFirst(ENProduct en) { throw new NotImplementedException(); }
        public bool readNext(ENProduct en) { throw new NotImplementedException(); }
        public bool readPrev(ENProduct en) { throw new NotImplementedException(); }
    }
}
