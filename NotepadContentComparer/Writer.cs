using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using PersonLib;

namespace ReadWriteLibrary
{
    public class Writer
    {
        SoapFormatter soapFormatter;

        public Writer()
        {
            soapFormatter = new SoapFormatter();
        }

        public void BinWrite(FileStream fileStream, PersonLib.Person person)
        {
            soapFormatter.Serialize(fileStream, person);
        }
    }
}
