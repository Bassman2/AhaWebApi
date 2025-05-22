namespace AhaWebApi.Service;

internal class HomeAutomationService(string login, string password, Uri? host = null) 
    : WebService(host ?? new Uri("http://fritz.box"), new HomeAutomationAuthenticator(login, password))
{
    internal string? sessionId;

    protected override string? AuthenticationTestUrl => BuildUrl("getdevicelistinfos");

    #region Private Methods

    private const int On = 254;
    private const int Off = 253;

    private string BuildUrl(string cmd)
    {
        return $"webservices/homeautoswitch.lua?switchcmd={cmd}&sid={this.sessionId}";
    }

    private string BuildUrl(string cmd, string ain)
    {
        return $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}";
    }

    private string BuildUrl(string cmd, string ain, string param)
    {
        return $"webservices/homeautoswitch.lua?ain={ain}&switchcmd={cmd}&sid={this.sessionId}&{param}";
    }

    #endregion

    public async Task<string[]?> GetSwitchListAsync(CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getswitchlist"), cancellationToken);
        return res!.SplitList();
    }

    public async Task<bool?> SetSwitchOnAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("setswitchon", ain), cancellationToken);
        return res.ToBool();
    }
        
    public async Task<bool?> SetSwitchOffAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("setswitchoff", ain), cancellationToken);
        return res.ToBool();
    }

    public async Task<bool?> SetSwitchToggleAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("setswitchtoggle", ain), cancellationToken);
        return res.ToBool();
    }

    public async Task<bool?> GetSwitchStateAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getswitchstate", ain), cancellationToken);
        return res.ToBool();
    }

    public async Task<bool?> GetSwitchPresentAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getswitchpresent", ain), cancellationToken);
        return res.ToBool();
    }

    public async Task<double?> GetSwitchPowerAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getswitchpower", ain), cancellationToken);
        return res.ToPower();
    }

    public async Task<double?> GetSwitchEnergyAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getswitchenergy", ain), cancellationToken);
        return res.ToPower();
    }
        
    public async Task<string?> GetSwitchNameAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getswitchname", ain), cancellationToken);
        return res?.TrimEnd();
    }

    public async Task<DeviceList?> GetDeviceListInfosAsync(CancellationToken cancellationToken)
    {
        var res = await this.client!.GetStringAsync(BuildUrl("getdevicelistinfos"), cancellationToken);
        return res.XDeserialize<DeviceList>("devicelist");
    }

    
    public async Task<XmlDocument?> GetDeviceListInfosXmlAsync(CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getdevicelistinfos"), cancellationToken);
        return res.ToXml();
    }
       
    public async Task<double?> GetTemperatureAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("gettemperature", ain), cancellationToken);
        return res.ToTemperature();
    }

    public async Task<double> GetHkrtSollAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("gethkrtsoll", ain), cancellationToken);
        return res.ToHkrTemperature();
    }

    public async Task<double> GetHkrKomfortAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("gethkrkomfort", ain), cancellationToken);
        return res.ToHkrTemperature();
    }

    public async Task<double> GetHkrAbsenkAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("gethkrabsenk", ain), cancellationToken);
        return res.ToHkrTemperature();
    }

    public async Task<double> SetHkrtSollAsync(string ain, double temperature, CancellationToken cancellationToken)
    {
        if ((temperature < 8 || temperature > 28) && (temperature != On) && (temperature != Off))
        {
            throw new ArgumentOutOfRangeException(nameof(temperature));
        }
        var res = await GetStringAsync(BuildUrl("sethkrtsoll", ain, $"param={temperature.ToHkrTemperature()}"), cancellationToken);
        return res.ToHkrTemperature();
    }

    public async Task<DeviceStats?> GetBasicDeviceStatsAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getbasicdevicestats", ain), cancellationToken);
        return res.XDeserialize<DeviceStats>("devicestats");
    }

    public async Task<XmlDocument?> GetBasicDeviceStatsXmlAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getbasicdevicestats", ain), cancellationToken);
        return res.ToXml();
    }
        
    public async Task<TriggerList?> GetTriggerListInfosAsync(CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("gettriggerlistinfos"), cancellationToken);
        return res.XDeserialize<TriggerList>("triggerlist");
    }
        
    public async Task<XmlDocument?> GetTriggerListInfosXmlAsync(CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("gettriggerlistinfos"), cancellationToken);
        return res.ToXml();
    }

    public async Task<bool?> SetTriggerActiveAsync(string ain, bool active, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("settriggeractive", ain, $"active={(active ? "1" : "0")}"), cancellationToken);
        return res.ToBool();
    }

    public async Task<TemplateList?> GetTemplateListInfosAsync(CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("gettemplatelistinfos"), cancellationToken);
        return res.XDeserialize<TemplateList>("templatelist");
    }

    public async Task<XmlDocument?> GetTemplateListInfosXmlAsync(CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("gettemplatelistinfos"), cancellationToken);
        return res.ToXml();
    }

    public async Task<int?> ApplyTemplateAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("applytemplate", ain), cancellationToken);
        return res.ToInt();
    }

    public async Task<OnOff?> SetSimpleOnOffAsync(string ain, OnOff onOff, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("setsimpleonoff", ain, $"onoff={((int)onOff)}"), cancellationToken);
        return res.ToOnOff();
    }

    public async Task<int?> SetLevelAsync(string ain, int level, CancellationToken cancellationToken)
    {
        if (level < 0 || level > 255)
        {
            throw new ArgumentOutOfRangeException(nameof(level));
        }
        var res = await GetStringAsync(BuildUrl("setlevel", ain, $"level={level}"), cancellationToken);
        return res?.ToInt();
    }

    public async Task<int?> SetLevelPercentageAsync(string ain, int level, CancellationToken cancellationToken)
    {
        if (level < 0 || level > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(level));
        }
        var res = await GetStringAsync(BuildUrl("setlevelpercentage", ain, $"level={level}"), cancellationToken);
        return res?.ToInt();
    }

    public async Task<int?> SetColorAsync(string ain, int hue, int saturation, TimeSpan? duration = null, CancellationToken cancellationToken = default)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(hue, 0, nameof(hue));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(hue, 359, nameof(hue));
        if (hue < 0 || hue > 359)
        {
            throw new ArgumentOutOfRangeException(nameof(hue));
        }
        if (saturation < 0 || saturation > 255)
        {
            throw new ArgumentOutOfRangeException(nameof(saturation));
        }
        var res = await GetStringAsync(BuildUrl("setcolor", ain, $"hue={hue}&saturation={saturation}&duration={duration.ToDeciseconds()}"), cancellationToken);
        return res?.ToInt();
    }

    public async Task<int?> SetUnmappedColorAsync(string ain, int hue, int saturation, TimeSpan? duration = null, CancellationToken cancellationToken = default)
    {
        if (hue < 0 || hue > 359)
        {
            throw new ArgumentOutOfRangeException(nameof(hue));
        }
        if (saturation < 0 || saturation > 255)
        {
            throw new ArgumentOutOfRangeException(nameof(saturation));
        }
        var res = await GetStringAsync(BuildUrl("setunmappedcolor", ain, $"hue={hue}&saturation={saturation}&duration={duration.ToDeciseconds()}"), cancellationToken);
        return res?.ToInt();
    }

    public async Task<int?> SetColorTemperatureAsync(string ain, int temperature, TimeSpan? duration = null, CancellationToken cancellationToken = default)
    {
        if (temperature < 2700 || temperature > 6500)
        {
            throw new ArgumentOutOfRangeException(nameof(temperature));
        }
        var res = await GetStringAsync(BuildUrl("setcolortemperature", ain, $"temperature={temperature}&duration={duration.ToDeciseconds()}"), cancellationToken);
        return res.ToInt();
    }

    public async Task<int?> AddColorLevelTemplateAsync(string name, int levelPercentage, int hue, int saturation, IEnumerable<string> ains, bool colorpreset = false, CancellationToken cancellationToken = default)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(levelPercentage, 0, nameof(levelPercentage));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(levelPercentage, 1000, nameof(levelPercentage));
        if (hue < 0 || levelPercentage > 359)
        {
            throw new ArgumentOutOfRangeException(nameof(hue));
        }
        if (saturation < 0 || saturation > 255)
        {
            throw new ArgumentOutOfRangeException(nameof(saturation));
        }
        string ainlist = ains.Select((v, i) => $"child_{i + 1}={v}").Aggregate("", (a, b) => $"{a}&{b}");
        string req = $"webservices/homeautoswitch.lua?switchcmd=addcolorleveltemplate&sid={this.sessionId}&name={name}&levelPercentage={levelPercentage}&hue={hue}&saturation={saturation}&{ainlist}" + (colorpreset ? "&colorpreset=true" : "");
        var res = await GetStringAsync(req, cancellationToken);
        return res.ToInt();
    }

    public async Task<int?> AddColorLevelTemplateAsync(string name, int levelPercentage, int temperature, IEnumerable<string> ains, bool colorpreset = false, CancellationToken cancellationToken = default)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(levelPercentage, 0, nameof(levelPercentage));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(levelPercentage, 1000, nameof(levelPercentage));
        if (temperature < 2700 || temperature > 6500)
        {
            throw new ArgumentOutOfRangeException(nameof(temperature));
        }
        string ainlist = ains.Select((v, i) => $"child_{i + 1}={v}").Aggregate("", (a, b) => $"{a}&{b}");
        string req = $"webservices/homeautoswitch.lua?switchcmd=addcolorleveltemplate&sid={this.sessionId}&name={name}&levelPercentage={levelPercentage}&temperature={temperature}&{ainlist}" + (colorpreset ? "&colorpreset=true" : "");
        var res = await GetStringAsync(req, cancellationToken);
        return res?.ToInt();
    }

    public async Task<ColorDefaults?> GetColorDefaultsAsync(CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getcolordefaults"), cancellationToken);
        return res.XDeserialize<ColorDefaults>("colordefaults");
    }
        
    public async Task<XmlDocument?> GetColorDefaultsXmlAsync(CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getcolordefaults"), cancellationToken);
        return res?.ToXml();
    }

    public async Task<DateTime?> SetHkrBoostAsync(string ain, DateTime? endtimestamp = null, CancellationToken cancellationToken = default)
    {
        if (endtimestamp.HasValue && (endtimestamp < DateTime.Now || endtimestamp > DateTime.Now + new TimeSpan(24, 0, 0)))
        {
            throw new ArgumentOutOfRangeException(nameof(endtimestamp));
        }
        var res = await GetStringAsync(BuildUrl("sethkrboost", ain, $"endtimestamp={endtimestamp.ToUnixTime()}"), cancellationToken);
        return res?.ToNullableDateTime();
    }

    public async Task<DateTime?> SetHkrWindowOpenAsync(string ain, DateTime? endtimestamp = null, CancellationToken cancellationToken = default)
    {
        if (endtimestamp.HasValue && (endtimestamp < DateTime.Now || endtimestamp > DateTime.Now + new TimeSpan(24, 0, 0)))
        {
            throw new ArgumentOutOfRangeException(nameof(endtimestamp));
        }
        var res = await GetStringAsync(BuildUrl("sethkrwindowopen", ain, $"endtimestamp={endtimestamp.ToUnixTime()}"), cancellationToken);
        return res?.ToNullableDateTime();
    }

    
    public async Task<Target?> SetBlindAsync(string ain, Target target, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("setblind", ain, $"target={target.ToString().ToLower()}"), cancellationToken);
        return res?.ToTarget();
    }

    public async Task<string?> SetNameAsync(string ain, string name, CancellationToken cancellationToken)
    {
        if (name.Length > 40)
        {
            throw new ArgumentOutOfRangeException(nameof(name));
        }
        var res = await GetStringAsync(BuildUrl("setname", ain, $"name={name}"), cancellationToken);
        return res?.TrimEnd();
    }

    public async Task SetMetaDataAsync(string ain, MetaData metaData, CancellationToken cancellationToken)
    {
        string md = ""; // metaData.AsToJson();
        var res = await GetStringAsync(BuildUrl("setmetadata", ain, $"metadata={md}"), cancellationToken);
        //return res;
    }

    public async Task StartUleSubscriptionAsync(CancellationToken cancellationToken)
    {
        await GetStringAsync(BuildUrl("startulesubscription"), cancellationToken);
    }

    public async Task<SubscriptionState?> GetSubscriptionStateAsync(CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getsubscriptionstate"), cancellationToken);
        return res.XDeserialize<SubscriptionState>("state");
    }

    public async Task<XmlDocument?> GetSubscriptionStateXmlAsync(CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getsubscriptionstate"), cancellationToken);
        return res.ToXml();
    }

    public async Task<Device?> GetDeviceInfosAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getdeviceinfos", ain), cancellationToken);
        return res.XDeserialize<Device>("device");
    }

    public async Task<XmlDocument?> GetDeviceInfosXmlAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getdeviceinfos", ain), cancellationToken);
        return res.ToXml();
    }

    public void CreateBugReportFile()
    {
        string fileName = $"BugReport-{DateTime.Now:yyy-MM-dd-HH-mm-ss}.xml";
        using var file = File.CreateText(fileName);

        file.WriteLine("<Report>");
        file.WriteLine(this.client!.GetStringAsync(BuildUrl("getdevicelistinfos")).Result);
        file.WriteLine(this.client!.GetStringAsync(BuildUrl("gettemplatelistinfos")).Result);
        file.WriteLine(this.client!.GetStringAsync(BuildUrl("getcolordefaults")).Result);
        try
        {
            file.WriteLine(this.client!.GetStringAsync(BuildUrl("gettriggerlistinfos")).Result);
        }
        catch
        { }
        file.WriteLine("</Report>");

    }
}
