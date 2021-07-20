using WebhooksAPIStore.Models;
using System.Collections.Generic;

namespace WebhooksAPIStore.Repository
{
    public interface IWebhooks
    {
        List<WebhooksTB> GetWebhooksStore();
    }
}
