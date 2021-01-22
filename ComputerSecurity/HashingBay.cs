using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ComputerSecurity
{
    class HashingBay
    {
        //HashAlgorithm is an abstract class and is Base class for all hasshing Algorithms
        //like MD5, RIPEMD160, SHA1, SHA256, SHA384, and SHA512.
      

         public static string ComputeSHA2556Hash(string rawData)
        {
            //create a SHA256Hash
            using (SHA256 sha256hash = SHA256.Create())
            {
                byte[] SHA256Byte = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                //Convert byte array to string
                //StringBuilder strBuilder = new StringBuilder();
                StringBuilder strBuilder1 = new StringBuilder();

                //for (int i = 0; i < SHA256Byte.Length; i++)
                //{
                //    strBuilder.Append(SHA256Byte[i].ToString());
                //}
                //Console.WriteLine(strBuilder);

                foreach (byte b in SHA256Byte)
                {
                    strBuilder1.Append(b.ToString("x2"));
                }
                
                Console.WriteLine(strBuilder1);
                return strBuilder1.ToString();
            }
        }

        public static string ComputeMD5Hash(string rawData)
        {
            using (MD5 MD5Hash = MD5.Create())
            {
                byte[] MD5byte = MD5Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                //Console.WriteLine(MD5byte);

                StringBuilder strBuilder = new StringBuilder();
                foreach(byte b in MD5byte)
                {
                    strBuilder.Append(b.ToString()); 
                }
                Console.WriteLine(strBuilder.ToString());

                return strBuilder.ToString();
            }

        }
     }

}
