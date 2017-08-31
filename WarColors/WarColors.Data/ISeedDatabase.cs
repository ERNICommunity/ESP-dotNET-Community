using System.Threading.Tasks;
using WarColors.Data.Repositories;

namespace WarColors.Data
{
    public interface ISeedDatabase
    {
        Task SeedAsync(bool wipeDatabase, IProjectRepository projectRepository);
    }
}