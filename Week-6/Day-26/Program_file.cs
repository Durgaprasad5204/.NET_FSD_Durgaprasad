using ConsoleApp2;

    class Program
    {
        static void Main()
        {
            ProductDA dal = new ProductDA();

            while (true)
            {
                Console.WriteLine("\n1.Insert\n2.View\n3.Update\n4.Delete\n5.Get Details By ID \n6.Exit");

                if (!int.TryParse(Console.ReadLine(), out int ch))
                {
                    Console.WriteLine("Invalid Choice");
                    continue;
                }

            if (ch == 1)
            {
                Console.Write("\nProduct Name: ");
                string name = Console.ReadLine();

                Console.Write("Category: ");
                string cat = Console.ReadLine();

                Console.Write("Price: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    Console.WriteLine("Invalid Price");
                    continue;
                }

                dal.InsertProduct(name, cat, price);
            }
            else if (ch == 2)
            {
                dal.ViewProducts();
            }
            else if (ch == 3)
            {
                Console.Write("Id: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid Id");
                    continue;
                }

                Console.Write("Product Name: ");
                string name = Console.ReadLine();

                Console.Write("Category: ");
                string cat = Console.ReadLine();

                Console.Write("Price: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                {
                    Console.WriteLine("Invalid Price");
                    continue;
                }

                dal.UpdateProduct(id, name, cat, price);
            }
            else if (ch == 4)
            {
                Console.Write("Enter Id: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid Id");
                    continue;
                }

                dal.DeleteProduct(id);
            }
            else if (ch == 5)
            {
                Console.Write("Enter Product Id: ");

                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid Id");
                    continue;
                }

                dal.GetProductById(id);
            }
            else if (ch == 6)
            {
                break;
            }
            else
            {
                Console.WriteLine("Wrong Choice");
            }
            }
        }
    }
