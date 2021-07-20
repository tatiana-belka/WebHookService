using WebhooksAPIStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebhooksAPIStore.Repository
{
    public interface IRequestLogger
    {
        void InsertLoggingData(LoggerTB loggerTB);
    }
}
