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
            String comando = "Insert INTO [dbo].[Products] (name, code, amount, price, category, creationDate) VALUES ('"+en.Name + "', '" + en.Code + "', " + en.Amount + "', '" + en.Price + "', '" + en.CreationDate + ")";
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
                Console.WriteLine("Error inserting a product: " + en.Name, e);
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
            string comando = "UPDATE Products SET name = @Name, code = @Code, amount = @Amount, price = @Price, category = @Category, creationDate = @CreationDate WHERE id = @ID";


            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand cmd = new SqlCommand(comando, conn);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("Error updating the product: " + en.Name, sqlex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return false;
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
                return true;
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("Error deleting a product: " + en.Name, sqlex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return false;

        }

        public bool Read(ENProduct en)
        {
            SqlConnection conn = null;
            string comando = "Select * from Product where name=" + en.Name + ";";
            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand cmd = new SqlCommand(comando, conn);
                cmd.ExecuteNonQuery();

                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    en.SetCode = dataReader["Code"].ToString();
                    en.SetName = dataReader["Name"].ToString();
                    en.SetAmount = int.Parse(dataReader["Amount"].ToString());
                    en.SetPrice = float.Parse(dataReader["Price"].ToString());
                    en.SetDate = DateTime.Parse(dataReader["CreationDate"].ToString());

                    dataReader.Close();


                }
                else
                {
                    dataReader.Close();
                    return false;
                }

            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("Error reading a product: " + en.Name, sqlex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return false;
        }



        public bool ReadFirst(ENProduct en)
        {
            SqlConnection conn = null;
            
            string comando = "SELECT * FROM Product WHERE name = '" + en.Name + "' ORDER BY ProductID";

            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand cmd = new SqlCommand(comando, conn);
                cmd.ExecuteNonQuery();

                SqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    en.SetCode = dataReader["Code"].ToString();
                    en.SetName = dataReader["Name"].ToString();
                    en.SetAmount = int.Parse(dataReader["Amount"].ToString());
                    en.SetPrice = float.Parse(dataReader["Price"].ToString());
                    en.SetDate = DateTime.Parse(dataReader["CreationDate"].ToString());
                    dataReader.Close();


                }
                else
                {
                    dataReader.Close();
                    return false;
                }
            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("Error reading a product: " + en.Name, sqlex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return false;
        }


        public bool ReadNext(ENProduct en)
        {
            bool done=false;
            string firstName = "";
            SqlConnection conn = null;

            string comando = "SELECT * FROM Product WHERE Name = "+en.Name+" ORDER BY Name DESC";

            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand cmd = new SqlCommand(comando, conn);
                cmd.ExecuteNonQuery();

                SqlDataReader dataReader = cmd.ExecuteReader();
                ENProduct enb = new ENProduct();

                while (dataReader.Read())
                {
                    if (done == false)
                    {
                        firstName = dataReader["Name"].ToString();
                        done = true;
                    }
                    if (dataReader["Name"].ToString()!= en.SetName)
                    {
                        enb.SetCode = dataReader["Code"].ToString();
                        enb.SetName = dataReader["Name"].ToString();
                        enb.SetAmount = int.Parse(dataReader["Amount"].ToString());
                        enb.SetPrice = float.Parse(dataReader["Price"].ToString());
                        enb.SetDate = DateTime.Parse(dataReader["CreationDate"].ToString());
                    }
                    else
                    {
                        if(firstName == dataReader["Name"].ToString())
                        {
                            en.SetCode = dataReader["Code"].ToString();
                            en.SetName = dataReader["Name"].ToString();
                            en.SetAmount = int.Parse(dataReader["Amount"].ToString());
                            en.SetPrice = float.Parse(dataReader["Price"].ToString());
                            en.SetDate = DateTime.Parse(dataReader["CreationDate"].ToString());
                            return false;
                        }
                        en.SetCode = enb.SetCode;
                        en.SetName = enb.SetName;
                        en.SetAmount = enb.SetAmount;
                        en.SetPrice = enb.SetPrice;
                        en.SetDate = enb.SetDate;
                        return true;
                    }
                }
                dataReader.Close();
                return false;

            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("Error reading the next product : " + en.Name, sqlex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return false;
        }

        public bool ReadPrev(ENProduct en)
        {
            bool done = false;
            string firstName = "";
            SqlConnection conn = null;

            string comando = "SELECT * FROM Product WHERE Name = " + en.Name + " ;";

            try
            {
                conn = new SqlConnection(constring);
                conn.Open();
                SqlCommand cmd = new SqlCommand(comando, conn);
                cmd.ExecuteNonQuery();

                SqlDataReader dataReader = cmd.ExecuteReader();
                ENProduct enb = new ENProduct();

                while (dataReader.Read())
                {
                    if (done == false)
                    {
                        firstName = dataReader["Name"].ToString();
                        done = true;
                    }
                    if (dataReader["Name"].ToString() != en.SetName)
                    {
                        enb.SetCode = dataReader["Code"].ToString();
                        enb.SetName = dataReader["Name"].ToString();
                        enb.SetAmount = int.Parse(dataReader["Amount"].ToString());
                        enb.SetPrice = float.Parse(dataReader["Price"].ToString());
                        enb.SetDate = DateTime.Parse(dataReader["CreationDate"].ToString());
                    }
                    else
                    {
                        if (firstName == dataReader["Name"].ToString())
                        {
                            en.SetCode = dataReader["Code"].ToString();
                            en.SetName = dataReader["Name"].ToString();
                            en.SetAmount = int.Parse(dataReader["Amount"].ToString());
                            en.SetPrice = float.Parse(dataReader["Price"].ToString());
                            en.SetDate = DateTime.Parse(dataReader["CreationDate"].ToString());
                            return false;
                        }
                        en.SetCode = enb.SetCode;
                        en.SetName = enb.SetName;
                        en.SetAmount = enb.SetAmount;
                        en.SetPrice = enb.SetPrice;
                        en.SetDate = enb.SetDate;
                        return true;
                    }
                }
                dataReader.Close();
                return false;

            }
            catch (SqlException sqlex)
            {
                Console.WriteLine("Error reading the next product : " + en.Name, sqlex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }
            return false;
        }


    }
}