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
        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
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

        [Fact]
        public void InjectionContainerRegisterIsRegistered()
        {
            // Arrange.
            var container = new SimpleInjectionContainer();

            // Act.
            container.Register(typeof(IFoo), typeof(Foo));

            // Assert.
            container.IsRegistered<IFoo>().Should().BeTrue();
        }

        [Fact]
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

        [Fact]
        public void InjectionContainerRegisterHandlerGetInstance()
        {
            // Arrange.
            var container = new SimpleInjectionContainer();

            // Act.
            container.RegisterHandler(typeof(IFoo), c => new Foo("Diego"));

            // Assert.
            var testee = container.GetInstance<IFoo>();

            System.Threading.Thread.Sleep(50);

            var testee2 = container.GetInstance<IFoo>();

            testee.Name.Should().Be("Diego", "Testee name should be Diego");
            testee2.Time.Should().BeMoreThan(TimeSpan.FromTicks(testee2.Time.Ticks));
        }
    }
}
