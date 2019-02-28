using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using PersonLib;

namespace NotepadReadWriteLibrary
{
    public class Writer
    {
        public FileStream FileStream { get; set; }
        public Person Person { get; set; }

        public Writer(FileStream fileStream, PersonLib.Person person) { FileStream = fileStream; Person = person; }


        public void BinWrite()
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(FileStream, Person);

            FileStream.Close();
        }
    }
}
