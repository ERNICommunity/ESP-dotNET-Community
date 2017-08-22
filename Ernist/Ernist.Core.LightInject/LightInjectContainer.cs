using Ernist.Core.Injection;
using LightInject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ernist.Core.LightInject
{
    /// <summary>
    /// This class encapsulates LightInject
    /// </summary>
    public class LightInjectContainer : IInjectionContainer
    {
        private IServiceContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="LightInjectContainer"/> class.
        /// </summary>
        public LightInjectContainer()
        {
            this.container = new ServiceContainer();

            this.RegisterInstance<IServiceContainer>(this.container);
            this.RegisterInstance<IInjectionContainer>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LightInjectContainer"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public LightInjectContainer(IServiceContainer container)
        {
            this.container = container;

            this.RegisterInstance<IServiceContainer>((IServiceContainer)container);
            this.RegisterInstance<IInjectionContainer>(this);
        }

        /// <summary>
        /// Determines whether this instance [can get instance] the specified service name.
        /// </summary>
        /// <typeparam name="T">Type of the instance</typeparam>
        /// <param name="serviceName">Name of the service.</param>
        /// <returns>
        /// Returns if the instance can be get or not
        /// </returns>
        public bool CanGetInstance<T>(string serviceName)
        {
            return ((IServiceContainer)this.container).CanGetInstance(typeof(T), serviceName);
        }

        /// <summary>
        /// Gets all instances.
        /// </summary>
        /// <typeparam name="T">Type of the service to get</typeparam>
        /// <returns>
        /// Collection of instance services of the type T
        /// </returns>
        public IEnumerable<T> GetAllInstances<T>()
        {
            return ((IServiceContainer)this.container).GetAllInstances<T>();
        }

        /// <summary>
        /// Gets all instances.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>
        /// Collection of instance services
        /// </returns>
        public IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return ((IServiceContainer)this.container).GetAllInstances(serviceType);
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="T">Type of the service to get</typeparam>
        /// <returns>
        /// Instance of the service
        /// </returns>
        public T GetInstance<T>()
        {
            return ((IServiceContainer)this.container).GetInstance<T>();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <typeparam name="T">Type of the service to get</typeparam>
        /// <param name="serviceName">Name of the service.</param>
        /// <returns>
        /// Instance of the service
        /// </returns>
        public T GetInstance<T>(string serviceName)
        {
            return ((IServiceContainer)this.container).GetInstance<T>(serviceName);
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns>
        /// Instance of the service
        /// </returns>
        public object GetInstance(Type serviceType)
        {
            return ((IServiceContainer)this.container).GetInstance(serviceType);
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="serviceName">Name of the service.</param>
        /// <returns>
        /// Instance of the service
        /// </returns>
        public object GetInstance(Type serviceType, string serviceName)
        {
            return ((IServiceContainer)this.container).GetInstance(serviceType, serviceName);
        }

        /// <summary>
        /// Registers the specified scope.
        /// </summary>
        /// <typeparam name="T">Type of the service to register</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="scope">The scope.</param>
        public void Register<T, TImplementation>(Injection.Scope scope = Injection.Scope.Transient) where TImplementation : T
        {
            if (scope == Injection.Scope.Singleton)
            {
                this.container.Register<T, TImplementation>(new PerContainerLifetime());
            }
            else
            {
                this.container.Register<T, TImplementation>();
            }
        }

        /// <summary>
        /// Registers the specified service name.
        /// </summary>
        /// <typeparam name="T">Type of the service to register</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="serviceName">Name of the service.</param>
        /// <param name="scope">The scope.</param>
        public void Register<T, TImplementation>(string serviceName, Injection.Scope scope = Injection.Scope.Transient) where TImplementation : T
        {
            if (scope == Injection.Scope.Singleton)
            {
                this.container.Register<T, TImplementation>(serviceName, new PerContainerLifetime());
            }
            else
            {
                this.container.Register<T, TImplementation>(serviceName);
            }
        }

        /// <summary>
        /// Registers the specified scope.
        /// </summary>
        /// <typeparam name="T">Interface to register</typeparam>
        /// <param name="scope">The scope.</param>
        public void Register<T>(Injection.Scope scope = Injection.Scope.Transient)
        {
            if (scope == Injection.Scope.Singleton)
            {
                this.container.Register<T>(new PerContainerLifetime());
            }
            else
            {
                this.container.Register<T>();
            }
        }

        /// <summary>
        /// Registers the specified module.
        /// </summary>
        /// <param name="module">The module.</param>
        public void Register(IInjectionModule module)
        {
            module.Register(this);
        }

        /// <summary>
        /// Registers the specified assembly.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public void Register(Assembly assembly)
        {
            foreach (var t in assembly.DefinedTypes.Where(t => t.IsClass && t.ImplementedInterfaces.Any(i => i.Equals(typeof(IInjectionModule)))))
            {
                if (Activator.CreateInstance(t.AsType()) is IInjectionModule module)
                {
                    module.Register(this);
                }
            }
        }

        /// <summary>
        /// Registers the specified service type.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <param name="implementation">The implementation of the service.</param>
        /// <param name="scope">The scope.</param>
        public void Register(Type serviceType, Type implementation, Injection.Scope scope = Injection.Scope.Transient)
        {
            if (scope == Injection.Scope.Singleton)
            {
                this.container.Register(serviceType, implementation, new PerContainerLifetime());
            }
            else
            {
                this.container.Register(serviceType, implementation);
            }
        }

        /// <summary>
        /// Registers the instance.
        /// </summary>
        /// <typeparam name="T">Type of the instance</typeparam>
        /// <param name="instance">The instance.</param>
        public void RegisterInstance<T>(T instance)
        {
            this.container.RegisterInstance<T>(instance);
        }

        /// <summary>
        /// Registers the instance.
        /// </summary>
        /// <typeparam name="T">Type of the instance</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="serviceName">Name of the service.</param>
        public void RegisterInstance<T>(T instance, string serviceName)
        {
            this.container.RegisterInstance<T>(instance, serviceName);
        }

        /// <summary>
        /// Registers the instance.
        /// </summary>
        /// <typeparam name="T">Type of the instance</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="serviceName">Name of the service.</param>
        public void RegisterInstance<T>(Func<IInjectionContainer, T> instance, string serviceName)
        {
            this.container.Register<T>(factory => instance(this), serviceName);
        }
    }
}
