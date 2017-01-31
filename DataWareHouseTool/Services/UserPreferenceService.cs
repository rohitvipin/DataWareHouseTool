using System;
using System.IO;
using System.Threading.Tasks;
using DataWareHouseTool.Entities;
using DataWareHouseTool.Services.Interfaces;
using Newtonsoft.Json;

namespace DataWareHouseTool.Services
{
    public class UserPreferenceService : IUserPreferenceService
    {
        private const string FilePath = "UserFiles\\Preference.json";
        private UserPreference _userPreference = new UserPreference();

        private async Task LoadPreferenceFromFileAsync()
        {
            using (var streamReader = new StreamReader(Path.Combine(Environment.CurrentDirectory, FilePath)))
            {
                var readToEndAsync = streamReader.ReadToEndAsync();
                if (readToEndAsync != null)
                {
                    _userPreference = JsonConvert.DeserializeObject<UserPreference>(await readToEndAsync);
                }
            }
        }

        private async Task WritereferenceToFileAsync()
        {
            using (var streamWriter = new StreamWriter(Path.Combine(Environment.CurrentDirectory, FilePath), false))
            {
                var str = JsonConvert.SerializeObject(_userPreference);
                var writeAsync = streamWriter.WriteAsync(str);
                if (writeAsync != null)
                {
                    await writeAsync;
                }
            }
        }

        public async Task<ServerOption> GetInputServerDetailsAsync()
        {
            if (_userPreference?.InputServer == null)
            {
                await LoadPreferenceFromFileAsync();
            }
            return _userPreference?.InputServer;
        }

        public async Task SaveInputServerDetailsAsync(ServerOption serverOption)
        {
            if (_userPreference == null)
            {
                return;
            }
            _userPreference.InputServer = serverOption;
            await WritereferenceToFileAsync();
        }

        public async Task<ServerOption> GetOutputServerDetailsAsync()
        {
            if (_userPreference?.OutputServer == null)
            {
                await LoadPreferenceFromFileAsync();
            }
            return _userPreference?.OutputServer;
        }

        public async Task SaveOutputServerDetailsAsync(ServerOption serverOption)
        {
            if (_userPreference == null)
            {
                return;
            }
            _userPreference.OutputServer = serverOption;
            await WritereferenceToFileAsync();
        }
    }
}