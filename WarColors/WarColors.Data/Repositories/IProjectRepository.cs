using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarColors.Data.Entities;

namespace WarColors.Data.Repositories
{
    public interface IProjectRepository : IRepository<Project, string>
    {
    }
}
