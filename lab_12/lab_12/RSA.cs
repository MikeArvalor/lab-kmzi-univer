using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace lab_12
{
    class RSA
    {
        private Random random = new Random();
        private BigInteger p, q, n, fi, e, d;
        private string hash = "";

        private BigInteger GeneratePrimeNumber()
        {
            BigInteger number = random.Next(1000, 5000);
            while (!GCD.IsSimple(number))
            {
                number = random.Next(1000, 5000);
            }
            return number;
        }

        private BigInteger GenerateCoprimeNumber(BigInteger coprime)
        {
            BigInteger number = random.Next(2, (int)coprime - 1), nod = GCD.GetNOD(number, coprime);
            while (nod != 1)
            {
                number = random.Next(2, (int)coprime - 1);
                nod = GCD.GetNOD(number, coprime);
            }
            return number;
        }

        public RSA()
        {
            p = GeneratePrimeNumber();
            q = GeneratePrimeNumber();
            n = p * q;
            fi = (p - 1) * (q - 1);
            e = GenerateCoprimeNumber(fi);
            d = GCD.ModInverse(e, fi);
            Console.WriteLine(new string('-', 40) + "Digital sign via RSA" + new string('-', 40));
            Console.WriteLine($"p = {p}, q = {q}, n = p * q = {p * q}, fi(n) = {fi}, e = {e}, d = {d}\n");
            Console.WriteLine($"PUBLIC KEY: (e, n) = ({e}, {n})");
            Console.WriteLine($"PRIVATE KEY: (d, n) = ({d}, {n})");
            Console.WriteLine();
        }

        public BigInteger[] CreateDigitalSign(string text)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                hash = MD5Hash.GetMd5Hash(md5Hash, text);
            }
            byte[] bytes = Encoding.ASCII.GetBytes(hash);
            BigInteger[] digitalSign = new BigInteger[bytes.Length];
            for (int i = 0; i < bytes.Length; i++)
            {
                digitalSign[i] = BigInteger.ModPow(bytes[i], d, n);
            }
            return digitalSign;
        }

        public bool VerifyDigitalSign(string text, BigInteger[] digitalSign)
        {
            byte[] signBytes = new byte[digitalSign.Length];
            for (int i = 0; i < digitalSign.Length; i++)
            {
                signBytes[i] = Convert.ToByte(BigInteger.ModPow(digitalSign[i], e, n).ToString());
            }
            string receivedHash = Encoding.ASCII.GetString(signBytes);
            using (MD5 md5Hash = MD5.Create())
            {
                return MD5Hash.VerifyMd5Hash(md5Hash, text, receivedHash);
            }
        }
    }
}
