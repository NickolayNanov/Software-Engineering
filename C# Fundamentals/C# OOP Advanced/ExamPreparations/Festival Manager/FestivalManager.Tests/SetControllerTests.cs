// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class SetControllerTests
    {
        [Test]
        public void ProduceReportShouldMatch()
        {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);

            ISet set = new Short("set1");
            stage.AddSet(set);

            string actual = setController.PerformSets();
            string expected = "1. set1:\r\n-- Did not perform";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void WearShouldBeDifferent()
        {
            IStage stage = new Stage();
            ISetController setController = new SetController(stage);

            IPerformer performer = new Performer("Niki", 18);
            performer.AddInstrument(new Guitar());

            double instrumentWearBefore = performer.Instruments.First().Wear;
            ISet set = new Short("short1");
            set.AddSong(new Song("Pesna", new TimeSpan(0, 1, 10)));
            set.AddPerformer(performer);
            stage.AddSet(set);

            setController.PerformSets();

            FieldInfo listField = typeof(Performer).GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(p => p.Name == "instruments");

            List<IInstrument> insturments = (List<IInstrument>)listField.GetValue(performer);
            double instrumentWearAfter = insturments[0].Wear;

            Assert.That(instrumentWearAfter, Is.Not.EqualTo(instrumentWearBefore));
        }
    }
}