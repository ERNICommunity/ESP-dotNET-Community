using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarColors.Core.Injection
{
    public static class IInjectionContainerExtensions
    {
        public static IInjectionContainer PerRequest<TService, TImplementation>(this IInjectionContainer container)
        {
            container.Register(typeof(TService), typeof(TImplementation), Scope.PerRequest);
            return container;
        }

        public static IInjectionContainer PerRequest<TService, TImplementation>(this IInjectionContainer container, string key)
        {
            container.Register(typeof(TService), typeof(TImplementation), key, Scope.PerRequest);
            return container;
        }

        public static IInjectionContainer PerRequest(this IInjectionContainer container, Type service, Type implementation)
        {
            container.Register(service, implementation, Scope.PerRequest);
            return container;
        }

        public static IInjectionContainer PerRequest(this IInjectionContainer container, Type service, Type implementation, string key)
        {
            container.Register(service, implementation, key, Scope.PerRequest);
            return container;
        }
        public static IInjectionContainer PerRequest<TService>(this IInjectionContainer container)
        {
            container.Register(typeof(TService), typeof(TService), Scope.PerRequest);
            return container;
        }

        public static IInjectionContainer PerRequest<TService>(this IInjectionContainer container, string key)
        {
            container.Register(typeof(TService), typeof(TService), key, Scope.PerRequest);
            return container;
        }

        public static IInjectionContainer PerRequest(this IInjectionContainer container, Type service)
        {
            container.Register(service, service, Scope.PerRequest);
            return container;
        }

        public static IInjectionContainer PerRequest(this IInjectionContainer container, Type service, string key)
        {
            container.Register(service, service, key, Scope.PerRequest);
            return container;
        }

        public static IInjectionContainer Singleton<TService, TImplementation>(this IInjectionContainer container)
        {
            container.Register(typeof(TService), typeof(TImplementation), Scope.Singleton);
            return container;
        }

        public static IInjectionContainer Singleton<TService, TImplementation>(this IInjectionContainer container, string key)
        {
            container.Register(typeof(TService), typeof(TImplementation), key, Scope.Singleton);
            return container;
        }

        public static IInjectionContainer Singleton(this IInjectionContainer container, Type service, Type implementation)
        {
            container.Register(service, implementation, Scope.Singleton);
            return container;
        }

        public static IInjectionContainer Singleton(this IInjectionContainer container, Type service, Type implementation, string key)
        {
            container.Register(service, implementation, key, Scope.Singleton);
            return container;
        }
        public static IInjectionContainer Singleton<TService>(this IInjectionContainer container)
        {
            container.Register(typeof(TService), typeof(TService), Scope.Singleton);
            return container;
        }

        public static IInjectionContainer Singleton<TService>(this IInjectionContainer container, string key)
        {
            container.Register(typeof(TService), typeof(TService), key, Scope.Singleton);
            return container;
        }

        public static IInjectionContainer Singleton(this IInjectionContainer container, Type service)
        {
            container.Register(service, service, Scope.Singleton);
            return container;
        }

        public static IInjectionContainer Singleton(this IInjectionContainer container, Type service, string key)
        {
            container.Register(service, service, key, Scope.Singleton);
            return container;
        }

        public static IInjectionContainer Instance<TService>(this IInjectionContainer container, TService implementation)
        {
            container.Register(typeof(TService), implementation);
            return container;
        }

        public static IInjectionContainer Instance<TService>(this IInjectionContainer container, TService implementation, string key)
        {
            container.Register(typeof(TService), implementation, key);
            return container;
        }

        public static bool IsRegistered<TService>(this IInjectionContainer container) => container.IsRegistered(typeof(TService));

        public static bool IsRegistered<TService>(this IInjectionContainer container, string key) => container.IsRegistered(typeof(TService), key);
    }
}
