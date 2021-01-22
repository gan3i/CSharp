using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSecurity
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Hashing
            //string rawData = "Django";
            //Console.WriteLine(rawData);
            //String SHA256Hash=HashingBay.ComputeSHA2556Hash(rawData);
            //String MD5Hash=HashingBay.ComputeMD5Hash(rawData);
            #endregion

            #region Encoding and Decoding.
            EncodingDecoding.TestEncodingDecoding();
            #endregion
            Console.ReadLine();
        }
    }
}
