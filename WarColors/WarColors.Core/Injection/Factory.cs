using System.Collections.Generic;

namespace WarColors.Core.Injection
{
    public class Factory<T> : IFactory<T>
    {
        private IInjectionContainer container;

        public Factory(IInjectionContainer container)
        {
            this.container = container;
        }

        public T Get()
        {
            return container.GetInstance<T>();
        }

        public T Get(string name)
        {
            return container.GetInstance<T>(name);
        }

        public IEnumerable<T> GetAll()
        {
            return container.GetAllInstances<T>();
        }
    }
}