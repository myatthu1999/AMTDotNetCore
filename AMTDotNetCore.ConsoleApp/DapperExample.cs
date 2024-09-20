using AMTDotNetCore.ConsoleApp.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMTDotNetCore.ConsoleApp
{
    public class DapperExample
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=AMTDotNetCore;User ID=sa;Password=sasa@123;";

        public void Read()
        {
            //using (IDbConnection db = new SqlConnection(_connectionString))
            //{
            //    string query = "select * from tbl_blog where DeleteFlag = 0;";
            //    var lst = db.Query(query).ToList();

            //    foreach (var item in lst) {
            //        Console.WriteLine(item.BlogId);
            //        Console.WriteLine(item.BlogTitle);
            //        Console.WriteLine(item.BlogAuthor);
            //        Console.WriteLine(item.BlogContent);
            //    }
            //}

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "select * from tbl_blog where DeleteFlag = 0;";
                var lst = db.Query<BlogDataModel>(query).ToList();

                foreach (var item in lst)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }
            }


        }

        public void Create(string title, string author, string content)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = $@"INSERT INTO [dbo].[Tbl_Blog]
               ([BlogTitle]
               ,[BlogAuthor]
               ,[BlogContent]
               ,[DeleteFlag])
         VALUES
               (@BlogTitle
               ,@BlogAuthor
               ,@BlogContent
               ,0)";

                int result = db.Execute(query, new BlogDataModel
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content

                });

                Console.WriteLine(result == 1 ? "create success" : "create failed");
            }
        }

        public void Edit(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = $@"select * from tbl_blog where DeleteFlag = 0 and BlogId = @BlogId";
                var item = db.Query<BlogDataModel>(query, new BlogDataModel
                {
                    BlogId = id
                }).FirstOrDefault();
                if (item is null)
                {
                    Console.WriteLine("no data found");
                    return;
                }
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        public void Update(int id,string title,string author,string content)
        {
            using(IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
      ,[DeleteFlag] = 0
 WHERE BlogId = @BlogId";
                int result = db.Execute(query, new BlogDataModel
                {
                    BlogId = id,
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content,
                });

                Console.WriteLine( result == 1 ? "update success" : "update failed");

            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
               string query = $@"UPDATE [dbo].[Tbl_Blog]
               SET [DeleteFlag] = 1
             WHERE BlogId = @BlogId";

               int result =  db.Execute(query, new BlogDataModel
                {
                    BlogId = id,
                });

                Console.WriteLine(result == 1 ? "delete success" : "not deleted");
            }
        }
    }
}
