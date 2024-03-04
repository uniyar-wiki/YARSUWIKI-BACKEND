using YARSUWIKI.SERVICE.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace YARSUWIKI.Controllers;
[Route("api/")]
[ApiController]

public class StorageController : Controller
{
    private readonly IStorageService _storageService;

    public StorageController(IStorageService storageService)
    {
        _storageService = storageService;
    }

    [HttpGet("storage/{fileName}")]
    public async Task<IActionResult> Download(string fileName)
    {
        if(ModelState.IsValid)
        {
            var response = await _storageService.Download(fileName);
            if(response.StatusCode == DOMAIN.Enum.StatusCode.OK)
            {
                return File(System.IO.File.ReadAllBytes("/storage/" + fileName), MimeTypes.GetMimeType("/storage/" + fileName));
            }
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Upload(System.IO.FileInfo fileInfo)
    {
        if(ModelState.IsValid) 
        { 
            try
            {
                fileInfo.CopyTo($"/storage/{fileInfo.FullName}");
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        return BadRequest();
    }
}
