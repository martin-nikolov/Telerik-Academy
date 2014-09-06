/*
 * 7. In a text file we are given the name, address and phone number
 * of given person (each at a single line). Write a program, which 
 * creates new XML document, which contains these data in structured XML format.
 */

namespace ProcessingXml
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    public class ConvertTextToXml
    {
        public static void Main()
        {
            var fileContent = GetFileTextContent("../../persons.txt");
            var persons = ExtractSubscribers(fileContent);
            
            var phonebookXml = GeneratePhonebookAsXml(persons);
            PrintAndSavePhonebookXml(phonebookXml);
        }

        private static XElement GeneratePhonebookAsXml(IList<Person> persons)
        {
            var phonebookXml = new XElement(XName.Get("phonebook"));
            var listOfPersonsXml = new XElement("persons");

            foreach (var person in persons)
            {
                var personXml = new XElement("person",
                    new XElement("name", person.Name),
                    new XElement("address", person.Address),
                    new XElement("phone-number", person.PhoneNumber));

                listOfPersonsXml.Add(personXml);
            }

            phonebookXml.Add(listOfPersonsXml);
            return phonebookXml;
        }

        private static void PrintAndSavePhonebookXml(XElement phonebookXml)
        {
            Console.WriteLine(phonebookXml);
            phonebookXml.Save("../../phonebook.xml");
        }

        private static IList<Person> ExtractSubscribers(string text)
        {
            var splitByLine = text.Split('\n');
            var persons = new List<Person>();

            foreach (var line in splitByLine)
            {
                var person = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(a => a.Trim())
                                 .ToArray();

                persons.Add(new Person()
                {
                    Name = person[0],
                    Address = person[1],
                    PhoneNumber = person[2]
                });
            }

            return persons;
        }

        private static string GetFileTextContent(string fullPath)
        {
            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException("File does not exist. File name: " + fullPath);
            }

            string textContent = string.Empty;

            using (var reader = new StreamReader(fullPath))
            {
                textContent = reader.ReadToEnd();
            }

            return textContent;
        }
    }
}