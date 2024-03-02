using Microsoft.AspNetCore.Mvc;
using YARSUWIKI.DAL.Interfaces;
using YARSUWIKI.DOMAIN.Entity;

namespace YARSUWIKI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        // GET api/author/getauthors
        [HttpGet("getauthors")]
        public async Task<IActionResult> GetAuthors()
        {
            var response = await _authorRepository.Select();
            return Ok(response); // Возвращает JSON
        }
    }
}