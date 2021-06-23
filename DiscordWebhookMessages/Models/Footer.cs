using Newtonsoft.Json;

namespace DiscordWebhookMessages.Models
{
    public struct Footer
    {
        [JsonProperty("text")]
        public string Text;

        [JsonProperty("icon_url")]
        public string IconUrl;
    }
}