using Ernist.Core.Injection;

namespace Ernist.Core.UnitTests
{
    /// <summary>
    /// The IFoo interface.
    /// </summary>
    public interface IFoo
    {
    }

    /// <summary>
    /// The Foo class.
    /// </summary>
    /// <seealso cref="Ernist.Core.UnitTests.IFoo" />
    public class Foo : IFoo
    {
    }

    /// <summary>
    /// The IBar interface.
    /// </summary>
    public interface IBar
    {
    }

    /// <summary>
    /// The Bar class.
    /// </summary>
    /// <seealso cref="Ernist.Core.UnitTests.IBar" />
    public class Bar : IBar
    {
    }

    /// <summary>
    /// The FooModule.
    /// </summary>
    /// <seealso cref="Ernist.Core.Injection.IInjectionModule" />
    public class FooModule : IInjectionModule
    {
        /// <summary>
        /// Registers the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        public void Register(IInjectionContainer container)
        {
            container.Register<IFoo, Foo>();
        }
    }

    /// <summary>
    /// The BarModule.
    /// </summary>
    /// <seealso cref="Ernist.Core.Injection.IInjectionModule" />
    public class BarModule : IInjectionModule
    {
        /// <summary>
        /// Registers the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        public void Register(IInjectionContainer container)
        {
            container.Register<IBar, Bar>();
        }
    }
}
