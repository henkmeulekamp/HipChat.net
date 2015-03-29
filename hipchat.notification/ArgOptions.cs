using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;

namespace hipchat.notification
{
    internal class ArgOptions
    {
        //cli options copied from
        //https://github.com/hipchat/hipchat-cli
        /*
        OPTIONS:
               -h             Show this message
               -t <token>     API token
               -r <room id>   Room ID
               -f <from name> From name
               -i <input>     Message to send to room
               -l               List Rooms
               
   //todo
              -c <color>     Message color (yellow, red, green, purple or random - default: yellow)
               -m <format>    Message format (html or text - default: html)
               -i <input>     Message to send to room, allows you to specify input via command line instead of stdin
               -l <level>     Nagios message level (critical, warning, unknown, ok, down, up). Will override color.
               -n             Trigger notification for people in the room (default: 0)
               -o             API host (api.hipchat.com)
               -v <version>   API version (default: v1)
        */
        [Option('h', "help", DefaultValue = false, Required = false, HelpText = "Show help message")]
        public bool ShowHelp { get; set; }

        [Option('t', "token", Required = true, HelpText = "API Token")]
        public string Token { get; set; }

        [Option('l', "list", Required = false, HelpText = "List all available rooms")]
        public bool ListAllRooms { get; set; }

        [Option('r', "roomid", Required = false, HelpText = "Room ID")]
        public int RoomId { get; set; }

        [Option('f', "from", Required = false, HelpText = "From Name")]
        public string  From { get; set; }

        [Option('i', "input", Required = false, HelpText = "Message to be posted to room")]
        public string Message { get; set; }

        // omitting long name, default --verbose
        [Option(DefaultValue = true, HelpText = "Prints all messages to standard output.")]
        public bool Verbose { get; set; }


        [HelpOption]
        public string GetUsage()
        {
            var help = new HelpText
            {
                Heading = new HeadingInfo("Hipchat CLI"),
                //AdditionalNewLineAfterOption = true,
                AddDashesToOption = true
            };
            help.AddPreOptionsLine("Usage: app -t [token] -f [from] -r [roomId] -i \"message to send\"");
            help.AddOptions(this);
            return help;
        }
    }
}