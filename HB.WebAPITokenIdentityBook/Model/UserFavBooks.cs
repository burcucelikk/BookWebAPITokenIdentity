namespace HB.WebAPITokenIdentiyBook.Model
{
	public class UserFavBooks
	{
        public string AppUserId { get; set; }
		public int BookId { get; set; }
		public AppUser AppUser { get; set; }
		public Book Books { get; set; }
    }
}
