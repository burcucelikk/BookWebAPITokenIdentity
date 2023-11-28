using Microsoft.AspNetCore.Identity;

namespace HB.WebAPITokenIdentiyBook.Model
{
	public class AppUser :IdentityUser
	{
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public List<UserFavBooks> UserFavBooks { get; set; }
    }
}
