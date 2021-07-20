using WebhooksAPIStore.Models;
using WebhooksAPIStore.MoviesContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebhooksAPIStore.Repository
{
    public class WebhooksConcrete : IWebhooks
    {
        private DatabaseContext _context;
        public WebhooksConcrete(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/LatestWebhooks
        public List<WebhooksTB> GetWebhooksStore()
        {
            try
            {
                var listofMovies = _context.WebhooksTB.ToList();
                return listofMovies;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
