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
        public int Ssn { get; set; }

        public override bool Equals(Object obj)
        {
            if (this.GetType() != obj.GetType())
                return false;
            else if (this.Ssn != ((Person)obj).Ssn)
                return false;
            else
                return true;
        }
    }
}
