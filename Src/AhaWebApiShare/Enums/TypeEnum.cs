namespace AhaWebApi;

/// <summary>
/// Specifies the type of event or action, such as coming, leaving, or generic.
/// </summary>
[DataContract]
public enum TypeEnum
{
    /// <summary>
    /// Coming
    /// </summary>
    [EnumMember(Value = "coming")]
    Coming,

    /// <summary>
    /// Leaving
    /// </summary>
    [EnumMember(Value = "leaving")]
    Leaving,

    /// <summary>
    /// Generic
    /// </summary>
    [EnumMember(Value = "generic")]
    Generic
}
