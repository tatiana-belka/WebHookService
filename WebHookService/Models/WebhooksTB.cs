using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebhooksAPIStore.Models
{
    [Table("WebhooksTB")]
    public class WebhooksTB
    {
        [Key]
        public long WebhookID { get; set; }
        public string Title { get; set; }
        public string Host { get; set; }
        public string Rated { get; set; }
        public DateTime? Date { get; set; }
        public string ID { get; set; }
        public string Connection { get; set; }
        public string Contetntype { get; set; }
        public string QueryString { get; set; }
        public string Language { get; set; }
        public string FormValues { get; set; }
        public string RavContent { get; set; }
        public string Trace { get; set; }
        public string Production { get; set; }
        public string Website { get; set; }
    }

}
