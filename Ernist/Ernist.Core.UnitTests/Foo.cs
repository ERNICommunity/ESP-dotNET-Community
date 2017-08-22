using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ernist.Core.Injection;

namespace Ernist.Core.UnitTests
{
    public interface IFoo
    {

    }

    public class Foo : IFoo
    {
    }

    public interface IBar
    {
    }

    public class Bar: IBar
    {
    }

    public class FooModule : Injection.IInjectionModule
    {

        public void Register(IInjectionContainer container)
        {
            container.Register<IFoo, Foo>();
        }
    }

    public class BarModule : Injection.IInjectionModule
    {
        public void Register(IInjectionContainer container)
        {
            container.Register<IBar, Bar>();
        }
    }
}
