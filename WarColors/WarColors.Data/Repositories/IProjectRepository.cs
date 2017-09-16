using WarColors.Data.Entities;

namespace WarColors.Data.Repositories
{
    /// <summary>
    /// The IProjectRepository interface.
    /// </summary>
    /// <seealso cref="WarColors.Data.Repositories.IRepository{WarColors.Data.Entities.Project, System.String}" />
    public interface IProjectRepository : IRepository<Project, string>
    {
    }
}
