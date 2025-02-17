namespace AVMHomeAutomation;

/// <summary>
/// Subscription state code
/// </summary>
public enum SubscriptionCode
{
    /// <summary>
    /// No subscription running.
    /// </summary>
    NoSubscription = 0,

    /// <summary>
    /// Subscription running.
    /// </summary>
    SubscriptionRunning = 1,

    /// <summary>
    /// Timeout
    /// </summary>
    Timeout = 2,

    /// <summary>
    /// Error
    /// </summary>
    Error = 3  
}
