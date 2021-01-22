using System;
using System.Collections.Generic;

namespace ContactManager.Actions
{
    public class Remove : Action
    {
        public Remove(IContactStore manager, Contact contact)
            : base(manager, contact)
        {
        }

        public override IEnumerable<Contact> Execute()
        {
            Contact removed;
            if (manager.Remove(this.contact, out removed))
            {
                return new List<Contact>(1) { removed };
            }

            return new List<Contact>(0);
        }
    }
}
