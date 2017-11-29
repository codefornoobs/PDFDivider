using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace website
{
    [Route("api/[controller]")]
    public class PdfDividersController
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value2", "value1" };
        }
    }
}
