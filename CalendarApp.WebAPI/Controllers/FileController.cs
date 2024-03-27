using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using CalendarApp.Services.Models;
using Microsoft.AspNetCore.Http;

namespace CalendarApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromForm] FileModel file)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.FileName);

                using (Stream stream = new FileStream(path, FileMode.Create)) 
                {
                    file.FormFile.CopyTo(stream);
                }
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult Get(int userTz)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", $"{userTz}.jpg");
                var imageFileStream = System.IO.File.OpenRead(path);
                return File(imageFileStream, "image/jpeg");
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status404NotFound);
            }
            
        }
    }
}
