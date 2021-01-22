using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TPL
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

            foreach (KeyValuePair<int, string> kv in dict)
            {
                string s2 = dict[1];
                Console.WriteLine(kv.Key +" " + kv.Value+ " "+ dict.Count);
            }

            if (dict.ContainsKey(2))
            {

            }
            #endregion

            #region Hashtable
            Hashtable ht = new Hashtable();

            ht[1] = "Hey1";
            ht[2] = "Hey2";
            ht["s"] = "Hey2";
            ht.Remove(1);
            foreach(DictionaryEntry d in ht)
            {
                string s =(string) ht[1];
                Console.WriteLine(d.Key + " " + d.Value + " " + ht.Count);

            }
            if (ht.ContainsKey(1))
            {
                   
            }

            #endregion

            #region HashSet
            HashSet<int> hs = new HashSet<int>();
            hs.Add(1);
            hs.Add(2);
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
            lst.Remove(1);

            lst.Sort();
            lst.Reverse();
            #endregion

            #region Stack

            Stack stack = new Stack();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            int peek =(int) stack.Peek();
            for(int i = 0; i < stack.Count; i++)
            {
                Console.WriteLine("Print stack " + stack.Pop());
            }
            #endregion

            #region Queue
            Queue q = new Queue();

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
                Console.WriteLine("prit Sorted List" + d.Key + " " + d.Value + " " + ht.Count);
            }
            if (sl.ContainsKey(1))
            {

            }

            #endregion

        }
    }
}
