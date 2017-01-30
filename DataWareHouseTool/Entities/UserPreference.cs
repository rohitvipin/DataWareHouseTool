using Newtonsoft.Json;

namespace DataWareHouseTool.Entities
{
    public class UserPreference
    {

        [JsonProperty("inputServer")]
        public ServerOption InputServer { get; set; }

        [JsonProperty("outputServer")]
        public ServerOption OutputServer { get; set; }
    }
}