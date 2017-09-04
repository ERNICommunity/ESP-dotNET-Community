using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WarColors.Models;

namespace WarColors.ViewModels
{
    /// <summary>
    /// The MasterViewModel class.
    /// </summary>
    /// <seealso cref="Caliburn.Micro.Conductor{Caliburn.Micro.IScreen}.Collection.OneActive" />
    /// <seealso cref="Caliburn.Micro.IHandle{WarColors.ViewModels.NavigationMessage}" />
    public class MasterViewModel : Conductor<IScreen>.Collection.OneActive, IHandle<NavigationMessage>
    {
        private IEventAggregator eventAggregator;

        /// <summary>
        /// Initializes a new instance of the <see cref="MasterViewModel"/> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public MasterViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            eventAggregator.Subscribe(this);

            MenuItems = new ObservableCollection<MasterViewMenuItem>
            {
                    new MasterViewMenuItem { Id = 0, Title = "Color Palette", TargetType = typeof(MainViewModel) },
                    new MasterViewMenuItem { Id = 1, Title = "Projects", TargetType = typeof(ProjectListViewModel) }
            };
        }

        /// <summary>
        /// Gets or sets the menu items.
        /// </summary>
        /// <value>
        /// The menu items.
        /// </value>
        public ObservableCollection<MasterViewMenuItem> MenuItems { get; set; }

        /// <summary>
        /// Handles the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Handle(NavigationMessage message)
        {
            if (message != null && message.TargetType != this.ActiveItem.GetType())
            {
                var vm = IoC.GetInstance(message.TargetType, null) as IScreen;
                ActivateItem(vm);
            }
        }

        /// <summary>
        /// Gets the item tapped.
        /// </summary>
        /// <value>
        /// The item tapped.
        /// </value>
        public ICommand ItemTapped { get; private set; }

        private void OnItemTapped(MasterViewMenuItem item)
        {
            eventAggregator.PublishOnUIThreadAsync(new NavigationMessage(item.TargetType));
        }
    }
}
