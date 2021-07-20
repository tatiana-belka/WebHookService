using WebhooksAPIStore.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebhooksAPIStore.Models
{
    public class GenerateKeysVM
    {
        [Required(ErrorMessage ="Choose Service")]
        [ServiceValidate]
        public int? ServiceID { get; set; }
        [SizeValidate]
        [Required(ErrorMessage = "Choose Max Request")]
        public int? SizeID { get; set; }

        public List<SizeTB> ListSize { get; set; }
        public List<ServicesTB> ListServices { get; set; }

        public string APIKey { get; set; }
    }
}
