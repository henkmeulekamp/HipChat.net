using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hipchat.notification
{
    enum ExitCode : int
    {
        Success = 0,
        ApplicationError = 1,
        InvalidArgs = 2
    }

    class Program
    {
        static void Main(string[] args)
        {
            //System.Diagnostics.Debugger.Launch();
            try
            {
                var options = new ArgOptions();
                if (! CommandLine.Parser.Default.ParseArguments(args, options))
                {
                    Console.WriteLine(options.GetUsage());
                    Environment.Exit((int)ExitCode.InvalidArgs);    
                }

                if(options.ShowHelp)
                {
                    Console.WriteLine(options.GetUsage());
                    Environment.Exit((int)ExitCode.Success);
                }
                
                //still here? either l or message
                //todo move to better validation
                if( !options.ListAllRooms 
                   && (string.IsNullOrWhiteSpace(options.Message)) )
                {
                    Console.WriteLine(options.GetUsage());
                    Environment.Exit((int)ExitCode.InvalidArgs);                   
                }

                //setup client
                var client = new HipChat.HipChatClient(options.Token);
         
                if (options.ListAllRooms)
                {
                    var rooms = client.ListAllRooms();
                   
                    Console.WriteLine("Available rooms:");

                    foreach (var room in rooms)
                    {
                        Console.WriteLine("- {0} (id={1} )", room.Name, room.Id);
                    }

                    Environment.Exit((int)ExitCode.Success);                    
                }
    
                //only thing left is sending message
                client.SendMessage(options.Message, options.RoomId, options.From); 


                Console.WriteLine("Sending message '{0}' to room {1} from {2}",options.Message, options.RoomId, options.From);

                Environment.Exit((int)ExitCode.Success);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                Environment.Exit((int)ExitCode.ApplicationError);
            }
        }
    }
}
