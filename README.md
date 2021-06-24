![DiscordWebhookMessage Logo](https://github.com/guiifva/DiscordWebhookMessages/blob/main/Logo_DiscordWebhookMessage.jpg "DiscordWebhookMessage Logo")

# DiscordWebhookMessage

![Nuget](https://img.shields.io/nuget/v/DiscordWebhookMessages)

A .NET library to enable you to send rich formatted bot messages in discord

## NuGet

Install via NuGet: ``` Install-Package DiscordWebhookMessage ```

[Or click here to go to the NuGet package landing page](https://www.nuget.org/packages/DiscordWebhookMessages)

## Making WebHook Url with discord

[Click here to Discord tutorial](https://support.discord.com/hc/en-us/articles/228383668-Intro-to-Webhooks)

- Sign in to Slack
- Open your Server Settings and head into the Integrations tab
- Click the "Create Webhook" button to create a new webhook
- You will be given a WebHook Url. Keep this private. Use it when you set up the DiscordWebhookMessage. See example below.

## How to Use
#### Create a Webhook
```C#
DiscordWebhookClient discordWebhookClient = new DiscordWebhookClient(WebhookURL);
```
##### Overloads
```C#
DiscordWebhookClient discordWebhookClient = new DiscordWebhookClient(WebhookURL, Username);
```
```C#
DiscordWebhookClient discordWebhookClient = new DiscordWebhookClient(WebhookURL, Username, AvatarURL);
```
#### Send Messages Async
```C#
discordWebhookClient.SendMessageAsync(string content, bool tts = false)
discordWebhookClient.SendMessageAsync(Embed embed, string content = null, bool tts = false)
discordWebhookClient.SendMessageAsync(IEnumerable<Embed> embeds, string content = null, bool tts = false)
```
#### Send Messages
```C#
discordWebhookClient.SendMessage(string content, bool tts = false)
discordWebhookClient.SendMessage(Embed embed, string content = null, bool tts = false)
discordWebhookClient.SendMessage(IEnumerable<Embed> embeds, string content = null, bool tts = false)
```

# Embed Example
#### Embed Factory
```C#
Embed embedFactory = new EmbedFactory()
    .SetColor(3093173)
    .SetTitle($"Title here")
    .SetDescription("Description Here")
    .SetImage("https://raw.githubusercontent.com/guiifva/DiscordWebhookMessages/main/Logo_DiscordWebhookMessage.jpg")
    .AddField("Field 1", "Value 1", true)
    .AddField("Field 2", "Value 2", true)
    .SetTimestamp()
    .SetFooter("Guilherme Alves")
    .SetAuthor("Author")
    .SetUrl("https://github.com/guiifva/DiscordWebhookMessages")
    .SetThumbnail("https://cdn.pixabay.com/photo/2020/06/04/22/05/typewriter-5260673_960_720.jpg")
    .Build();
```

#### Embed Instaciate
```C#
Embed embed = new Embed() 
{
    Title = "Title example",
    Url = "https://cdn.pixabay.com/photo/2020/06/04/22/05/typewriter-5260673_960_720.jpg",
    Color = 3093173,
    Fields = new List < Field > 
    {
      new Field() 
      {
        Name = "Field 1",
        Value = "Field Value"
      }
    }
}
```

# Here is an example
## Code
```C#
string discordWebhookUrl = "https://discord.com/api/webhooks/839875803676540969/rh9OuMlRCR47Xx7-5smmpX4MStD73mXz_3TraI0pKvMIEZ-qRMoVBAXMe3VL6eIReXGG";
string username = "Your Username";
string avatarUrl = "https://img2.gratispng.com/20180920/yko/kisspng-computer-icons-portable-network-graphics-avatar-ic-5ba3c66df14d32.3051789815374598219884.jpg";

DiscordWebhookClient discordWebhookClient = new DiscordWebhookClient(discordWebhookUrl, username, avatarUrl);

Embed embedFactory = new EmbedFactory()
    .SetTitle($"Title with URL")
    .SetUrl("https://github.com/guiifva/DiscordWebhookMessages")
    .SetColor(3093173)
    .SetDescription("Description Here")
    .SetAuthor("Author")
    .SetImage("https://raw.githubusercontent.com/guiifva/DiscordWebhookMessages/main/Logo_DiscordWebhookMessage.jpg")
    .AddField("Field 1", "Value 1", true)
    .AddField("Field 2", "Value 2", true)
    .SetThumbnail("https://cdn.pixabay.com/photo/2020/06/04/22/05/typewriter-5260673_960_720.jpg")
    .SetTimestamp()
    .SetFooter("Guilherme Alves")
    .Build();

await discordWebhookClient.SendMessageAsync(embedFactory);
```
## Result
[![Result of discord message](https://github.com/guiifva/DiscordWebhookMessages/blob/main/Images/discord_message_result.jpg?raw=true "Result of discord message")](http://https://github.com/guiifva/DiscordWebhookMessages/blob/main/Images/discord_message_result.jpg?raw=true "Result of discord message")
