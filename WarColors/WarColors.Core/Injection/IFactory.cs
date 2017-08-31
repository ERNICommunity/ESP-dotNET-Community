using System.Collections.Generic;

namespace WarColors.Core.Injection
{
    public interface IFactory<T>
    {
        T Get();

        T Get(string name);

        IEnumerable<T> GetAll();
    }
}