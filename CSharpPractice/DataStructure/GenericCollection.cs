using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure
{
    public class GenericCollection
    {
        public GenericCollection()
        {

        }

        public  void Start()
        {
            #region Dictionary
            Dictionary<int, string> dict = new Dictionary<int, string>();


            dict[1] = "Hey";
            dict[2] = "Hey";
            dict[1] = "Hey again";
           
            
            dict.Remove(1);
            dict.Add(4, "four");
            dict.Append(new KeyValuePair<int, string>(5, "five"));
            dict.Contains(new KeyValuePair<int, string>(5, "five"));

           
            foreach (KeyValuePair<int, string> kv in dict)
            {
                Console.WriteLine(kv.Key +" " + kv.Value+ " "+ dict.Count);
            }

            if (dict.ContainsKey(2))
            {

            }
            #endregion

            #region HashSet
            HashSet<int> hs = new HashSet<int>();
            hs.Add(1);
            hs.Add(2);
            HashSet<int> hs2 = new HashSet<int>();
            hs2.Add(1);
            hs2.Add(3);

            hs.UnionWith(hs2);

            hs.Remove(1);
            foreach(int i in hs)
            {
                Console.WriteLine(i +" " + hs.Count);
            }
            if (hs.Contains(1))
            {

            }
            #endregion

            #region List
            List<int> lst = new List<int>();

            lst.Add(1);
            lst.Add(2);
            for (int i = 0; i < lst.Count; i++)
            {
                Console.WriteLine("printing List"+" "+lst[i]);
            }

            foreach(int i in lst)
            {
                Console.WriteLine("Printing Inside Foreach");
            }
            lst.Remove(1);

            lst.Sort();
            lst.Reverse();
            #endregion

            #region Stack

            Stack<int> stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            int peek =(int) stack.Peek();
            for(int i = 0; i < stack.Count(); i++)
            {
                Console.WriteLine("Print stack " + stack.Pop());
            }
            #endregion

            #region Queue
            Queue<int> q = new Queue<int>();

            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            int peek1 =(int) q.Peek();

            foreach(var i in q)
            {
                Console.WriteLine((int)(i));
            }
            q.Dequeue();
            #endregion

            #region LinkedList
            LinkedList<int> ll = new LinkedList<int>();

            ll.AddFirst(1);
            ll.AddLast(2);
            ll.AddLast(3);
            ll.RemoveFirst();
            ll.RemoveLast();
            int first = ll.First();
            int last = ll.Last();

            #endregion

            #region SortedList

            //SortedList sl = new SortedList();
            SortedList<int,string> sl = new SortedList<int, string>();

            sl[2] = "Hey2";
            sl[1] = "Hey1";
            sl[3] = "Hey3";
            //sl.Remove(1);
            //foreach (dictionaryentry d in sl)
            //{
            //    console.writeline("prit sorted list" + d.key + " " + d.value + " " + ht.count);
            //}
            foreach (KeyValuePair<int, string> d in sl)
            {
                Console.WriteLine("prit Sorted List" + d.Key + " " + d.Value + " " + sl.Count);
            }
            if (sl.ContainsKey(1))
            {

            }

            #endregion

        }
    }
}
