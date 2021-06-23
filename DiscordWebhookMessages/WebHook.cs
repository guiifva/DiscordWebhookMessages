using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DiscordWebhookMessages.Models;
using Newtonsoft.Json;

namespace DiscordWebhookMessages
{
    public class DiscordWebhookClient
    {        
        /// <summary>
        ///     The http client used for posting the data to the Discord webhook.
        /// </summary>
        private static readonly HttpClient Client = new HttpClient();

        /// <summary>
        ///     The name of the message sender 
        /// </summary>
        public string Username { get; }

        /// <summary>
        ///     The avatar url that included in message
        /// </summary>
        public string AvatarUrl { get; }

        /// <summary>
        ///     The web hook url to send the message to
        /// </summary>
        public Uri DiscordWebhookUri { get; }


        /// <summary>
        ///     Create the Discord Message client and set the webhook url.
        /// </summary>
        /// <param name="url">Discord webhook URL</param>
        public DiscordWebhookClient(string url)
        {
            DiscordWebhookUri = TryGetUri(url);
        }

        /// <summary>
        ///     Create the Discord Message client and set the webhook url and username.
        /// </summary>
        /// <param name="url">Discord webhook URL</param>
        /// <param name="username">The username that will be used in messages</param>
        public DiscordWebhookClient(string url, string username)
        {
            DiscordWebhookUri = TryGetUri(url); Username = username;
        }

        /// <summary>
        ///     Create the Discord Message client and set the webhook url, username and avatar image.
        /// </summary>
        /// <param name="url">Discord webhook URL</param>
        /// <param name="username">The username that will be used in messages</param>
        /// <param name="avatarUrl">The avatar image that will be used in messages</param>
        public DiscordWebhookClient(string url, string username, string avatarUrl)
        {
            DiscordWebhookUri = TryGetUri(url); Username = username; AvatarUrl = avatarUrl;
        }

        #region SendMessageAsync
        /// <summary>
        ///     The method used to send the message to the Discord webhook
        /// </summary>
        /// <param name="content">Text message, can contain up to 2000 characters</param>
        /// <param name="tts">Makes message to be spoken</param>
        /// <returns></returns>
        public async Task<string> SendMessageAsync(string content, bool tts = false)
        {
            var message = new Message(content, Username, AvatarUrl, tts);
            return await SendRequestAsync(message);
        }

        /// <summary>
        ///     The method used to send the message to the Discord webhook
        /// </summary>
        /// <param name="embed">Embed model that goes inside the message</param>
        /// <param name="content">Text message, can contain up to 2000 characters</param>
        /// <param name="tts">Makes message to be spoken</param>
        /// <returns></returns>
        public async Task<string> SendMessageAsync(Embed embed, string content = null, bool tts = false)
        {
            var message = new Message(embed, Username, AvatarUrl, content, tts);
            return await SendRequestAsync(message);
        }

        /// <summary>
        ///     The method used to send the message to the Discord webhook
        /// </summary>
        /// <param name="embeds"> List of Embed model that goes inside the message</param>
        /// <param name="content">Text message, can contain up to 2000 characters</param>
        /// <param name="tts">Makes message to be spoken</param>
        /// <returns></returns>
        public async Task<string> SendMessageAsync(IEnumerable<Embed> embeds, string content = null, bool tts = false)
        {
            var message = new Message(embeds, Username, AvatarUrl, content, tts);
            return await SendRequestAsync(message);
        }
        #endregion

        #region SendMessage
        /// <summary>
        ///     The method used to send the message to the Discord webhook
        /// </summary>
        /// <param name="content">Text message, can contain up to 2000 characters</param>
        /// <param name="tts">Makes message to be spoken</param>
        /// <returns></returns>
        public string SendMessage(string content, bool tts = false)
        {
            var message = new Message(content, Username, AvatarUrl, tts);
            return SendRequest(message).Result;
        }

        /// <summary>
        ///     The method used to send the message to the Discord webhook
        /// </summary>
        /// <param name="embed">Embed model that goes inside the message</param>
        /// <param name="content">Text message, can contain up to 2000 characters</param>
        /// <param name="tts">Makes message to be spoken</param>
        /// <returns></returns>
        public string SendMessage(Embed embed, string content = null, bool tts = false)
        {
            var message = new Message(embed, Username, AvatarUrl, content, tts);
            return SendRequest(message).Result;
        }

        /// <summary>
        ///     The method used to send the message to the Discord webhook
        /// </summary>
        /// <param name="embeds"> List of Embed model that goes inside the message</param>
        /// <param name="content">Text message, can contain up to 2000 characters</param>
        /// <param name="tts">Makes message to be spoken</param>
        /// <returns></returns>
        public string SendMessage(IEnumerable<Embed> embeds, string content = null, bool tts = false)
        {
            var message = new Message(embeds, Username, AvatarUrl, content, tts);
            return SendRequest(message).Result;
        }
        #endregion
        
        private static Uri TryGetUri(string url)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out var uri))
                throw new UriFormatException();

            return uri;
        }
        private async Task<string> SendRequest(Message message)
        {
            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Post, DiscordWebhookUri);
                using var content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
                request.Content = content;
                Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                using var response = await Client.SendAsync(request).ConfigureAwait(false);
                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return "Error when request discord webhook url. Error Message: " + ex.Message;
            }
        }
        private async Task<string> SendRequestAsync(Message message)
        {
            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Post, DiscordWebhookUri);
                using var content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
                Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
                var response = Client.SendAsync(request).Result;
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return "Error when request discord webhook url. Error Message:" + ex.Message;
            }
        }
    }
}
