using System.Linq;
using System.Collections.Generic;
using ContactManager;
using ContactManager.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactManagerTests
{
    [TestClass]
    public class SearchTests
    {
        [TestMethod]
        public void Search_FirstName()
        {
            ContactStore store = new ContactStore();
            store.Add(Contact.Create("a", "x", "x", "x", "x", "x"));
            store.Add(Contact.Create("b", "x", "x", "x", "x", "x"));
            store.Add(Contact.Create("c", "x", "x", "x", "x", "x"));
            store.Add(Contact.Create("a", "x", "x", "x", "x", "x"));
            store.Add(Contact.Create("b", "x", "x", "x", "x", "x"));
            store.Add(Contact.Create("c", "x", "x", "x", "x", "x"));

            ContactFieldFilter filter = new ContactFieldFilter();
            filter.SetFirstName("b");

            CollectionAssert.AreEqual(
                new List<int> { 2, 5 },
                store.Search(filter).Select(c => c.ID).ToList());
        }

        [TestMethod]
        public void Search_LastName()
        {
            ContactStore store = new ContactStore();
            store.Add(Contact.Create("x", "a", "x", "x", "x", "x"));
            store.Add(Contact.Create("x", "b", "x", "x", "x", "x"));
            store.Add(Contact.Create("x", "c", "x", "x", "x", "x"));
            store.Add(Contact.Create("x", "a", "x", "x", "x", "x"));
            store.Add(Contact.Create("x", "b", "x", "x", "x", "x"));
            store.Add(Contact.Create("x", "c", "x", "x", "x", "x"));

            ContactFieldFilter filter = new ContactFieldFilter();
            filter.SetLastName("b");

            CollectionAssert.AreEqual(
                new List<int> { 2, 5 },
                store.Search(filter).Select(c => c.ID).ToList());
        }

        [TestMethod]
        public void Search_StreetAddress()
        {
            ContactStore store = new ContactStore();
            store.Add(Contact.Create("x", "x", "a", "x", "x", "x"));
            store.Add(Contact.Create("x", "x", "b", "x", "x", "x"));
            store.Add(Contact.Create("x", "x", "c", "x", "x", "x"));
            store.Add(Contact.Create("x", "x", "a", "x", "x", "x"));
            store.Add(Contact.Create("x", "x", "b", "x", "x", "x"));
            store.Add(Contact.Create("x", "x", "c", "x", "x", "x"));

            ContactFieldFilter filter = new ContactFieldFilter();
            filter.SetStreetAddress("b");

            CollectionAssert.AreEqual(
                new List<int> { 2, 5 },
                store.Search(filter).Select(c => c.ID).ToList());
        }

        [TestMethod]
        public void Search_City()
        {
            ContactStore store = new ContactStore();
            store.Add(Contact.Create("x", "x", "x", "a", "x", "x"));
            store.Add(Contact.Create("x", "x", "x", "b", "x", "x"));
            store.Add(Contact.Create("x", "x", "x", "c", "x", "x"));
            store.Add(Contact.Create("x", "x", "x", "a", "x", "x"));
            store.Add(Contact.Create("x", "x", "x", "b", "x", "x"));
            store.Add(Contact.Create("x", "x", "x", "c", "x", "x"));

            ContactFieldFilter filter = new ContactFieldFilter();
            filter.SetCity("b");

            CollectionAssert.AreEqual(
                new List<int> { 2, 5 },
                store.Search(filter).Select(c => c.ID).ToList());
        }

        [TestMethod]
        public void Search_State()
        {
            ContactStore store = new ContactStore();
            store.Add(Contact.Create("x", "x", "x", "x", "a", "x"));
            store.Add(Contact.Create("x", "x", "x", "x", "b", "x"));
            store.Add(Contact.Create("x", "x", "x", "x", "c", "x"));
            store.Add(Contact.Create("x", "x", "x", "x", "a", "x"));
            store.Add(Contact.Create("x", "x", "x", "x", "b", "x"));
            store.Add(Contact.Create("x", "x", "x", "x", "c", "x"));

            ContactFieldFilter filter = new ContactFieldFilter();
            filter.SetState("b");

            CollectionAssert.AreEqual(
                new List<int> { 2, 5 },
                store.Search(filter).Select(c => c.ID).ToList());
        }

        [TestMethod]
        public void Search_PostalCode()
        {
            ContactStore store = new ContactStore();
            store.Add(Contact.Create("x", "x", "x", "x", "x", "a"));
            store.Add(Contact.Create("x", "x", "x", "x", "x", "b"));
            store.Add(Contact.Create("x", "x", "x", "x", "x", "c"));
            store.Add(Contact.Create("x", "x", "x", "x", "x", "a"));
            store.Add(Contact.Create("x", "x", "x", "x", "x", "b"));
            store.Add(Contact.Create("x", "x", "x", "x", "x", "c"));

            ContactFieldFilter filter = new ContactFieldFilter();
            filter.SetPostalCode("b");

            CollectionAssert.AreEqual(
                new List<int> { 2, 5 },
                store.Search(filter).Select(c => c.ID).ToList());
        }

        [TestMethod]
        public void Search_ID()
        {
            ContactStore store = new ContactStore();
            store.Add(Contact.Create("x", "x", "x", "x", "x", "x"));
            store.Add(Contact.Create("x", "x", "x", "x", "x", "x"));
            store.Add(Contact.Create("x", "x", "x", "x", "x", "x"));
            store.Add(Contact.Create("x", "x", "x", "x", "x", "x"));
            store.Add(Contact.Create("x", "x", "x", "x", "x", "x"));
            store.Add(Contact.Create("x", "x", "x", "x", "x", "x"));

            ContactFieldFilter filter = new ContactFieldFilter();
            filter.SetID(3);

            CollectionAssert.AreEqual(
                new List<int> { 3 },
                store.Search(filter).Select(c => c.ID).ToList());
        }

        [TestMethod]
        public void Search_Missing()
        {
            ContactStore store = new ContactStore();
            store.Add(Contact.Create("x", "x", "x", "x", "x", "x"));
            store.Add(Contact.Create("x", "x", "x", "x", "x", "x"));
            store.Add(Contact.Create("x", "x", "x", "x", "x", "x"));
            store.Add(Contact.Create("x", "x", "x", "x", "x", "x"));
            store.Add(Contact.Create("x", "x", "x", "x", "x", "x"));
            store.Add(Contact.Create("x", "x", "x", "x", "x", "x"));

            ContactFieldFilter filter = new ContactFieldFilter();
            filter.SetID(7);

            Assert.AreEqual(0, store.Search(filter).Count());
        }

        [TestMethod]
        public void Search_MultipleFields()
        {
            ContactStore store = new ContactStore();
            store.Add(Contact.Create("x", "g", "x", "x", "x", "a"));
            store.Add(Contact.Create("x", "g", "x", "x", "x", "b"));
            store.Add(Contact.Create("x", "g", "x", "x", "x", "c"));
            store.Add(Contact.Create("x", "h", "x", "x", "x", "a"));
            store.Add(Contact.Create("x", "h", "x", "x", "x", "b"));
            store.Add(Contact.Create("x", "h", "x", "x", "x", "c"));

            ContactFieldFilter filter = new ContactFieldFilter();
            filter.SetLastName("h");
            filter.SetPostalCode("b");

            CollectionAssert.AreEqual(
                new List<int> { 5 },
                store.Search(filter).Select(c => c.ID).ToList());
        }
    }
}
