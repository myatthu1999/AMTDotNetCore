using System;
using System.Collections.Generic;
using System.Data;
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

        public void Edit()
        {
            Console.WriteLine("Blog Id :");
            string id = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId",id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

        if(dt.Rows.Count == 0)
            {
                Console.WriteLine("no data found");
                return;
            }

            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);
        }

        public void Update()
        {
            Console.WriteLine("BlogId: ");
            string id = Console.ReadLine();

            Console.WriteLine("BlogTitle: ");
            string title = Console.ReadLine();

            Console.WriteLine("BlogAuthor: ");
            string author = Console.ReadLine();

            Console.WriteLine("BlogContent: ");
            string content = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
      ,[DeleteFlag] = 0
 WHERE BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query,connection);

            cmd.Parameters.AddWithValue("@BlogId",id);
            cmd.Parameters.AddWithValue("@BlogTitle",title);
            cmd.Parameters.AddWithValue("@BlogAuthor",author);
            cmd.Parameters.AddWithValue("@BlogContent",content);
            int result = cmd.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine(result == 1 ? "update success" : "not update success");
        }

        public void Delete()
        {
            Console.WriteLine("BlogId: ");
            string id = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = $@"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);

            int result = cmd.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine(result == 1 ? "delete success" : "not delete success");
        }
    }
}
