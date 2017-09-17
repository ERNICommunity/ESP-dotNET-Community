using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
            sd.SeedAsync(true).ContinueWith(result =>
            {
                this.projectFactoryRepository = projectFactoryRepository;

                LoadProjects().ContinueWith(r => { });
            });

            this.eventAggregator = eventAggregator;
            ProjectTapped = new Command<ItemProjectModel>(OnProjectTapped);
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

        private void OnProjectTapped(ItemProjectModel item)
        {
            eventAggregator.PublishOnUIThreadAsync(new NavigationMessage(item.TargetType, item.Id));
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
                        var project = new ProjectModel(p.Title);
                        
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
