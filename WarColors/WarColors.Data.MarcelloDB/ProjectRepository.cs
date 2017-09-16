using WarColors.Data.Entities;
using WarColors.Data.Repositories;

namespace WarColors.Data.Marcello
{
    /// <summary>
    /// The ProjectRepository class.
    /// </summary>
    /// <seealso cref="WarColors.Data.Marcello.RepositoryBase{WarColors.Data.Entities.Project, System.String}" />
    /// <seealso cref="WarColors.Data.Repositories.IProjectRepository" />
    public class ProjectRepository : RepositoryBase<Project, string>, IProjectRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectRepository"/> class.
        /// </summary>
        /// <param name="database">The database.</param>
        public ProjectRepository(IDatabase database) : base(database)
        {
        }
    }
}
