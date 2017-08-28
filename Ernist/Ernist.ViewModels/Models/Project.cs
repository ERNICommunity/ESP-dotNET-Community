using System.Collections.ObjectModel;

namespace Ernist.ViewModels.Models
{
    /// <summary>
    /// The project class.
    /// </summary>
    /// <seealso cref="System.Collections.ObjectModel.ObservableCollection{Ernist.ViewModels.Models.ItemProject}" />
    public class Project : ObservableCollection<ItemProject>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Project"/> class.
        /// </summary>
        /// <param name="projectTitle">The project title.</param>
        public Project (string projectTitle)
        {
            ProjectTitle = projectTitle;
        }

        /// <summary>
        /// Gets or sets the project title.
        /// </summary>
        /// <value>
        /// The project title.
        /// </value>
        public string ProjectTitle { get; set; }
    }
}
