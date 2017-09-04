
using System;

namespace WarColors.ViewModels
{
    /// <summary>
    /// The NavigationMessage class.
    /// </summary>
    public class NavigationMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationMessage"/> class.
        /// </summary>
        /// <param name="targetType">Type of the target.</param>
        public NavigationMessage(Type targetType)
        {
            TargetType = targetType;
        }

        /// <summary>
        /// Gets the type of the target.
        /// </summary>
        /// <value>
        /// The type of the target.
        /// </value>
        public Type TargetType { get; internal set; }
    }
}
