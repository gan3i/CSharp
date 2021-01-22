using System;

namespace ContactManager
{
    public struct Contact : IComparable<Contact>
    {
        private Contact(string first, string last, string street, string city, string state, string code)
        {
            ID = default;
            FirstName = first;
            LastName = last;
            StreetAddress = street;
            City = city;
            State = state;
            PostalCode = code;
        }

        private Contact(int ID, string first, string last, string street, string city, string state, string code)
            : this(first, last, street, city, state, code)
        {
            this.ID = ID;
        }


        public static Contact Create(string first, string last, string street, string city, string state, string code)
        {
            return new Contact(first, last, street, city, state, code);
        }

        internal static Contact CreateWithId(int ID, Contact contact)
        {
            return new Contact(ID, contact.FirstName, contact.LastName, contact.StreetAddress, contact.City, contact.State, contact.PostalCode);
        }

        public int? ID
        {
            get;
        }

        public string FirstName
        {
            get;
        }

        public string LastName
        {
            get;
        }

        public string StreetAddress
        {
            get;
        }

        public string City
        {
            get;
        }

        public string State
        {
            get;
        }

        public string PostalCode
        {
            get;
        }

        public int CompareTo(Contact other)
        {
            int comp;

            comp = String.Compare(this.FirstName, other.FirstName);
            if (comp != 0) return comp;

            comp = String.Compare(this.LastName, other.LastName);
            if (comp != 0) return comp;

            comp = String.Compare(this.StreetAddress, other.StreetAddress);
            if (comp != 0) return comp;

            comp = String.Compare(this.City, other.City);
            if (comp != 0) return comp;

            comp = String.Compare(this.State, other.State);
            if (comp != 0) return comp;

            comp = String.Compare(this.PostalCode, other.PostalCode);
            if (comp != 0) return comp;

            if (this.ID.HasValue && other.ID.HasValue)
            {
                // if they both have an ID they must match
                comp = this.ID.Value.CompareTo(other.ID.Value);
                if (comp != 0) return comp;
            } else if(!(!this.ID.HasValue && !other.ID.HasValue))
            {
                // if they aren't both not set (then only one must be set
                // because of the previous condition)
                return this.ID.HasValue ? 1 : -1;
            }

            return 0;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Contact))
                return false;

            Contact other = (Contact)obj;

            return CompareTo(other) == 0;
        }

        public override string ToString()
        {
            if(ID.HasValue)
            {
                return String.Format("{0} {1} {2} {3} {4} {5} {6}",
                    ID.Value, FirstName, LastName, StreetAddress, City, State, PostalCode).Trim();
            }
            {
                return String.Format("{0} {1} {2} {3} {4} {5}",
                    FirstName, LastName, StreetAddress, City, State, PostalCode).Trim();
            }
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}
