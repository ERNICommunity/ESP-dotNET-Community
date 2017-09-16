﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using WarColors.Core.Injection;
using WarColors.Data;
using WarColors.Data.Repositories;
using WarColors.Models;

namespace WarColors.ViewModels
{
    /// <summary>
    /// The MiniViewModel class.
    /// </summary>
    /// <seealso cref="WarColors.ViewModels.ViewModelBase" />
    public class MiniViewModel : ViewModelBase
    {
        private ObservableCollection<Piece> pieces;
        private string title;

        private IFactory<IProjectRepository> projectFactoryRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MiniViewModel"/> class.
        /// </summary>
        /// <param name="projectFactoryRepository">The project factory repository.</param>
        public MiniViewModel(IFactory<IProjectRepository> projectFactoryRepository)
        {
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
        public ObservableCollection<Piece> Pieces
        {
            get => pieces;
            set { SetField(ref pieces, value); }
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
                                var pieceList = new List<Piece>();
                                if (model.Parts != null && model.Parts.Count > 0)
                                {
                                    foreach (var part in model.Parts)
                                    {
                                        var piece = new Piece { Id = "1", Color = "Red", Name = part.Name };
                                        pieceList.Add(piece);
                                    }

                                    Pieces = new ObservableCollection<Piece>(pieceList);
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