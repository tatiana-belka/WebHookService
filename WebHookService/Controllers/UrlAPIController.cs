using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebhooksAPIStore.Repository;
using WebhooksAPIStore.Models;



namespace WebhooksAPIStore.Controllers
{
    [Route("api/[controller]")]
    public class UrlAPIController : Controller
    {

        IUrl _IUrl;
        public UrlAPIController(IUrl IUrl)
        {
            _IUrl = IUrl;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public List<UrlTB> Post([FromQuery]string key)
        {
            try
            {
                return _IUrl.GetUrlStore();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
