using FluentAssertions;
using System.Reflection;
using Xunit;

namespace Ernist.Core.UnitTests
{
    public class InjectionTests
    {
        // Testee.
        private LightInject.LightInjectContainer _container;

        public InjectionTests()
        {
            _container = new LightInject.LightInjectContainer();
        }

        [Fact]
        public void RegisterInterfaceShouldBeRegistered()
        {
            // Arrange.
            // Act.
            _container.Register<IFoo, Foo>();

            // Assert.
            _container.CanGetInstance<IFoo>(string.Empty).Should().BeTrue();
        }

        [Fact]
        public void RegisterWithModuleInAssemblyShouldRegisterIFoo()
        {
            // Arrange.
            // Act.
            _container.Register(this.GetType().GetTypeInfo().Assembly);

            // Assert.
            _container.CanGetInstance<IFoo>(string.Empty).Should().BeTrue();
            _container.CanGetInstance<IBar>(string.Empty).Should().BeFalse();
        }

        [Fact]
        public void RegisterWithModulesInAssemblyShouldRegisterAllInterfaces()
        {
            // Arrange.
            // Act.
            _container.Register(this.GetType().GetTypeInfo().Assembly);

            // Assert.
            _container.CanGetInstance<IFoo>(string.Empty).Should().BeTrue("IFoo was not registered");
            _container.CanGetInstance<IBar>(string.Empty).Should().BeTrue("IBar was not registered");
        }
    }
}
