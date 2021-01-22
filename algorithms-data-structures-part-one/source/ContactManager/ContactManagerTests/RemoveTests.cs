using System;
using System.Collections.Generic;
using System.Linq;
using ContactManager;
using ContactManager.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactManagerTests
{
    [TestClass]
    public class RemoveTests
    {
        [TestMethod]
        public void RemoveFirst()
        {
            ContactStore store = new ContactStore();
            Contact a = store.Add(Contact.Create("a", "ln", "street", "city", "st", "zip"));
            Contact b = store.Add(Contact.Create("b", "ln", "street", "city", "st", "zip"));
            Contact c = store.Add(Contact.Create("c", "ln", "street", "city", "st", "zip"));

            Remove(store, a);

            Assert.AreEqual(2, store.Contacts.Count());
            Assert.AreEqual("b", store.Contacts.First().FirstName);
            Assert.AreEqual("c", store.Contacts.Last().FirstName);
        }

        [TestMethod]
        public void RemoveLast()
        {
            ContactStore store = new ContactStore();
            Contact a = store.Add(Contact.Create("a", "ln", "street", "city", "st", "zip"));
            Contact b = store.Add(Contact.Create("b", "ln", "street", "city", "st", "zip"));
            Contact c = store.Add(Contact.Create("c", "ln", "street", "city", "st", "zip"));

            Remove(store, c);

            Assert.AreEqual(2, store.Contacts.Count());
            Assert.AreEqual("a", store.Contacts.First().FirstName);
            Assert.AreEqual("b", store.Contacts.Last().FirstName);
        }

        [TestMethod]
        public void RemoveMiddle()
        {
            ContactStore store = new ContactStore();
            Contact a = store.Add(Contact.Create("a", "ln", "street", "city", "st", "zip"));
            Contact b = store.Add(Contact.Create("b", "ln", "street", "city", "st", "zip"));
            Contact c = store.Add(Contact.Create("c", "ln", "street", "city", "st", "zip"));

            Remove(store, b);

            Assert.AreEqual(2, store.Contacts.Count());
            Assert.AreEqual("a", store.Contacts.First().FirstName);
            Assert.AreEqual("c", store.Contacts.Last().FirstName);
        }

        [TestMethod]
        public void RemoveAll()
        {
            ContactStore store = new ContactStore();
            Contact a = store.Add(Contact.Create("a", "ln", "street", "city", "st", "zip"));
            Contact b = store.Add(Contact.Create("b", "ln", "street", "city", "st", "zip"));
            Contact c = store.Add(Contact.Create("c", "ln", "street", "city", "st", "zip"));

            Assert.AreEqual(3, store.Contacts.Count());

            Remove(store, a);
            Remove(store, b);
            Remove(store, c);

            Assert.AreEqual(0, store.Contacts.Count());
        }

        [TestMethod]
        public void RemoveOnly()
        {
            ContactStore store = new ContactStore();
            Contact c = Contact.Create("fn", "ln", "street", "city", "st", "zip");

            c = store.Add(c);
            Assert.AreEqual(1, store.Contacts.Count());

            Remove(store, c);
            Assert.AreEqual(0, store.Contacts.Count());
        }

        [TestMethod]
        public void RemoveMissing()
        {
            ContactStore store = new ContactStore();
            Contact a = store.Add(Contact.Create("a", "ln", "street", "city", "st", "zip"));
            Contact b = store.Add(Contact.Create("b", "ln", "street", "city", "st", "zip"));
            Contact c = store.Add(Contact.Create("c", "ln", "street", "city", "st", "zip"));

            Assert.AreEqual(3, store.Contacts.Count());

            Contact d = Contact.Create("d", "ln", "street", "city", "st", "zip");

            Remove(store, d);

            Assert.AreEqual(3, store.Contacts.Count());

            CollectionAssert.AreEqual(
                new List<string> { "a", "b", "c" },
                store.Contacts.Select(c => c.FirstName).ToList());
        }

        [TestMethod]
        public void RemoveEmpty()
        {
            ContactStore store = new ContactStore();
            Remove(store, Contact.Create("f", "l", "s", "c", "s", "p"));
            Assert.AreEqual(0, store.Contacts.Count());
        }

        [TestMethod]
        public void RemoveSkipsFirstSameContentButMissingID()
        {
            ContactStore store = new ContactStore();
            Contact c1_with_id = store.Add(Contact.Create("fn", "ln", "street", "city", "st", "zip"));
            Contact c2_with_id = store.Add(Contact.Create("fn", "ln", "street", "city", "st", "zip"));
            Contact c3_with_id = store.Add(Contact.Create("fn", "ln", "street", "city", "st", "zip"));
            Contact c4_with_id = store.Add(Contact.Create("fn", "ln", "street", "city", "st", "zip"));
            Contact missing_id = Contact.Create("fn", "ln", "street", "city", "st", "zip");

            Assert.AreEqual(4, store.Contacts.Count());
            Remove(store, missing_id);

            CollectionAssert.AreEqual(
                new List<int> { 1, 2, 3, 4 },
                store.Contacts.Select(c => c.ID).ToList());
        }

        [TestMethod]
        public void RemoveRemovesExactWhenSameContentDifferentIDs()
        {
            ContactStore store = new ContactStore();
            Contact c1_with_id = store.Add(Contact.Create("fn", "ln", "street", "city", "st", "zip"));
            Contact c2_with_id = store.Add(Contact.Create("fn", "ln", "street", "city", "st", "zip"));
            Contact c3_with_id = store.Add(Contact.Create("fn", "ln", "street", "city", "st", "zip"));
            Contact c4_with_id = store.Add(Contact.Create("fn", "ln", "street", "city", "st", "zip"));

            Assert.AreEqual(4, store.Contacts.Count());
            Remove(store, c3_with_id);

            CollectionAssert.AreEqual(
                new List<int> { 1, 2, 4 },
                store.Contacts.Select(c => c.ID).ToList());
        }

        [TestMethod]
        public void RemoveWithFilterNoMatch()
        {
            ContactStore store = new ContactStore();
            Contact c1_with_id = store.Add(Contact.Create("fn1", "ln1", "street1", "city1", "st1", "zip1"));
            Contact c2_with_id = store.Add(Contact.Create("fn2", "ln2", "street2", "city2", "st2", "zip2"));

            ContactFieldFilter filter = new ContactFieldFilter();
            filter.SetID(5);

            Contact removed;
            Assert.IsFalse(store.Remove(filter, out removed));
        }


        [TestMethod]
        public void RemoveWithFilter()
        {
            ContactStore store = new ContactStore();
            Contact c1_with_id = store.Add(Contact.Create("fn1", "ln1", "street1", "city1", "st1", "zip1"));
            Contact c2_with_id = store.Add(Contact.Create("fn2", "ln2", "street2", "city2", "st2", "zip2"));
            Contact c3_with_id = store.Add(Contact.Create("fn3", "ln3", "street3", "city3", "st3", "zip3"));
            Contact c4_with_id = store.Add(Contact.Create("fn4", "ln4", "street4", "city4", "st4", "zip4"));
            Contact c5_with_id = store.Add(Contact.Create("fn5", "ln5", "street5", "city5", "st5", "zip5"));
            Contact c6_with_id = store.Add(Contact.Create("fn6", "ln6", "street6", "city6", "st6", "zip6"));
            Contact c7_with_id = store.Add(Contact.Create("fn7", "ln7", "street7", "city7", "st7", "zip7"));

            Assert.AreEqual(7, store.Contacts.Count());

            Contact removed;

            ContactFieldFilter filterFN = new ContactFieldFilter();
            filterFN.SetFirstName("fn1");
            Assert.IsTrue(store.Remove(filterFN, out removed));
            Assert.AreEqual(1, removed.ID.Value);

            ContactFieldFilter filterLN = new ContactFieldFilter();
            filterLN.SetLastName("ln2");
            Assert.IsTrue(store.Remove(filterLN, out removed));
            Assert.AreEqual(2, removed.ID.Value);

            ContactFieldFilter filterStreet = new ContactFieldFilter();
            filterStreet.SetStreetAddress("street3");
            Assert.IsTrue(store.Remove(filterStreet, out removed));
            Assert.AreEqual(3, removed.ID.Value);

            ContactFieldFilter filterCity = new ContactFieldFilter();
            filterCity.SetCity("city4");
            Assert.IsTrue(store.Remove(filterCity, out removed));
            Assert.AreEqual(4, removed.ID.Value);

            ContactFieldFilter filterState = new ContactFieldFilter();
            filterState.SetState("st5");
            Assert.IsTrue(store.Remove(filterState, out removed));
            Assert.AreEqual(5, removed.ID.Value);

            ContactFieldFilter filterZip = new ContactFieldFilter();
            filterZip.SetPostalCode("zip6");
            Assert.IsTrue(store.Remove(filterZip, out removed));
            Assert.AreEqual(6, removed.ID.Value);

            ContactFieldFilter filterId = new ContactFieldFilter();
            filterId.SetID(7);
            Assert.IsTrue(store.Remove(filterId, out removed));
            Assert.AreEqual(7, removed.ID.Value);

            Assert.AreEqual(0, store.Contacts.Count());
        }

        Contact Remove(ContactStore store, Contact c)
        {
            Contact removed;
            store.Remove(c, out removed);

            return removed;
        }
    }
}
