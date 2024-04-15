using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Lab16
{
    internal class Progr
    {
        static void Main(string[] args)
        {
            string jsonString = String.Empty;
            using (StreamReader rd = new StreamReader("../../../Tovar.json"))
            {
                jsonString = rd.ReadToEnd();
            }
            Tovar[] tovars = JsonSerializer.Deserialize<Tovar[]>(jsonString);
            Tovar highCostTovars = tovars[0];
            foreach (Tovar tovar in tovars)
            {
                if (tovar.Price > highCostTovars.Price)
                {
                    highCostTovars = tovar;
                }
            }
            Console.WriteLine($"Самый дорогой товар: {highCostTovars.TovarName}");
            Console.ReadKey();
        }
    }
}
