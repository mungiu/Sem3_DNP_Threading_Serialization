using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ComparingFileContents
{
    class Program
    {
        static void Main(string[] args)
        {
            // string fileName1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "thisisanidiot.txt");
            // string fileName2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "thisisnotanidiot.txt");
            string fileName1 = @"C:\Users\andre\source\repos\Sem3_DNP_Threading\idiot1.txt";
            string fileName2 = @"C:\Users\andre\source\repos\Sem3_DNP_Threading\idiot2.txt";
            NotepadReadWriteLibrary.Reader reader = new NotepadReadWriteLibrary.Reader(fileName1);
            NotepadReadWriteLibrary.Reader reader1 = new NotepadReadWriteLibrary.Reader(fileName2);


            Thread t0 = new Thread(reader.StringRead);
            Thread t1 = new Thread(reader1.StringRead);
            t0.Start();
            t1.Start();

            t0.Join(); // nothing
            t1.Join();

            Console.WriteLine(reader.data);
            Console.WriteLine(reader1.data);
            Console.WriteLine(Comparer<string>.Equals(reader.data, reader1.data));

            Console.ReadKey();
        }
    }
}
