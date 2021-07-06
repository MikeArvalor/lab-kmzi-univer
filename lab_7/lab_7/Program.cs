using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_7
{
    class Program
    {
        static void Main(string[] args)
        {
            DES des = new DES();
            Console.Write($"Input text: ");
            string inputText = Console.ReadLine();

            var stopwatch = Stopwatch.StartNew();
            var encryptedText = des.Encrypt(inputText, "MAXIMCHI");
            stopwatch.Stop();
            Console.WriteLine($"Encrypted text: {encryptedText}");
            Console.WriteLine($"Execution time: {stopwatch.ElapsedTicks} ticks");

            stopwatch.Restart();
            var decryptedText  = des.Decrypt(encryptedText, "MAXIMCHI");
            stopwatch.Stop();
            Console.WriteLine($"Decrypted text: {decryptedText}");
            Console.WriteLine($"Execution time: {stopwatch.ElapsedTicks} ticks");

            Console.Write("\nPress any key...");
            Console.ReadKey();
        }
    }
}
