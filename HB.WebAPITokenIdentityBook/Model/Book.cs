namespace HB.WebAPITokenIdentiyBook.Model
{
	public class Book
	{
        public int Id { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int PageCount { get; set; }
		public Color Color { get; set; } = new();
		public List<UserFavBooks> UserFavBooks { get; set; }
    }
    public enum Color
    {
		Red = 1,
		Blue = 2,
		Green = 3,
		Yellow = 4,
		White = 5,
		Black = 6
	}
}
