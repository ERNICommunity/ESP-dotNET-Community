﻿using System.Collections.Generic;
using WarColors.Data.Repositories;

namespace WarColors.Data.Entities
{
    /// <summary>
    /// The Part class.
    /// </summary>
    public class Part : IEntity<string>
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
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the techniques.
        /// </summary>
        /// <value>
        /// The techniques.
        /// </value>
        public IList<PartTechnique> Techniques { get; set; }
    }
}