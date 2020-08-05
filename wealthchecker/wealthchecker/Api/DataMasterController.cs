using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using wealthchecker.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace wealthchecker.Api
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DataMasterController : ControllerBase
    {
        // GET: api/<DataMasterController>
        [HttpGet]
        public List<KiwiSaverData> Get()
        {
            return WealthTrackerOutputModel.KiwiSaverList;
        }

        // GET api/<DataMasterController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {

            return "value";
        }

        // POST api/<DataMasterController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            //HttpContext.Request.Form[""];
        }

        // PUT api/<DataMasterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DataMasterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
