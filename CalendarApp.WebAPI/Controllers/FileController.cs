using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using CalendarApp.Services.Models;
using Microsoft.AspNetCore.Http;
using Repository.Entities;
using CalendarApp.WebAPI.Helpers;
using CalendarApp.Repositories.Entities;

namespace CalendarApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public ActionResult Post([FromForm] FileModel file)
        {
            try
            {
                var steUserId = (SiteUserDTO)HttpContext.Items["steUserId"];
                string fileExtension = Path.GetExtension(file.FormFile.FileName);
                //TODO change file name to use tz from user
                string fileName = $"{steUserId}{fileExtension}";

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

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
            //TODO: change the userTz to other property
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
