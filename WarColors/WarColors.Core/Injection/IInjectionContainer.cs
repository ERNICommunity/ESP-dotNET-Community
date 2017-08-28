using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarColors.Core.Injection
{
    public interface IInjectionContainer
    {
        void BuildUp(object instance);

        IEnumerable<T> GetAllInstances<T>();
        IEnumerable<object> GetAllInstances(Type service);

        T GetInstance<T>();
        T GetInstance<T>(string key);
        object GetInstance(Type service);
        object GetInstance(Type service, string key);

        void Register(Type service, Type implementation);
        void Register(Type service, Type implementation, Scope scope);
        void Register(Type service, Type implementation, string key);
        void Register(Type service, Type implementation, string key, Scope scope);
        void Register(Type service, object implementation);
        void Register(Type service, object implementation, string key);

        bool IsRegistered(Type service);

        bool IsRegistered(Type service, string key);

        void RegisterHandler(Type service, Func<IInjectionContainer, object> handler);
        void RegisterHandler(Type service, Func<IInjectionContainer, object> handler, string key);
    }
}
