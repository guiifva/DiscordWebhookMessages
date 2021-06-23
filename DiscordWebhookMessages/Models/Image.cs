using Newtonsoft.Json;

namespace DiscordWebhookMessages.Models
{
    public struct Image
    {
        [JsonProperty("url")]
        public string Url;
    }
}