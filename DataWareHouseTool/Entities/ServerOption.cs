using Newtonsoft.Json;

namespace DataWareHouseTool.Entities
{
    public class ServerOption
    {
        [JsonProperty("serverName")]
        public string ServerName { get; set; }

        [JsonProperty("userName")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}