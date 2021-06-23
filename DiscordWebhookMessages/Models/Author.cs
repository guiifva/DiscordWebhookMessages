using Newtonsoft.Json;

namespace DiscordWebhookMessages.Models
{
    public struct Author
    {
        public string Name;

        public string Url;

        [JsonProperty("icon_url")]
        public string IconUrl;
    }
}