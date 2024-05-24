using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YARSU.Server.Models;
using YARSU.Server.Services;
using YARSU.Infrastructure.DataContracts;

namespace YARSU.Server.Controllers
{
    [Route("pages")]
    [ApiController]
    public class PageController : Controller
    {
        private readonly AppDbContext _context;

        public PageController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Page>> AddPage([FromBody] Page page)
        {
            _context.Pages.Add(page);
            await _context.SaveChangesAsync();
            CreatedAtAction(nameof(GetPage), new { id = page.Id }, page);
            return Ok();
        }

        // GET: api/Page/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Page>> GetPage(int id)
        {
            var page = await _context.Pages.FindAsync(id);
            if (page == null)
            {
                return NotFound();
            }

            page.Comments = (from com in _context.Comments where com.PageId == id select com).ToList();

            return page;
        }

        // PUT: api/Page/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> ModifyPage(int id, [FromBody] Page modifiedPage)
        {
            if (id != modifiedPage.Id)
            {
                return BadRequest();
            }

            _context.Entry(modifiedPage).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                if (!_context.Pages.Any(p => p.Id == id))
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

        // POST: api/Page/{pageId}/comment
        [HttpPost("{pageId}/comment")]
        public async Task<ActionResult<Comment>> AddComment(int pageId, [FromBody] Comment comment)
        {
            var page = await _context.Pages.FindAsync(pageId);



            if (page == null)
            {
                return NotFound();
            }

            page.Comments.Add(comment);
            decimal rating = Math.Round((from com in _context.Comments where com.Rating > 0 select com.Rating).Average(), 2);

            page.Ratings = rating;

            CreatedAtAction(nameof(GetPage), new { id = pageId }, comment);

            await ModifyPage(page.Id, page);

            await _context.SaveChangesAsync();

            return Ok();
        }



    }
}
