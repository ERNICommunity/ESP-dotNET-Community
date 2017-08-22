using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Ernist.Core.UnitTests
{
    [TestClass]
    public class InjectionTests
    {
        [TestMethod]
        public void RegisterInterfaceShouldBeRegistered()
        {
            LightInject.LightInjectContainer container = new LightInject.LightInjectContainer();

            container.Register<IFoo, Foo>();

            container.CanGetInstance<IFoo>(string.Empty).Should().BeTrue();
        }

        [TestMethod]
        public void RegisterWithModuleInAssemblyShouldRegisterIFoo()
        {
            LightInject.LightInjectContainer container = new LightInject.LightInjectContainer();

            container.Register(this.GetType().Assembly);

            container.CanGetInstance<IFoo>(string.Empty).Should().BeTrue();
        }

        [TestMethod]
        public void RegisterWithModulesInAssemblyShouldRegisterAllInterfaces()
        {
            LightInject.LightInjectContainer container = new LightInject.LightInjectContainer();

            container.Register(this.GetType().Assembly);

            container.CanGetInstance<IFoo>(string.Empty).Should().BeTrue("IFoo was not registered");
            container.CanGetInstance<IBar>(string.Empty).Should().BeTrue("IBar was not registered");
        }
    }
}
