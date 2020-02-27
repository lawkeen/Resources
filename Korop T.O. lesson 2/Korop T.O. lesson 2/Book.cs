using System;
using System.Diagnostics;
using System.Globalization;

namespace Korop_T.O._lesson_2
{
    /// <summary>
    /// Class for resource with type = "Book"
    /// </summary>
    public class Book : Source
    {
        public Book()
        {
        }

        private readonly string _name;
        private readonly string _type;
        private readonly string _year;
        private readonly string _publishingHouse;
        private readonly string _author;

        public Book(string type, string name, string author, string year, string publishingHouse)
        {
            this._type = type;
            this._author = author;
            this._name = name;
            this._year = year;
            this._publishingHouse = publishingHouse;
            Trace.WriteLine("_name = " + _name + "; _author = " + _author + "; _year = " + _year +
                            "; _publishingHouse = " + _publishingHouse);
        }

        /// <summary>
        /// Method to return the name of resource
        /// </summary>
        /// <returns></returns>
        protected override string Name()
        {
            return _name;
        }

        /// <summary>
        /// Method to return the name of book
        /// </summary>
        /// <returns>name</returns>
        protected override string Author()
        {
            return _author;
        }

        /// <summary>
        /// Method to return the type of resource
        /// </summary>
        /// <returns>type</returns>
        protected override string Type()
        {
            return _type;
        }

        /// <summary>
        /// Method to return the year of book was typed
        /// </summary>
        /// <returns>year</returns>
        private string Year()
        {
            return _year;
        }

        /// <summary>
        /// Method to return the publishing house of book
        /// </summary>
        /// <returns>publishingHouse</returns>
        private string PublishingHouse()
        {
            return _publishingHouse;
        }

        /// <summary>
        /// Method to show all info about book
        /// </summary>
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Год: {Year()}\n" +
                              $"Издательство: {PublishingHouse()}\n");
        }
    }
}