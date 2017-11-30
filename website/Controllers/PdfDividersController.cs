using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace website.Controllers
{
    [Route("api/[controller]")]
    public class PdfDividersController: Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value2", "value1" };
        }
        [HttpPost]
        public string Post(int id)
        {
            return id.ToString();
        }
    }
}
