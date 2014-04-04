using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

class InternetStore
{
    static readonly StringBuilder output = new StringBuilder();

    static MultiDictionary<string, Product> byName = new MultiDictionary<string, Product>(true);
    static MultiDictionary<string, Product> byProducer = new MultiDictionary<string, Product>(true);
    static MultiDictionary<Tuple<string, string>, Product> byNameAndProducer = new MultiDictionary<Tuple<string, string>, Product>(true);
    static OrderedMultiDictionary<double, Product> byPrice = new OrderedMultiDictionary<double, Product>(true);

    static void Main()
    {
        ExecuteCommands();

        Console.Write(output);
    }

    static void ExecuteCommands()
    {
        int N = int.Parse(Console.ReadLine());

        string[] parameters;
        string input = string.Empty, command = string.Empty;
        int firstSpace = -1;

        for (int i = 0; i < N; i++)
        {
            input = Console.ReadLine();
            firstSpace = input.IndexOf(' ');

            command = input.Substring(0, firstSpace);
            parameters = input.Substring(firstSpace + 1).Split(';').ToArray();

            switch (command)
            {
                case "AddProduct": output.AppendLine(AddProduct(parameters)); break;
                case "DeleteProducts": output.AppendLine(DeleteProducts(parameters)); break;
                case "FindProductsByName": PrintSortedProducts(byName[parameters[0]]); break;
                case "FindProductsByProducer": PrintSortedProducts(byProducer[parameters[0]]); break;
                case "FindProductsByPriceRange":
                    double from = double.Parse(parameters[0]), to = double.Parse(parameters[1]);
                    PrintSortedProducts(byPrice.Range(from, true, to, true).Values);
                    break;
            }
        }
    }

    static string AddProduct(string[] parameters)
    {
        var product = new Product(parameters[0], double.Parse(parameters[1]), parameters[2]);
        byName.Add(product.Name, product);
        byPrice.Add(product.Price, product);
        byProducer.Add(product.Producer, product);
        byNameAndProducer.Add(Tuple.Create(product.Name, product.Producer), product);

        return "Product added";
    }

    static string DeleteProducts(string[] parameters)
    {
        Product[] products;

        if (parameters.Length == 1)
        {
            products = byProducer[parameters[0]].ToArray();
            byProducer[parameters[0]].Clear();
        }
        else
        {
            var tuple = Tuple.Create(parameters[0], parameters[1]);
            products = byNameAndProducer[tuple].ToArray();
            byNameAndProducer[tuple].Clear();
        }

        string outputResult = products.Length > 0 ? products.Length + " products deleted" : "No products found";

        foreach (var product in products)
        {
            byName[product.Name].Remove(product);
            byPrice[product.Price].Remove(product);
        }

        return outputResult;
    }

    static void PrintSortedProducts(ICollection<Product> products)
    {
        if (products.Count == 0)
        {
            output.AppendLine("No products found");
            return;
        }

        output.AppendLine(string.Join(Environment.NewLine, products.OrderBy(a => a.Name)
                                                                   .ThenBy(a => a.Producer)
                                                                   .ThenBy(a => a.Price)));
    }

    class Product : IComparable<Product>
    {
        public Product(string name, double price, string producer)
        {
            this.Name = name;
            this.Price = price;
            this.Producer = producer;
        }

        public string Name { get; private set; }

        public double Price { get; private set; }

        public string Producer { get; private set; }

        public int CompareTo(Product other)
        {
            return (int)(this.Price - other.Price);
        }

        public override string ToString()
        {
            return string.Format("{{{0};{1};{2:0.00}}}", this.Name, this.Producer, this.Price);
        }
    }
}