using System;
using System.Collections;

namespace DataStructure
{
    public class JustCollections
    {
        public JustCollections()
        {

        }

        public void Start()
        {
            #region Hashtable
            Hashtable ht = new Hashtable();

            ht[1] = "Hey1";
            ht[2] = "Hey2";
            ht["s"] = "Hey2";
            ht.Remove(1);
            ht.Add(3, "Hey");
            foreach (DictionaryEntry d in ht)
            {
                string s = (string)ht[1];
                Console.WriteLine(d.Key + " " + d.Value + " " + ht.Count);

            }
            if (ht.ContainsKey(1))
            {

            }


            Object key = ht[1];
            bool ct = ht.ContainsKey("2");
            bool cv = ht.ContainsValue(2);

            ICollection keys = ht.Keys;
            ICollection values = ht.Values;

            #endregion

            #region Queue
            Queue q = new Queue();

            q.Enqueue(1);
            q.Enqueue("h");
            int count = q.Count;
            object top = q.Peek();


            foreach(object o in q)
            {

            }

            #endregion


            Stack stk = new Stack();
            stk.Push('2');
            object stackTop = stk.Peek();
            top = stk.Pop();
            int count = stk.Count;




            SortedList list_name = new SortedList();

            list_name.Add(2, "Hi");
            list_name.Add(1, "Hkllo");


            ArrayList arrlst = new ArrayList();
            arrlst.Add(2);
            //arrlst.Add(1);

            foreach (int a in arrlst)
            {
                //Console.WriteLine(a);
            }

            Console.WriteLine(arrlst.Capacity);
            Console.WriteLine(arrlst.Count);
            Console.WriteLine(arrlst[0]);

            Console.WriteLine(arrlst.Capacity);













            //        const int n = 4;
            //        const int m = 4;
            //        int[,] arr = new int[n, m];// { { 1, 2, 3, 4 }, { 3, 4, 5, 5 }, { 5, 6, 3, 8 }, { 5, 6, 3, 8 } };

            //        int l = arr.Length;

            //        for (int i = 0; i<n; i++)
            //        {
            //            for (int j = 0; j<m; j++)
            //            {
            //                Console.WriteLine(arr[i, j]);
            //            }
            //}


            //string s = "abcd";

            ////var chars = 







            //int[][] arr1 = new int[n][];


            //for(int i = 0; i<n; i++)
            //{
            //    arr1[i] = new int[m];
            //}

            //for (int i =0; i<n; i++)
            //{
            //    for (int j = 0; j<m; j++)
            //    {
            //        Console.WriteLine(arr1[i][j]);
            //    }
            //}



            //List<int> lst = GetValues(arr1);


            //for(int j=0 ;j<3; j++)
            //{
            //    for (int k = 0; k< 2; k++)
            //    {
            //        Console.WriteLine(arr[j, k]);
            //    }

            //}

            //char[] crr = new char[10];

            //char[][] crr1 = new char[4][];


            //for (int i = 0; i<crr1.Length; i++)
            //{
            //    crr1[i] = new char[2] { 'a', 'b' };
            //}

        }
    }
}
