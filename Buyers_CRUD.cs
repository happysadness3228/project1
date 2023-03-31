using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WebApplication2.Models;
using System.Runtime.Remoting.Messaging;

namespace WebApplication2.CRUD
{
    public class Buyers_CRUD
    {
        string conString = ConfigurationManager.ConnectionStrings["adoConnectionstring"].ToString();

        //Get all buyers
        public List<Buyers> GetAllBuyers()
        {
            List<Buyers> buyersList = new List<Buyers>();
                using (SqlConnection connection=new SqlConnection(conString))
            {
                SqlCommand command=connection.CreateCommand();  
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetAllBuyers";
                SqlDataAdapter sqlDA=new   SqlDataAdapter(command);
                DataTable dtBuyers = new DataTable();

                connection.Open();
                sqlDA.Fill(dtBuyers);   
                connection.Close();

                foreach (DataRow dr in dtBuyers.Rows) 
                {
                    buyersList.Add(new Buyers()
                    {
                        id= Convert.ToInt32(dr["id"]),
                        name = dr["name"].ToString(),
                        surname = dr["surname"].ToString(),
                        adress = dr["adress"].ToString(),
                        index_mail = Convert.ToInt32(dr["index_mail"]),
                        phone = dr["phone"].ToString(),


                    });
                }
            }
                return buyersList;
        }

        // insert all buyers
        public bool InsertBuyers(Buyers buyers)
        {
            int id = 10;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command= new SqlCommand("sp_InsertBuyers",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", buyers.id);
                command.Parameters.AddWithValue("@name",buyers.name);
                command.Parameters.AddWithValue("@surname", buyers.surname);
                command.Parameters.AddWithValue("@adress", buyers.adress);
                command.Parameters.AddWithValue("@index_mail", buyers.index_mail);
                command.Parameters.AddWithValue("@phone", buyers.phone);

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
        public List<Buyers> GetBuyersById(int id)
        {
            List<Buyers> buyersList = new List<Buyers>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetBuyerById";
                command.Parameters.AddWithValue ("@id", id); 
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtBuyers = new DataTable();

                connection.Open();
                sqlDA.Fill(dtBuyers);
                connection.Close();

                foreach (DataRow dr in dtBuyers.Rows)
                {
                    buyersList.Add(new Buyers()
                    {
                        id = Convert.ToInt32(dr["id"]),
                        name = dr["name"].ToString(),
                        surname = dr["surname"].ToString(),
                        adress = dr["adress"].ToString(),
                        index_mail = Convert.ToInt32(dr["index_mail"]),
                        phone = dr["phone"].ToString(),


                    });
                }
            }
            return buyersList;
        }

        // update all buyers
        public bool UpdateBuyers(Buyers buyers)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_UpdateBuyers", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", buyers.id);
                command.Parameters.AddWithValue("@name", buyers.name);
                command.Parameters.AddWithValue("@surname", buyers.surname);
                command.Parameters.AddWithValue("@adress", buyers.adress);
                command.Parameters.AddWithValue("@index_mail", buyers.index_mail);
                command.Parameters.AddWithValue("@phone", buyers.phone);

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

        public string DeleteBuyers(int id)
        {
            string result = "";
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_deletebuyers",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id",id);
                command.Parameters.Add("@outputmessage", SqlDbType.VarChar,50).Direction=ParameterDirection.Output;

                connection.Open();
                command.ExecuteNonQuery();
                result = command.Parameters["@outputmessage"].Value.ToString();
                connection.Close();
                    }



                return result;
        }
    }
}