using System.Collections.Generic;
using System.IO;

namespace ContactManager
{
    internal interface IContactReader
    {
        IEnumerable<Contact> Read(Stream stream);
    }
}
