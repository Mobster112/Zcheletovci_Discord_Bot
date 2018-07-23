using System;

namespace Zcheletovci_Discord_Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Token - " + Config.bot.token);
            Console.WriteLine("Command Prefix - " + Config.bot.cmdPrefix);
            Console.ReadLine();
        }
    }
}
