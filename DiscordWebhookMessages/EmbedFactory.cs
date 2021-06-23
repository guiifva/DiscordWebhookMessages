using System;
using System.Drawing;
using System.Globalization;
using DiscordWebhookMessages.Models;

namespace DiscordWebhookMessages
{
    public class EmbedFactory
    {
        /// <summary>
        /// Embed model that populate in methods
        /// </summary>
        private readonly Embed _embed;

        /// <summary>
        /// Create Factory of Embed
        /// </summary>
        public EmbedFactory()
        {
            _embed = new Embed();
        }

        /// <summary>
        /// Return Embed that is populated at the moment
        /// </summary>
        /// <returns></returns>
        public Embed Build() => _embed;

        /// <summary>
        /// Adds Author block to embed. author is an object which includes three values:
        /// </summary>
        /// <param name="name">sets author name</param>
        /// <param name="url">sets link. Requires name value. If used, transforms name into hyperlink.</param>
        /// <param name="iconUrl">sets avatar. Requires name value</param>
        /// <returns></returns>
        public EmbedFactory SetAuthor(string name, string url = null, string iconUrl = null)
        {
            _embed.Author = new Author
            {
                Name = name,
                Url = url,
                IconUrl = iconUrl
            };
            return this;
        }

        /// <summary>
        /// Sets title for webhook's embed.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public EmbedFactory SetTitle(string title)
        {
            _embed.Title = title;
            return this;
        }

        /// <summary>
        /// Sets link for title in your webhook message. Requires title variable and turns it into hyperlink.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public EmbedFactory SetUrl(string url)
        {
            _embed.Url = url;
            return this;
        }

        /// <summary>
        /// Sets description for webhook's embed.
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public EmbedFactory SetDescription(string description)
        {
            _embed.Description = description;
            return this;
        }

        /// <summary>
        /// Sets color for webhook's embed format RGB
        /// </summary>
        /// <param name="r">Represents RED</param>
        /// <param name="g">Represents GREEN</param>
        /// <param name="b">Represents BLUE</param>
        /// <returns></returns>
        public EmbedFactory SetColor(uint r, uint g, uint b)
        {
            _embed.Color = RgbToColor(r, g, b);
            return this;
        }

        /// <summary>
        /// Sets color for webhook's embed format HEXADECIMAL
        /// </summary>
        /// <param name="hexColor">Hexadecimal string that represent color</param>
        /// <returns></returns>
        public EmbedFactory SetColor(string hexColor)
        {
            _embed.Color = HexToColor(hexColor);
            return this;
        }

        /// <summary>
        /// Sets color for webhook's embed format decimal
        /// </summary>
        /// <param name="colorVal">Decimal int that represent color</param>
        /// <returns></returns>
        public EmbedFactory SetColor(uint colorVal)
        {
            _embed.Color = colorVal;
            return this;
        }

        /// <summary>
        /// Sets color for webhook's embed format System.Drawing.Color
        /// </summary>
        /// <param name="color">System.Drawing.Color that represent color</param>
        /// <returns></returns>
        public EmbedFactory SetColor(Color color)
        {
            var r = uint.Parse(color.R.ToString());
            var g = uint.Parse(color.G.ToString());
            var b = uint.Parse(color.B.ToString());
            _embed.Color = RgbToColor(r, g, b);
            return this;
        }

        /// <summary>
        /// Allows you to use multiple title + description blocks in embed.
        /// </summary>
        /// <param name="name">Sets name for field object. Required</param>
        /// <param name="value">Sets description for field object</param>
        /// <param name="inline">if true then sets field objects in same line. false by default.</param>
        /// <returns></returns>
        public EmbedFactory AddField(string name, string value, bool inline = false)
        {
            _embed.Fields.Add(new Field
            {
                Name = name,
                Value = value,
                Inline = inline
            });
            return this;
        }

        /// <summary>
        /// Allows you to add footer to embed.
        /// </summary>
        /// <param name="text">Sets name for author object. Markdown is disabled here!</param>
        /// <param name="iconUrl">Sets icon for author object. Requires text value</param>
        /// <returns></returns>
        public EmbedFactory SetFooter(string text, string iconUrl = null)
        {
            _embed.Footer = new Footer
            {
                Text = text,
                IconUrl = iconUrl
            };
            return this;
        }

        /// <summary>
        /// Allows you to add timestamp to embed. 
        /// </summary>
        /// <returns></returns>
        public EmbedFactory SetTimestamp()
        {
            _embed.Timestamp = DateTime.Now;
            return this;
        }

        /// <summary>
        /// Allows you to add timestamp to embed. 
        /// </summary>
        /// <param name="dateTime">Sets timestamp to embed</param>
        /// <returns></returns>
        public EmbedFactory SetTimestamp(DateTime dateTime)
        {
            _embed.Timestamp = dateTime;
            return this;
        }

        /// <summary>
        /// Allows you to use image in the embed. You can set only url of the image.
        /// </summary>
        /// <param name="url">Image URL</param>
        /// <returns></returns>
        public EmbedFactory SetImage(string url)
        {
            _embed.Image = new Image { Url = url };
            return this;
        }

        /// <summary>
        /// Allows you to use thumbnail in the embed. You can set only url of the thumbnail.
        /// </summary>
        /// <param name="url">Thumbnail image URL</param>
        /// <returns></returns>
        public EmbedFactory SetThumbnail(string url)
        {
            _embed.Thumbnail = new Thumbnail { Url = url };
            return this;
        }

        /// <summary>
        /// Method that convert RGB to Decimal color
        /// </summary>
        /// <param name="r">Represents RED</param>
        /// <param name="g">Represents GREEN</param>
        /// <param name="b">Represents BLUE</param>
        /// <returns></returns>
        private static uint RgbToColor(uint r, uint g, uint b)
        {
            return (uint)(r * 65536 + g * 256 + b);
        }

        /// <summary>
        /// Method that convert Hexadecimal to Decimal color
        /// </summary>
        /// <param name="hexColor">Hexadecimal string color</param>
        /// <returns></returns>
        private static uint HexToColor(string hexColor)
        {
            //Remove # if present
            if (hexColor.IndexOf('#') != -1)
                hexColor = hexColor.Replace("#", "");

            uint red = 0;
            uint green = 0;
            uint blue = 0;

            if (hexColor.Length == 6)
            {
                //#RRGGBB
                red = uint.Parse(hexColor[..2], NumberStyles.AllowHexSpecifier);
                green = uint.Parse(hexColor.Substring(2, 2), NumberStyles.AllowHexSpecifier);
                blue = uint.Parse(hexColor.Substring(4, 2), NumberStyles.AllowHexSpecifier);
            }
            else if (hexColor.Length == 3)
            {
                //#RGB
                red = uint.Parse(hexColor[0].ToString() + hexColor[0], NumberStyles.AllowHexSpecifier);
                green = uint.Parse(hexColor[1].ToString() + hexColor[1], NumberStyles.AllowHexSpecifier);
                blue = uint.Parse(hexColor[2].ToString() + hexColor[2], NumberStyles.AllowHexSpecifier);
            }

            return RgbToColor(red, green, blue);
        }
    }
}
