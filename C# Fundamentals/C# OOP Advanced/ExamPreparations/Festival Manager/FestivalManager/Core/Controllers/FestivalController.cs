namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Contracts;
	using Entities.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
	{
        ISetController setController;

		private const string TimeFormat = "mm\\:ss";
		private const string TimeFormatLong = "{0:2D}:{1:2D}";
		private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

        private IInstrumentFactory instrumentFactory;
        private ISetFactory setFactory;

		private readonly IStage stage;

		public FestivalController(IStage stage)
		{
			this.stage = stage;

            this.instrumentFactory = new InstrumentFactory();
            this.setFactory = new SetFactory();
        }        

        public string RegisterSet(string[] args)
		{
            string setName = args[0];
            string setType = args[1];

            ISet set = this.setFactory.CreateSet(setName, setType);
            this.stage.AddSet(set);
            string result = $"Registered {setType} set";

            return result;
		}//

		public string SignUpPerformer(string[] args)
		{
			string name = args[0];
			int age = int.Parse(args[1]);

			string[] instruments = args.Skip(2).ToArray();

			IInstrument[] instrumentsAsObjects = instruments
                .Select(i => this.instrumentFactory.CreateInstrument(i))
				.ToArray();

			IPerformer performer = new Performer(name, age);

			foreach (var instrument in instrumentsAsObjects)
			{
				performer.AddInstrument(instrument);
			}

			this.stage.AddPerformer(performer);
            string result = $"Registered performer {performer.Name}";

            return result;
		}//

		public string RegisterSong(string[] args)
		{
            string songName = args[0];

            int minutes = int.Parse(args[1].Split(':')[0]);
            int seconds = int.Parse(args[1].Split(':')[1]);

            TimeSpan songLength = new TimeSpan(0, minutes, seconds);

            ISong song = new Song(songName, songLength);
            this.stage.AddSong(song);

            string result = $"Registered song {song}";

            return result;
		}//

        public string AddSongToSet(string[] args)
		{
			var songName = args[0];
			var setName = args[1];

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			if (!this.stage.HasSong(songName))
			{
				throw new InvalidOperationException("Invalid song provided");
			}

			var set = this.stage.GetSet(setName);
			var song = this.stage.GetSong(songName);

			set.AddSong(song);

			return $"Added {song} to {set.Name}";
		}//

		public string AddPerformerToSet(string[] args)
		{
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            IPerformer performer = this.stage.GetPerformer(performerName);
            ISet set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }//

		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}//
        
        public string ProduceReport()
        {
            var result = string.Empty;

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            result += ($"Festival length: {FormatTime(totalFestivalLength)}") + "\n";

            foreach (var set in this.stage.Sets)
            {
                result += ($"--{set.Name} ({FormatTime(set.ActualDuration)}):") + "\n";

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result += ($"---{performer.Name} ({instruments})") + "\n";
                }

                if (!set.Songs.Any())
                    result += ("--No songs played") + "\n";
                else
                {
                    result += ("--Songs played:") + "\n";
                    foreach (var song in set.Songs)
                    {
                        result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
                    }
                }
            }

            return result.ToString();
        }//

        private string FormatTime(TimeSpan totalFestivalLength)
        {
            return $"{(int)totalFestivalLength.TotalMinutes:d2}:{(int)totalFestivalLength.Seconds:d2}";
        }               
    }
}