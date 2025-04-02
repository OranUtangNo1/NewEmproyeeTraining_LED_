using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace XmlSerializationExample
{
    // クラスの定義：シリアライズ対象のクラス
    [XmlRoot("Person")]
    public class Person
    {
        // XmlElementという属性をつけることでxmlファイル読み書き時のタグを指定できる
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Age")]
        public int Age { get; set; }

        [XmlElement("Address")]
        public Address Address { get; set; }

        // コレクション型のプロパティ
        [XmlArray("PhoneNumbers")]
        [XmlArrayItem("PhoneNumber")]
        public List<string> PhoneNumbers { get; set; }

        // XmlIgnore属性をつけるとシリアライズ対象から外れる
        [XmlIgnore]
        public string Secret { get; set; }

        public Person() { }

        public Person(string name, int age, Address address, List<string> phoneNumbers)
        {
            Name = name;
            Age = age;
            Address = address;
            PhoneNumbers = phoneNumbers;
        }
    }

    // 住所情報を持つクラス
    public class Address
    {
        [XmlElement("Street")]
        public string Street { get; set; }

        [XmlElement("City")]
        public string City { get; set; }

        [XmlElement("PostalCode")]
        public string PostalCode { get; set; }

        public Address() { }

        public Address(string street, string city, string postalCode)
        {
            Street = street;
            City = city;
            PostalCode = postalCode;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string dirPath = @"..\..\..\personalfile";
            string fileName = "person.xml";
            string filePath = Path.Combine(dirPath, fileName);

            Directory.CreateDirectory(dirPath);

            // シリアライズするオブジェクトを作成
            Address address = new Address("123 Main St", "Springfield", "12345");
            List<string> phoneNumbers = new List<string> { "123-456-7890", "987-654-3210" };
            Person person = new Person("John Doe", 30, address, phoneNumbers);

            // シリアライズして XML ファイルに保存
            SerializeToXmlFile(person, filePath);
            Console.WriteLine($"Serialized data saved to {filePath}");

            // XML ファイルからデシリアライズ
            Person deserializedPerson = DeserializeFromXmlFile(filePath);
            Console.WriteLine("\nDeserialized Object:");
            Console.WriteLine($"Name: {deserializedPerson.Name}");
            Console.WriteLine($"Age: {deserializedPerson.Age}");
            Console.WriteLine($"Street: {deserializedPerson.Address.Street}");
            Console.WriteLine($"Phone Numbers: {string.Join(", ", deserializedPerson.PhoneNumbers)}");
        }

        // オブジェクトを XML ファイルにシリアライズするメソッド
        public static void SerializeToXmlFile(object obj, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fs, obj);
            }
        }

        // XML ファイルからオブジェクトをデシリアライズするメソッド
        public static Person DeserializeFromXmlFile(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Person));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                return (Person)serializer.Deserialize(fs);
            }
        }
    }
}
