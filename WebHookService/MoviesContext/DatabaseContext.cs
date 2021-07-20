using Microsoft.EntityFrameworkCore;
using WebhooksAPIStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebhooksAPIStore.MoviesContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
          
        }
        public DbSet<RegisterUser> RegisterUser { get; set; }
        public DbSet<ServicesTB> ServicesTB { get; set; }
        public DbSet<SizeTB> SizeTB { get; set; }
        public DbSet<APIManagerTB> APIManagerTB { get; set; }
        public DbSet<WebhooksTB> WebhooksTB { get; set; }
        public DbSet<UrlTB> UrlTB { get; set; }
        public DbSet<LoggerTB> LoggerTB { get; set; }

        
    }
}
