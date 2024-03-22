using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace library
{
    public class CADProduct
    {
        private String constring;
        public CADProduct()
        {
            constring = "Database.mdf";
        }

        public bool Create(ENProduct en)
        {
            bool done;
            SqlConnection conn = null;
            String comando = "Insert INTO [dbo].[Products] (id, name, code, amount, price, category, creationDate) VALUES ('" + en.Name + "', '" + en.Code + "', " + en.Amount + "', '" + en.Price + "', '" + en.CreationDate + ")";
            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand cmd = new SqlCommand(comando, conn);
                comando.ExecuteNonQuery();
                done = true;
                conn.Close();
            }
            catch (SqlException e)
            {
                done = false;
                throw new CADException("Error inserting a product: " + en.Name, e);
            }
            catch (Exception e)
            {
                done = false;
                throw e;
            }
            finally
            {
                if (conn != null) conn.Close();
                return done;

            }
        }

    }

        public bool Update(ENProduct en)
        {

        }

        public bool Delete(ENProduct en)
        {

        }

        public bool Read(ENProduct en)
        {

        }

        public bool ReadFirst(ENProduct en)
        {

        }

        public bool ReadNext(ENProduct en)
        {

        }

        public bool ReadPrev(ENProduct en)
        {

        }
    }
}
