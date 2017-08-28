using System;
using System.Collections.Generic;
using System.Text;

namespace WarColors.Core.UnitTests.Stubs
{
    /// <summary>
    /// The IFoo Stub.
    /// </summary>
    interface IFoo
    {
        string Name { get; set; }

        DateTime Time { get; set; }
    }

    /// <summary>
    /// The Bar Stub.
    /// </summary>
    /// <seealso cref="WarColors.Core.UnitTests.Stubs.IFoo" />
    class Bar : IFoo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Foo"/> class.
        /// </summary>
        public Bar()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bar"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Bar(string name)
        {
            Name = name;
            Time = DateTime.Now;
        }

        public string Name { get; set; }

        public DateTime Time { get; set; }
    }

    /// <summary>
    /// The Foo Stub.
    /// </summary>
    /// <seealso cref="WarColors.Core.UnitTests.Stubs.IFoo" />
    class Foo : IFoo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Foo"/> class.
        /// </summary>
        public Foo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Foo"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public Foo(string name)
        {
            Name = name;
            Time = DateTime.Now;
        }

        public string Name { get; set; }

        public DateTime Time { get; set; }
    }
}
