using System.Collections.Generic;
using ContactManager;
using ContactManager.Filters;

namespace cm
{
    internal class CommandArgParser
    {
        public static Contact ContactFromArgs(IReadOnlyDictionary<string, string> args)
        {
            string first = null;
            string last = null;
            string street = null;
            string city = null;
            string state = null;
            string zip = null;

            foreach (KeyValuePair<string, string> pair in args)
            {
                switch (pair.Key.ToLower())
                {
                    case "f":
                    case "fn":
                    case "first":
                    case "firstname":
                        first = pair.Value; break;
                    case "l":
                    case "ln":
                    case "last":
                    case "lastname":
                        last = pair.Value; break;
                    case "str":
                    case "street":
                        street = pair.Value; break;
                    case "c":
                    case "cty":
                    case "city":
                        city = pair.Value; break;
                    case "stt":
                    case "state":
                        state = pair.Value; break;
                    case "pc":
                    case "postal":
                    case "postalcode":
                    case "zip":
                        zip = pair.Value; break;
                    default:
                        break;
                }
            }

            return Contact.Create(first, last, street, city, state, zip);
        }

        public static ContactFieldFilter FilterFromArgs(IReadOnlyDictionary<string, string> args)
        {
            ContactFieldFilter filter = new ContactFieldFilter();

            foreach (KeyValuePair<string, string> pair in args)
            {
                switch (pair.Key.ToLower())
                {
                    case "id":
                        int id;
                        if (int.TryParse(pair.Value, out id))
                        {
                            filter.SetID(id);
                        }
                        else
                        {
                            Log.Error("Unable to parse ID - must be an integer");
                        }
                        break;
                    case "f":
                    case "fn":
                    case "first":
                    case "firstname":
                        filter.SetFirstName(pair.Value); break;
                    case "l":
                    case "ln":
                    case "last":
                    case "lastname":
                        filter.SetLastName(pair.Value); break;
                    case "str":
                    case "street":
                        filter.SetStreetAddress(pair.Value); break;
                    case "c":
                    case "cty":
                    case "city":
                        filter.SetCity(pair.Value); break;
                    case "stt":
                    case "state":
                        filter.SetState(pair.Value); break;
                    case "pc":
                    case "postal":
                    case "postalcode":
                    case "zip":
                        filter.SetPostalCode(pair.Value); break;
                    default:
                        break;
                }
            }

            return filter;
        }
    }
}
