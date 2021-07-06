using System;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Text;

namespace Lab8
{
    internal class Program
    {
        private static void Main()
        {
            Stopwatch time = new Stopwatch();
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            time.Start();
            byte[] text = Encoding.UTF8.GetBytes("");
            byte[] crypted = RSAcl.Encryption(text, RSA.ExportParameters(false), false);
            string cryptedText = Convert.ToBase64String(crypted);
            time.Stop();
            Console.WriteLine($"Сrypted: {cryptedText} | {(float)time.ElapsedMilliseconds / 1000} sec");

            time.Reset();

            time.Start();
            string decryptedText = RSAcl.Decryption(crypted, RSA.ExportParameters(true), false);
            time.Stop();
            Console.WriteLine($"Decrypted: {decryptedText} | {(float)time.ElapsedMilliseconds / 1000} sec");

            Console.ReadKey();
        }
    }


    public class RSAcl
    {
        static public byte[] Encryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(512))
                {
                    RSA.ImportParameters(RSAKey);
                    encryptedData = RSA.Encrypt(Data, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        static public string Decryption(byte[] Data, RSAParameters RSAKey, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(512))
                {
                    RSA.ImportParameters(RSAKey);
                    decryptedData = RSA.Decrypt(Data, DoOAEPPadding);
                }
                return Encoding.UTF8.GetString(decryptedData);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
