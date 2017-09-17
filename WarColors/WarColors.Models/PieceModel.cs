using System.Collections.ObjectModel;

namespace WarColors.Models
{
    /// <summary>
    /// The Piece model.
    /// </summary>
    public class PieceModel : ObservableCollection<TechniqueModel>
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
    }
}
