namespace Travel.Core
{
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IAirportController airportController;
        private readonly IFlightController flightController;

        public Engine(IReader reader, IWriter writer, IAirportController airportController,
            IFlightController flightController)
        {
            this.reader = reader;
            this.writer = writer;
            this.airportController = airportController;
            this.flightController = flightController;
        }

        public void Run()
        {
            while (true)
            {
                var input = this.reader.ReadLine();

                if (input == "END")
                {
                    break;
                }

                if(input == "TakeOff")
                {
                    string result = this.flightController.TakeOff();
                    this.writer.WriteLine(result);
                    continue;
                }

                try
                {
                    var result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.Message);
                }
            }

            
        }

        public string ProcessCommand(string input)
        {
            string[] tokens = input.Split(' ');

            string command = tokens[0];
            string[] args = tokens.Skip(1).ToArray();


            MethodInfo currentMethod = this.airportController.GetType()
                .GetMethods()
                .FirstOrDefault(m => m.Name == command);

            ParameterInfo[] parameters = currentMethod.GetParameters();

            object[] parametersForInput = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {                
                Type convertingType = parameters[i].ParameterType;

                if(command == "RegisterBag" && i == 1)
                {
                    parametersForInput[i] = args.Skip(1).ToList();
                    continue;
                }
                else if(command == "CheckIn" && i == 2)
                {
                    parametersForInput[i] = args.Skip(2).Select(int.Parse).ToList();
                    continue;
                }

                var paramOfMethod = Convert.ChangeType(args[i], convertingType);

                parametersForInput[i] = paramOfMethod;
            }

            string output;

            try
            {
                output = (string)currentMethod.Invoke(this.airportController, parametersForInput);
            }
            catch(InvalidOperationException ex)
            {
                output = "ERROR: " + ex.Message;
            }
            catch (TargetInvocationException ex)
            {
                output = "ERROR: " + ex.InnerException.Message;
            }

            return output;
        }
    }
}