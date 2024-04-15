using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Lab16
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            const int n = 5;
            Tovar[] tovars = new Tovar[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите данные товара {i + 1}");
                Console.WriteLine("Введите код товара");
                int code = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара");
                string name = Console.ReadLine();
                Console.WriteLine("Введите цену товара");
                double price = Convert.ToDouble(Console.ReadLine());
                tovars[i] = new Tovar() { TovarCode = code, TovarName = name, Price = price };
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(tovars, options);
            using (StreamWriter writer = new StreamWriter("../../../Tovar.json"))
            {
                writer.WriteLine(jsonString);
            }
        }
    }
}
