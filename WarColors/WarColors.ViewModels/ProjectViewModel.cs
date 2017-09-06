using Caliburn.Micro;
using WarColors.Models;

namespace WarColors.ViewModels
{
    /// <summary>
    /// The ProjectViewModel class.
    /// </summary>
    /// <seealso cref="WarColors.ViewModels.ViewModelBase" />
    public class ProjectViewModel : ViewModelBase, IHandle<ItemProject>
    {
        private IEventAggregator eventAggregator;
        private ItemProject itemProject;
        private string title;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectViewModel"/> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public ProjectViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            eventAggregator.Subscribe(this);
        }

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

        public void Handle(ItemProject message)
        {
            ItemProject = message;
        }
    }
}
