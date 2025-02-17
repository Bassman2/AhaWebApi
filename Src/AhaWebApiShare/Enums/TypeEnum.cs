namespace AVMHomeAutomation;

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
