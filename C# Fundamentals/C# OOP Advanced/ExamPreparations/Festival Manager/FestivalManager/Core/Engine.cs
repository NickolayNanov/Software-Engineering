
using System;
using System.Linq;
namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
    using FestivalManager.Core.IO;
    using FestivalManager.Entities.Contracts;
    using IO.Contracts;

	class Engine : IEngine
	{
        private IReader reader;
	    private IWriter writer;

        private IFestivalController festivalCоntroller;
        private ISetController setController;

        public Engine(IFestivalController festivalCоntroller, ISetController setController)
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();

            this.festivalCоntroller = festivalCоntroller;
            this.setController = setController;
        }

		public void Run()
		{
			while (true)
			{
				string input = reader.ReadLine();

                if (input == "END")
                {
                    break;
                }

				try
				{
					string result = this.ProcessCommand(input);
					this.writer.WriteLine(result);
				}
				catch (InvalidOperationException ex) //Check if this is the correctException
				{
					this.writer.WriteLine("ERROR: " + ex.Message);
				}
                catch(TargetInvocationException ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.InnerException.Message);
                }
			}

			var end = this.festivalCоntroller.ProduceReport();

			this.writer.WriteLine("Results:");
			this.writer.WriteLine(end);
		}

		public string ProcessCommand(string input)
		{
            string[] tokens = input.Split();

            string command = tokens[0];
			string[] args = tokens.Skip(1).ToArray();

			if (command == "LetsRock")
			{
				string setsResult = this.setController.PerformSets();
				return setsResult;
			}

			MethodInfo currentMethod = this.festivalCоntroller.GetType()
				.GetMethods()
				.FirstOrDefault(m => m.Name == command);

			string output;

			try
			{
                output = (string)currentMethod.Invoke(this.festivalCоntroller, new object[] { args });
			}
			catch (InvalidOperationException ex)
			{
				output = "ERROR: " + ex.Message; 
			}
            catch(TargetInvocationException ex)
            {
                output = "ERROR: " + ex.InnerException.Message;
            }

			return output;
		}
	}
}