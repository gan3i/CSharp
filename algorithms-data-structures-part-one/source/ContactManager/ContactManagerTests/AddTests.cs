using System;
using System.Collections.Generic;
using System.Linq;
using ContactManager;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactManagerTests
{
    [TestClass]
    public class AddTests
    {
        [TestMethod]
        public void Add_One_Test()
        {
            ContactStore store = new ContactStore();
            Contact c = Contact.Create("fn", "ln", "street", "city", "st", "zip");
            Assert.IsFalse(c.ID.HasValue, "New contact should not have an ID");

            Contact c_with_id = store.Add(c);

            Assert.IsFalse(c.ID.HasValue, "Old contact should not have been updated with an ID");
            Assert.IsTrue(c_with_id.ID.HasValue, "Stored contact should have an ID");
            Assert.IsTrue(c_with_id.ID.Value > 0, "The new contact ID should be greater than 0");

            Assert.AreEqual(c_with_id.FirstName, c.FirstName);
            Assert.AreEqual(c_with_id.LastName, c.LastName);
            Assert.AreEqual(c_with_id.StreetAddress, c.StreetAddress);
            Assert.AreEqual(c_with_id.City, c.City);
            Assert.AreEqual(c_with_id.State, c.State);
            Assert.AreEqual(c_with_id.PostalCode, c.PostalCode);
        }

        [TestMethod]
        public void Add_N_Test()
        {
            ContactStore store = new ContactStore();
            store.Add(Contact.Create("first", "ln", "street", "city", "st", "zip"));
            store.Add(Contact.Create("second", "ln", "street", "city", "st", "zip"));
            store.Add(Contact.Create("third", "ln", "street", "city", "st", "zip"));
            store.Add(Contact.Create("fourth", "ln", "street", "city", "st", "zip"));
            store.Add(Contact.Create("fifth", "ln", "street", "city", "st", "zip"));
            store.Add(Contact.Create("sixth", "ln", "street", "city", "st", "zip"));

            Assert.AreEqual(6, store.Contacts.Count(), "There should be six contacts in the list");

            List<string> expected = new List<string> { "fifth", "first", "fourth", "second", "sixth", "third" };
            List<string> actual = store.Contacts.Select(c => c.FirstName).ToList();

            CollectionAssert.AreEqual(expected, actual, "The ordering was not as expected");
        }
    }
}
