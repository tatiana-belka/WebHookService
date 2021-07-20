using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebhooksAPIStore.Models
{
    [Table("APIManagerTB")]
    public class APIManagerTB
    {
        [Key]
        public int? TokenID { get; set; }
        public string APIKey { get; set; }
        public DateTime? CreatedOn { get; set; }
        public long UserID { get; set; }
        public long? SizeID { get; set; }
        public int? ServiceID { get; set; }
        public string Status { get; set; }
        
    }
}
