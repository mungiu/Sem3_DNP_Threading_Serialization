using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{
    [Serializable]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Ssb { get; set; }

        public Person(string firstName, string lastName, int ssb)
        {
            FirstName = firstName;
            LastName = lastName;
            Ssb = ssb;
        }
    }
}
