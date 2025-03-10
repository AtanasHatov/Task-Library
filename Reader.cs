using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectLibrary
{
    public class Reader
    {
		private string name;

		public string Name
		{
			get { return name; }
			set { this.name = value; }
		}

		private int id;

		public int Id
		{
			get { return id; }
			set { this.id = value; }
		}

		private int age;

		public int Age
		{
			get { return age; }
			set { this.age = value; }
		}

		private List<Book> zaemaniBook;

		public List<Book> ZaemaniBook
		{
			get { return zaemaniBook; }
			set { this.zaemaniBook = value; }
		}

        public Reader(string name, int id, int age, List<Book> zaemaniBook)
        {
            Name = name;
            Id = id;
            Age = age;
            ZaemaniBook = new List<Book>();
        }
    }
}
