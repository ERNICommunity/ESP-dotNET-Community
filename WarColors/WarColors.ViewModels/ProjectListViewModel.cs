using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarColors.Models;

namespace WarColors.ViewModels
{
    public class ProjectListViewModel : ViewModelBase
    {
        private ObservableCollection<Project> projects;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectViewModel"/> class.
        /// </summary>
        public ProjectListViewModel()
        {
            // TODO - Projects DataAccess to create the list.
            projects = new ObservableCollection<Project>
           {
                new Project("Death Batallion")
                {
                    new ItemProject { Title = "Skeleton" },
                    new ItemProject { Title = "Zombie" },
                    new ItemProject { Title = "Neferata" },
                    new ItemProject { Title = "Nagash" }
                },
                new Project("Kharadron Overlords")
                {
                    new ItemProject { Title = "Admiral" },
                    new ItemProject { Title = "Frigate" },
                    new ItemProject { Title = "Gunhauler" },
                    new ItemProject { Title = "Arkanout Company" },
                    new ItemProject { Title = "Skywardens" }
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
            get => projects;
            set => SetField(ref projects, value);
        }
    }
}
