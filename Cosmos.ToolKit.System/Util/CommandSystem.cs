using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos.ToolKit.System.Util
{
    public class CommandSystem
    {

        public List<CommandBase> Commands;

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="LoadCommon">If True will add common command's</param>
        public CommandSystem(bool LoadCommon = false)
        {
            if (LoadCommon)
                loadCommon(); 
        }

        private void loadCommon()
        {

        }

        /// <summary>
        /// Parse's Commands
        /// </summary>
        /// <param name="text">The Command you want to Parse</param>
        public void Parse(string text)
        {
            try
            {
                List<string> tokens = Tokenizer.getTokens(text);

                getCommand(tokens[0].ToLower()).execute(text.Replace(tokens[0], ""));

            }
            catch (Exception exception)
            {
                try
                {
                    getCommand("print").execute(exception.ToString());
                }
                catch
                {
                    Console.WriteLine(exception);
                }
            }
        }

        /// <summary>
        /// Lets you register a command to the system.
        /// </summary>
        /// <param name="Command"></param>
        public void RegisterCommand(CommandBase Command)
        {
            Commands.Add(Command);
        }

        public CommandBase getCommand(string text)
        {
            for (int i = 0; i < Commands.Count; i++)
            {
                if (text.ToLower() == Commands[i].Name)
                {
                    return Commands[i];
                }
            }
            return new CommandBase("null", new CommandBase.command(nothing));//null command
        }

        #region "Commands"

        void Print(List<string> args)
        {
            
            foreach (string Item in args)
            {

                Item.Replace("\n", Environment.NewLine);
                Item.Replace("\t", "    ");
                Item.Replace("\v", Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine);

                //Item.Replace("/n", Environment.NewLine);
                //Item.Replace("/t", "    ");
                //Item.Replace("/v", Environment.NewLine + Environment.NewLine + Environment.NewLine + Environment.NewLine);

                Console.Write(Item + " ");

            }

        }

        void nothing(List<string> args)
        {
            try
            {
                getCommand("print").execute("No Command Found:" + args.ToString());
            }
            catch
            {
                Console.WriteLine("No Command Found:" + args.ToString());
            }
        }

        #endregion

    }

    public class CommandBase
    {

        public CommandBase(string Command, command _command)
        {
            executec = _command;
            Name = Command;
        }

        public CommandBase(string Command, string Help, command _command)
        {
            help = Help;
            executec = _command;
            Name = Command;
        }

        public void execute(string s)
        {
            executec(Tokenizer.getTokens(s));
        }

        public string help { get; set; }
        public string Name { get; set; }

        public command executec;
        public delegate void command(List<string> args);

    }

    public class Tokenizer
    {
        public const char split = ' ';
        public const char quote = '"';

        public static List<string> getTokens(string s)
        {
            bool isinquotes = false;

            List<string> tokens = new List<string> { "" };
            foreach (char c in s)
            {

                if (c == quote) { isinquotes = !isinquotes; }
                else if (c == split && isinquotes == false) { tokens.Add(""); }
                else { tokens[tokens.Count - 1] += c; }
            }

            return tokens;
        }
    }

}
