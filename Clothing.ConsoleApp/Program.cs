using System;
using System.Collections.Generic;

namespace Clothing.ConsoleApp
{
    class Program
    {
        static List<Product> products = new List<Product>();

        static void Main(string[] args)
        {
            bool exit = false;

        Start:
            Console.WriteLine("1. Add Prouduct");
            Console.WriteLine("2. Product List");
            Console.WriteLine("3. Edit Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Exit");

            Console.WriteLine("What do you want to do : ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
                {
                    case 1:
                        AddProduct();
                        goto Start;
                    case 2:
                        ShowProduct();
                        goto Start;
                    case 3:
                        EditProduct();
                        goto Start;
                    case 4:
                        DeleteProduct();
                        goto Start;
                    default:
                        break;
                }
            }
        static void AddProduct()
        {
            Console.WriteLine(" ADD NEW PRODUCT ");

            int id = 0;
            Console.Write("Enter Product Name : ");
            string productName = Console.ReadLine();

            Console.Write("Enter Brand: ");
            string productQuentity = Console.ReadLine();

            Console.Write("Enter Color: ");
            string productColor = Console.ReadLine();

            Console.Write("Enter Size: ");
            string productSize = Console.ReadLine();

            Console.Write("Enter Quantity: ");
            int ProductQuantity = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Price: ");
            decimal productPrice = Convert.ToDecimal(Console.ReadLine());

            if (products.Count is 0)
            {
                id += 1;
            }
            else
            {
                id = products.Max(x => x.Id) + 1;
            }

            products.Add ( new Product
            {
                Id = id,
                Name = productName,
                Brand = productQuentity,
                Color = productColor,
                Size = productSize,
                Quantity = ProductQuantity,
                Price = productPrice,
            });

            Console.WriteLine("Product Save Successfully");
        }

        static void ShowProduct()
        {
            Console.WriteLine(" ALL PRODUCTS ");
            foreach (var product in products)
            {
                Console.WriteLine($"Product Code : {product.Id}");
                Console.WriteLine($"Name : {product.Name}");
                Console.WriteLine($"Brand : {product.Brand}");
                Console.WriteLine($"Color : {product.Color}");
                Console.WriteLine($"Size : {product.Size}");
                Console.WriteLine($"Quantity : {product.Quantity}");
                Console.WriteLine($"Price : {product.Price}");
            }
            Console.ReadLine();
        }


        static void EditProduct()
        {
            Console.Write("Enter your Id : ");
            int id = Convert.ToInt32(Console.ReadLine());

            var product = products.Where(x => x.Id == id).FirstOrDefault();

            if (product is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            Console.WriteLine($"{product.Id}. Name: {product.Name}, Brand: {product.Brand}, Color: {product.Color}, Size: {product.Size}, Price: {product.Price}, Quantity: {product.Quantity}");
            Console.WriteLine("------------------------------------------");

            // Name
            Console.Write("Enter New Name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                name = product.Name;
            }

            // Brand
            Console.Write("Enter New Brand: ");
            string brand = Console.ReadLine();
            if (string.IsNullOrEmpty(brand))
            {
                brand = product.Brand;
            }

            // Color
            Console.Write("Enter New Color: ");
            string color = Console.ReadLine();
            if (string.IsNullOrEmpty(color))
            {
                color = product.Color;
            }

            // Size
            Console.Write("Enter New Size: ");
            string size = Console.ReadLine();
            if (string.IsNullOrEmpty(size))
            {
                size = product.Size;
            }

            // Price
            Console.Write("Enter New Price: ");
            string str = Console.ReadLine();
            decimal price = 0;
            if (string.IsNullOrEmpty(str))
            {
                price = product.Price;
            }
            else
            {
                price = Convert.ToDecimal(str);
            }

            // Quantity
            Console.Write("Enter New Quantity: ");
            str = Console.ReadLine();
            int quantity = 0;
            if (string.IsNullOrEmpty(str))
            {
                quantity = product.Quantity;
            }
            else
            {
                quantity = Convert.ToInt32(str);
            }

            // Update List
            int index = products.FindIndex(x => x.Id == id);
            products[index].Name = name;
            products[index].Brand = brand;
            products[index].Color = color;
            products[index].Size = size;
            products[index].Price = price;
            products[index].Quantity = quantity;

            Console.WriteLine("Product Updated!");
            Console.WriteLine("------------------------------------------");
        }

        static void DeleteProduct()
        {
            Console.Write("Enter Id You want to delete:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Are you sure to delete? (Y/N) :");
            string confirm = Console.ReadLine();
            if (confirm.ToUpper() != "Y")
            {
                return;
            }
            var product = products.Where(x => x.Id == id).FirstOrDefault();
            if (product is null)
            {
                Console.WriteLine("No data found !");
                return;
            }

            products.Remove(product);
            Console.WriteLine("Product deleted successfully !");
            Console.WriteLine("------------------------------------------");
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}