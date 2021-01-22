using System.Collections.Generic;
using System.IO;

namespace ContactManager
{
    internal interface IContactWriter
    {
        void Write(Stream stream, IEnumerable<Contact> contacts);
    }
}
