using Ernist.ViewModels.Base;
using Ernist.ViewModels.Models;
using System.Collections.ObjectModel;

namespace Ernist.ViewModels
{
    /// <summary>
    /// View model of Projects
    /// </summary>
    /// <seealso cref="Ernist.ViewModels.Base.ViewModelBase" />
    public class ProjectViewModel : ViewModelBase
    {
        private ObservableCollection<Project> _observableCollectionProject;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectViewModel"/> class.
        /// </summary>
        public ProjectViewModel()
        {
            // TODO - Projects DataAccess to create the list.
            _observableCollectionProject = new ObservableCollection<Project>
            {
                new Project("Death Batallion")
                {
                    new ItemProject { ItemTitle = "Skeleton" },
                    new ItemProject { ItemTitle = "Zombie" },
                    new ItemProject { ItemTitle = "Neferata" },
                    new ItemProject { ItemTitle = "Nagash" }
                },
                new Project("Stormcast")
                {
                    new ItemProject { ItemTitle = "Stormcast 1" },
                    new ItemProject { ItemTitle = "Stormcast 2" },
                    new ItemProject { ItemTitle = "Stormcast 3" },
                    new ItemProject { ItemTitle = "Stormcast 4" }
                }
            };
        }

        /// <summary>
        /// Gets or sets the observable collection item project.
        /// </summary>
        /// <value>
        /// The observable collection item project.
        /// </value>
        public ObservableCollection<Project> ObservableCollectionProject
        {
            get { return _observableCollectionProject; }
            set { SetProperty(ref _observableCollectionProject, value); }
        }
    }
}
