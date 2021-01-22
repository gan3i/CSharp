using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ContactManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactManagerTests
{
    [TestClass]
    public class CsvContactWriterTests
    {
        [TestMethod]
        public void CsvWriterWrites()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                ContactStore store = new ContactStore();
                store.Add(Contact.Create("first", "ln", "street", "city", "st", "zip"));
                store.Add(Contact.Create("second", "ln", "street", "city", "st", "zip"));
                store.Add(Contact.Create("third", "ln", "street", "city", "st", "zip"));

                CsvContactWriter writer = new CsvContactWriter();

                writer.Write(stream, store.Contacts);
                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);

                StreamReader sr = new StreamReader(stream);

                string header = sr.ReadLine();
                string first = sr.ReadLine();
                string second = sr.ReadLine();
                string third = sr.ReadLine();

                Assert.AreEqual("ID,FirstName,LastName,StreetAddress,City,State,PostalCode", header,
                    "Header row is not equal to expected");

                Assert.AreEqual("1,first,ln,street,city,st,zip", first);
                Assert.AreEqual("2,second,ln,street,city,st,zip", second);
                Assert.AreEqual("3,third,ln,street,city,st,zip", third);

                Assert.AreEqual(-1, sr.Peek());
            }
        }

        [TestMethod]
        public void CsvWriterWrites_NoID()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                List<Contact> store = new List<Contact>();
                store.Add(Contact.Create("first", "ln", "street", "city", "st", "zip"));
                store.Add(Contact.Create("second", "ln", "street", "city", "st", "zip"));
                store.Add(Contact.Create("third", "ln", "street", "city", "st", "zip"));

                CsvContactWriter writer = new CsvContactWriter();

                writer.Write(stream, store);
                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);

                StreamReader sr = new StreamReader(stream);

                string header = sr.ReadLine();
                string first = sr.ReadLine();
                string second = sr.ReadLine();
                string third = sr.ReadLine();

                Assert.AreEqual("ID,FirstName,LastName,StreetAddress,City,State,PostalCode", header,
                    "Header row is not equal to expected");

                Assert.AreEqual(",first,ln,street,city,st,zip", first);
                Assert.AreEqual(",second,ln,street,city,st,zip", second);
                Assert.AreEqual(",third,ln,street,city,st,zip", third);

                Assert.AreEqual(-1, sr.Peek());
            }
        }
    }
}
