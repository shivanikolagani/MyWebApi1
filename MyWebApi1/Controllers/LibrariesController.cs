using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApi1.Models;
using MyWebApi1.DTO;

namespace MyWebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {
        private readonly MyWebApiContext _context;

        public LibrariesController(MyWebApiContext context)
        {
            _context = context;
        }

        // GET: api/Libraries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Library>>> GetLibraries()
        {
            return await _context.Libraries.ToListAsync();
        }

        // GET: api/Libraries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Library>> GetLibrary(int id)
        {
            var library = await _context.Libraries.FindAsync(id);

            if (library == null)
            {
                return NotFound();
            }

            return library;
        }

        // PUT: api/Libraries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibrary(int id, Library library)
        {
            if (id != library.LibraryId)
            {
                return BadRequest();
            }

            _context.Entry(library).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibraryExists(id))
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

        // POST: api/Libraries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Library>> PostLibrary(LibraryDTO libraryDTO)
        {
            Library library = new Library();
            library.LibraryId = libraryDTO.LibraryId;
            library.LibraryName = libraryDTO.LibraryName;
            _context.Libraries.Add(library);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LibraryExists(library.LibraryId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLibrary", new { id = library.LibraryId }, library);
        }

        // DELETE: api/Libraries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibrary(int id)
        {
            var library = await _context.Libraries.FindAsync(id);
            if (library == null)
            {
                return NotFound();
            }

            _context.Libraries.Remove(library);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibraryExists(int id)
        {
            return _context.Libraries.Any(e => e.LibraryId == id);
        }
    }
}
