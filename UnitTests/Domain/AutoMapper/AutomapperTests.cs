using AutoMapper;
using Domain.AutoMapper;
using NUnit.Framework;

namespace UnitTests.Domain.AutoMapper
{
    [TestFixture]
    public class Automapper
    {
        [OneTimeSetUp]
        public void RunOnceSetup()
        {
            Mapper.Initialize(mapper =>
                mapper.AddProfiles(
                    typeof(EventsToDomain)));
        }

        [Test]
        public void CommandsToEventsAreValid()
        {
            Mapper.AssertConfigurationIsValid();
        }

    }
}
