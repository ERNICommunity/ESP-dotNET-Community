using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarColors.Data;
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
            var sd = IoC.Get<ISeedDatabase>();
            sd.SeedAsync(true, projectRepository).ContinueWith(result =>
            {
                this.projectRepository = projectRepository;

                LoadProjects().ContinueWith(r => { });
            });
        }

        private async Task LoadProjects()
        {
            try
            {
                var items = await projectRepository.GetAllAsync();

                var result = new List<Project>();
                foreach (var p in items)
                {
                    var project = new Project(p.Title);
                    foreach (var m in p.Models)
                    {
                        project.Add(new ItemProject { Title = m.Name });
                    }
                    result.Add(project);
                }

                Projects = new ObservableCollection<Project>(result);
            } catch(Exception e)
            {
                Debug.WriteLine(e);
            }
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
