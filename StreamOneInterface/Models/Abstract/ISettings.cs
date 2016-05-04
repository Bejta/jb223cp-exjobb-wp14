using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamOneInterface.Models.Abstract
{
    public interface ISettings
    {
        string Mode { get; set; }
        string Token { get; set; }
        string CancellationURI { get; set; }
        string APIPassword { get; set; }
        string APIUsername { get; set; }

        void Initialize(bool load = false);
        void Load();
        void Save();
    }
}
