using System;
using System.Collections.Generic;

namespace ContactManager.Actions
{
    public interface IAction
    {
        IEnumerable<Contact> Execute();
    }

    public abstract class Action : IAction
    {
        protected readonly IContactStore manager;
        protected readonly Contact contact;

        internal Action(IContactStore manager, Contact contact)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("manager");
            }

            this.manager = manager;
            this.contact = contact;
        }

        public abstract IEnumerable<Contact> Execute();
    }
}
