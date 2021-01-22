using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresTests
{
    [TestClass]
    public class HashFunctionExampleTests
    {
        public uint SDBMHash(string input)
        {
            uint hash = 0;

            foreach (byte ascii in input)
            {
                hash = hash * 65599 + ascii;
            }

            return hash;
        }

        [TestMethod]
        public void SDBMTests()
        {
            Assert.AreEqual((uint)849955110, SDBMHash("foo"));
            Assert.AreEqual((uint)924308646, SDBMHash("oof"));
            Assert.AreEqual((uint)923718264, SDBMHash("ofo"));
        }

        public int StableHash(string input)
        {
            int result = 0;

            foreach (byte ascii in input)
            {
                result += ascii;
            }

            return result;
        }

        [TestMethod]
        public void StableHashTests()
        {
            Assert.AreEqual(324, StableHash("foo"));
            Assert.AreEqual(324, StableHash("oof"));
            Assert.AreEqual(324, StableHash("ofo"));
        }


        public ulong Dbj2Hash(string input)
        {
            ulong hash = 5381;

            foreach(byte c in input)
            {
                hash = hash * 33 + c;
            }

            return hash;
        }

        [TestMethod]
        public void Dbj2HashTests()
        {
            Assert.AreEqual((ulong)193491849, Dbj2Hash("foo"));
        }
    }
}

