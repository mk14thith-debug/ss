using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bt3buoi3
{
    struct Product
    {
        public string Name;
        public double Price;
        public int Quantity;
        public string Category;
    }

    internal class Program
    {
        static Dictionary<string , Product> product = new Dictionary<string, Product> ();
        static void AddOrUpdate(string code, string name, double price, int quantity, string category)
        {
            if (product.ContainsKey(code))
            {
                Product p = product[code];
                p.Quantity += quantity;
                p.Price = price;
                product[code] = p;

            }
            else
            {
                Product p = new Product { Name = name, Price = price, Quantity = quantity, Category = category };
                product.Add(code, p);
            }
        }
        static void InfoProduct (string code)
        {
            if (product.ContainsKey(code))
            {
                Product p = product[code];
                Console.WriteLine($"Mã: {code}, Tên: {p.Name}, Giá: {p.Price}, SL: {p.Quantity}, Danh muc: {p.Category}");
            }
            else
                Console.WriteLine("Khong tim thay san pham");
        }

        static void BestSeller()
        {
            if (product.Count == 0)
            {
                Console.WriteLine(" Chua co du lieu!");
                return;
            }

            Product best = default(Product);
            int maxQuantity = int.MinValue;

            foreach (var item in product.Values)
            {
                if (item.Quantity > maxQuantity)
                {
                    maxQuantity = item.Quantity;
                    best = item;
                }
            }

            Console.WriteLine($" San pham ban chay nhat: {best.Name} ({best.Quantity} chiec)");
        }

     
        static void BestSellerByCategory(string category)
        {
            Product best = default(Product);
            int maxQuantity = int.MinValue;
            bool found = false;

            foreach (var item in product.Values)
            {
                if (item.Category == category)
                {
                    found = true;
                    if (item.Quantity > maxQuantity)
                    {
                        maxQuantity = item.Quantity;
                        best = item;
                    }
                }
            }

            if (!found)
                Console.WriteLine($" Khong co san pham trong danh mục '{category}'!");
            else
                Console.WriteLine($" Danh muc: {category} -> Ban chay nhat: {best.Name} ({best.Quantity} chiec)");
        }

   
        static void RevenueByCategory(string category)
        {
            double total = 0;
            bool found = false;

            foreach (var item in product.Values)
            {
                if (item.Category == category)
                {
                    total += item.Price * item.Quantity;
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine($" Khong co san pham trong danh muc '{category}'!");
            else
                Console.WriteLine($" Doanh thu danh muc {category}: {total}");
        }

        static void Main()
        {
            AddOrUpdate("P01", "But bi Thiên Long", 5000, 100, "Van phong pham");
            AddOrUpdate("P02", "Vo Hong Ha", 10000, 80, "Van phong pham");
            AddOrUpdate("P03", "Sua Vinamilk", 15000, 50, "Thuc pham");
            AddOrUpdate("P02", "Vo Hong Ha", 10000, 20, "Van phong pham"); 

            Console.WriteLine("=== DANH SACH SAN PHAM ===");
            foreach (var item in product)
            {
                Console.WriteLine($"{item.Key} - {item.Value.Name} - SL: {item.Value.Quantity}");
            }

            Console.WriteLine();
            InfoProduct("P02");
            Console.WriteLine();
            BestSeller();
            BestSellerByCategory("Van phong pham");
            RevenueByCategory("Van phong pham");
        }
    }
}