using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Soap;
using System.Security.AccessControl;
using PersonLib;
using System.Xml.Serialization;

namespace TestPersonLib
{
    class Program
    {
        // If path not specified file create in current PROJECT directory (not Solution directory): 
        // <Solution_path> \ <Project_path> \ bin \ Debug \ <fileName>
        private static string fileName1;
        private static string fileName2;
        private static PersonLib.Person person1;
        private static PersonLib.Person person2;



        static void Main(string[] args)
        {
            fileName1 = @"Person1.txt";
            fileName2 = @"Person2.txt";
            person1 = new PersonLib.Person();
            person2 = new PersonLib.Person();

            person1.FirstName = "one";
            person1.LastName = "two";
            person1.Ssn = 123;

            person2.FirstName = "one";
            person2.LastName = "two";
            person2.Ssn = 123;

            /// USING BINARY FORMATTER
            ///
            IFormatter binaryFormatter = new BinaryFormatter();
            Stream writeStream;
            Stream readStream;

            // SERIALIZING
            writeStream = new FileStream(fileName1, FileMode.Create, FileAccess.Write, FileShare.None);
            binaryFormatter.Serialize(writeStream, person1);
            writeStream.Close();

            writeStream = new FileStream(fileName2, FileMode.Create, FileAccess.Write, FileShare.None);
            binaryFormatter.Serialize(writeStream, person2);
            writeStream.Close();

            // DESERIALIZING
            readStream = new FileStream(fileName1, FileMode.Open, FileAccess.Read, FileShare.Read);
            PersonLib.Person _person1 = (PersonLib.Person)binaryFormatter.Deserialize(readStream);
            readStream.Close();

            readStream = new FileStream(fileName2, FileMode.Open, FileAccess.Read, FileShare.Read);
            PersonLib.Person _person2 = (PersonLib.Person)binaryFormatter.Deserialize(readStream);
            readStream.Close();


            Console.WriteLine(_person1.Equals(_person2));


            /// USING SOAP FORMATTER
            /// NOTE: SoapFormatter serializes the root object and all of its children
            /// 
            IFormatter soapFormatter = new SoapFormatter();

            // SERIALIZING
            writeStream = new FileStream(fileName1, FileMode.Create, FileAccess.Write, FileShare.None);
            soapFormatter.Serialize(writeStream, person1);
            writeStream.Close();

            writeStream = new FileStream(fileName2, FileMode.Create, FileAccess.Write, FileShare.None);
            soapFormatter.Serialize(writeStream, person2);
            writeStream.Close();

            // DESERIALIZING
            readStream = new FileStream(fileName1, FileMode.Open, FileAccess.Read, FileShare.Read);
            _person1 = (PersonLib.Person)soapFormatter.Deserialize(readStream);
            readStream.Close();

            readStream = new FileStream(fileName2, FileMode.Open, FileAccess.Read, FileShare.Read);
            _person2 = (PersonLib.Person)soapFormatter.Deserialize(readStream);
            readStream.Close();

            Console.WriteLine(_person1.Equals(_person2));


            /// USING XML SERIALIZER
            /// PROs: 
            /// * Generally speaking it offers much more flexibility in terms of what should be serialized and how it should be serialized.
            /// * If a property or field returns a complex object (such as an array or a class instance), 
            /// the XmlSerializer converts it to an element nested within the main XML document. 
            /// For example, the first class in the following code example returns an instance of the second class.
            /// 
            /// CONs:
            /// Can ONLY seialize objects that have a parameterless constructor.
            /// 

            Type[] extraTypes = new Type[2];
            extraTypes[0] = typeof(string);
            extraTypes[1] = typeof(int);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PersonLib.Person), extraTypes);

            // SERIALIZING
            writeStream = new FileStream(fileName1, FileMode.Create, FileAccess.Write, FileShare.None);
            xmlSerializer.Serialize(writeStream, person1);
            writeStream.Close();

            writeStream = new FileStream(fileName2, FileMode.Create, FileAccess.Write, FileShare.None);
            xmlSerializer.Serialize(writeStream, person2);
            writeStream.Close();

            // DESERIALIZING
            readStream = new FileStream(fileName1, FileMode.Open, FileAccess.Read, FileShare.Read);
            _person1 = (PersonLib.Person)xmlSerializer.Deserialize(readStream);
            readStream.Close();

            readStream = new FileStream(fileName2, FileMode.Open, FileAccess.Read, FileShare.Read);
            _person2 = (PersonLib.Person)xmlSerializer.Deserialize(readStream);
            readStream.Close();

            Console.WriteLine(_person1.Equals(_person2));

            Console.ReadKey();
        }
    }
}
