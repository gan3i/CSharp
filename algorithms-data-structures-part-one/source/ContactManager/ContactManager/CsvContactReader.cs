using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ContactManager
{
    public class CsvContactReader : IContactReader
    {
        readonly string seperator = ",";

        public IEnumerable<Contact> Read(Stream stream)
        {
            List<Contact> contacts = new List<Contact>();

            using(StreamReader reader = new StreamReader(stream, Encoding.UTF8, true, 4096, true))
            {
                List<Column> columns = ReadHeader(reader);
                while (!reader.EndOfStream)
                {
                    Contact c;
                    if(ReadContact(reader.ReadLine(), columns, out c))
                    {
                        contacts.Add(c);
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }
                }
            }

            return contacts;

        }

        private bool ReadContact(string line, List<Column> columns, out Contact contact)
        {
            if(string.IsNullOrEmpty(line))
            {
                contact = default;
                return false;
            }

            string[] values = line.Split(new[] { seperator }, StringSplitOptions.None);

            if(values.Length != columns.Count)
            {
                Console.WriteLine(string.Format("Contact line does not contain appropriate number of columns: {0}", line));
                contact = default;
                return false;
            }

            int? id = new Nullable<int>();
            string first = null;
            string last = null;
            string street = null;
            string city = null;
            string state = null;
            string zip = null;

            for(int i = 0; i < values.Length; i++)
            {
                switch(columns[i].ColumnName)
                {
                    case "id":
                        if (!string.IsNullOrEmpty(values[i]) && !string.IsNullOrEmpty(values[i].Trim()))
                        {
                            id = int.Parse(values[i]); break;
                        }
                        break;
                    case "firstname": first = values[i]; break;
                    case "lastname": last = values[i]; break;
                    case "streetaddress": street = values[i]; break;
                    case "city": city = values[i]; break;
                    case "state": state = values[i]; break;
                    case "postalcode": zip = values[i]; break;
                    default:
                        throw new InvalidOperationException("Unknown column name: " + columns[i].ColumnName);
                }
            }

            contact = Contact.Create(first, last, street, city, state, zip);

            if (id.HasValue) contact = Contact.CreateWithId(id.Value, contact);

            return true;
        }

        private List<Column> ReadHeader(StreamReader sr)
        {
            List<Column> columns = new List<Column>();
            string headerRow = sr.ReadLine();

            string[] headers = headerRow.Split(new string[] { seperator }, StringSplitOptions.None);

            for(int i = 0; i < headers.Length; i++)
            {
                columns.Add(new Column(i, headers[i]));
            }

            return columns;
        }
    }

    internal class Column
    {
        public readonly int Index;
        public readonly string ColumnName;

        public Column(int index, string columnName)
        {
            Index = index;
            ColumnName = columnName.Trim().ToLower();
        }
    }
}
