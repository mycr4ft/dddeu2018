using System.Collections.Generic;
using System.Linq;
using Acme.Commands;
using Acme.Events;

namespace Acme.Tests
{
    public class Scenario
    {
        private readonly string _name;
        private readonly List<Step> _steps = new List<Step>();
        private readonly EventStore _eventStore;

        public Scenario(EventStore eventStore, string name)
        {
            _eventStore = eventStore;
            _name = name;
        }

        public Scenario Given(Event anEvent)
        {
            _steps.Add(
                new Step
            {
                Title = anEvent.GetType().FullName,
                Type = "Event",
                Data = anEvent
                            .GetType()
                            .GetProperties()
                            .ToDictionary(x=>x.Name, x =>x.GetValue(anEvent).ToString())

            });
            _eventStore.Add(anEvent.AggregateId(), new List<Event> {anEvent});
            return this;
        }

        public Scenario When(Command aCommand)
        {
            _steps.Add(
                new Step
                {
                    Title = aCommand.GetType().FullName,
                    Type = "Command",
                    Data = aCommand
                        .GetType()
                        .GetProperties()
                        .ToDictionary(x => x.Name, x => x.GetValue(aCommand).ToString())

                });
            return this;
        }

        public Scenario Then(Event anEvent)
        {
            _steps.Add(
                new Step
                {
                    Title = anEvent.GetType().FullName,
                    Type = "Event",
                    Data = anEvent
                        .GetType()
                        .GetProperties()
                        .ToDictionary(x => x.Name, x => x.GetValue(anEvent).ToString())

                });
            _eventStore.Add(anEvent.AggregateId(), new List<Event> {anEvent});
            return this;
        }

        public Scenario ThenNothing()
        {
            _steps.Add(
                new Step
                {
                    Title = "Nothing",
                    Type = "Hotspot",
                    Data = new Dictionary<string, string>()

                });
            return this;
        }

        public void Assert()
        {
            var scenarioSteps = new ScenarioSteps(_steps, _name);
            StepsReporter.Instance().Add(scenarioSteps);
            Xunit.Assert.True(false);
        }
    }
}
