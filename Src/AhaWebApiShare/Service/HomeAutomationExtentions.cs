namespace AhaWebApi;

internal static class HomeAutomationExtentions
{
    private readonly static DateTime UnixDateTimeStart = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);


    //private static JsonSerializerOptions options;

    //[RequiresDynamicCode("Calls System.Text.Json.Serialization.JsonStringEnumConverter.JsonStringEnumConverter()")]
    //static HomeAutomationExtentions()
    //{
    //    options = new JsonSerializerOptions();
    //    options.Converters.Add(new JsonStringEnumConverter());
    //}

    public static string ToHkrTemperature(this double val)
    {
        return val switch
        {
            double.MaxValue => "254",     // ON
            double.MinValue => "253",     // OFF
            _ => ((int)Math.Round(val * 2.0)).ToString()
        };
    }

    /// <summary>
    /// Temperature value in 0.5 ° C, value range: 16 - 56 8 to 28 ° C, 16 &lt;= 8 ° C, 17 =, 5 ° C ...... 56 &gt;= 28 ° C 254 = ON, 253 = OFF.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static double ToHkrTemperature(this string? value)
    {
        if (int.TryParse(value, out int val))
        {
            return val switch
            {
                254 => HomeAutomation.On,
                253 => HomeAutomation.Off,
                _ => val / 2.0
            };
        }
        throw new ArgumentException($"Unknown value: '{value}'", nameof(value));
    }

    /// <summary>
    /// Temperature value in 0.1 ° C, negative and positive values possible Ex. "200" means 20 ° C
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Temeratur in °C or null</returns>
    public static double? ToTemperature(this string? value)
    {
        if (value == "inval\n")
        {
            return null;
        }
        if (int.TryParse(value, out int val))
        {
            return val / 10.0;
        }
        throw new ArgumentException($"Unknown value: '{value}'", nameof(value));
    }

    public static string[] SplitList(this string? str)
    {
        return str?.TrimEnd().Split(',') ?? [];
    }

    public static int ToDeciseconds(this TimeSpan? duration)
    {
        return duration.HasValue ? (int)(duration.Value.Ticks / (TimeSpan.TicksPerSecond / 10)) : 0;
    }

    public static double? ToPower(this string? value)
    {
        if (value == "inval\n")
        {
            return null;
        }
        if (int.TryParse(value, out int res))
        {
            return res / 1000.0;
        }
        throw new ArgumentException($"Unknown value: '{value}'", nameof(value));
    }

    public static bool? ToBool(this string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }
        return value switch
        {
            "0\n" => false,
            "1\n" => true,
            "inval\n" => null,
            _ => null
        };
    }


    public static OnOff? ToOnOff(this string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }
        return value switch
        {
            "0\n" => OnOff.Off,
            "1\n" => OnOff.On,
            "2\n" => OnOff.Toggle,
            _ => null
        };
    }

    public static Target? ToTarget(this string value)
    {
        return value.TrimEnd() switch
        {
            "close" => (Target?)Target.Close,
            "open" => (Target?)Target.Open,
            "stop" => (Target?)Target.Stop,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value),
        };
    }

    public static XmlDocument? ToXml(this string? value)
    {
        if (value == null)
        {
            return null;
        }
        var doc = new XmlDocument();
        doc.LoadXml(value);
        return doc;
    }

    public static int? ToInt(this string? value)
    {
        if (int.TryParse(value, out var val))
        {
            return val;
        }
        return null;
    }

    

    //public static SubscriptionState? ToSubscriptionState(this string? value)
    //{
    //    if (value is null)    
    //    {
    //        return null;
    //    }

    //    var res = new SubscriptionState();
    //    var doc = XDocument.Parse(value);
    //    var state = doc.Element("state");
    //    res.Code = state.ReadAttributeEnum<SubscriptionCode>("code");
    //    res.LatestAin = state.ReadElementString("latestain");
    //    return res;
    //}

    //public static DeviceList? ToToDeviceList(this string? value)
    //{
    //    if (value is null)
    //    {
    //        return null;
    //    }

    //    var res = new DeviceList();
    //    var doc = XDocument.Parse(value);
    //    var device = doc.Element("devicelist");

    //    return res;
    //}

    //public static Device? ToDevice(this string? value)
    //{
    //    if (value is null)
    //    {
    //        return null;
    //    }

    //    var res = new Device();
    //    var doc = XDocument.Parse(value);
    //    var device = doc.Element("device");

    //    res.Identifier = device.ReadAttributeString("identifier");
    //    res.Id = device.ReadAttributeString("id");
    //    res.FirmwareVersion = device.ReadAttributeString("fwversion");
    //    res.Manufacturer = device.ReadAttributeString("manufacturer");
    //    res.ProductName = device.ReadAttributeString("productname");
    //    res.FunctionBitMask = device.ReadAttributeEnum<Functions>("functionbitmask");

    //    res.IsPresent = device.ReadElementBool("present");
    //    res.IsTXBusy = device.ReadElementBool("txbusy");
    //    res.Name = device.ReadElementString("name");
    //    res.IsBatteryLow = device.ReadElementBool("batterylow");
    //    res.Battery = device.ReadElementInt("batterylow");
        
    //    var _switch = new Switch();
    //    var switchElm = device?.Element("switch");
    //    //_switch.State = switchElm
    //    //TODO
    //    res.Switch = _switch;
    //    return res;
    //}

    
    //private static string? ReadAttributeString(this XElement? elm, string attrName)
    //{
    //    return elm?.Attribute("latestain")?.Value;
    //}

    //private static int? ReadAttributeInt(this XElement? elm, string attrName)
    //{
    //    string? value = elm?.Attribute(attrName)?.Value;
    //    if (int.TryParse(value, out var val))
    //    {
    //       return val;
    //    }
    //    return null;
    //}

    //private static T ReadAttributeEnum<T>(this XElement? elm, string attrName) where T : Enum
    //{
    //    string? value = elm?.Attribute(attrName)?.Value;
    //    if (int.TryParse(value, out var val))
    //    {
    //        return (T)(object)val;
    //    }
    //    return default(T);
    //}

    //private static string? ReadElementString(this XElement? elm, string attrName)
    //{
    //    return elm?.Element(attrName)?.Value;
    //}

    //private static int? ReadElementInt(this XElement? elm, string attrName)
    //{
    //    string? value = elm?.Attribute(attrName)?.Value;
    //    if (int.TryParse(value, out var val))
    //    {
    //        return val;
    //    }
    //    return null;
    //}

    //private static bool? ReadElementBool(this XElement? elm, string attrName)
    //{
    //    string? value = elm?.Attribute(attrName)?.Value;
    //    if (int.TryParse(value, out var val))
    //    {
    //        return val != 0;
    //    }
    //    return null;
    //}

    //[RequiresUnreferencedCode("Calls System.Xml.Serialization.XmlSerializer.XmlSerializer(Type)")]
    //public static T? XmlToAs<T>(this string value)
    //{
    //    var serializer = new XmlSerializer(typeof(T));
    //    using var reader = new StringReader(value);
    //    T? val = (T?)serializer.Deserialize(reader);
    //    return val;

    //}



    //public static T? JsonToAs<T>(this string value)
    //{

    //    return JsonSerializer.Deserialize<T>(value, options);
    //}

    //public static string AsToJson<T>(this T value)
    //{
    //    var options = new JsonSerializerOptions
    //    {
    //        WriteIndented = true,
    //        Converters = { new JsonStringEnumConverter() }
    //    };

    //    return JsonSerializer.Serialize(value, options);
    //}

    public static long ToUnixTime(this DateTime dateTime)
    {
        // return ((DateTimeOffset)dateTime).ToUnixTimeSeconds();
        //return (long)dateTime.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        //return (long)dateTime.Subtract(DateTime.UnixEpoch).TotalSeconds;

        return (long)dateTime.ToUniversalTime().Subtract(UnixDateTimeStart).TotalSeconds;
    }

    public static long ToUnixTime(this DateTime? dateTime)
    {
        return dateTime.HasValue ? dateTime.Value.ToUnixTime() : 0;
    }

    /// <summary>
    /// Time in seconds since 1970
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static DateTime? ToNullableDateTime(this string value)
    {
        if (long.TryParse(value, out long val))
        {
            return val == 0 ? null : (DateTime?)(UnixDateTimeStart.AddSeconds(val));
        }
        return null;
    }

    ///// <summary>
    ///// Fix bug in Fritz!OS
    ///// </summary>
    ///// <param name="value">Result string.</param>
    ///// <returns>Result string</returns>
    ///// <exception cref="HttpRequestException">Throw exception is result string starts with HTTP error.</exception>

//    public static string CheckStatusCode(this string value)
//    {
//        // "HTTP/1.0 500 Internal Server Error\r\nContent-Length: 0\r\nContent-Type: text/plain; charset=utf-8\r\nPragma: no-cache\r\nCache-Control: no-cache\r\nExpires: -1"
//        if (value.StartsWith("HTTP/1.0 500"))
//        {
//#if NET
//            throw new HttpRequestException("Internal Server Error", null, HttpStatusCode.InternalServerError);
//#else
//            throw new HttpRequestException("Internal Server Error", null);
//#endif
//        }
//        return value;
//    }
}
