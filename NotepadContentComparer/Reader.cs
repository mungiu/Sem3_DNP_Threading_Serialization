using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace NotepadComparerLib
{
    public class Reader
    {
        string fileName;
        public string data;
        AsyncCallback callback;
        public Reader(string fn) { fileName = fn; }

        public async Task<string> StringRead()
        {
            Stream s = new FileStream(fileName, FileMode.Open);
            StreamReader r = new StreamReader(s);
            r.Close();
            s.Close();

            return await r.ReadToEndAsync();
        }

        public PersonLib.Person BinRead()
        {

            IFormatter formatter = new BinaryFormatter();

            PersonLib.Person tempPerson = (PersonLib.Person)formatter.Deserialize(tempBinaryStream);
            callback = new AsyncCallback(this.OnCompletedRead);
            tempBinaryStream.Close();

            return tempPerson;
        }
    }
}
