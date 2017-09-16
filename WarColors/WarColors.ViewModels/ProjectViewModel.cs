using WarColors.Models;

namespace WarColors.ViewModels
{
    /// <summary>
    /// The ProjectViewModel class.
    /// </summary>
    /// <seealso cref="WarColors.ViewModels.ViewModelBase" />
    public class ProjectViewModel : ViewModelBase
    {
        private ItemProject itemProject;
        private string title;

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get => title;
            set => SetField(ref title, value);
        }

        /// <summary>
        /// Gets or sets the item project.
        /// </summary>
        /// <value>
        /// The item project.
        /// </value>
        public ItemProject ItemProject
        {
            get => itemProject;
            set
            {
                SetField(ref itemProject, value);
                Title = itemProject.Title;
            }
        }
    }
}
