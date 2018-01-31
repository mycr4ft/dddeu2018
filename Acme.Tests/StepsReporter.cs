using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Acme.Tests
{
    public class ScenarioSteps
    {
        public readonly IEnumerable<Step> Steps;
        public readonly string Name;

        public ScenarioSteps(IEnumerable<Step> steps, string name)
        {
            Steps = steps;
            Name = name;
        }
    }
    
    public class StepsReporter
    {
        private readonly IList<ScenarioSteps> _scenarioStepses = new List<ScenarioSteps>();

        private static StepsReporter _singleton;
        
        private StepsReporter() {}

        public static StepsReporter Instance()
        {
            if (_singleton == null)
            {
                _singleton = new StepsReporter();
            }

            return _singleton;
        }

        public void Add(ScenarioSteps ss)
        {
            _scenarioStepses.Add(ss);
        }

        public void Build()
        {
            foreach (var scenarioStepse in _scenarioStepses)
            {
                GenerateHtml.Generate(scenarioStepse.Name, scenarioStepse.Steps);
            }
        }
    }
}