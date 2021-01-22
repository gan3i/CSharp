using System;

namespace CSharpPractice
{
    public delegate int Ops(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {


            var binaryData = System.IO.File.ReadAllBytes(@"C:\New folder (2)\New Text Document.TXT");
            long arrayLength = (long)((4.0d / 3.0d) * binaryData.Length);

            // If array length is not divisible by 4, go up to the next
            // multiple of 4.
            if (arrayLength % 4 != 0)
            {
                arrayLength += 4 - arrayLength % 4;
            }

            char[] base64CharArray = new char[arrayLength];

            try
            {
                //Convert binary data to base64
                System.Convert.ToBase64CharArray(binaryData,
                    0,
                    binaryData.Length,
                    base64CharArray,
                    0);
            }
            catch (Exception e)
            {
                //throw new NIException(e); 
                throw (new SystemException("Cannot convert to base64", e));
            }

            //Return the converted base64 char array
            Console.WriteLine(base64CharArray);



            //Ops objDelOps = new Ops(Operation.Addition);
            //Console.WriteLine(objDelOps.Invoke(1, 2));
            //Console.WriteLine(objDelOps(1, 2));

            //Ops[] objDelOps1 = new Ops[]
            //{
            //    new Ops(Operation.Addition),

            //new Ops(Operation.Mult)
            //};

            //foreach(Ops o in objDelOps1)
            //{
            // Console.WriteLine(o(3, 4));
            //}
        }
    }
    public static class Operation
    {

        public static int Addition(int x, int y)
        {
            return x + y;
        }
        public static int Mult(int x, int y)
        {
            return x + y;
        }


    }
}
