using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using WarColors.Core.Injection;
using WarColors.Data;
using WarColors.Data.Repositories;
using WarColors.Models;
using Xamarin.Forms;

namespace WarColors.ViewModels
{
    /// <summary>
    /// The ProjectListViewModel class.
    /// </summary>
    /// <seealso cref="WarColors.ViewModels.ViewModelBase" />
    public class ProjectListViewModel : ViewModelBase
    {
        private ObservableCollection<ProjectModel> projects;
        private IFactory<IProjectRepository> projectFactoryRepository;
        private IEventAggregator eventAggregator;

        /// <summary>
        /// Initializes a new instance of the <see cref="MiniViewModel"/> class.
        /// </summary>
        public ProjectListViewModel(IFactory<IProjectRepository> projectFactoryRepository, IEventAggregator eventAggregator)
        {
            var sd = IoC.Get<ISeedDatabase>();
            sd.SeedAsync(false).ContinueWith(result =>
            {
                this.projectFactoryRepository = projectFactoryRepository;

                LoadProjects().ContinueWith(r => { });
            });

            this.eventAggregator = eventAggregator;

            // Commands
            ProjectTapped = new Command<ItemProjectModel>(OnProjectTapped);
            AddProjectTapped = new Command(OnAddProjectTaped);
            RemoveProjectTapped = new Command<string>(OnRemoveProjectTapped);
        }

        /// <summary>
        /// Gets or sets the observable collection item project.
        /// </summary>
        /// <value>
        /// The observable collection item project.
        /// </value>
        public ObservableCollection<ProjectModel> Projects
        {
            get => projects;
            set => SetField(ref projects, value);
        }

        /// <summary>
        /// Gets the project tapped.
        /// </summary>
        /// <value>
        /// The project tapped.
        /// </value>
        public ICommand ProjectTapped { get; private set; }

        /// <summary>
        /// Gets the add project tapped.
        /// </summary>
        /// <value>
        /// The add project tapped.
        /// </value>
        public ICommand AddProjectTapped { get; private set; }

        /// <summary>
        /// Gets the remove project tapped.
        /// </summary>
        /// <value>
        /// The remove project tapped.
        /// </value>
        public ICommand RemoveProjectTapped { get; private set; }

        private void OnProjectTapped(ItemProjectModel item)
        {
            eventAggregator.PublishOnUIThreadAsync(new NavigationMessage(item.TargetType, item.Id));
        }

        private void OnAddProjectTaped()
        {
            eventAggregator.PublishOnUIThreadAsync(new NavigationMessage(typeof(AddEditProjectViewModel)));
        }

        private void OnRemoveProjectTapped(string projectModel)
        {
            try
            {
                var project = Projects.FirstOrDefault(p => p.Title == projectModel);

                // Remove from Database.
                RemoveProjectFromDatabase(project.Id).ContinueWith(r => { });

                Projects.Remove(project);

                // Needed to update the Collection properly.
                Projects = new ObservableCollection<ProjectModel>(Projects);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        private async Task RemoveProjectFromDatabase(string id)
        {
            using (var projectRepository = projectFactoryRepository.Get())
            {
                await projectRepository.DeleteAsync(id);
            }
        }

        private async Task LoadProjects()
        {
            using (var projectRepository = projectFactoryRepository.Get())
            {
                try
                {
                    var items = await projectRepository.GetAllAsync();

                    var result = new List<ProjectModel>();
                    foreach (var p in items)
                    {
                        var project = new ProjectModel(p.Id, p.Title);
                        
                        foreach (var m in p.Models)
                        {
                            project.Add(new ItemProjectModel { Id = m.Id, Title = m.Name, TargetType = typeof(MiniViewModel) });
                        }
                        result.Add(project);
                    }

                    Projects = new ObservableCollection<ProjectModel>(result);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }
    }
}
