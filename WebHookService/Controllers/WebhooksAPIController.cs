using Microsoft.AspNetCore.Mvc;
using WebhooksAPIStore.Models;
using WebhooksAPIStore.Repository;
using System.Collections.Generic;

namespace WebhooksAPIStore.Controllers
{
    [Route("api/[controller]")]
    public class WebhooksAPIController : Controller
    {
        IWebhooks _IWebhooks;
        public WebhooksAPIController(IWebhooks IWebhooks)
        {
            _IWebhooks = IWebhooks;
        }

        // POST api/values
        [HttpPost]
        public List<WebhooksTB> Post([FromQuery]string key)
        {
            return _IWebhooks.GetWebhooksStore();
        }
    }
}
