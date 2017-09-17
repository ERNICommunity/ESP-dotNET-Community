using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using WarColors.Core.Injection;
using WarColors.Data;
using WarColors.Data.Repositories;
using WarColors.Models;
using Xamarin.Forms;

namespace WarColors.ViewModels
{
    /// <summary>
    /// The MiniViewModel class.
    /// </summary>
    /// <seealso cref="WarColors.ViewModels.ViewModelBase" />
    public class MiniViewModel : ViewModelBase
    {
        private IEventAggregator eventAggregator;
        private ObservableCollection<PieceModel> pieces;
        private string title;

        private IFactory<IProjectRepository> projectFactoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MiniViewModel" /> class.
        /// </summary>
        /// <param name="projectFactoryRepository">The project factory repository.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        public MiniViewModel(IFactory<IProjectRepository> projectFactoryRepository, IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            BackMiniTapped = new Command(OnBackMiniTapped);

            var sd = IoC.Get<ISeedDatabase>();
            sd.SeedAsync(false).ContinueWith(result =>
            {
                this.projectFactoryRepository = projectFactoryRepository;

                LoadItem().ContinueWith(r => { });
            });
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get => title;
            set { SetField(ref title, value); }
        }

        /// <summary>
        /// Gets or sets the pieces.
        /// </summary>
        /// <value>
        /// The pieces.
        /// </value>
        public ObservableCollection<PieceModel> Pieces
        {
            get => pieces;
            set { SetField(ref pieces, value); }
        }

        /// <summary>
        /// Gets the back mini tapped.
        /// </summary>
        /// <value>
        /// The back mini tapped.
        /// </value>
        public ICommand BackMiniTapped { get; private set; }

        private void OnBackMiniTapped()
        {
            eventAggregator.PublishOnUIThreadAsync(new NavigationMessage(typeof(ProjectListViewModel)));
        }

        private async Task LoadItem()
        {
            using (var projectRepository = projectFactoryRepository.Get())
            {
                try
                {
                    var items = await projectRepository.GetAllAsync();

                    foreach (var item in items)
                    {
                        foreach (var model in item.Models)
                        {
                            if (model.Id == Id)
                            {
                                var pieceList = new List<PieceModel>();
                                if (model.Parts != null && model.Parts.Count > 0)
                                {
                                    foreach (var part in model.Parts)
                                    {
                                        var piece = new PieceModel { Id = "1", Name = part.Name };
                                        piece.Add(new TechniqueModel { Color = "Red", CitadelColor = "Stormcast Gold", Technique = "Dry" });
                                        piece.Add(new TechniqueModel { Color = "Blue", CitadelColor = "Stormhost Silver", Technique = "Base" });
                                        piece.Add(new TechniqueModel { Color = "Black", CitadelColor = "Stormhost Silver", Technique = "Base" });
                                        pieceList.Add(piece);
                                    }

                                    Pieces = new ObservableCollection<PieceModel>(pieceList);
                                    Title = model.Name;
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }
    }
}
