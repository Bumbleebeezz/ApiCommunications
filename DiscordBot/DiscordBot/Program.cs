/*
    discord developer portal
    applications
    new application
    settings:
        give permissions in server
    OAuth2
        url generator
            bot
            administrator
        copy url
    Paste url in explorer
    Discord bot default: offline


    mongodbdriver
    dsharpplus

    reset token in discord developer portal
 */


using System.Runtime.CompilerServices;
using DSharpPlus;

var discordclient = new DiscordClient(new DiscordConfiguration
{
    Token = "token",  // SECRET DELUX !!! DO NOT SHARE 
    TokenType = TokenType.Bot, 
    Intents = DiscordIntents.All
});

// create events
discordclient.MessageCreated += OnMessageCreated;
// parameters (discordclient, messagecreateeventargs)
// create if statements for keywords bot will listen to

// Make all async

await discordclient.ConnectAsync();
await Task.Delay(-1);

// Computer now busy 

// publish bot, portal.azhure.com


