using WebhooksAPIStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebhooksAPIStore.Repository
{
    public interface IServicesStore
    {
        List<ServicesTB> GetServiceList();
        List<ServicesTB> GetServiceListforDashboard();
    }
}
