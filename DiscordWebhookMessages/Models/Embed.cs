using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DiscordWebhookMessages.Models
{
    public class Embed
    {
        /// <summary>
        /// Create empty Embed     
        /// </summary>
        public Embed()
        {
            Fields = new List<Field>();
        }

        /// <summary>
        /// Title of embed
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// Description text
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// URL of embed. If title was used, it becomes hyperlink
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Color code of the embed. You have to use Decimal numeral system, not Hexadecimal. You can use SpyColor for that. It has decimal number converter.
        /// </summary>
        [JsonProperty("color")]
        public uint Color { get; set; }

        /// <summary>
        /// DateTime shown in message 
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Embed footer object
        /// </summary>
        [JsonProperty("footer")]
        public Footer Footer { get; set; }

        /// <summary>
        /// Embed image object
        /// </summary>
        [JsonProperty("image")]
        public Image Image { get; set; }

        /// <summary>
        /// Embed thumbnail object
        /// </summary>
        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        /// <summary>
        /// Embed author object
        /// </summary>
        [JsonProperty("author")]
        public Author Author { get; set; }

        /// <summary>
        /// List of embed field objects
        /// </summary>
        [JsonProperty("fields")]
        public IList<Field> Fields { get; set; }
    }
}