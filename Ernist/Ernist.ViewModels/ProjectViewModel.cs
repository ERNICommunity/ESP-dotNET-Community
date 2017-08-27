using Ernist.ViewModels.Base;
using Ernist.ViewModels.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Ernist.ViewModels
{
    /// <summary>
    /// View model of Projects
    /// </summary>
    /// <seealso cref="Ernist.ViewModels.Base.ViewModelBase" />
    public class ProjectViewModel : ViewModelBase, IProjectViewModel
    {
        private ObservableCollection<Project> projects;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectViewModel"/> class.
        /// </summary>
        public ProjectViewModel()
        {
            // TODO - Projects DataAccess to create the list.
           projects = new ObservableCollection<Project>
           {
                new Project("Death Batallion")
                {
                    new ItemProject { ItemTitle = "Skeleton" },
                    new ItemProject { ItemTitle = "Zombie" },
                    new ItemProject { ItemTitle = "Neferata" },
                    new ItemProject { ItemTitle = "Nagash" }
                },
                new Project("Kharadron Overlords")
                {
                    new ItemProject { ItemTitle = "Admiral" },
                    new ItemProject { ItemTitle = "Frigate" },
                    new ItemProject { ItemTitle = "Gunhauler" },
                    new ItemProject { ItemTitle = "Arkanout Company" },
                    new ItemProject { ItemTitle = "Skywardens" }
                }
           };
        }

        /// <summary>
        /// Gets or sets the observable collection item project.
        /// </summary>
        /// <value>
        /// The observable collection item project.
        /// </value>
        public ObservableCollection<Project> Projects
        {
            get { return projects; }
            set { SetProperty(ref projects, value); }
        }
    }
}
