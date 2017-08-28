using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarColors.Core.Injection
{
    public class SimpleInjectionContainer : IInjectionContainer
    {
        private SimpleContainer container;

        public SimpleInjectionContainer()
            : this(new SimpleContainer())
        {
        }

        public SimpleInjectionContainer(SimpleContainer container)
        {
            this.container = container;
            this.container
                .Instance<IInjectionContainer>(this);
        }

        public void BuildUp(object instance) => container.BuildUp(instance);

        public IEnumerable<T> GetAllInstances<T>() => container.GetAllInstances<T>();

        public IEnumerable<object> GetAllInstances(Type service) => container.GetAllInstances(service);

        public T GetInstance<T>() => container.GetInstance<T>(null);

        public T GetInstance<T>(string key) => container.GetInstance<T>(key);

        public object GetInstance(Type service) => container.GetInstance(service, null);

        public object GetInstance(Type service, string key) => container.GetInstance(service, key);

        public bool IsRegistered(Type service)
        {
            return IsRegistered(service, null);
        }

        public bool IsRegistered(Type service, string key)
        {            
            return container.HasHandler(service, key);
        }

        public void Register(Type service, Type implementation) => Register(service, implementation, null, Scope.PerRequest);

        public void Register(Type service, Type implementation, string key) => Register(service, implementation, key, Scope.PerRequest);

        public void Register(Type service, Type implementation, Scope scope) => Register(service, implementation, null, scope);

        public void Register(Type service, Type implementation, string key, Scope scope)
        {
            switch (scope)
            {
                case Scope.Singleton:
                    container.RegisterSingleton(service, key, implementation);
                    break;
                case Scope.PerRequest:
                default:
                    container.RegisterPerRequest(service, key, implementation);
                    break;
            }            
        }

        public void Register(Type service, object implementation) => Register(service, implementation, null);

        public void Register(Type service, object implementation, string key) => container.RegisterInstance(service, key, implementation);

        public void RegisterHandler(Type service, Func<IInjectionContainer, object> handler) => RegisterHandler(service, handler, null);

        public void RegisterHandler(Type service, Func<IInjectionContainer, object> handler, string key) => container.RegisterHandler(service, key, (container) => handler(this));
    }
}
