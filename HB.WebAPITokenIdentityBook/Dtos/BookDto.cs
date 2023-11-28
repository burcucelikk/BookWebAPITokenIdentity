using System.Drawing;

namespace HB.WebAPITokenIdentiyBook.Dtos
{
	public class BookDto
	{
        public string BookName { get; set; }
		public string Category { get; set; }
		public string Author { get; set; }
		public int PageCount { get; set; }
		public Color Color { get; set; } = new();
    }
}
