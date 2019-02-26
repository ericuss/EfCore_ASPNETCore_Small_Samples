
namespace Creating.From.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Creating.From.Api.Models;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsV2Controller : ControllerBase
    {
        public static IEnumerable<AuthorDto> _authors { get; set; } = new List<AuthorDto>();
        
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return this.Ok(_authors);
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

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] AuthorCreateDto authorCreate)
        {
            if (string.IsNullOrWhiteSpace(authorCreate.Name))
            {
                return this.BadRequest(new { message = "author name cannot be empty"});
            }
            else if (_authors.Any(x => x.Name == authorCreate.Name))
            {
                return this.BadRequest(new { message = "author name has been created before"});
            }

            var newAuthor = new AuthorDto()
            {
                Id = Guid.NewGuid(),
                Name = authorCreate.Name
            };

            var authors = _authors.ToList();
            authors.Add(newAuthor);;
            _authors =authors;

            return this.Ok(newAuthor);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]AuthorCreateDto authorCreate )
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
            return this.Ok(author);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            if (_authors.Any(x => x.Id == id))
            {
                return this.NotFound(new { message = "author name was not found"});
            }

            _authors = _authors.Where(x => x.Id != id);
            return this.Ok();
        }
    }
}
