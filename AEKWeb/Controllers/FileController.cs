﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AEKWeb.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class FileController : Controller
    {

        [HttpGet("{fileName}")]
        public IActionResult Index(string fileName)
        {

            var bytes = System.IO.File.ReadAllBytes("Files/" + fileName + ".zip");

            return File(bytes, "application/octet-stream", fileName + ".zip", false);
        }

    }
}
