using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ConsoleApp2
{
    public class ProductDA
    {
        string connStr;

        public ProductDA()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            connStr = config.GetConnectionString("DefaultConnection");
        }

        // INSERT
        public void InsertProduct(string name, string category, decimal price)
        {
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("sp_InsertProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@ProductName", SqlDbType.VarChar, 100);
            p1.Value = name;

            SqlParameter p2 = new SqlParameter("@Category", SqlDbType.VarChar, 50);
            p2.Value = category;

            SqlParameter p3 = new SqlParameter("@Price", SqlDbType.Decimal);
            p3.Value = price;

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Console.WriteLine("Product Inserted");
        }

        // VIEW
        public void ViewProducts()
        {
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("sp_GetAllProducts", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr["ProductId"]}  {dr["ProductName"]}  {dr["Category"]}  {dr["Price"]}");
            }

            conn.Close();
        }

        // UPDATE
        public void UpdateProduct(int id, string name, string category, decimal price)
        {
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("sp_UpdateProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@ProductId", SqlDbType.Int);
            p1.Value = id;

            SqlParameter p2 = new SqlParameter("@ProductName", SqlDbType.VarChar, 100);
            p2.Value = name;

            SqlParameter p3 = new SqlParameter("@Category", SqlDbType.VarChar, 50);
            p3.Value = category;

            SqlParameter p4 = new SqlParameter("@Price", SqlDbType.Decimal);
            p4.Value = price;

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Console.WriteLine("Product Updated");
        }

        // DELETE
        public void DeleteProduct(int id)
        {
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("sp_DeleteProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@ProductId", SqlDbType.Int);
            p1.Value = id;

            cmd.Parameters.Add(p1);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            Console.WriteLine("Product Deleted");
        }

            public void GetProductById(int id)
            {
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand cmd = new SqlCommand("sp_GetProductDetailsById", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter("@ProductId", SqlDbType.Int);
            p1.Value = id;

            cmd.Parameters.Add(p1);

            conn.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Console.WriteLine("\nProduct Found:");
                Console.WriteLine($"Id : {dr["ProductId"]}");
                Console.WriteLine($"Name : {dr["ProductName"]}");
                Console.WriteLine($"Category : {dr["Category"]}");
                Console.WriteLine($"Price : {dr["Price"]}");
            }
            else
            {
                Console.WriteLine("Product Details Not Found");
            }

            conn.Close();
        }
    }
    }
