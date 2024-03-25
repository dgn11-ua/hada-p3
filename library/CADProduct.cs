using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

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
                cmd.ExecuteNonQuery();
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

            }
            return done;
        }



        public bool Update(ENProduct en)
        {

        }

        public bool Delete(ENProduct en)
        {
            SqlConnection conn = null;

            String comando = "Delete from Product where name= " + en.Name;
            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand cmd = new SqlCommand(comando, conn);


                cmd.ExecuteNonQuery();
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Error deleting a product: " + en.Name, sqlex);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }

        }

        public bool Read(ENProduct en)
        {
            SqlConnection conn = null;
            DataSet dsProduct = null;
            string comando = "Select * from Product where name= " + en.Name;
            try
            {
                conn = new SqlConnection(constring);
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(comando, conn);
                dsProduct = new DataSet();
                sqlAdaptador.Fill(dsProduct);
                return dsProduct;
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Error reading a product: " + en.Name, sqlex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }

        }

        public bool ReadFirst(ENProduct en)
        {
            SqlConnection conn = null;
            DataSet dsProduct = null;
            string comando = "SELECT TOP 1 * FROM Product WHERE name = '" + en.Name + "' ORDER BY ProductID";
            try
            {
                conn = new SqlConnection(constring);
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(comando, conn);
                dsProduct = new DataSet();
                sqlAdaptador.Fill(dsProduct);
                return dsProduct;
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Error reading a product: " + en.Name, sqlex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }

        }

        public bool ReadNext(ENProduct en)
        {
            public bool ReadNext(ENProduct en)
            {
                SqlConnection conn = null;
                DataSet dsProduct = null;

                string comando = "SELECT TOP 1 * FROM Product WHERE ProductID > " + en.ProductID + " ORDER BY ProductID ASC";

                try
                {
                    conn = new SqlConnection(constring);
                    SqlDataAdapter sqlAdapter = new SqlDataAdapter(comando, conn);
                    dsProduct = new DataSet();
                    sqlAdapter.Fill(dsProduct);
                    return dsProduct;
                }
                catch (SqlException sqlex)
                {
                    throw new CADException("Error reading the next product after: " + en.Name, sqlex);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn != null) conn.Close();
                }
            }


        }
        public bool ReadPrev(ENProduct en)
        {
            SqlConnection conn = null;
            DataSet dsProduct = null;

            string comando = "SELECT TOP 1 * FROM Product WHERE ProductID < " + en.ProductID + " ORDER BY ProductID DESC";

            try
            {
                conn = new SqlConnection(constring);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(comando, conn);
                dsProduct = new DataSet();
                sqlAdapter.Fill(dsProduct);
                return dsProduct;
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Error reading the previous product to: " + en.Name, sqlex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
        }

    }
}