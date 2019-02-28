using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestPersonLib
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName1 = @"C:\Users\andre\source\repos\Sem3_DNP_Threading\idiot1.bin";
            string fileName2 = @"C:\Users\andre\source\repos\Sem3_DNP_Threading\idiot2.bin";


            PersonLib.Person person1 = new PersonLib.Person("smartfirstname", "smartsurname", 123);
            PersonLib.Person person2 = new PersonLib.Person("smartfirstname1", "smartsurname1", 1234);

            Stream outputBinaryStream1 = new FileStream(fileName1, FileMode.OpenOrCreate, FileAccess.Write);
            Stream outputBinaryStream2 = new FileStream(fileName2, FileMode.OpenOrCreate, FileAccess.Write);
            Stream inputBinaryStream1 = new FileStream(fileName1, FileMode.Open, FileAccess.Read, FileShare.Read);
            Stream inputBinaryStream2 = new FileStream(fileName2, FileMode.Open, FileAccess.Read, FileShare.Read);


            // WRITING TO BIN FILES
            AsyncSerializeAndWrite(outputBinaryStream1, outputBinaryStream2, person1, person2);

            Thread.Sleep(1000);
            // READING & COMPARING BIN FILES
            AsyncCompareBinFiles(fileName1, fileName2);

            Console.ReadKey();
        }

        public static async void AsyncCompareBinFiles(FileStream fileStream1, FileStream fileStream2, string fileName1, string fileName2)
        {
            NotepadComparerLib.Reader reader1 = new NotepadComparerLib.Reader(fileName1);
            NotepadComparerLib.Reader reader2 = new NotepadComparerLib.Reader(fileName2);

            PersonLib.Person tempPerson1 = await reader1.BinRead();
            PersonLib.Person tempPerson2 = await reader2.BinRead();

            Comparer<PersonLib.Person>.Equals(task1, task2);
        }

        public static void AsyncSerializeAndWrite(FileStream fileStream1, FileStream fileStream2, PersonLib.Person person1, PersonLib.Person person2)
        {
            IFormatter binaryFormater = new BinaryFormatter();

            binaryFormater.Serialize(fileStream1, person1);
            binaryFormater.Serialize(fileStream2, person2);

            fileStream1.Close();
            fileStream2.Close();
        }
    }
}
