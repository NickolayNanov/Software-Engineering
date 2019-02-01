namespace _03BarracksFactory
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;

    class AppEntryPoint
    {
        static void Main(string[] args)
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            ICommandInterpreter cmd = new CommandInterpreter(repository, unitFactory);
            IRunnable engine = new Engine(cmd);
            engine.Run();
        }
    }
}
