﻿namespace HB.WebAPITokenIdentiyBook.Dtos
{
	public class RegisterDto
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public DateTime BirthDate { get; set; }
	}
}
