using System;
using System.Threading;
using System.Threading.Tasks;
using Sample.ExternalSmokeTests.Utilities;

namespace SmokeMe.Tests.SmokeTests
{
    public class FeatureToggledAlwaysPositiveSmokeTest : SmokeTest
    {
        private readonly IToggleFeatures _featureToggles;
        private readonly TimeSpan _delay;

        public FeatureToggledAlwaysPositiveSmokeTest(IToggleFeatures featureToggles, TimeSpan delay)
        {
            _featureToggles = featureToggles;
            _delay = delay;
        }

        public override Task<bool> HasToBeDiscarded()
        {
            return Task.FromResult(!_featureToggles.IsEnabled("featureToggledSmokeTest"));
        }

        public override string SmokeTestName => "Feature toggled test";
        public override string Description { get; }

        public override Task<SmokeTestResult> Scenario()
        {
            Thread.Sleep(Convert.ToInt32(_delay.TotalMilliseconds));
            return Task.FromResult(new SmokeTestResult(true));
        }
    }
}