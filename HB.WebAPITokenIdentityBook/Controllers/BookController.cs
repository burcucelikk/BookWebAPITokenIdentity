using HB.WebAPITokenIdentiyBook.Context;
using HB.WebAPITokenIdentiyBook.Dtos;
using HB.WebAPITokenIdentiyBook.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HB.WebAPITokenIdentiyBook.Controllers
{
	[Authorize]
	public class BookController : Controller
	{
		private readonly AppDbContext _context;
        public BookController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("Get")]
		public async Task<IActionResult> Get()
		{
			var books= await _context.Books.ToListAsync();
			return Ok(books);
		}
		[HttpGet("Get/{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var book = await _context.Books.FirstOrDefaultAsync(x=>x.Id==id);
			return Ok(book);
		}

		[HttpPost("Add")]
		public async Task<IActionResult> Add(BookDto bookDto)
		{
			Book book = new() 
			{
				BookName = bookDto.BookName,
				Category = bookDto.Category,
				Author = bookDto.Author,
				PageCount = bookDto.PageCount,
				//Color = bookDto.Color
			};
			await _context.Books.AddAsync(book);
			await _context.SaveChangesAsync();

			return StatusCode(201);
		}
		[HttpPut("Update")]
		public async Task<IActionResult> Update(BookDto bookDto)
		{
			//await _context.Books.Update();
			return Ok();
		}
		[HttpPut("Update/{id}")]
		public async Task<IActionResult> Update(int id)
		{
			var book = await _context.Books.FirstOrDefaultAsync(x=>x.Id==id);
			return Ok(book);
		}
		[HttpDelete("Delete/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var book= await _context.Books.FirstOrDefaultAsync(x=>x.Id==id);
			if (book != null)
			{
				_context.Books.Remove(book);
				await _context.SaveChangesAsync();
			}
			return Ok();
		}
	}
}
