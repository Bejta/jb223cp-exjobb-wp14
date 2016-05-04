using Newtonsoft.Json;
using StreamOneInterface.Models.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace StreamOneInterface.Models
{
    public class Settings : ISettings 
    {
        /*  Use this line when download from GitHub
         *  settings.json will be ignored and NOT uploaded to GitHub
         *  private const string FILENAME = "settingsdummy.json";
         */
        private const string FILENAME = "settings.json";
        private readonly string _filePath;

        ////Properties
        public string Mode { get; set; }
        public string Token { get; set; } // Token for StreamOne authentication

        public string CancellationURI { get; set; }
        public string APIPassword { get; set; } // API Partner password
        public string APIUsername { get; set; }

        //Constructors
        [JsonConstructor]
        public Settings(bool load = false)
        {
            string pathAppData = HttpContext.Current.ApplicationInstance.Server.MapPath("~/App_Data/");
            _filePath = Path.Combine(pathAppData, FILENAME);

            Initialize(load);
        }

        public Settings(string filepath, bool load = false)
        {
            _filePath = filepath;

            Initialize(load);
        }

        //Methods
        public void Initialize(bool load = false)
        {
            if (load)
            {
                Load();
            }
        }

        public void Load()
        {
            if (System.IO.File.Exists(_filePath))
            {
                try
                {
                    using (StreamReader file = File.OpenText(_filePath))
                    {
                        string json = file.ReadToEnd();
                        Settings settings = JsonConvert.DeserializeObject<Settings>(json);

                        //set all properties
                        this.Mode = settings.Mode;
                        this.Token = settings.Token;
                        this.CancellationURI = settings.CancellationURI;
                        this.APIPassword = settings.APIPassword;
                        this.APIUsername = settings.APIUsername;
                    }
                }
                catch (Exception e)
                {
                    // TODO: Impossible to read from the settings
                }
            }
            else
            {
                Save();
            }
        }

        public void Save()
        {
            try
            {
                using (StreamWriter file = File.CreateText(_filePath))
                using (JsonTextWriter writer = new JsonTextWriter(file))
                {
                    string json = JsonConvert.SerializeObject(this);
                    writer.WriteRaw(json);
                    writer.Close();
                    file.Close();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Could not write to settings file. " + ex);
            }
        }

    }
}