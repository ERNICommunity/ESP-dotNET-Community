using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ernist.Core.Injection
{
    /// <summary>
    /// Type of scope of the services.
    /// </summary>
    public enum Scope
    {
        /// <summary>
        /// Set a service as a singleton, returns always the same instance.
        /// </summary>
        Singleton,

        /// <summary>
        /// Set a service as transient, return a new instance in every call.
        /// </summary>
        Transient
    }
}
