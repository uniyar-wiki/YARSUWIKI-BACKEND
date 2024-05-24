using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;
using YARSU.Server.Services;

public class StorageController : Controller
{

    [HttpGet]
    [Route("download/{filename}")]
    public async Task<IActionResult> Download(string filename)
    {
        // Define the path to the file
        var filePath = Path.Combine("storage", filename);

        if (!System.IO.File.Exists(filePath))
        {
            return NotFound();
        }

        var memory = new MemoryStream();
        using (var stream = new FileStream(filePath, FileMode.Open))
        {
            await stream.CopyToAsync(memory);
        }
        memory.Position = 0;

        return File(memory, GetContentType(filePath), filename);
    }

    private string GetContentType(string path)
    {
        var types = new Dictionary<string, string>
        {
            { ".txt", "text/plain" },
            { ".pdf", "application/pdf" },
            { ".doc", "application/vnd.ms-word" },
            { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { ".xls", "application/vnd.ms-excel" },
            { ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
            { ".png", "image/png" },
            { ".jpg", "image/jpeg" },
            { ".jpeg", "image/jpeg" },
            { ".gif", "image/gif" },
            { ".csv", "text/csv" }
        };

        var ext = Path.GetExtension(path).ToLowerInvariant();
        return types.ContainsKey(ext) ? types[ext] : "application/octet-stream";
    }



    [HttpPost]
    [Route("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        // Define the path to the storage folder
        var storagePath = Path.Combine("storage");

        // Ensure the storage directory exists
        if (!Directory.Exists(storagePath))
        {
            Directory.CreateDirectory(storagePath);
        }

        // Combine the storage path with the file name
        var filePath = Path.Combine(storagePath, Path.GetFileName(file.FileName));

        // Save the file to the storage path
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return Ok(new { filePath });
    }
}
