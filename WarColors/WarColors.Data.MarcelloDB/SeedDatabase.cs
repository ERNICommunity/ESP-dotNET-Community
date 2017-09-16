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
            try
            {
                using (var projectRepository = projectFactoryRepository.Get())
                {
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
                                            Id = Guid.NewGuid().ToString(), Name = "Akranaut Almirant", Description = "Lord of the Kharadrons",
                                            Parts = new List<Part> { new Part { Name = "Part 1" }, new Part { Name = "Part 2"} }
                                        },
                                        new Model
                                        {
                                            Id = Guid.NewGuid().ToString(), Name = "Arkanaut Frigate", Description = "Frigate of the Karadrons",
                                            Parts = new List<Part> { new Part { Name = "Part 1" }, new Part { Name = "Part 2"} }
                                        },
                                        new Model
                                        {
                                            Id = Guid.NewGuid().ToString(), Name = "Arkanaut Company", Description = "Basic unit of the Karadrons",
                                            Parts = new List<Part> { new Part { Name = "Part 1" }, new Part { Name = "Part 2"} }
                                        },
                                        new Model
                                        {
                                            Id = Guid.NewGuid().ToString(), Name = "Khemist", Description = "Khemist Karadron",
                                            Parts = new List<Part> { new Part { Name = "Part 1" }, new Part { Name = "Part 2"} }
                                        },
                                        new Model
                                        {
                                            Id = Guid.NewGuid().ToString(), Name = "Grunstock Gunhauler", Description = "Grunstock Karadron",
                                            Parts = new List<Part> { new Part { Name = "Part 1" }, new Part { Name = "Part 2"} }
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
                                            Id = Guid.NewGuid().ToString(), Name = "Skeleton", Description = "Basic unit for the Skeleton army",
                                            Parts = new List<Part> { new Part { Name = "Part 1" }, new Part { Name = "Part 2"} }
                                        },
                                        new Model
                                        {
                                            Id = Guid.NewGuid().ToString(), Name = "Zombie", Description = "Basic unit for the Zombie army",
                                            Parts = new List<Part> { new Part { Name = "Part 1" }, new Part { Name = "Part 2"} }
                                        },
                                        new Model
                                        {
                                            Id = Guid.NewGuid().ToString(), Name = "Neferata", Description = "Mortach",
                                            Parts = new List<Part> { new Part { Name = "Part 1" }, new Part { Name = "Part 2"} }
                                        },
                                        new Model
                                        {
                                            Id = Guid.NewGuid().ToString(), Name = "Nagash", Description = "Lord of the undeath",
                                            Parts = new List<Part> { new Part { Name = "Part 1" }, new Part { Name = "Part 2"} }
                                        }
                                    }
                        };

                        await projectRepository.SaveAsync(project);
                        await projectRepository.SaveAsync(project2);
                    }
                }
            }
            catch (Exception ex)
            {
                var x  = ex;
            }
        }
    }
}
