using StreamOneInterface.Models.Webservices.APIFacade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamOneInterface.Models.Abstract
{
    public interface IProvisioningWebService : IDisposable
    {
        APIFacadeOrder ProvisionApp(string provisionData, string token);
    }
}
