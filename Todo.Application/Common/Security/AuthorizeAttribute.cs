namespace Todo.Application.Common.Security
{
    /// <summary>
    /// Specifies the class this attribute is required for authorization.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class AuthorizeAttribute : Attribute
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="AuthorizeAttribute" /> class.
        /// </summary>
        public AuthorizeAttribute() { }

        /// <summary>
        /// Gets or sets a comma delimited list of roles that are allowed to access the resources
        /// </summary>
        public String Roles { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the policy name that determines access to the resource.
        /// </summary>
        public string Policy { get; set; } = string.Empty;
    }
}
