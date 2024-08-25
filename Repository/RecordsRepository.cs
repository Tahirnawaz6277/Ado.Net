using CRUDInADO.NET.Models;
using System.Data.SqlClient;

namespace CRUDInADO.NET.Repository
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly IConfiguration _configuration;

        public PromotionRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void AddRecords(Records records)
        {
            var connectionstring = _configuration.GetConnectionString("DefaultConnection");

            using (var con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("AddRecords", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name" ,records.Name);
                cmd.Parameters.AddWithValue("@Address",records.ADDRESS);
                cmd.Parameters.AddWithValue ("@City",records.CITY);
                con.Open();
                cmd.ExecuteNonQuery();
    
                
            }
        }

        public void DeleteRecordsAsync(int id)
        {
            var connectionstring = _configuration.GetConnectionString("DefaultConnection");
            //int id = records;
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                //var query = "Delete FROM RECORDS WHERE Id=id";
                SqlCommand cmd = new SqlCommand("DeleteRecord", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();

               cmd.ExecuteReader();

            }



        }

        public List<Records> GetRecordsAsync()
        {
            var connection = _configuration.GetConnectionString("DefaultConnection");
           List<Records> records = new List<Records>(); 
            using (var con = new SqlConnection(connection))
            {
                SqlCommand cmd = new SqlCommand("GetRecords", con);
                cmd.CommandType=System.Data.CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //Console.WriteLine("Id:{0},Name:{1},Address{2},City{3}",
                    //    reader["Id"], reader["Name"], reader["Address"], reader["City"]
                    //    );

                    Records data = new Records();
                    data.Id = (int)reader["Id"];
                    data.Name = (string)reader["Name"];
                    data.ADDRESS = (string)reader["Address"];
                    data.CITY = (string)reader["City"];
                    records.Add(data);
                }
                
              
            }
            return records;
        }
        public Records GetRecordById(int id)
        {
            var connectionstring = _configuration.GetConnectionString("DefaultConnection");
            Records data = new Records();
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd =new SqlCommand("GetRecordById", con);
                cmd.CommandType= System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();

               SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    data.Id = (int)reader["Id"];
                    data.Name = (string)reader["Name"];
                    data.ADDRESS = (string)reader["Address"];
                    data.CITY = (string)reader["City"];

                }

            }
            return data;
        }
        
        public Records UpdateRecords(Records records)
        {
            var Connectionstring = _configuration.GetConnectionString("DefaultConnection");
            Records data = new Records();
            using (var connection = new SqlConnection(Connectionstring))
            {
             
                SqlCommand cmd = new SqlCommand("UpdateRecord", connection);
                cmd.CommandType=System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id",records.Id);
                cmd.Parameters.AddWithValue("@Name", records.Name);
                cmd.Parameters.AddWithValue("@Address", records.ADDRESS);
                cmd.Parameters.AddWithValue("@City", records.CITY);
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    data.Id = (int)reader["Id"];
                    data.Name = (string)reader["Name"];
                    data.ADDRESS = (string)reader["Address"];
                    data.CITY = (string)reader["City"];
                   
                }
               
            }
            return data;


        }
    }
}