namespace PerformanceApp.Models
{
    /// <summary>
    /// The person model class.
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the is developer.
        /// </summary>
        /// <value>
        /// The is developer.
        /// </value>
        public bool IsDeveloper { get; set; }
    }
}
