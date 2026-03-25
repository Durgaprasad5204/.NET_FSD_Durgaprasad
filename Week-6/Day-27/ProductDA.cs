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
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            connStr = config.GetConnectionString("DefaultConnection");
        }

        // INSERT
        public void InsertProduct(string name, string category, decimal price)
        {
            using SqlConnection conn = new SqlConnection(connStr);
            using SqlCommand cmd = new SqlCommand("sp_InsertProduct", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 100).Value = name;
            cmd.Parameters.Add("@Category", SqlDbType.VarChar, 50).Value = category;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = price;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);   // Executes SP (connection auto open/close)

            Console.WriteLine("Product Inserted (Disconnected)");
        }

        // VIEW ALL 
        public void ViewProducts()
        {
            using SqlConnection conn = new SqlConnection(connStr);
            using SqlCommand cmd = new SqlCommand("sp_GetAllProducts", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{row["ProductId"]}  {row["ProductName"]}  {row["Category"]}  {row["Price"]}");
            }
        }

        // UPDATE
        public void UpdateProduct(int id, string name, string category, decimal price)
        {
            using SqlConnection conn = new SqlConnection(connStr);
            using SqlCommand cmd = new SqlCommand("sp_UpdateProduct", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@ProductName", SqlDbType.VarChar, 100).Value = name;
            cmd.Parameters.Add("@Category", SqlDbType.VarChar, 50).Value = category;
            cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = price;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            Console.WriteLine("Product Updated (Disconnected)");
        }

        // DELETE
        public void DeleteProduct(int id)
        {
            using SqlConnection conn = new SqlConnection(connStr);
            using SqlCommand cmd = new SqlCommand("sp_DeleteProduct", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = id;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            Console.WriteLine("Product Deleted (Disconnected)");
        }

        // GET BY ID
        public void GetProductById(int id)
        {
            using SqlConnection conn = new SqlConnection(connStr);
            using SqlCommand cmd = new SqlCommand("sp_GetProductDetailsById", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = id;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];

                Console.WriteLine("\nProduct Found:");
                Console.WriteLine($"Id : {r["ProductId"]}");
                Console.WriteLine($"Name : {r["ProductName"]}");
                Console.WriteLine($"Category : {r["Category"]}");
                Console.WriteLine($"Price : {r["Price"]}");
            }
            else
            {
                Console.WriteLine("Product Not Found");
            }
        }
    }
}