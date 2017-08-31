using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarColors.Core.Injection;
using WarColors.Data.Entities;
using WarColors.Data.Repositories;

namespace WarColors.Data.Marcello
{
    public class SeedDatabase : ISeedDatabase
    {
        IFactory<IProjectRepository> projectFactoryRepository;

        public SeedDatabase(IFactory<IProjectRepository> projectFactoryRepository)
        {
            this.projectFactoryRepository = projectFactoryRepository;
        }

        public async Task SeedAsync(bool wipeDatabase)
        {
            using (var projectRepository = projectFactoryRepository.Get()) { 
                IEnumerable<Project> projects = null;

            if (wipeDatabase)
            {
                projects = await projectRepository.GetAllAsync();

                var tasks = new List<Task>();
                foreach (var p in projects)
                {
                    tasks.Add(projectRepository.DeleteAsync(p.Id));
                }

                Task.WaitAll(tasks.ToArray());
            }

            projects = await projectRepository.GetAllAsync();
                if (!projects.Any())
                {
                    var project = new Project()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "Kharadron Overlords",
                        Description = "Armies on Parade",
                        Creator = "Diego",
                        Created = DateTime.Now,
                        Models = new List<Model>()
                                    {
                                        new Model
                                        {
                                            Name = "Akranaut Almirant"
                                        },
                                        new Model
                                        {
                                            Name = "Arkanaut Frigate"
                                        },
                                        new Model
                                        {
                                            Name = "Arkanaut Company"
                                        },
                                        new Model
                                        {
                                            Name = "Khemist"
                                        },
                                        new Model
                                        {
                                            Name = "Grunstock Gunhauler"
                                        }
                                    }
                    };

                    var project2 = new Project()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "Death Batallion",
                        Description = "Armies on Parade",
                        Creator = "Diego",
                        Created = DateTime.Now,
                        Models = new List<Model>()
                                    {
                                        new Model
                                        {
                                            Name = "Skeleton"
                                        },
                                        new Model
                                        {
                                            Name = "Zombie"
                                        },
                                        new Model
                                        {
                                            Name = "Neferata"
                                        },
                                        new Model
                                        {
                                            Name = "Nagash"
                                        }
                                    }
                    };

                    await projectRepository.SaveAsync(project);
                    await projectRepository.SaveAsync(project2);
                }
            }
        }
    }
}
