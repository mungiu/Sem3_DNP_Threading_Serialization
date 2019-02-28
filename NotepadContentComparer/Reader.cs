using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace NotepadReadWriteLibrary
{
    public class Reader
    {
        string fileName;
        public string data;
        public Reader(string fn) { fileName = fn; }

        public async Task<string> StringRead()
        {
            Stream s = new FileStream(fileName, FileMode.Open);
            StreamReader r = new StreamReader(s);

            r.Close();
            s.Close();

            return await r.ReadToEndAsync();
        }

        public PersonLib.Person BinRead(FileStream fileStream)
        {
            FileStream _fileStream = fileStream;
            IFormatter formatter = new BinaryFormatter();
            PersonLib.Person tempPerson = (PersonLib.Person)formatter.Deserialize(_fileStream);

            return tempPerson;
        }
    }
}
