using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Acme.Commands;
using Acme.Events;

namespace Acme.Tests
{
    public class Scenario
    {
        private readonly string _name;
        private readonly List<Step> _steps = new List<Step>();

        public Scenario(string name="temp")
        {
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
            return this;
        }

        public Scenario ThenNothing()
        {
            _steps.Add(
                new Step
                {
                    Title = "Nothing",
                    Type = "HotSpot",
                    Data = new Dictionary<string, string>()

                });
            return this;
        }

        public void Assert()
        {
            GenerateHtml.Generate(_name, _steps);
        }
    }
}
