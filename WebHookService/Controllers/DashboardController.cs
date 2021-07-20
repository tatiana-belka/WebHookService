using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebhooksAPIStore.Filters;
using WebhooksAPIStore.Repository;



namespace WebhooksAPIStore.Controllers
{

    
    [ValidateUserSession]
    public class DashboardController : Controller
    {
        ISize _ISize;
        public DashboardController(ISize ISize)
        {
            _ISize = ISize;
        }

        // GET: /<controller>/
        public IActionResult Dashboard()
        {
            try
            {
                var movieCountList = string.Join(",", _ISize.GetChartsWebhooksreport());
                var musicCountList = string.Join(",", _ISize.GetChartsUrlreport());
                ViewBag.MovieCountList = movieCountList;
                ViewBag.MusicCountList = musicCountList;
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
