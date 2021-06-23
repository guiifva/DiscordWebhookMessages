using Newtonsoft.Json;

namespace DiscordWebhookMessages.Models
{
    public struct Thumbnail
    {
        [JsonProperty("url")]
        public string Url;
    }
}