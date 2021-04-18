using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SwiftRebuild
{
    class Program
    {

        public static string Encode(string input, byte[] key)
        {
            HMACSHA1 myhmacsha1 = new HMACSHA1(key);
            byte[] byteArray = Encoding.ASCII.GetBytes(input);
            MemoryStream stream = new MemoryStream(byteArray);
            return myhmacsha1.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество инструментов");
            int NumberOfItems = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Количество инструментов {NumberOfItems}, Введите название этих интсрументов: ") ;

            int i;
            string[] items = new string[NumberOfItems];
            i = 0;
            do
            {
                items [i] = Console.ReadLine();
                i++;
            }
            while (i < NumberOfItems);
            Console.WriteLine();
            for (int k = 0; k < items.Length; k++)
            {
                Console.WriteLine($"{k} - {items[k]} ");
            }

            Console.WriteLine();

            Random rnd = new Random();
            int computerDecision = rnd.Next(items.Length);
            int YourDecision = rnd.Next(items.Length);
            Console.WriteLine($"Computer decision {computerDecision}");
            Console.WriteLine($"Your decision {YourDecision}");

            Console.WriteLine();

            var result = (NumberOfItems + YourDecision - computerDecision) % NumberOfItems;
            
            if (result == 0)
            {
                Console.WriteLine("Ничья");
            }
            else if (result % 2 == 1)
            {
                Console.WriteLine("Ты выиграл");
            }
            else if (result % 2 == 0)
            {
                Console.WriteLine("Ты проиграл");
            }
            
            string ComputerDesicion2 = items[computerDecision];
            string YourDecision1 = items[YourDecision];
            byte[] key = Encoding.ASCII.GetBytes("abcdefghijklmnopqrstuvwxyz"); //код шифровки
            string input = ComputerDesicion2;
            string input1 = YourDecision1;
            Console.WriteLine();
            System.Console.WriteLine($"HMAC выбора компьютера {Encode(input, key)}") ;
            System.Console.WriteLine($"HMAC выбора пользователя {Encode(input1, key)}");
           
      
            Console.ReadKey();


        }
    }
}
