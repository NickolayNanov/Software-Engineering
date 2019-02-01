namespace Solid_Logger
{
    using Solid_Logger.Core;
    using Solid_Logger.Core.Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            ICommandInterpreter cm = new CommandInterpreter();
            IEngine engine = new Engine(cm);
            engine.Run();
        }
    }
}
