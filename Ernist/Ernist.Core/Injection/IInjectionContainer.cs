using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ernist.Core.Injection
{
    /// <summary>
    /// Injection Container Interface
    /// </summary>
    public interface IInjectionContainer
    {
        /// <summary>
        /// Registers the specified scope.
        /// </summary>
        /// <typeparam name="T">Interface to register</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="scope">The scope.</param>
        void Register<T, TImplementation>(Scope scope = Scope.Transient) where TImplementation : T;

        /// <summary>
        /// Registers the specified service name.
        /// </summary>
        /// <typeparam name="T">Interface to register</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="serviceName">Name of the service.</param>
        /// <param name="scope">The scope.</param>
        void Register<T, TImplementation>(string serviceName, Scope scope = Scope.Transient) where TImplementation : T;

        /// <summary>
        /// Registers the specified scope.
        /// </summary>
        /// <typeparam name="T">Interface to register</typeparam>
        /// <param name="scope">The scope.</param>
        void Register<T>(Scope scope = Scope.Transient);

        /// <summary>
        /// Registers the specified service type.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="implementation">The implementation of the service.</param>
        /// <param name="scope">The scope.</param>
        void Register(Type serviceType, Type implementation, Scope scope = Scope.Transient);

        /// <summary>
        /// Registers the specified module.
        /// </summary>
        /// <param name="module">The module.</param>
        void Register(IInjectionModule module);

        /// <summary>
        /// Registers the specified assembly.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        void Register(Assembly assembly);

        /// <summary>
        /// Registers the instance.
        /// </summary>
        /// <typeparam name="T">Type of the instance</typeparam>
        /// <param name="instance">The instance.</param>
        void RegisterInstance<T>(T instance);

        /// <summary>
        /// Registers the instance.
        /// </summary>
        /// <typeparam name="T">Type of the instance</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="serviceName">Name of the service.</param>
        void RegisterInstance<T>(T instance, string serviceName);

        /// <summary>
        /// Registers the instance.
        /// </summary>
        /// <typeparam name="T">Type of the instance</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="serviceName">Name of the service.</param>
        void RegisterInstance<T>(Func<IInjectionContainer, T> instance, string serviceName);

        /// <summary>
        /// Determines whether this instance [can get instance] the specified service name.
        /// </summary>
        /// <typeparam name="T">Type of the instance</typeparam>
        /// <param name="serviceName">Name of the service.</param>
        /// <returns>Returns if the instance can be get or not</returns>
        bool CanGetInstance<T>(string serviceName);

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="T">Type of the service to get</typeparam>
        /// <returns>Instance of the service</returns>
        T GetInstance<T>();

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>Instance of the service</returns>
        object GetInstance(Type serviceType);

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="T">Type of the service to get</typeparam>
        /// <param name="serviceName">Name of the service.</param>
        /// <returns>Instance of the service</returns>
        T GetInstance<T>(string serviceName);

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="serviceName">Name of the service.</param>
        /// <returns>Instance of the service</returns>
        object GetInstance(Type serviceType, string serviceName);

        /// <summary>
        /// Gets all instances.
        /// </summary>
        /// <typeparam name="T">Type of the service to get</typeparam>
        /// <returns>Collection of instance services of the type T</returns>
        IEnumerable<T> GetAllInstances<T>();

        /// <summary>
        /// Gets all instances.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>Collection of instance services</returns>
        IEnumerable<object> GetAllInstances(Type serviceType);

    }
}
