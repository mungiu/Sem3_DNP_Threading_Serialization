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
        private static Stream binaryStream1;
        private static Stream binaryStream2;
        private static Stream outputBinaryStream1;
        private static Stream outputBinaryStream2;
        private static byte[] buffer = new byte[256];
        private static AsyncCallback callback;

        static void Main(string[] args)
        {
            string filePath1 = @"C:\Users\Home\Source\Repos\mungiu\Sem3_DNP_Threading_Serialization\Idiot1.txt";
            string filePath2 = @"C:\Users\Home\Source\Repos\mungiu\Sem3_DNP_Threading_Serialization\Idiot2.txt";

            PersonLib.Person person1 = new PersonLib.Person("smartfirstname", "smartsurname", 123);
            PersonLib.Person person2 = new PersonLib.Person("smartfirstname1", "smartsurname1", 1234);

            // calling beginStream with callback delegate
            binaryStream1 = new FileStream(filePath1, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            binaryStream2 = new FileStream(filePath2, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

            
            // callback = new AsyncCallback(OnCompletedRead);


            // WRITING TO BIN FILES
            SerializeAndWritePersonToBinFiles((FileStream)binaryStream1, (FileStream)binaryStream2, person1, person2);
            // READING & COMPARING BIN FILES
            ComparePersonsFromBinFiles(null, null, filePath1, filePath2);



            binaryStream1.Close();
            binaryStream2.Close();
            Console.ReadKey();
        }

        public static void OnCompletedRead(IAsyncResult result)
        {
            int bytesRead1 = binaryStream1.EndRead(result);
            int bytesRead2 = binaryStream2.EndRead(result);
        }

        public static bool ComparePersonsFromBinFiles(FileStream fileStream1, FileStream fileStream2, string filePath1, string filePath2)
        {
            NotepadReadWriteLibrary.Reader reader1 = new NotepadReadWriteLibrary.Reader(filePath1);
            NotepadReadWriteLibrary.Reader reader2 = new NotepadReadWriteLibrary.Reader(filePath2);

            PersonLib.Person _person1 = reader1.BinRead((FileStream) binaryStream1);
            PersonLib.Person _person2 = reader2.BinRead((FileStream) binaryStream2);

            return Comparer<PersonLib.Person>.Equals(_person1, _person2);
        }

        public static void SerializeAndWritePersonToBinFiles(FileStream fileStream1, FileStream fileStream2, PersonLib.Person person1, PersonLib.Person person2)
        {
            NotepadReadWriteLibrary.Writer _writer1 = new NotepadReadWriteLibrary.Writer(fileStream1, person1);
            NotepadReadWriteLibrary.Writer _writer2 = new NotepadReadWriteLibrary.Writer(fileStream2, person2);

            _writer1.BinWrite();
            _writer2.BinWrite();
        }
    }
}
