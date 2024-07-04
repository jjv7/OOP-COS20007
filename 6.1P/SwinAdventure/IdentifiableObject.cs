using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers;

        public string FirstID
        {
            get
            {
                if (_identifiers.Count > 0)
                {
                    return _identifiers[0];
                }
                return "";
            }
        }

        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<string>();
            for (int i = 0; i < idents.Length; i++)
            {
                _identifiers.Add(idents[i].ToLower());
            }
        }

        public bool AreYou(string id)
        {
            bool result = false;

            foreach (string ident in _identifiers) 
            {
                if (ident == id.ToLower())
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }
    }
}
