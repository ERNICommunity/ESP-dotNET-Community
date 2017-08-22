using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ernist.Core.Injection
{
    /// <summary>
    /// Interface of the Injection Module
    /// </summary>
    public interface IInjectionModule
    {
        /// <summary>
        /// Registers the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        void Register(IInjectionContainer container);
    }
}
