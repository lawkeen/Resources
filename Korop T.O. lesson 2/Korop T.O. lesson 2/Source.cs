using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Korop_T.O._lesson_2
{
    /// <summary>
    /// Abstract class with parental function ShowInfo displaying information which in all 3 classes 
    /// </summary>
    public abstract class Source
    {
        /// <summary>
        /// Method to return the type of resource
        /// </summary>
        /// <returns></returns>
        protected abstract string Type();

        /// <summary>
        /// Method to return the name of resource
        /// </summary>
        /// <returns></returns>
        protected abstract string Name();

        /// <summary>
        /// Method to return the author of resource
        /// </summary>
        /// <returns></returns>
        protected abstract string Author();

        /// <summary>
        /// Method which shows main info about resource
        /// </summary>
        public virtual void ShowInfo()
        {
            Console.WriteLine($"Издание типа: {Type()}\n" +
                              $"Название: {Name()}\n" +
                              $"Фамилия автора: {Author()}"
            );
        }

        /// <summary>
        /// Method to search resources with author's surname
        /// </summary>
        /// <param name="fam"></param>
        public virtual void Search(string fam)
        {
            if (Author() == fam)
            {
                Console.WriteLine($"Данный автор издавался в {Name()}");
            }
        }
    }

    /// <summary>
    /// Main class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Array with resources
        /// </summary>
        static List<Source> mySources = new List<Source>();

        /// <summary>
        /// Array with unparsed strings
        /// </summary>
        private static string[] _inp = new string[1024];

        /// <summary>
        /// Surname of author you want to search
        /// </summary>
        private static string _fam;

        private static string _type,
            _name,
            _author,
            _year,
            _publishingHouse,
            _magazineName,
            _magazineNumber,
            _link,
            _annotation;


        /// <summary>
        /// Method to read the file
        /// </summary>
        private static void ReadFile()
        {
            _inp = File.ReadAllLines("input.txt", Encoding.Default);
            try
            {
                /*using (var sR = new StreamReader("input.txt", System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sR.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(line) && string.IsNullOrEmpty(line)) continue;
                        _inp[counter] = line;
                        counter++;
                    }
                }*/

                foreach (var i in _inp)
                {
                    Trace.WriteLine("Строка из файла = " + i);
                    var str = i.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                    switch (_type = str[0])
                    {
                        case "Book":
                            _name = str[1];
                            _author = str[2];
                            _year = str[3];
                            _publishingHouse = str[4];
                            mySources.Add(new Book(_type, _name, _author, _year, _publishingHouse));
                            break;
                        case "Paper":
                            _name = str[1];
                            _author = str[2];
                            _magazineNumber = str[4];
                            _magazineName = str[3];
                            mySources.Add(new Paper(_type, _name, _author, _magazineNumber, _magazineName));
                            break;
                        case "EResource":
                            _name = str[1];
                            _author = str[2];
                            _link = str[3];
                            _annotation = str[4];
                            mySources.Add(new EResources(_type, _author, _name, _link, _annotation));
                            break;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Входной файл не найден");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Входной файл не найден");
            }
        }


        /// <summary>
        /// Main with calling all base methods
        /// </summary>
        public static void Main()
        {
            ReadFile();

            Serialize(mySources);

            Console.WriteLine(
                "Введите фамилию, поиск по которой вы хотите выполнить или нажмите 1, если хотите вывести всю информацию");
            _fam = Console.ReadLine();

            if (_fam != null && _fam.ToLower() == "1")
            {
                foreach (var src in mySources)
                {
                    src.ShowInfo();
                }
            }
            else
            {
                foreach (var src in mySources)
                {
                    src.Search(_fam);
                }
            }
        }

        /// <summary>
        /// Serialization into output.txt
        /// </summary>
        /// <param name="f">List of resources</param>
        private static void Serialize(List<Source> f)
        {
            var types = new[] {typeof(EResources), typeof(Book), typeof(Paper)};
            var serializer = new XmlSerializer(typeof(Source), types);
            using (var sW = new StreamWriter("output.txt"))
            {
                foreach (var item in f)
                {
                    serializer.Serialize(sW, item);
                }
            }
        }
    }
}