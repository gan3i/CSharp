﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStructures;

namespace DataStructuresTests
{
    [TestClass]
    class HashTableTests
    {
        Random _rng = new Random();

        [TestMethod]
        public void Add_Unique_Adds()
        {
            HashTable<string, int> table = new HashTable<string, int>();
            System.Collections.Generic.List<int> added = new System.Collections.Generic.List<int>();

            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(i, table.Count, "The count was incorrect");

                int value = _rng.Next();
                string key = value.ToString();

                // this ensure we should never throw on Add
                while (table.ContainsKey(key))
                {
                    value = _rng.Next();
                    key = value.ToString();
                }

                table.Add(key, value);
                added.Add(value);
            }

            // now make sure all the keys and values are there
            foreach (int value in added)
            {
                Assert.IsTrue(table.ContainsKey(value.ToString()), "ContainsKey returned false?");
                Assert.IsTrue(table.ContainsValue(value), "ContainsValue returned false?");

                int found = table[value.ToString()];
                Assert.AreEqual(value, found, "The indexed value was incorrect");
            }
        }

        [TestMethod]
        public void Add_Duplicate_Throws()
        {
            HashTable<string, int> table = new HashTable<string, int>();
            System.Collections.Generic.List<int> added = new System.Collections.Generic.List<int>();

            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(i, table.Count, "The count was incorrect");

                int value = _rng.Next();
                string key = value.ToString();

                // this ensure we should never throw on Add
                while (table.ContainsKey(key))
                {
                    value = _rng.Next();
                    key = value.ToString();
                }

                table.Add(key, value);
                added.Add(value);
            }

            // now make sure each attempt to re-add throws
            foreach (int value in added)
            {
                try
                {
                    table.Add(value.ToString(), value);
                    Assert.Fail("The Add operation should have thrown with the duplicate key");
                }
                catch (ArgumentException)
                {
                    // correct!
                }
            }
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Get_From_Empty()
        {
            HashTable<string, int> table = new HashTable<string, int>();
            int value = table["missing"];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Get_Missing()
        {
            HashTable<string, int> table = new HashTable<string, int>();
            table.Add("100", 100);

            int value = table["missing"];
        }

        [TestMethod]
        public void Get_Succeeds()
        {
            HashTable<string, int> table = new HashTable<string, int>();
            table.Add("100", 100);

            int value = table["100"];
            Assert.AreEqual(100, value, "The returned value was incorrect");

            for (int i = 0; i < 100; i++)
            {
                table.Add(i.ToString(), i);

                value = table["100"];
                Assert.AreEqual(100, value, "The returned value was incorrect");
            }
        }

        [TestMethod]
        public void TryGet_From_Empty()
        {
            HashTable<string, int> table = new HashTable<string, int>();
            int value;

            Assert.IsFalse(table.TryGetValue("missing", out value));
        }

        [TestMethod]
        public void TryGet_Missing()
        {
            HashTable<string, int> table = new HashTable<string, int>();
            table.Add("100", 100);

            int value;
            Assert.IsFalse(table.TryGetValue("missing", out value));
        }

        [TestMethod]
        public void TryGet_Succeeds()
        {
            HashTable<string, int> table = new HashTable<string, int>();
            table.Add("100", 100);

            int value;
            Assert.IsTrue(table.TryGetValue("100", out value));
            Assert.AreEqual(100, value, "The returned value was incorrect");

            for (int i = 0; i < 100; i++)
            {
                table.Add(i.ToString(), i);

                Assert.IsTrue(table.TryGetValue("100", out value));
                Assert.AreEqual(100, value, "The returned value was incorrect");
            }
        }
        [TestMethod]
        public void Enumerate_Keys_Empty()
        {
            HashTable<string, string> table = new HashTable<string, string>();

            foreach (string key in table.Keys)
            {
                Assert.Fail("There should be nothing in the Keys collection");
            }
        }

        [TestMethod]
        public void Enumerate_Values_Empty()
        {
            HashTable<string, string> table = new HashTable<string, string>();

            foreach (string key in table.Values)
            {
                Assert.Fail("There should be nothing in the Values collection");
            }
        }

        [TestMethod]
        public void Enumerate_Keys_Populated()
        {
            HashTable<int, string> table = new HashTable<int, string>();

            System.Collections.Generic.List<int> keys = new System.Collections.Generic.List<int>();
            for (int i = 0; i < 100; i++)
            {
                int value = _rng.Next();
                while (table.ContainsKey(value))
                {
                    value = _rng.Next();
                }

                keys.Add(value);
                table.Add(value, value.ToString());
            }

            foreach (int key in table.Keys)
            {
                Assert.IsTrue(keys.Remove(key), "The key was missing from the keys collection");
            }

            Assert.AreEqual(0, keys.Count, "There were left over values in the keys collection");
        }

        [TestMethod]
        public void Enumerate_Values_Populated()
        {
            HashTable<int, string> table = new HashTable<int, string>();

            System.Collections.Generic.List<string> values = new System.Collections.Generic.List<string>();
            for (int i = 0; i < 100; i++)
            {
                int value = _rng.Next();
                while (table.ContainsKey(value))
                {
                    value = _rng.Next();
                }

                values.Add(value.ToString());
                table.Add(value, value.ToString());
            }

            foreach (string value in table.Values)
            {
                Assert.IsTrue(values.Remove(value), "The key was missing from the values collection");
            }

            Assert.AreEqual(0, values.Count, "There were left over values in the value collection");
        }

        [TestMethod]
        public void Remove_Empty()
        {
            HashTable<string, int> table = new HashTable<string, int>();
            Assert.IsFalse(table.Remove("missing"), "Remove on an empty collection should return false");

        }

        [TestMethod]
        public void Remove_Missing()
        {
            HashTable<string, int> table = new HashTable<string, int>();
            table.Add("100", 100);

            Assert.IsFalse(table.Remove("missing"), "Remove on an empty collection should return false");
        }

        [TestMethod]
        public void Remove_Found()
        {
            HashTable<string, int> table = new HashTable<string, int>();
            for (int i = 0; i < 100; i++)
            {
                table.Add(i.ToString(), i);
            }

            for (int i = 0; i < 100; i++)
            {
                Assert.IsTrue(table.ContainsKey(i.ToString()), "The key was not found in the collection");
                Assert.IsTrue(table.Remove(i.ToString()), "The value was not removed (or remove returned false)");
                Assert.IsFalse(table.ContainsKey(i.ToString()), "The key should not have been found in the collection");
            }
        }

    }
}