using System;
using System.Collections.Generic;
using System.IO;
using ContactManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactManager.Filters;
using System.Linq;

namespace ContactManagerTests
{
    [TestClass]
    public class CsvContactReaderTests
    {
        [TestMethod]
        public void CsvReader_ReadsHappyPath()
        {
            using (MemoryStream ms = new MemoryStream())
            using (StreamWriter sw = new StreamWriter(ms))
            {
                sw.WriteLine("ID,FirstName,LastName,StreetAddress,City,State,PostalCode");
                sw.WriteLine("1,first1,last1,street1,city1,state1,postalcode1");
                sw.WriteLine("2,first2,last2,street2,city2,state2,postalcode2");

                sw.Flush();

                ms.Seek(0, SeekOrigin.Begin);

                CsvContactReader reader = new CsvContactReader();
                List<Contact> contacts = new List<Contact>(reader.Read(ms));

                Assert.AreEqual(2, contacts.Count, "There should be 2 contacts");

                for(int i = 0; i < 2; i++)
                {
                    Assert.AreEqual(i + 1, contacts[i].ID.Value);
                    Assert.AreEqual(string.Format("first{0}", i + 1), contacts[i].FirstName);
                    Assert.AreEqual(string.Format("last{0}", i + 1), contacts[i].LastName);
                    Assert.AreEqual(string.Format("street{0}", i + 1), contacts[i].StreetAddress);
                    Assert.AreEqual(string.Format("city{0}", i + 1), contacts[i].City);
                    Assert.AreEqual(string.Format("state{0}", i + 1), contacts[i].State);
                    Assert.AreEqual(string.Format("postalcode{0}", i + 1), contacts[i].PostalCode);
                }
            }
        }

        [TestMethod]
        public void CsvReader_ReadsHappyPath_NoIds()
        {
            using (MemoryStream ms = new MemoryStream())
            using (StreamWriter sw = new StreamWriter(ms))
            {
                sw.WriteLine("ID,FirstName,LastName,StreetAddress,City,State,PostalCode");
                sw.WriteLine(",first1,last1,street1,city1,state1,postalcode1");
                sw.WriteLine(",first2,last2,street2,city2,state2,postalcode2");

                sw.Flush();

                ms.Seek(0, SeekOrigin.Begin);

                CsvContactReader reader = new CsvContactReader();
                List<Contact> contacts = new List<Contact>(reader.Read(ms));

                Assert.AreEqual(2, contacts.Count, "There should be 2 contacts");

                for (int i = 0; i < 2; i++)
                {
                    Assert.IsFalse(contacts[i].ID.HasValue);
                    Assert.AreEqual(string.Format("first{0}", i + 1), contacts[i].FirstName);
                    Assert.AreEqual(string.Format("last{0}", i + 1), contacts[i].LastName);
                    Assert.AreEqual(string.Format("street{0}", i + 1), contacts[i].StreetAddress);
                    Assert.AreEqual(string.Format("city{0}", i + 1), contacts[i].City);
                    Assert.AreEqual(string.Format("state{0}", i + 1), contacts[i].State);
                    Assert.AreEqual(string.Format("postalcode{0}", i + 1), contacts[i].PostalCode);
                }
            }
        }

        [TestMethod]
        public void CsvReader_ReadsHappyPath_RoundTrip()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ContactStore store = new ContactStore();
                store.Add(Contact.Create("first", "ln", "street", "city", "st", "zip"));
                store.Add(Contact.Create("second", "ln", "street", "city", "st", "zip"));
                store.Add(Contact.Create("third", "ln", "street", "city", "st", "zip"));

                CsvContactWriter writer = new CsvContactWriter();

                writer.Write(ms, store.Contacts);

                ms.Seek(0, SeekOrigin.Begin);

                CsvContactReader reader = new CsvContactReader();
                List<Contact> contacts = new List<Contact>(reader.Read(ms));

                Assert.AreEqual(3, contacts.Count, "There should be 3 contacts");
                Assert.AreEqual("first", contacts[0].FirstName);
                Assert.AreEqual("second", contacts[1].FirstName);
                Assert.AreEqual("third", contacts[2].FirstName);
            }
        }

        [TestMethod]
        public void CsvReader_ReadsHappyPath_NoRows()
        {
            using (MemoryStream ms = new MemoryStream())
            using (StreamWriter sw = new StreamWriter(ms))
            {
                sw.WriteLine("ID,FirstName,LastName,StreetAddress,City,State,PostalCode");

                sw.Flush();

                ms.Seek(0, SeekOrigin.Begin);

                CsvContactReader reader = new CsvContactReader();
                List<Contact> contacts = new List<Contact>(reader.Read(ms));

                Assert.AreEqual(0, contacts.Count, "There should be 0 contacts");
            }
        }

        [TestMethod]
        public void CsvReader_AddWorksAfterRead()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ContactStore store = new ContactStore();
                store.Add(Contact.Create("first", "ln", "street", "city", "st", "zip"));
                store.Add(Contact.Create("second", "ln", "street", "city", "st", "zip"));
                store.Add(Contact.Create("third", "ln", "street", "city", "st", "zip"));

                CsvContactWriter writer = new CsvContactWriter();

                writer.Write(ms, store.Contacts);

                ms.Seek(0, SeekOrigin.Begin);

                CsvContactReader reader = new CsvContactReader();
                List<Contact> contacts = new List<Contact>(reader.Read(ms));

                Assert.AreEqual(3, contacts.Count, "There should be 3 contacts");
                Assert.AreEqual("first", contacts[0].FirstName);
                Assert.AreEqual("second", contacts[1].FirstName);
                Assert.AreEqual("third", contacts[2].FirstName);

                store.Add(Contact.Create("fourth", "ln", "street", "city", "st", "zip"));
                Assert.AreEqual(4, store.Contacts.Count(), "There should be four contacts");

                ContactFieldFilter filter = new ContactFieldFilter();
                filter.SetFirstName("fourth");

                var found = store.Search(filter);
                Assert.AreEqual(1, found.Count(), "There should have been one item found");
                Assert.AreEqual("fourth", found.First().FirstName, "The contact name was wrong");
            }
        }
    }
}
