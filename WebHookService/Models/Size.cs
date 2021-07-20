using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebhooksAPIStore.Models
{
    [Table("SizeTB")]
    public class SizeTB
    {
        [Key]
        public long SizeID { get; set; }
        public long Size { get; set; }
        public string SizeDisplay { get; set; }
        
    }
}
