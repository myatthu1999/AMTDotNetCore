using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMTDotNetCore.ConsoleApp
{
    public class AdoDotNetExample
    {   
        private readonly string _connectionString = "Data Source=.;Initial Catalog=AMTDotNetCore;User ID=sa;Password=sasa@123;";

        public void Read()
        {

            SqlConnection connection = new SqlConnection(_connectionString);
            Console.WriteLine("connection string :" + _connectionString);

            Console.WriteLine("connection opening...");
            connection.Open();
            Console.WriteLine("connection opened");

            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where DeleteFlag = 0";

            SqlCommand cmd = new SqlCommand(query, connection);
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            //DataTable dt = new DataTable();
            //adapter.Fill(dt);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader["BlogId"]);
                Console.WriteLine(reader["BlogTitle"]);
                Console.WriteLine(reader["BlogAuthor"]);
                Console.WriteLine(reader["BlogContent"]);
            }

            Console.WriteLine("connection closing...");
            connection.Close();
            Console.WriteLine("connection closed");

        }

        public void Create()
        {
            Console.WriteLine("BlogTitle :");
            string title = Console.ReadLine();

            Console.WriteLine("BlogAuthor :");
            string author = Console.ReadLine();

            Console.WriteLine("BlogContent :");
            string content = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();


            //string queryInsert = $@"INSERT INTO [dbo].[Tbl_Blog]
            //           ([BlogTitle]
            //           ,[BlogAuthor]
            //           ,[BlogContent]
            //           ,[DeleteFlag])
            //     VALUES
            //           ('{title}'
            //           ,'{author}'
            //           ,'{content}'
            //           ,0)";

            string queryInsert = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent
           ,0)";

            SqlCommand cmd = new SqlCommand(queryInsert, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            //SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine(result == 1 ? "created successful" : "not successful");

        }
    }
}
