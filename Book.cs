using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectLibrary
{
    public class Book
    {
		private string title;

		public string Title
		{
			get { return title; }
			set { this.title = value; }
		}

		private string author;

		public string Author
		{
			get { return author; }
			set { this.author = value; }
		}

		private string genre;

		public string Genre
		{
			get { return genre; }
			set { this.genre = value; }
		}
		private int brAvaibelCopys;

		public int BrAvaibelCopys
        {
			get { return brAvaibelCopys; }
			set { this.brAvaibelCopys = value; }
		}

		private int brTimesVzemana;

		public int BrTimesVzemana
        {
			get { return brTimesVzemana; }
			set { this.brTimesVzemana = value; }
		}

        public Book(string title, string author, string genre, int brAvaibelCopys, int brTimesVzemana)
        {
            Title = title;
            Author = author;
            Genre = genre;
            BrAvaibelCopys = brAvaibelCopys;
            BrTimesVzemana = brTimesVzemana;
        }
    }
}
