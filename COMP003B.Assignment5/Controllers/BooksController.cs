using COMP003B.Assignment5.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace COMP003B.Assignment5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        //in-memory DB
        private List<Book> _books = new List<Book>();

        //Books List
        public BooksController()
        {
            _books.Add(new Book { Id = 1, Title = "The Way of Kings", Author = "Brandon Sanderson", Series = "The Stormlight Archive", BookNum = "Book 1" });
            _books.Add(new Book { Id = 2, Title = "Burner", Author = "Mark Greaney", Series = "Gray Man", BookNum = "Book 12" });
            _books.Add(new Book { Id = 3, Title = "Long Shadows", Author = "David Baldacci", Series = "Memory Man", BookNum = "Book 7" });
            _books.Add(new Book { Id = 4, Title = "Malice", Author = "John Gwynne", Series = "The Faithful and the Fallen", BookNum = "Book 1" });
            _books.Add(new Book { Id = 5, Title = "The Salmon of Doubt", Author = "Douglas Adams", Series = "Dirk Gently", BookNum = "Book 3" });
        }


        // GET: All
        [HttpGet]
        public  ActionResult<IEnumerable<Book>> GetAllBooks() 
        {
            return _books;
        }


        // GET: ID
        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        { 
            var book = _books.Find(x => x.Id == id);

            if (book == null)
            { 
                return NotFound();
            }
            
            return book; 
        }

        // POST
        [HttpPost]
        public ActionResult<Book> AddBook(Book book)
        { 
            book.Id = _books.Max(x => x.Id) + 1;
            _books.Add(book);

            return CreatedAtAction(nameof(AddBook), new { id = book.Id }, book);
        }

        // PUT
        [HttpPut]
        public IActionResult PutBook(int id,Book newbook) 
        {
            var book = _books.Find(x => x.Id == id);

            if(book == null) 
            {
                return BadRequest();
            }

            book.Id = newbook.Id;
            book.Title = newbook.Title;
            book.Author = newbook.Author;
            book.Series = newbook.Series;
            book.BookNum = newbook.BookNum;

            return NoContent();

        }

        // DELETE
        [HttpDelete]
        public IActionResult DeleteBook(int id) 
        {
            var book = _books.Find(x =>x.Id == id);

            if (book == null) 
            {
                return NotFound();
            }

            _books.Remove(book);

            return NoContent();

        }
        
    }
}
