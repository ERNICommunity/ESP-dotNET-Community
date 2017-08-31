using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarColors.Core.Injection;
using WarColors.Data;
using WarColors.Data.Repositories;
using WarColors.Models;

namespace WarColors.ViewModels
{
    public class ProjectListViewModel : ViewModelBase
    {
        private ObservableCollection<Project> projects;
        private IFactory<IProjectRepository> projectFactoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectViewModel"/> class.
        /// </summary>
        public ProjectListViewModel(IFactory<IProjectRepository> projectFactoryRepository)
        {
            var sd = IoC.Get<ISeedDatabase>();
            sd.SeedAsync(true).ContinueWith(result =>
            {
                this.projectFactoryRepository = projectFactoryRepository;

                LoadProjects().ContinueWith(r => { });
            });
        }

        private async Task LoadProjects()
        {
            using (var projectRepository = projectFactoryRepository.Get())
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
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
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
