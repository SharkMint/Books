using BooksApi.Data;
using BooksApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AplicationContext _appcontext;

        public BooksController(AplicationContext apContext)
        {
            _appcontext = apContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetBooks()
        {
            return Ok(await _appcontext.Books.Select(x => BookDTO(x)).ToListAsync());
        }

        private object BookDTO(Books x)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Books>> GetBook(long id)
        {
            var bookItem = await _appcontext.Books.FindAsync(id);

            if (bookItem == null)
            {
                return NotFound();
            }

            return bookItem;
        }

        [HttpPost]
        public async Task<ActionResult<Books>> PostBookItem(Books bookItem)
        {
            _appcontext.Books.Add(bookItem);
            await _appcontext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBook), new { id = bookItem.Id }, bookItem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(long id, Books bookItem)
        {
            if (id != bookItem.Id)
            {
                return BadRequest();
            }

            _appcontext.Entry(bookItem).State = EntityState.Modified;

            try
            {
                await _appcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if (!BookExists(id))
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

        private bool BookExists(long id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(long id)
        {
            var bookItem = await _appcontext.Books.FindAsync(id);
            if (bookItem == null)
            {
                return NotFound();
            }

            _appcontext.Books.Remove(bookItem);
            await _appcontext.SaveChangesAsync();

            return NoContent();

        }


    }
}
