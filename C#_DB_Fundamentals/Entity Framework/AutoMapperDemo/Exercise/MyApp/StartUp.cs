namespace MyApp
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using AutoMapper;
    using Core;
    using Core.Contracts;
    using Data;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IServiceProvider provider = ConfigureService();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(provider);

            IEngine engine = new Engine(provider, commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider ConfigureService()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<Context>(db => 
                                                        db.UseSqlServer(Configuration.ConnectionString));

            serviceCollection.AddTransient<ICommandInterpreter, CommandInterpreter>();
            serviceCollection.AddSingleton<Mapper>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
