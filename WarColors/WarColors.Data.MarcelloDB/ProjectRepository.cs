using MarcelloDB.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarColors.Data.Entities;
using WarColors.Data.Repositories;

namespace WarColors.Data.Marcello
{
    public class ProjectRepository : RepositoryBase<Project, string>, IProjectRepository
    {
        public ProjectRepository(IDatabase database) : base(database)
        {
        }
    }
}
