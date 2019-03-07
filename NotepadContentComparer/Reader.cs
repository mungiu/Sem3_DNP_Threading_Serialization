using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace ReadWriteLibrary
{
    public class Reader
    {
        private SoapFormatter soapFormatter;

        public Reader()
        {
            soapFormatter = new SoapFormatter();
        }

        public PersonLib.Person BinRead(FileStream fileStream)
        {
            SoapFormatter soapFormatter = new SoapFormatter();
            PersonLib.Person tempPerson = (PersonLib.Person)soapFormatter.Deserialize(fileStream);

            return tempPerson;
        }
    }
}
