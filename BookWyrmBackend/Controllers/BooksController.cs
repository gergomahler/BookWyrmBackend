﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookWyrmBackend;
using BookWyrmBackend.Models;
using Microsoft.AspNetCore.Cors;
using BookWyrmBackend.DTOs;
using Microsoft.Extensions.Logging;

namespace BookWyrmBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly UserContext _context;
        private readonly ILogger _logger;

        public BooksController(UserContext context, ILogger<BooksController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public async Task<IActionResult> PutBook(Book book)
        {

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return NoContent();
        }

        // POST: api/Books
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [EnableCors]
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookDTOObject book)
        {
           // _context.Books.Add(book);
            //await _context.SaveChangesAsync();
            _logger.LogInformation(book.ToString());



            return CreatedAtAction("GetBook", new { id = 1 }, book);
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return book;
        }

    }
}
