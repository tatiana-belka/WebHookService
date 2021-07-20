using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



namespace WebhooksAPIStore.Controllers
{
    public class ErrorController : Controller
    {
        // GET: /<controller>/
        public IActionResult ErrorView()
        {
            return View();
        }
    }
}
