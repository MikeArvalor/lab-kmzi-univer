using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    class Program
    {
        private static void Main()
        {
            Console.WriteLine("Enter crypted string");
            var str = Console.ReadLine();
            Console.WriteLine("RSA");
            DateTime start1 = DateTime.Now;
            var rsaCrypted = Rsa.EnCrypt(str);
            Console.WriteLine("crypted = " + rsaCrypted);
            TimeSpan procTime1 = DateTime.Now - start1;
            Console.WriteLine("Encryption(RSA) execution time: " + procTime1.TotalSeconds.ToString() + " sec" + "\n");

            DateTime start2 = DateTime.Now;
            var rsaDecrypted = Rsa.DeCrypt(rsaCrypted);
            Console.WriteLine("decrypted = " + rsaDecrypted);
            TimeSpan procTime2 = DateTime.Now - start2;

            Console.WriteLine("Decryption(RSA) execution time: " + procTime2.TotalSeconds.ToString() + " sec" + "\n");


            Console.WriteLine("El-Gamal");
            DateTime start3 = DateTime.Now;
            var elgamalCrypted = ElGamalClass.EnCrypt(str);
            Console.WriteLine("crypted = " + elgamalCrypted);
            TimeSpan procTime3 = DateTime.Now - start3;
            Console.WriteLine("Encryption(El-Gamal) execution time: " + procTime3.TotalSeconds.ToString() + " sec" + "\n");

            DateTime start4 = DateTime.Now;
            var elgamalDecrypted = ElGamalClass.DeCrypt(elgamalCrypted);
            Console.WriteLine("decrypted = " + elgamalDecrypted);
            TimeSpan procTime4 = DateTime.Now - start4;
            Console.WriteLine("Decryption(El-Gamal) execution time: " + procTime4.TotalSeconds.ToString() + " sec" + "\n");


            Console.ReadLine();
        }
    }

    public static class ElGamalClass
    {
        private static int Power(int a, int b, int n)
        { // a^b mod n
            var tmp = a;
            var sum = tmp;
            for (var i = 1; i < b; i++)
            {
                for (var j = 1; j < a; j++)
                {
                    sum += tmp;
                    if (sum >= n)
                    {
                        sum -= n;
                    }
                }

                tmp = sum;
            }

            return tmp;
        }

        private static int Mul(int a, int b, int n)
        { // a*b mod n 
            var sum = 0;
            for (var i = 0; i < b; i++)
            {
                sum += a;
                if (sum >= n)
                {
                    sum -= n;
                }
            }
            return sum;
        }

        public static string EnCrypt(string str)
        {
            return Crypt(397, 277, 8, str);
        }

        public static string DeCrypt(string str)
        {
            return Decrypt(397, 8, str);
        }


        /*
        p - простое число
        0 < g < p-1
        0 < x < p-1
        m - шифруемое сообщение m < p
        */
        private static string Crypt(int p, int g, int x, string inString)
        {
            var result = "";
            var y = Power(g, x, p);
            var rand = new Random();
            Console.WriteLine($"Открытый ключ (p,g,y)=({p},{g},{y})");
            Console.WriteLine($"Закрытый ключ x={x}");

            Console.WriteLine("crypted = ");
            foreach (int code in inString)
                if (code > 0)
                {
                    Console.Write((char)code);
                    var k = rand.Next() % (p - 2) + 1; // 1 < k < (p-1) 
                    var a = Power(g, k, p);
                    var b = Mul(Power(y, k, p), code, p);
                    result += a + " " + b + " ";
                }
            Console.WriteLine("");
            return result;
        }

        private static string Decrypt(int p, int x, string inText)
        {
            var result = "";

            var arr = inText.Split(' ').Where(xx => xx != "").ToArray();
            for (var i = 0; i < arr.Length; i += 2)
            {
                var a = int.Parse(arr[i]);
                var b = int.Parse(arr[i + 1]);

                if (a != 0 && b != 0)
                {

                    var deM = Mul(b, Power(a, p - 1 - x, p),
                        p); // m=b*(a^x)^(-1)mod p =b*a^(p-1-x)mod p  
                    var m = (char)deM;
                    result += m;
                }
            }
            return result;
        }
    }

    public static class Rsa
    {
        public static string EnCrypt(string str)
        {
            var publicKey =
                "<RSAKeyValue><Modulus>21wEnTU+mcD2w0Lfo1Gv4rtcSWsQJQTNa6gio05AOkV/Er9w3Y13Ddo5wGtjJ19402S71HUeN0vbKILLJdRSES5MHSdJPSVrOqdrll/vLXxDxWs/U0UT1c8u6k/Ogx9hTtZxYwoeYqdhDblof3E75d9n2F0Zvf6iTb4cI7j6fMs=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

            var testData = Encoding.UTF8.GetBytes(str);

            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    rsa.FromXmlString(publicKey);
                    var encryptedData = rsa.Encrypt(testData, true);
                    var base64Encrypted = Convert.ToBase64String(encryptedData);
                    return base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }


        public static string DeCrypt(string str)
        {
            var privateKey =
                "<RSAKeyValue><Modulus>21wEnTU+mcD2w0Lfo1Gv4rtcSWsQJQTNa6gio05AOkV/Er9w3Y13Ddo5wGtjJ19402S71HUeN0vbKILLJdRSES5MHSdJPSVrOqdrll/vLXxDxWs/U0UT1c8u6k/Ogx9hTtZxYwoeYqdhDblof3E75d9n2F0Zvf6iTb4cI7j6fMs=</Modulus><Exponent>AQAB</Exponent><P>/aULPE6jd5IkwtWXmReyMUhmI/nfwfkQSyl7tsg2PKdpcxk4mpPZUdEQhHQLvE84w2DhTyYkPHCtq/mMKE3MHw==</P><Q>3WV46X9Arg2l9cxb67KVlNVXyCqc/w+LWt/tbhLJvV2xCF/0rWKPsBJ9MC6cquaqNPxWWEav8RAVbmmGrJt51Q==</Q><DP>8TuZFgBMpBoQcGUoS2goB4st6aVq1FcG0hVgHhUI0GMAfYFNPmbDV3cY2IBt8Oj/uYJYhyhlaj5YTqmGTYbATQ==</DP><DQ>FIoVbZQgrAUYIHWVEYi/187zFd7eMct/Yi7kGBImJStMATrluDAspGkStCWe4zwDDmdam1XzfKnBUzz3AYxrAQ==</DQ><InverseQ>QPU3Tmt8nznSgYZ+5jUo9E0SfjiTu435ihANiHqqjasaUNvOHKumqzuBZ8NRtkUhS6dsOEb8A2ODvy7KswUxyA==</InverseQ><D>cgoRoAUpSVfHMdYXW9nA3dfX75dIamZnwPtFHq80ttagbIe4ToYYCcyUz5NElhiNQSESgS5uCgNWqWXt5PnPu4XmCXx6utco1UVH8HGLahzbAnSy6Cj3iUIQ7Gj+9gQ7PkC434HTtHazmxVgIR5l56ZjoQ8yGNCPZnsdYEmhJWk=</D></RSAKeyValue>";

            using (var rsa = new RSACryptoServiceProvider(1024))
            {
                try
                {
                    var base64Encrypted = str;
                    rsa.FromXmlString(privateKey);
                    var resultBytes = Convert.FromBase64String(base64Encrypted);
                    var decryptedBytes = rsa.Decrypt(resultBytes, true);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }

            }
        }
    }
}