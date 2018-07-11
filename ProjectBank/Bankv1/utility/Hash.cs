// Thuật mã hóa.
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Bankv1.utility
{
    public class Hash
    {
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GenerateSaltedSHA1(string passwordString, string salt)
        {
            HashAlgorithm algorithm = new SHA1Managed(); // Thuật toán mã hóa.
            var saltBytes = Encoding.ASCII.GetBytes(salt); // Tạo muối và chuyển đổi muối về dạng byte array.
            var plainTextBytes = Encoding.ASCII.GetBytes(passwordString); // chuyển đổi password về dạng byte array.

            var plainTextWithSaltBytes = AppendByteArray(plainTextBytes, saltBytes); // ghép 2 byte array của muối và password vào.
            var saltedSHA1Bytes = algorithm.ComputeHash(plainTextWithSaltBytes); // Mã hóa mảng các byte được tạo ra.
            return Convert.ToBase64String(saltedSHA1Bytes); // chuyển đổi mảng về dạng string.
        }

        public static byte[] AppendByteArray(byte[] byteArray1, byte[] byteArray2)
        {
            var byteArrayResult = new byte[byteArray1.Length + byteArray2.Length];
            for (var i = 0; i < byteArray1.Length; i++)
                byteArrayResult[i] = byteArray1[i];
            for (var i = 0; i < byteArray2.Length; i++)
                byteArrayResult[byteArray1.Length + i] = byteArray2[i];
            return byteArrayResult;
        }

        private static byte[] GenerateSalt(int saltSize)
        {
            var rng = new RNGCryptoServiceProvider(); // Tạo ra số ngẫu nhiên
            var buff = new byte[saltSize]; // Tạo ra một mảng chưa các bytes theo size truyền vào trong tham số.
            rng.GetBytes(buff);
            return buff;
        }
    }
}