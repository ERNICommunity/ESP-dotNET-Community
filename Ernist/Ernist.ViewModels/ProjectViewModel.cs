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
        private ObservableCollection<ItemProject> _observableCollectionItemProject;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectViewModel"/> class.
        /// </summary>
        public ProjectViewModel()
        {
            // TODO - Projects DataAccess to create the list.
            _observableCollectionItemProject = new ObservableCollection<ItemProject>
            {
                new ItemProject { ItemTitle = "Skelleton" },
                new ItemProject { ItemTitle = "Horse" },
                new ItemProject { ItemTitle = "DeathLord" },
                new ItemProject { ItemTitle = "Zombie" }
            };
        }

        public ObservableCollection<ItemProject> ObservableCollectionItemProject
        {
            get { return _observableCollectionItemProject; }
            set { SetProperty(ref _observableCollectionItemProject, value); }
        }
    }
}
