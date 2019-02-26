
namespace Creating.From.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Creating.From.Api.Models;
    using Creating.From.Context.Contexts;
    using Creating.From.Context.Entities;
    using Microsoft.EntityFrameworkCore;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsV3Controller : ControllerBase
    {
        private readonly LibraryContext _context;

        private readonly DbSet<Author> _authors;
        
        public AuthorsV3Controller(LibraryContext context)
        {
            this._context = context;
            this._authors = this._context.Authors;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var authors = await _authors.ToListAsync();
            return this.Ok(authors);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var author = _authors.FirstOrDefault(x => x.Id == id);
            if (author != null)
            {
                return this.Ok(author);
            }
            else
            {
                return this.NotFound();
            }
        }
        

        // GET api/values/5
        [HttpGet("search/{search}")]
        public IActionResult Search(string search)
        {
            var author = _authors.Include(x => x.Books).FirstOrDefault(x => x.Name.Contains(search));
            if (author != null)
            {
                var authorDto = new AuthorWithBooksDto(){
                    Id = author.Id,
                    Name = author.Name,
                    Books = author.Books.Select(x => x.Name).ToList()
                };
                return this.Ok(authorDto);
            }
            else
            {
                return this.NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthorCreateDto authorCreate)
        {
            if (string.IsNullOrWhiteSpace(authorCreate.Name))
            {
                return this.BadRequest(new { message = "author name cannot be empty"});
            }
            else if (_authors.Any(x => x.Name == authorCreate.Name))
            {
                return this.BadRequest(new { message = "author name has been created before"});
            }

            var newAuthor = new Author()
            {
                Id = Guid.NewGuid(),
                Name = authorCreate.Name
            };

            _authors.Add(newAuthor);;
            await _context.SaveChangesAsync();

            return this.Ok(newAuthor);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]AuthorCreateDto authorCreate )
        {
            if (authorCreate == null && string.IsNullOrWhiteSpace(authorCreate.Name))
            {
                return this.BadRequest(new { message = "author name cannot be empty"});
            }

            var author = _authors.FirstOrDefault(x => x.Id == id);

            if (author == null)
            {
                return this.NotFound(new { message = "author was not found"});
            }

            author.Name = authorCreate.Name;
            await _context.SaveChangesAsync();
            return this.Ok(author);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (_authors.Any(x => x.Id == id))
            {
                return this.NotFound(new { message = "author name was not found"});
            }

            var authorToRemove = _authors.First(x => x.Id == id);
            _authors.Remove(authorToRemove);
            await _context.SaveChangesAsync();

            return this.Ok();
        }
    }
}
