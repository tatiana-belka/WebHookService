using WebhooksAPIStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebhooksAPIStore.Repository
{
    public interface ISize
    {
        List<SizeTB> GetSizeList();
        List<string> GetChartsWebhooksreport();
        List<string> GetChartsUrlreport();
    }
}
