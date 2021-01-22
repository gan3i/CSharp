using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ContactManager
{
    public class CsvContactWriter : IContactWriter
    {
        readonly string seperator;

        public CsvContactWriter(string seperator = ",")
        {
            this.seperator = seperator;
        }

        public void Write(Stream stream, IEnumerable<Contact> contacts)
        {
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8, 4096, true))
            {
                writeHeader(writer);
                foreach (Contact c in contacts)
                {
                    writeLine(writer, c);
                }
            }
        }

        private void writeHeader(StreamWriter writer)
        {
            WriteSeparated(writer, "ID", seperator);
            WriteSeparated(writer, "FirstName", seperator);
            WriteSeparated(writer, "LastName", seperator);
            WriteSeparated(writer, "StreetAddress", seperator);
            WriteSeparated(writer, "City", seperator);
            WriteSeparated(writer, "State", seperator);
            WriteSeparated(writer, "PostalCode");
            writer.WriteLine();
        }

        private void writeLine(StreamWriter writer, Contact contact)
        {
            WriteSeparated(writer, contact.ID.HasValue ? contact.ID.Value.ToString() : string.Empty, seperator);
            WriteSeparated(writer, contact.FirstName, seperator);
            WriteSeparated(writer, contact.LastName, seperator);
            WriteSeparated(writer, contact.StreetAddress, seperator);
            WriteSeparated(writer, contact.City, seperator);
            WriteSeparated(writer, contact.State, seperator);
            WriteSeparated(writer, contact.PostalCode);
            writer.WriteLine();
        }

        private void WriteSeparated(StreamWriter writer, string value, string seperator = null)
        {
            writer.Write("{0}{1}", value, seperator);
        }
    }
}
