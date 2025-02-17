namespace AVMHomeAutomation;

/// <summary>
/// Meta data
/// </summary>
public class MetaData
{
    /// <summary>
    /// Icon
    /// </summary>
    [JsonPropertyName("icon")]
    public int Icon { get; set; }

    /// <summary>
    /// Scenario type
    /// </summary>
    [JsonPropertyName("type")]
    public TypeEnum Type { get; set; }
}
