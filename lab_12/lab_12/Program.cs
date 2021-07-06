using System;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace lab_12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter source text: ");
            string sourceText = Console.ReadLine();
            RSA rsa = new RSA();
            var stopwatch = Stopwatch.StartNew();
            BigInteger[] digitalSignRSA = rsa.CreateDigitalSign(sourceText);
            stopwatch.Stop();
            Console.WriteLine($"Digital sign: {digitalSignRSA.Select(el => el.ToString()).Aggregate((prev, current) => prev + " " + current)}");
            Console.WriteLine($"Creating digital sign time: {stopwatch.ElapsedTicks} ticks");
            Console.Write("Enter text for checking: ");
            string checkingText = Console.ReadLine();
            stopwatch.Restart();
            Console.WriteLine($"Result of checking digital sign: {rsa.VerifyDigitalSign(checkingText, digitalSignRSA)}");
            stopwatch.Stop();
            Console.WriteLine($"Checking digital sign time: {stopwatch.ElapsedTicks} ticks");

            Console.WriteLine();

            Console.Write("Enter source text: ");
            sourceText = Console.ReadLine();
            ElGamal elGamal = new ElGamal();
            stopwatch.Restart();
            BigInteger[,] digitalSignElGamal = elGamal.CreateDigitalSign(sourceText);
            stopwatch.Stop();
            Console.WriteLine($"Digital sign: {string.Join(" ", digitalSignElGamal.Cast<BigInteger>())}");
            Console.WriteLine($"Creating digital sign time: {stopwatch.ElapsedTicks} ticks");
            Console.Write("Enter text for checking: ");
            checkingText = Console.ReadLine();
            stopwatch.Restart();
            Console.WriteLine($"Result of checking digital sign: {elGamal.VerifyDigitalSign(checkingText, digitalSignElGamal)}");
            stopwatch.Stop();
            Console.WriteLine($"Checking digital sign time: {stopwatch.ElapsedTicks} ticks");

            Console.WriteLine();

            Console.Write("Enter source text: ");
            sourceText = Console.ReadLine();
            Schnorr snorr = new Schnorr();
            stopwatch.Restart();
            BigInteger[,] digitalSignSnorr = snorr.CreateDigitalSign(sourceText);
            stopwatch.Stop();
            Console.WriteLine($"Digital sign: {string.Join(" ", digitalSignSnorr.Cast<BigInteger>())}");
            Console.WriteLine($"Creating digital sign time: {stopwatch.ElapsedTicks} ticks");
            Console.Write("Enter text for checking: ");
            checkingText = Console.ReadLine();
            stopwatch.Restart();
            Console.WriteLine($"Result of checking digital sign: {snorr.VerifyDigitalSign(checkingText, digitalSignSnorr)}");
            stopwatch.Stop();
            Console.WriteLine($"Checking digital sign time: {stopwatch.ElapsedTicks} ticks");
            Console.ReadKey();
        }
    }
}
