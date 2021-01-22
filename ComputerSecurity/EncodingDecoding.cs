using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;//has Encoding implementaions
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace ComputerSecurity
{
    class EncodingDecoding
    {
        public static void  TestEncodingDecoding()
        {
            try
            {
                WebRequest theRequest = WebRequest.Create(@"http://www.mindcracker.com");
                WebResponse theResponse = theRequest.GetResponse();
                int bytesRead = 0;
                byte[] buffer = new byte[256];//Buffer Size
                Stream responseStream = theResponse.GetResponseStream();
                bytesRead = responseStream.Read(buffer, 0, 256);
                StringBuilder strbuilder = new StringBuilder(@"");

                while (bytesRead != 0)
                {
                    // Returns an encoding for the ASCII (7 bit) character set
                    // ASCII characters are limited to the lowest 128 Unicode
                    // characters
                    // , from U+0000 to U+007f.
                    strbuilder.Append(Encoding.ASCII.GetString(buffer, 0, bytesRead));
                    bytesRead = responseStream.Read(buffer, 0, 256);
                    Console.WriteLine(strbuilder.ToString());
                }

                //return "HEY nothing worked";
            }
            catch(Exception ex)
            {
               Console.WriteLine( "There is an Exception"+ex);
            }
            
        }
             

  

    }
}
