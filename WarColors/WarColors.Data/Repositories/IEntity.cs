using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarColors.Data.Repositories
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
