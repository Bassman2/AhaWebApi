namespace AhaWebApi;

/// <summary>
/// Represents the state of a subscription, including its code and the latest registered device.
/// </summary>
public class SubscriptionState : IXSerializable
{
    /// <summary>
    /// Gets or sets the subscription state code.
    /// </summary>
    public SubscriptionCode Code { get; set; }

    /// <summary>
    /// Gets or sets the AIN (Access Identification Number) of the last registered device.
    /// </summary>
    public string? LatestAin { get; set; }

    /// <summary>
    /// Reads the subscription state from the specified XML element.
    /// </summary>
    /// <param name="elm">The XML element to read from.</param>
    public void ReadX(XElement elm)
    {
        Code = elm.ReadAttributeEnum<SubscriptionCode>("code");
        LatestAin = elm.ReadElementString("latestain"); 
    }
}
