using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WarColors.Data.Repositories;
using WarColors.Models;

namespace WarColors.ViewModels
{
    public class ProjectListViewModel : ViewModelBase
    {
        private ObservableCollection<Project> projects;
        private IProjectRepository projectRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectViewModel"/> class.
        /// </summary>
        public ProjectListViewModel(IProjectRepository projectRepository)
        {
            InitializeDataAsync(projectRepository).ContinueWith(result =>
            {
                var project1 = new Project("Death Batallion")
                {
                    new ItemProject { Title = "Skeleton" },
                    new ItemProject { Title = "Zombie" },
                    new ItemProject { Title = "Neferata" },
                    new ItemProject { Title = "Nagash" }
                };

                var project2 = new Project("Kharadron Overlords")
                {
                    new ItemProject { Title = "Admiral" },
                    new ItemProject { Title = "Frigate" },
                    new ItemProject { Title = "Gunhauler" },
                    new ItemProject { Title = "Arkanout Company" },
                    new ItemProject { Title = "Skywardens" }
                };

                // TODO - Projects DataAccess to create the list.
                Projects = new ObservableCollection<Project>
                {
                    project1, project2
                };
            });
        }

        private static async Task InitializeDataAsync(IProjectRepository projectRepository)
        {
            var p2 = await projectRepository.GetAllAsync();

            if (!p2.Any(p => p.Title == "Death Batallion"))
            {
                var p1 = new WarColors.Data.Entities.Project()
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = "Death Batallion"
                };

                await projectRepository.SaveAsync(p1);

                var p3 = await projectRepository.GetAsync(p1.Id);
            }
        }

        /// <summary>
        /// Gets or sets the observable collection item project.
        /// </summary>
        /// <value>
        /// The observable collection item project.
        /// </value>
        public ObservableCollection<Project> Projects
        {
            get => projects;
            set => SetField(ref projects, value);
        }
    }
}
