using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebhooksAPIStore.Models
{
    [Table("UrlTB")]
    public class UrlTB
    {
        [Key]
        public long UrlID { get; set; }
        public string UrlName { get; set; }
        public string WebhookName { get; set; }
        public string Request { get; set; }
        public string Tree { get; set; }
        public string Source { get; set; }
    }
}
