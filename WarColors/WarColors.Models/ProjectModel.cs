using System.Collections.ObjectModel;

namespace WarColors.Models
{
    /// <summary>
    /// The project class.
    /// </summary>
    /// <seealso cref="System.Collections.ObjectModel.ObservableCollection{WarColors.Models.ItemProjectModel}" />
    public class ProjectModel : ObservableCollection<ItemProjectModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectModel"/> class.
        /// </summary>
        /// <param name="projectTitle">The project title.</param>
        public ProjectModel(string id, string projectTitle)
        {
            Id = id;
            Title = projectTitle;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the project title.
        /// </summary>
        /// <value>
        /// The project title.
        /// </value>
        public string Title { get; set; }
    }
}
