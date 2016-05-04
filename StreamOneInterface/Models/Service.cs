using StreamOneInterface.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StreamOneInterface.Models
{
    public class Service : IService 
    {
        private readonly ISettings _settings;

        //Constructors
        public Service()
            : this(new Settings(true))
        {
            // Empty
        }

        public Service(Settings settings)
        {
            _settings = settings;
           
            _settings.Save();
        }

        #region Webservice functionality
        #endregion

        #region Database functionality
        #endregion
    }
}