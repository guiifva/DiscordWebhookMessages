using Newtonsoft.Json;

namespace DiscordWebhookMessages.Models
{
    public struct Field
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("value")]
        public string Value;

        [JsonProperty("inline")]
        public bool Inline;
    }
}