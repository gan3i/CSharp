using System;
using System.Collections.Generic;

namespace ContactManager.Filters
{
    public interface IContactFilter : IComparable<Contact>
    {
        IEnumerable<Contact> Apply(IEnumerable<Contact> contacts);
    }
}
