using System;
using System.IO;
using DataWareHouseTool.Entities;
using DataWareHouseTool.Services.Interfaces;
using Newtonsoft.Json;

namespace DataWareHouseTool.Services
{
    public class UserPreferenceService : IUserPreferenceService
    {
        private UserPreference _userPreference = new UserPreference();

        public ServerOption InputServerDetails
        {
            get
            {
                if (_userPreference?.InputServer == null)
                {
                    LoadPreferenceFromFile();
                }
                return _userPreference?.InputServer;
            }
            set
            {
                if (_userPreference == null)
                {
                    return;
                }
                _userPreference.InputServer = value;
            }
        }

        public ServerOption OutputServerDetails
        {
            get
            {
                if (_userPreference?.OutputServer == null)
                {
                    LoadPreferenceFromFile();
                }
                return _userPreference?.OutputServer;
            }
            set
            {
                if (_userPreference == null)
                {
                    return;
                }
                _userPreference.OutputServer = value;
            }
        }

        private void LoadPreferenceFromFile()
        {
            using (var r = new StreamReader(Path.Combine(Environment.CurrentDirectory, "UserFiles\\Preference.json")))
            {
                _userPreference = JsonConvert.DeserializeObject<UserPreference>(r.ReadToEnd());
            }
        }
    }
}