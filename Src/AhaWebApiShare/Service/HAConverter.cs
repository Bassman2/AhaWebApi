namespace AVMHomeAutomation;

internal static class HAConverter
{
    private readonly static DateTime UnixDateTimeStart = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

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
        if (int.TryParse(value.TrimEnd(), out var val))
        {
            return (OnOff)val;
        }
        return null;
    }

    public static Target? ToTarget(this string value)
    {
        return value.TrimEnd() switch
        {
            "close" => Target.Close,
            "open" => Target.Open,
            "stop" => Target.Stop,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value);
        }
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

    public static long ToUnixTime(this DateTime dateTime)
    {
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

    /// <summary>
    /// Fix bug in Fritz!OS
    /// </summary>
    /// <param name="value">Result string.</param>
    /// <returns>Result string</returns>
    /// <exception cref="HttpRequestException">Throw exception is result string starts with HTTP error.</exception>

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
