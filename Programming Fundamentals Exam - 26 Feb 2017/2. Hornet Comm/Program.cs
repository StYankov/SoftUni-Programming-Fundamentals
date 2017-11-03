using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace _2.Hornet_Comm
{
    class Program
    {
        class Message
        {
            public string Numbers { get; set; }
            public string Msg { get; set; }

            public Message(string numbers, string message)
            {
                this.Numbers = numbers;
                this.Msg = message;
            }
        }

        static void Main(string[] args)
        {
            List<Message> Broadcasts = new List<Message>();
            List<Message> Messages = new List<Message>();
            Regex r = new Regex(@"^(.*?) <-> ([a-zA-Z\d]+)$");

            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "Hornet is Green") break;

                Match valid = r.Match(inputLine);
                if (!valid.Success) continue;

                    ProcessInput(valid.Groups[1].Value, valid.Groups[2].Value, Broadcasts, Messages);

            }

            Console.WriteLine("Broadcasts:");
            if (Broadcasts.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
                foreach (var broadcast in Broadcasts)
                {
                    Console.WriteLine($"{broadcast.Numbers} -> {broadcast.Msg}");
                }
            Console.WriteLine("Messages:");
            if (Messages.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (var message in Messages)
                {
                    Console.WriteLine($"{message.Numbers} -> {message.Msg.Trim()}");
                }
            }

        }

        private static void ProcessInput(string left, string right, List<Message> broadcasts, List<Message> messages)
        {

            if (IsDigitsOnly(left)) // it's a private message
            {
                string recipient = new string(left.Reverse().ToArray());
                messages.Add(new Message(recipient, right));
            }
            else // it's a broadcast
            {
                string broadCastmsg = FlipOver(right);
                broadcasts.Add(new Message(broadCastmsg, left));
            }
        }

        private static string FlipOver(string str)
        {
            StringBuilder s = new StringBuilder();
            foreach (char ch in str)
            {
                if (char.IsUpper(ch))
                {
                    s.Append(char.ToLower(ch));
                }
                else
                {
                    s.Append(char.ToUpper(ch));
                }
            }

            return s.ToString();
        }

        private static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}
