using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace library
{
    public class CADCategory
    {
        private string constring;
        public CADCategory()
        {
            constring = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        }
        /*public bool read(ENCategory en) {
           

        }*/

        public List<ENCategory> readAll()
        {
            string query = "SELECT Nombre FROM Categorias;";
            List<ENCategory> categories = new List<ENCategory>();
            
            using (SqlConnection connection = new SqlConnection(constring))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                // Ejecuta la consulta y lee los resultados
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Crea una nueva instancia de ENCategory y la agrega a la lista
                        ENCategory categoria = new ENCategory(reader["Nombre"].ToString());
                        categories.Add(categoria);
                    }
                }
            }

            return categories;
        }
    }
}
