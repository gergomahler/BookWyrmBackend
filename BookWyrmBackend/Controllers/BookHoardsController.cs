using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookWyrmBackend;
using BookWyrmBackend.Models;

namespace BookWyrmBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookHoardsController : ControllerBase
    {
        private readonly UserContext _context;

        public BookHoardsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/BookHoards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookHoard>>> GetBookHoards()
        {
            return await _context.BookHoards.ToListAsync();
        }

        // GET: api/BookHoards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookHoard>> GetBookHoard(int id)
        {
            var bookHoard = await _context.BookHoards.FindAsync(id);

            if (bookHoard == null)
            {
                return NotFound();
            }

            return bookHoard;
        }

        // PUT: api/BookHoards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookHoard(int id, BookHoard bookHoard)
        {
            if (id != bookHoard.Id)
            {
                return BadRequest();
            }

            _context.Entry(bookHoard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookHoardExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BookHoards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BookHoard>> PostBookHoard(BookHoard bookHoard)
        {
            _context.BookHoards.Add(bookHoard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookHoard", new { id = bookHoard.Id }, bookHoard);
        }

        // DELETE: api/BookHoards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BookHoard>> DeleteBookHoard(int id)
        {
            var bookHoard = await _context.BookHoards.FindAsync(id);
            if (bookHoard == null)
            {
                return NotFound();
            }

            _context.BookHoards.Remove(bookHoard);
            await _context.SaveChangesAsync();

            return bookHoard;
        }

        private bool BookHoardExists(int id)
        {
            return _context.BookHoards.Any(e => e.Id == id);
        }
    }
}
