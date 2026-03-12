
//Assignment
  
// Write  a  C# program to process product details using object oriented programming.
 
//•	Class should contain private variables:  productId, productName, unitPrice, qty.
//•	Constructor should allow productId as parameter
//•	 Create properties for all private variables.Property Names :   ProductId, ProductName, UnitPrice, Quantity
//•	ProductId – should be readonly property
//•	ShowDetails()  method to display all the details along with total amount.

namespace ConsoleApp1
{
    class Product
    {
        private int productId;
        private string productName;
        private double unitPrice;
        private int qty;

        public Product(int productId)
        {
            this.productId = productId;
        }
        public int ProductId
        {
            get { return (productId); }
        }
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }
        public int Qty
        {
            get { return qty; }
            set { qty = value; }

        }

        public void ShowDetails()
        {
            double totalAmount = unitPrice * qty;
            Console.WriteLine("Product Id: " + ProductId);
            Console.WriteLine("Product Name: " + ProductName);
            Console.WriteLine("Unit Price : " + UnitPrice);
            Console.WriteLine("Quantity: " + Qty);
            Console.WriteLine("Total Amount: " + totalAmount);

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int id;
            double price;
            int quantity;

            Console.Write("Enter Product Id: ");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid Id. Enter again:");
            }

            Product p = new Product(id);

            Console.Write("Enter Product Name: ");
            p.ProductName = Console.ReadLine();

            Console.Write("Enter Unit Price: ");
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid Price. Enter again:");
            }
            p.UnitPrice = price;

            Console.Write("Enter Quantity: ");
            while (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Invalid Quantity. Enter again:");
            }
            p.Qty= quantity;

            p.ShowDetails();

            Console.ReadLine();
        }

       
        
    }
}
