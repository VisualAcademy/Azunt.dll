namespace Azunt.Models.Enums
{
    /// <summary>HTML template used for a Suitability Report.</summary>
    public enum SuitabilityTemplate
    {
        /// <summary>Default template for new (non-renewal) reports.</summary>
        Initial = 0,

        /// <summary>Template for renewal reports.</summary>
        Renewal = 1,

        /// <summary>Template for interim (mid-cycle or temporary) reports.</summary>
        Interim = 2,
    }
}
