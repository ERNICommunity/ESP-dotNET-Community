using System.Collections.ObjectModel;

namespace WarColors.Models
{
    /// <summary>
    /// The project class.
    /// </summary>
    /// <seealso cref="System.Collections.ObjectModel.ObservableCollection{WarColors.Models.ItemProject}" />
    public class Project : ObservableCollection<ItemProject>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Project"/> class.
        /// </summary>
        /// <param name="projectTitle">The project title.</param>
        public Project (string projectTitle)
        {
            Title = projectTitle;
        }

        /// <summary>
        /// Gets or sets the project title.
        /// </summary>
        /// <value>
        /// The project title.
        /// </value>
        public string Title { get; set; }
    }
}
