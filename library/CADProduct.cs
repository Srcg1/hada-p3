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
            //SqlConnection c = new SqlConnection(constring)
            try
            {
                using (SqlConnection c = new SqlConnection(constring)) //esta linea se quita por lo comentado
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
            //finally{
                //c.Close()
            //}
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

        public bool update(ENProduct en)
        {
            bool success = false;
            try
            {
                using (SqlConnection c = new SqlConnection(constring))
                {
                    c.Open();
                    // Consulta SQL para actualizar los campos del producto que coincida con el código
                    string sql = "UPDATE Products SET name=@name, amount=@amount, price=@price, category=@category, creationDate=@creationDate WHERE code=@code";
                    SqlCommand com = new SqlCommand(sql, c);

                    // Añadimos los parámetros igual que en el create
                    com.Parameters.AddWithValue("@name", en.Name);
                    com.Parameters.AddWithValue("@code", en.Code);
                    com.Parameters.AddWithValue("@amount", en.Amount);
                    com.Parameters.AddWithValue("@price", en.Price);
                    com.Parameters.AddWithValue("@category", en.Category);
                    com.Parameters.AddWithValue("@creationDate", en.CreationDate);

                    // ExecuteNonQuery devuelve el número de filas afectadas. Si es mayor que 0, se actualizó correctamente.
                    if (com.ExecuteNonQuery() > 0)
                    {
                        success = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                success = false;
            }
            return success;
        }

        public bool delete(ENProduct en)
        {
            bool success = false;
            try
            {
                using (SqlConnection c = new SqlConnection(constring))
                {
                    c.Open();
                    // Consulta SQL para borrar el producto que coincida con el código
                    string sql = "DELETE FROM Products WHERE code=@code";
                    SqlCommand com = new SqlCommand(sql, c);

                    com.Parameters.AddWithValue("@code", en.Code);

                    // Si devuelve más de 0 filas afectadas, se borró correctamente
                    if (com.ExecuteNonQuery() > 0)
                    {
                        success = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Product operation has failed. Error: {0}", ex.Message);
                success = false;
            }
            return success;
        }
        public bool readFirst(ENProduct en)
        {
            bool success = false;
            try
            {
                using (SqlConnection c = new SqlConnection(constring))
                {
                    c.Open();
                    // Seleccionamos el primer producto ordenado por código
                    string sql = "SELECT TOP 1 * FROM Products ORDER BY code ASC";
                    SqlCommand com = new SqlCommand(sql, c);
                    SqlDataReader dr = com.ExecuteReader();

                    if (dr.Read()) // Si encuentra un producto, rellenamos el objeto 'en'
                    {
                        en.Code = dr["code"].ToString();
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
        public bool readNext(ENProduct en)
        {
            bool success = false;
            try
            {
                using (SqlConnection c = new SqlConnection(constring))
                {
                    c.Open();
                    // Seleccionamos el primer producto cuyo código sea mayor al actual
                    string sql = "SELECT TOP 1 * FROM Products WHERE code > @code ORDER BY code ASC";
                    SqlCommand com = new SqlCommand(sql, c);
                    com.Parameters.AddWithValue("@code", en.Code);
                    SqlDataReader dr = com.ExecuteReader();

                    if (dr.Read())
                    {
                        en.Code = dr["code"].ToString();
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
        public bool readPrev(ENProduct en) { throw new NotImplementedException(); }
    }
}
