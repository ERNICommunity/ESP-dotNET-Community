using FluentAssertions;
using System;
using System.Linq;
using WarColors.Core.Injection;
using WarColors.Core.UnitTests.Stubs;
using Xunit;

namespace WarColors.Core.UnitTests
{
    /// <summary>
    /// The Injection Container Test.
    /// </summary>
    public class InjectionContainerTest
    {
        [Fact (DisplayName = "Injection container registers a new object and gets the instance")]
        public void InjectionContainerRegisterNewObjectGetInstance()
        {
            // Arrange.
            var container = new SimpleInjectionContainer();

            // Act.
            container.Register(typeof(IFoo), new Foo("Juan"));

            // Assert.
            var testee = container.GetInstance<IFoo>();
            testee.Should().NotBeNull();
            testee.Name.Should().Be("Juan");
        }

        [Fact (DisplayName = "Injection container register a new object and gets the instance using typeof")]
        public void InjectionContainerRegisterNewObjectGetInstanceTypeOf()
        {
            // Arrange.
            var container = new SimpleInjectionContainer();

            // Act.
            container.Register(typeof(IFoo), new Foo("Testee"));

            // Assert.
            var testee = (IFoo)container.GetInstance(typeof(IFoo));
            testee.Should().NotBeNull();
            testee.Name.Should().Be("Testee");
        }

        [Fact (DisplayName = "Injection container register a new class and gets the instance")]
        public void InjectionContainerRegisterClassGetInstance()
        {
            // Arrange.
            var container = new SimpleInjectionContainer();

            // Act.
            container.Register(typeof(IFoo), typeof(Foo));
            var testee = container.GetInstance<IFoo>();

            // Assert
            testee.Should().NotBeNull();
        }

        [Fact (DisplayName = "Injection container register a new classes and gets the instance")]
        public void InjectionContainerRegisterClassGetAllInstances()
        {
            // Arrange.
            var container = new SimpleInjectionContainer();

            // Act.
            container.Register(typeof(IFoo), typeof(Foo));
            container.Register(typeof(IFoo), typeof(Bar));

            // Assert.
            var testee = container.GetAllInstances<IFoo>();
            testee.Any(p => p is Foo).Should().BeTrue();
            testee.Any(p => p is Bar).Should().BeTrue();
            testee.Count().Should().Be(2);
        }

        [Fact (DisplayName = "Injection container register a new classes and gets the instance using typeof")]
        public void InjectionContainerRegisterClassGetAllInstancesTypeOf()
        {
            // Arrange.
            var container = new SimpleInjectionContainer();

            // Act.
            container.Register(typeof(IFoo), typeof(Foo));
            container.Register(typeof(IFoo), typeof(Bar));

            // Assert.
            var testee = container.GetAllInstances(typeof(IFoo));
            testee.Any(p => p is Foo).Should().BeTrue();
            testee.Any(p => p is Bar).Should().BeTrue();
            testee.Count().Should().Be(2);
        }

        [Fact (DisplayName = "Injection container register a new classes and gets the instance using key")]
        public void InjectionContainerRegisterGetInstanceKey()
        {
            // Arrange.
            var container = new SimpleInjectionContainer();

            // Act.
            container.Register(typeof(IFoo), new Foo("Testee 1"), "Testee 1");
            container.Register(typeof(IFoo), new Foo("Testee 2"), "Testee 2");

            // Assert.
            var testee = (IFoo) container.GetInstance(typeof(IFoo), "Testee 1");
            var testee2 = (IFoo) container.GetInstance(typeof(IFoo), "Testee 2");
            testee.Name.Should().Be("Testee 1");
            testee2.Name.Should().Be("Testee 2");
        }

        [Fact (DisplayName = "Injection container register a new class and check that is registered")]
        public void InjectionContainerRegisterIsRegistered()
        {
            // Arrange.
            var container = new SimpleInjectionContainer();

            // Act.
            container.Register(typeof(IFoo), typeof(Foo));

            // Assert.
            container.IsRegistered<IFoo>().Should().BeTrue();
        }

        [Fact (DisplayName = "Injection container register a new classes and check that are registered")]
        public void InjectionContainerRegisterIsRegisteredKey()
        {
            // Arrange.
            var container = new SimpleInjectionContainer();

            // Act.
            container.Register(typeof(IFoo), new Foo("Testee 1"), "Testee 1");
            container.Register(typeof(IFoo), new Foo("Testee 2"), "Testee 2");

            // Assert.
            container.IsRegistered(typeof(IFoo), "Testee 1");
            container.IsRegistered(typeof(IFoo), "Testee 2");
        }

        [Fact (DisplayName = "Injection container register a new class using register handler")]
        public void InjectionContainerRegisterHandlerGetInstance()
        {
            // Arrange.
            var container = new SimpleInjectionContainer();

            // Act.
            container.RegisterHandler(typeof(IFoo), c => new Foo("Testee 1"));

            // Assert.
            var testee = container.GetInstance<IFoo>();

            System.Threading.Thread.Sleep(10);

            var testee2 = container.GetInstance<IFoo>();

            testee.Name.Should().Be("Testee 1", "Testee name should be Testee 1");
            testee2.Time.Should().BeMoreThan(TimeSpan.FromTicks(testee2.Time.Ticks));
        }
    }
}
