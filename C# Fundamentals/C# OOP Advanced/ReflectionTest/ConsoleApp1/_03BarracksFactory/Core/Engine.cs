namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;

    class Engine : IRunnable
    {
        private ICommandInterpreter cmd;

        public Engine(ICommandInterpreter cmd)
        {
            this.cmd = cmd;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];                    
                    IExecutable executable = this.cmd.InterpretCommand(data, commandName);

                    Console.WriteLine(executable.Execute());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }       
    }
}
