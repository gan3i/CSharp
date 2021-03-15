///*
//// Sample code to perform I/O:

//name = Console.ReadLine();                  // Reading input from STDIN
//Console.WriteLine("Hi, {0}.", name);        // Writing output to STDOUT

//// Warning: Printing unwanted or ill-formatted data to output will cause the test cases to fail
//*/
//using System;

//// Write your code here
//class Solution
//{

//    public static void Main(string[] args)
//    {
//        string[] inputOne = Console.ReadLine().Split(' ');
//        int N = Convert.ToInt32(inputOne[0]);
//        int K = Convert.ToInt32(inputOne[1]);
//        string[] inputTwo = Console.ReadLine().Split(' ');
//        long score = 0;

//        foreach (string s in inputTwo)
//        {
//            var lastDigit = Convert.ToInt64(s) % 10;
//            if (lastDigit <= 1)
//            {
//                score = score + lastDigit;
//            }
//            else
//            {
//                if (score == 0)
//                {
//                    score = lastDigit;
//                }
//                else
//                {
//                    score = score * lastDigit;
//                }
//            }

//        }
//        Console.WriteLine(score % 1000000007);

//    }
//}