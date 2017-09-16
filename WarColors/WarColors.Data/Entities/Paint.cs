using WarColors.Data.Repositories;

namespace WarColors.Data.Entities
{
    /// <summary>
    /// The paint class.
    /// </summary>
    public class Paint : IEntity<string>
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

        /// <summary>
        /// Gets or sets the type of the paint.
        /// </summary>
        /// <value>
        /// The type of the paint.
        /// </value>
        public PaintType PaintType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is metallic.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is metallic; otherwise, <c>false</c>.
        /// </value>
        public bool IsMetallic { get; set; }
    }
}