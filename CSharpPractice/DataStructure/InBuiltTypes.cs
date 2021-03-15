using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class InBuiltTypes
    {
        public void Run()
        {

        int a = Convert.ToInt32(null);
            int b = Convert.ToInt32((string)null);
            int c = 0;

            string s = "508";

            int i = Convert.ToInt32(s);

            byte[] x =  Encoding.ASCII.GetBytes("AB");
            byte[] utf =  Encoding.UTF8.GetBytes("AB");

            string y = Encoding.ASCII.GetString(x);

            char[] z = Encoding.ASCII.GetChars(x);

            //char chr =(char) "A";
            char chr = 'A';

            //int val = (int)"A";
            int val = 'A' - 'B';

            string s1 = "highiighi";
            char[] chrlst = s.ToCharArray();
            s1 = string.Join("",chrlst);

            StringBuilder sb = new StringBuilder();
            sb.Append("Hi");
            sb.AppendLine("Hello");
            sb.ToString();


            GC.Collect();
        }
    }
}
