using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebhooksAPIStore.Models;
using WebhooksAPIStore.MoviesContext;

namespace WebhooksAPIStore.Repository
{
    public class UrlConcrete : IUrl
    {
        private DatabaseContext _context;
        public UrlConcrete(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/LatestUrl
        public List<UrlTB> GetUrlStore()
        {
            try
            {
                var listofUrl = _context.UrlTB.ToList();
                return listofUrl;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
