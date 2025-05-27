namespace Azunt.Models.ManageViewModels
{
    /// <summary>
    /// ViewModel used to represent external login information 
    /// for removing a linked external login from a user's account.
    /// </summary>
    public class RemoveLoginViewModel
    {
        /// <summary>
        /// The name of the external login provider (e.g., Google, Facebook).
        /// </summary>
        public string LoginProvider { get; set; }

        /// <summary>
        /// The unique key provided by the external login provider to identify the user.
        /// </summary>
        public string ProviderKey { get; set; }
    }
}
