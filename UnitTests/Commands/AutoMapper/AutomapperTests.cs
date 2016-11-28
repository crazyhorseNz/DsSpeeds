using AutoMapper;
using Commands.AutoMapper;
using Domain.AutoMapper;
using NUnit.Framework;

namespace UnitTests.Commands.AutoMapper
{
    [TestFixture]
    public class Automapper
    {
        [OneTimeSetUp]
        public void RunOnceSetup()
        {
            Mapper.Initialize(mapper =>
                mapper.AddProfiles(
                    typeof(CommandsToEvents)));
        }

        [Test]
        public void CommandsToEventsAreValid()
        {
            Mapper.AssertConfigurationIsValid();
        }

    }
}
