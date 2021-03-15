using System;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //JustCollections j = new JustCollections();

            //j.Start();

            GenericCollection k = new GenericCollection();

            k.Start();

            Reading[] readings = new Reading[2];

            readings[0] = new Reading();


            foreach(Reading r in readings)
            {

            }

            for (int i =0; i < readings.Length; i++)
            {

            }
        }

        class Reading
        {

            public Reading()
            {

            }
        }
    }
}
