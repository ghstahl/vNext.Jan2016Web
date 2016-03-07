﻿using System.Collections.Generic;
using System.Dynamic;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json.Linq;

namespace Basic.Controllers
{
    [Area("api")]
    [Produces("application/json")]
    public class DynamicTypesController:Controller
    {
        [HttpPost("kittens")]
        public int CreateKitten([FromBody]dynamic kitten)
        {
            return 1;
        }

        [HttpGet("unicorns")]
        public ExpandoObject GetUnicorns()
        {
            return new ExpandoObject(); 
        }

        [HttpPost("dragons")]
        public IActionResult CreateDragons([FromBody]object dragon)
        {
            return new ObjectResult(1);
        }

        [HttpGet("wizards")]
        public IEnumerable<JObject> GetWizards()
        {
            return new[]
            {
                new JObject(),
                new JObject()
            };
        }
    }
}