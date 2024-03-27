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
        
        public class CADException : Exception
        {
            public CADException()
            {
            }

            public CADException(string message)
                : base(message)
            {
            }

            public CADException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }
    

        private String constring;
        public CADProduct()
        {
            constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dgn11\source\repos\Git\hada-p3\proWeb\App_Data\Database.mdf;Integrated Security=True";
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
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection(constring);
                conn.Open();

                string comando = "UPDATE Products SET name = @Name, code = @Code, amount = @Amount, price = @Price, category = @Category, creationDate = @CreationDate WHERE id = @ID";

                SqlCommand cmd = new SqlCommand(comando, conn);

                cmd.Parameters.AddWithValue("@ID", en.ID);
                cmd.Parameters.AddWithValue("@Name", en.Name);
                cmd.Parameters.AddWithValue("@Code", en.Code);
                cmd.Parameters.AddWithValue("@Amount", en.Amount);
                cmd.Parameters.AddWithValue("@Price", en.Price);
                cmd.Parameters.AddWithValue("@Category", en.Category);
                cmd.Parameters.AddWithValue("@CreationDate", en.CreationDate);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    return true;
                else
                    return false;
            }
            catch (SqlException sqlex)
            {
                throw new CADException("Error updating the product: " + en.Name, sqlex);
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


        public bool Delete(ENProduct en)
        {
            SqlConnection conn = null;

            String comando = "Delete from Product where name= " + en.Name;
            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand cmd = new SqlCommand(comando, conn);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    return true;
                else
                    return false;
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

        public DataSet Read(ENProduct en)
        {
            SqlConnection conn = null;
            DataSet dsProduct = null;
            string comando = "Select * from Product where name= @Name";
            try
            {
                conn = new SqlConnection(constring);
                SqlDataAdapter sqlAdaptador = new SqlDataAdapter(comando, conn);
                sqlAdaptador.SelectCommand.Parameters.AddWithValue("@Name", en.Name);
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



        public DataSet ReadFirst(ENProduct en)
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


        public DataSet ReadNext(ENProduct en)
        {
            SqlConnection conn = null;
            DataSet dsProduct = null;

            string comando = "SELECT TOP 1 * FROM Product WHERE Name > @Name ORDER BY Name ASC";

            try
            {
                conn = new SqlConnection(constring);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(comando, conn);
                sqlAdapter.SelectCommand.Parameters.AddWithValue("@Name", en.Name);
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

        public DataSet ReadPrev(ENProduct en)
        {
            SqlConnection conn = null;
            DataSet dsProduct = null;

            string comando = "SELECT TOP 1 * FROM Product WHERE Name < @Name ORDER BY Name DESC";

            try
            {
                conn = new SqlConnection(constring);
                SqlDataAdapter sqlAdapter = new SqlDataAdapter(comando, conn);
                sqlAdapter.SelectCommand.Parameters.AddWithValue("@Name", en.Name);
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