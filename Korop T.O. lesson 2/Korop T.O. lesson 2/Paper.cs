using System;
using System.Diagnostics;

namespace Korop_T.O._lesson_2
{
    /// <summary>
    /// Class for resource with type = "Paper"
    /// </summary>
    public class Paper : Source
    {
        public Paper()
        {
        }

        private readonly string _name;
        private readonly string _type;
        private readonly string _magazineName;
        private readonly string _magazineNumber;
        private readonly string _author;

        /// <summary>
        /// Constructor for Paper class
        /// </summary>
        /// <param name="type">type of resource</param>
        /// <param name="name">name of paper</param>
        /// <param name="author">author of paper</param>
        /// <param name="magazineName">name of magazine</param>
        /// <param name="magazineNumber">number of magazine</param>
        public Paper(string type, string name, string author, string magazineName, string magazineNumber)
        {
            this._type = type;
            this._author = author;
            this._name = name;
            this._magazineName = magazineName;
            this._magazineNumber = magazineNumber;
            Trace.WriteLine("_name = " + _name + "; _author = " + _author + "; _magazineNumber = " +
                            _magazineNumber +
                            "; _magazineName = " + _magazineName);
        }

        /// <summary>
        /// Method to return the name of paper
        /// </summary>
        /// <returns>name</returns>
        protected override string Name()
        {
            return _name;
        }

        /// <summary>
        /// Method to return the author of paper
        /// </summary>
        /// <returns>author</returns>
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
        /// Method to return the name of magazine
        /// </summary>
        /// <returns>magazineName</returns>
        private string MagazineName()
        {
            return _magazineName;
        }

        /// <summary>
        /// Method to return the number of magazine
        /// </summary>
        /// <returns>magazineNumber</returns>
        private string MagazineNumber()
        {
            return _magazineNumber;
        }

        /// <summary>
        /// Method to show the info about paper
        /// </summary>
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Название журнала: {MagazineName()}\n" +
                              $"Номер журнала: {MagazineNumber()}\n");
        }
    }
}