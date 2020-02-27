using System;
using System.Diagnostics;

namespace Korop_T.O._lesson_2
{
    /// <summary>
    /// Class for resource with type = "EResource"
    /// </summary>
    public class EResources : Source
    {
        public EResources()
        {
        }

        private readonly string _type;
        private readonly string _name;
        private readonly string _author;
        private readonly string _link;
        private readonly string _annotation;

        /// <summary>
        /// Constructor of EResources class
        /// </summary>
        /// <param name="type">type of it</param>
        /// <param name="author">author of it</param>
        /// <param name="name">name of it</param>
        /// <param name="link">link to it</param>
        /// <param name="annotation">annotation to it</param>
        public EResources(string type, string author, string name, string link, string annotation)
        {
            this._type = type;
            this._author = author;
            this._name = name;
            this._link = link;
            this._annotation = annotation;
            Trace.WriteLine("_name = " + _name + "; _author = " + _author + "; _link = " + _link +
                            "; _annotation = " + _annotation);
        }

        /// <summary>
        /// Method to return the name of resource
        /// </summary>
        /// <returns>name</returns>
        protected override string Name()
        {
            return _name;
        }

        /// <summary>
        /// Method to return the author of resource
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
        /// Method to return the link to resource
        /// </summary>
        /// <returns>link</returns>
        private string Link()
        {
            return _link;
        }

        /// <summary>
        /// Method to return the annotation to resource
        /// </summary>
        /// <returns>annotation</returns>
        private string Annotation()
        {
            return _annotation;
        }

        /// <summary>
        /// Method to show all info about resource
        /// </summary>
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Ссылка: {Link()}\n" +
                              $"Аннотация: {Annotation()}\n");
        }
    }
}