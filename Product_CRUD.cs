using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WebApplication2.Models;

namespace WebApplication2.CRUD
{
    public class Product_CRUD
    {
        string conString = ConfigurationManager.ConnectionStrings["adoConnectionstring"].ToString();

        //Get all buyers
        public List<Product> GetAllProduct()
        {
            List<Product> productList = new List<Product>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetAllProduct";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtProduct = new DataTable();

                connection.Open();
                sqlDA.Fill(dtProduct);
                connection.Close();

                foreach (DataRow dr in dtProduct.Rows)
                {
                    productList.Add(new Product()
                    {
                        id = Convert.ToInt32(dr["id"]),
                        article = dr["article"].ToString(),
                        name = dr["name"].ToString(),
                        price = dr["price"].ToString(),
                        size = dr["size"].ToString(),
                        color = dr["color"].ToString(),
                        categories_id = Convert.ToInt32(dr["categories_id"]),
                        recept_of_products_id = Convert.ToInt32(dr["recept_of_products_id"]),

                    });
                }
            }
            return productList;
        }

        // insert all buyers
        public bool InsertProduct(Product product)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_InsertProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", product.id);
                command.Parameters.AddWithValue("@article", product.article);
                command.Parameters.AddWithValue("@name", product.name);
                command.Parameters.AddWithValue("@price", product.price);
                command.Parameters.AddWithValue("@size", product.size);
                command.Parameters.AddWithValue("@color", product.color);
                command.Parameters.AddWithValue("@categories_id", product.categories_id);
                command.Parameters.AddWithValue("@recept_of_products_id", product.recept_of_products_id);

                connection.Open();
                id = command.ExecuteNonQuery();
                connection.Close();

            }
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Get  buyers by buyers id
        public List<Product> GetProductById(int id)
        {
            List<Product> productList = new List<Product>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetProductById";
                command.Parameters.AddWithValue("@id",id);  
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtProduct = new DataTable();

                connection.Open();
                sqlDA.Fill(dtProduct);
                connection.Close();

                foreach (DataRow dr in dtProduct.Rows)
                {
                    productList.Add(new Product()
                    {
                        id = Convert.ToInt32(dr["id"]),
                        article = dr["article"].ToString(),
                        name = dr["name"].ToString(),
                        price = dr["price"].ToString(),
                        size = dr["size"].ToString(),
                        color = dr["color"].ToString(),
                        categories_id = Convert.ToInt32(dr["categories_id"]),
                        recept_of_products_id = Convert.ToInt32(dr["recept_of_products_id"]),


                    });
                }
            }
            return productList;
        }

        // update all buyers
        public bool UpdateProduct(Product product)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_UpdateProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", product.id);
                command.Parameters.AddWithValue("@article", product.article);
                command.Parameters.AddWithValue("@name", product.name);
                command.Parameters.AddWithValue("@price", product.price);
                command.Parameters.AddWithValue("@size", product.size);
                command.Parameters.AddWithValue("@color", product.color);
                command.Parameters.AddWithValue("@categories_id", product.categories_id);
                command.Parameters.AddWithValue("@recept_of_products_id", product.recept_of_products_id);

                connection.Open();
                i = command.ExecuteNonQuery();
                connection.Close();

            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // delete buyers

        public string DeleteProduct(int id)
        {
            string result = "";
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_deleteproduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.Add("@outputmessage", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

                connection.Open();
                command.ExecuteNonQuery();
                result = command.Parameters["@outputmessage"].Value.ToString();
                connection.Close();
            }



            return result;
        }
    }
}