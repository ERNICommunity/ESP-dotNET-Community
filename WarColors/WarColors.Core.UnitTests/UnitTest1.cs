using System;
using WarColors.Core.Injection;
using Xunit;

namespace WarColors.Core.UnitTests
{
    interface IFoo
    {
        string Name { get; set; }

        DateTime Time { get; set; }
    }

    class Foo : IFoo
    {
        public Foo(string name)
        {
            this.Name = name;
            this.Time = DateTime.Now;
        }

        public string Name { get; set; }
        public DateTime Time { get; set; }
    }

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            IInjectionContainer container = new SimpleInjectionContainer();

            container.RegisterHandler(typeof(IFoo), c => new Foo("Diego"));

            var testee = container.GetInstance<IFoo>();

            System.Threading.Thread.Sleep(50);

            var testee2 = container.GetInstance<IFoo>();

            Assert.Equal("Diego", testee.Name);
            Assert.True(testee2.Time > testee.Time);
        }
    }
}
