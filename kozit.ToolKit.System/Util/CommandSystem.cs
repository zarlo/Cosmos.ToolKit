using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kozit.ToolKit.System.Util
{
    public class CommandSystem
    {
        public List<CommandBase> Commands;
        /// <summary>
        /// 
        /// </summary>
        public CommandSystem()
        {

            RegisterCommand(new CommandBase("print", "Prints text", new CommandBase.command(Print)));
            RegisterCommand(new CommandBase("cls", "clear's screen", new CommandBase.command(cls)));
            RegisterCommand(new CommandBase("help", "Prints out help", new CommandBase.command(help)));
            RegisterCommand(new CommandBase("reboot", "reboots the system", new CommandBase.command(reboot)));
            RegisterCommand(new CommandBase("shell", "runs script", new CommandBase.command(shell)));
            RegisterCommand(new CommandBase("dir", "", new CommandBase.command(dir)));

        }

        public void overrideCommand(string Command, CommandBase comm)
        {
            for (int i = 0; i < Commands.Count; i++)
            {
                if (Command.ToLower() == Commands[i].Name)
                {
                    Commands[i] = comm;
                    break;
                }
            }
        }

        /// <summary>
        /// Parse's Commands
        /// </summary>
        /// <param name="text">The Command you want to Parse</param>
        public void Parse(string text)
        {
            if (text.Trim() != "")
            {
                try
                {
                    List<string> tokens = Tokenizer.getTokens(text);
                    getCommand(tokens[0]).execute(text);
                }
                catch (Exception exception)
                {
                    try
                    {
                        this.Parse($"print { exception.ToString()}");
                    }
                    catch
                    {
                        Console.WriteLine(exception);
                    }
                }
            }
        }
        /// <summary>
        /// Lets you register a command to the system.
        /// </summary>
        /// <param name="Command"></param>
        public void RegisterCommand(CommandBase Command)
        {
            if (!Command.Name.Trim().Contains(" "))
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

        #region "File Commands"

        void dir(List<string> args)
        {
            string[] files = Directory.GetDirectories(Globals.WorkingPath);
            foreach (string Files in files)
            {
                this.Parse($"print {Globals.WorkingPath + Files}");
            }
        }

        #endregion

        void shell(List<string> args)
        {
            if (File.Exists(args[1]))
            {
                string[] Script = File.ReadAllLines(args[1]);
                foreach (string Line in Script)
                {
                    this.Parse(Line);
                }
            }
            else
            {
                this.Parse("print cant find file");
            }
        }

        void reboot(List<string> args)
        {
            ToolKit.HAL.Power.Reboot();
        }

        void gfx(List<string> args)
        {

            if (args[1] == "start")
            {
            }
            else if (args[1] == "end")
            {
            }
            else
            {
            }
        }

        void cls(List<string> args)
        {
            Console.Clear();
        }
        

        void Print(List<string> args)
        {
            List<string> output = new List<string> { "" };
            bool isincon = false;
            int i = 0;
            foreach (string Item in args)
            {
                if (i == 0 && Item == "print")
                { i = 1; }
                else
                {

                    foreach (char C in Item)
                    {

                        if (C == '/') { isincon = !isincon; }
                        else if (isincon)
                        {
                            if (C == 'n')
                            { Console.WriteLine(); isincon = false; }
                            else if (C == 'v')
                            { Console.WriteLine(); Console.WriteLine(); Console.WriteLine(); isincon = false; }
                            else if (C == 't')
                            { Console.Write("   "); isincon = false; }
                        }
                        else { Console.Write(C); }

                    }
                    isincon = false;
                    i = 1;
                }
            }
            Console.WriteLine();
        }

        void help(List<string> args)
        {
            foreach (CommandBase Item in Commands)
            {
                this.Parse($"print $> {Item.Name} : {Item.help} ");
            }
        }
        void nothing(List<string> args)
        {
            try
            {
                this.Parse("print No Command Found:" + args[0]);
            }
            catch
            {
                Console.WriteLine("No Command Found:" + args[0]);
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
