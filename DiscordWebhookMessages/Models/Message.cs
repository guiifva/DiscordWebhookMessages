using System.Collections.Generic;
using Newtonsoft.Json;

namespace DiscordWebhookMessages.Models
{
    internal class Message
    {
        [JsonProperty("username")]
        public string Username;

        [JsonProperty("avatar_url")]
        public string AvatarUrl;

        [JsonProperty("content")]
        public string Content;
        
        [JsonProperty("tts")]
        public bool Tts;
        
        [JsonProperty("embeds")]
        public IEnumerable<Embed> Embeds;

        public Message(IEnumerable<Embed> embeds, string username = null, string avatarUrl = null, string content = null, bool tts = false)
        {
            Username = username;
            AvatarUrl = avatarUrl;
            Content = content;
            Tts = tts;
            Embeds = new List<Embed>(embeds);
        }

        public Message(Embed embed, string username = null, string avatarUrl = null, string content = null, bool tts = false)
        {
            Username = username;
            AvatarUrl = avatarUrl;
            Content = content;
            Tts = tts;
            Embeds = new List<Embed> {embed};
        }

        public Message(string content, string username = null, string avatarUrl = null, bool tts = false)
        {
            Username = username;
            AvatarUrl = avatarUrl;
            Content = content;
            Tts = tts;
        }
    }
}