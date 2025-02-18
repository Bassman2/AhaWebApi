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

    /// <summary>
    /// Returns the AIN / MAC list of all known sockets.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<string[]?> GetSwitchListAsync(CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getswitchlist"), cancellationToken);
        return res!.SplitList();
    }

    /// <summary>
    /// Turns on the socket.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<bool?> SetSwitchOnAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("setswitchon", ain), cancellationToken);
        return res.ToBool();
    }

    /// <summary>
    /// Switches off the socket.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<bool?> SetSwitchOffAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("setswitchoff", ain), cancellationToken);
        return res.ToBool();
    }

    /// <summary>
    /// Toggle the power socket on / off.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<bool?> SetSwitchToggleAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("setswitchtoggle", ain), cancellationToken);
        return res.ToBool();
    }

    /// <summary>
    /// Determines the switching state of the socket.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <remarks>Changes if the connection is lost the condition only with some Minutes delay to false.</remarks>
    public async Task<bool?> GetSwitchStateAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getswitchstate", ain), cancellationToken);
        return res.ToBool();
    }

    /// <summary>
    /// Determines the connection status of the actuator.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<bool?> GetSwitchPresentAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getswitchpresent", ain), cancellationToken);
        return res.ToBool();
    }

    /// <summary>
    /// Determines current power taken from the power outlet.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<double?> GetSwitchPowerAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getswitchpower", ain), cancellationToken);
        return res.ToPower();
    }

    /// <summary>
    /// Delivers the amount of energy taken from the socket since commissioning or resetting the energy statistics.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<double?> GetSwitchEnergyAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getswitchenergy", ain), cancellationToken);
        return res.ToPower();
    }

    /// <summary>
    /// Returns identifiers of the actor.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<string?> GetSwitchNameAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getswitchname", ain), cancellationToken);
        return res?.TrimEnd();
    }

    /// <summary>
    /// Provides the basic information of all SmartHome devices.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<DeviceList?> GetDeviceListInfosAsync(CancellationToken cancellationToken)
    {
        var res = await this.client!.GetStringAsync(BuildUrl("getdevicelistinfos"), cancellationToken);
        return res.XDeserialize<DeviceList>("devicelist");
    }

    /// <summary>
    /// Provides the basic information of all SmartHome devices as XML.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<XmlDocument?> GetDeviceListInfosXmlAsync(CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getdevicelistinfos"), cancellationToken);
        return res.ToXml();
    }

    /// <summary>
    /// Last temperature information of the actuator.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<double?> GetTemperatureAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("gettemperature", ain), cancellationToken);
        return res.ToTemperature();
    }

    /// <summary>
    /// Setpoint temperature currently set for HKR.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<double> GetHkrtSollAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("gethkrtsoll", ain), cancellationToken);
        return res.ToHkrTemperature();
    }

    /// <summary>
    /// Comfort temperature set for HKR timer.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<double> GetHkrKomfortAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("gethkrkomfort", ain), cancellationToken);
        return res.ToHkrTemperature();
    }

    /// <summary>
    /// Economy temperature set for HKR timer.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<double> GetHkrAbsenkAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("gethkrabsenk", ain), cancellationToken);
        return res.ToHkrTemperature();
    }

    /// <summary>
    /// HKR set temperature. The setpoint temperature is transferred with the "param" Get parameter.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <param name="temperature">Temperature value °C (8°C - 28°C), On or Off.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<double> SetHkrtSollAsync(string ain, double temperature, CancellationToken cancellationToken)
    {
        if ((temperature < 8 || temperature > 28) && (temperature != On) && (temperature != Off))
        {
            throw new ArgumentOutOfRangeException(nameof(temperature));
        }
        var res = await GetStringAsync(BuildUrl("sethkrtsoll", ain, $"param={temperature.ToHkrTemperature()}"), cancellationToken);
        return res.ToHkrTemperature();
    }

    /// <summary>
    /// Provides the basic statistics (temperature, voltage, power) of the actuator.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<DeviceStats?> GetBasicDeviceStatsAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getbasicdevicestats", ain), cancellationToken);
        return res.XDeserialize<DeviceStats>("devicestats");
    }

    /// <summary>
    /// Provides the basic statistics (temperature, voltage, power) of the actuator as XML.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<XmlDocument?> GetBasicDeviceStatsXmlAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getbasicdevicestats", ain), cancellationToken);
        return res.ToXml();
    }

    /// <summary>
    /// Provides the basics information of all routines/triggers.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <remarks>Needs FRITZ!OS 7.39 or higher.</remarks>
    public async Task<TriggerList?> GetTriggerListInfosAsync(CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("gettriggerlistinfos"), cancellationToken);
        return res.XDeserialize<TriggerList>("triggerlist");
    }

    /// <summary>
    /// Provides the basics information of all routines/triggers as XML.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <remarks>Needs FRITZ!OS 7.39 or higher.</remarks>
    public async Task<XmlDocument?> GetTriggerListInfosXmlAsync(CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("gettriggerlistinfos"), cancellationToken);
        return res.ToXml();
    }

    /// <summary>
    /// Activate or deactivate trigger.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <param name="active">True to activate, false to deactivate.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <remarks>Needs FRITZ!OS 7.39 or higher.</remarks>
    public async Task<bool?> SetTriggerActiveAsync(string ain, bool active, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("settriggeractive", ain, $"active={(active ? "1" : "0")}"), cancellationToken);
        return res.ToBool();
    }

    /// <summary>
    /// Returns the basic information of all templates / templates.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<TemplateList?> GetTemplateListInfosAsync(CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("gettemplatelistinfos"), cancellationToken);
        return res.XDeserialize<TemplateList>("templatelist");
    }

    /// <summary>
    /// Returns the basic information of all templates / templates as XML.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<XmlDocument?> GetTemplateListInfosXmlAsync(CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("gettemplatelistinfos"), cancellationToken);
        return res.ToXml();
    }

    /// <summary>
    /// Apply template, the ain parameter is evaluated.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<int?> ApplyTemplateAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("applytemplate", ain), cancellationToken);
        return res.ToInt();
    }

    /// <summary>
    /// Device/actuator/lamp switch on/off or toggle. 
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <param name="onOff">Switch on, off or toggle.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<OnOff?> SetSimpleOnOffAsync(string ain, OnOff onOff, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("setsimpleonoff", ain, $"onoff={((int)onOff)}"), cancellationToken);
        return res.ToOnOff();
    }

    /// <summary>
    /// Set dimming, height, brightness or level.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <param name="level">Level (0 - 255) to set.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public async Task<int?> SetLevelAsync(string ain, int level, CancellationToken cancellationToken)
    {
        if (level < 0 || level > 255)
        {
            throw new ArgumentOutOfRangeException(nameof(level));
        }
        var res = await GetStringAsync(BuildUrl("setlevel", ain, $"level={level}"), cancellationToken);
        return res?.ToInt();
    }

    /// <summary>
    /// Set dimming, height, brightness or level level in percent.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <param name="level">Level in percent (0 - 100) to set.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public async Task<int?> SetLevelPercentageAsync(string ain, int level, CancellationToken cancellationToken)
    {
        if (level < 0 || level > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(level));
        }
        var res = await GetStringAsync(BuildUrl("setlevelpercentage", ain, $"level={level}"), cancellationToken);
        return res?.ToInt();
    }

    /// <summary>
    /// Adjust hue saturation color. The HSV color space is used with the hue saturation mode supports.
    /// Of the brightness (value) can be over setlevel/setlevelpercentage be configured, the hue and saturation values are here configurable.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <param name="hue">Hue value of the color.</param>
    /// <param name="saturation">Saturation value of the color.</param>
    /// <param name="duration">Speed of the change.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
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

    /// <summary>
    /// Adjust hue saturation color. 
    /// Of the brightness (value) can be over setlevel/setlevelpercentage be configured, the hue and saturation values are here configurable.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <param name="hue">Hue value of the color.</param>
    /// <param name="saturation">Saturation value of the color.</param>
    /// <param name="duration">Speed of the change.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
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

    /// <summary>
    /// Adjust color temperature.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <param name="temperature">Color temperature in °Kelvin (2700° bis 6500°)</param>
    /// <param name="duration">Speed of the change.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public async Task<int?> SetColorTemperatureAsync(string ain, int temperature, TimeSpan? duration = null, CancellationToken cancellationToken = default)
    {
        if (temperature < 2700 || temperature > 6500)
        {
            throw new ArgumentOutOfRangeException(nameof(temperature));
        }
        var res = await GetStringAsync(BuildUrl("setcolortemperature", ain, $"temperature={temperature}&duration={duration.ToDeciseconds()}"), cancellationToken);
        return res.ToInt();
    }

    /// <summary>
    /// Creates a color template for lamps.
    /// </summary>
    /// <param name="name">Name of the template to create.</param>
    /// <param name="levelPercentage">Level Percentage of the light.</param>
    /// <param name="hue">Hue value.</param>
    /// <param name="saturation">Saturation value.</param>
    /// <param name="ains">List of lamp devices.</param>
    /// <param name="colorpreset">User color preset or not.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">On of the argument are out of range.</exception>
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

    /// <summary>
    /// Creates a color template for lamps
    /// </summary>
    /// <param name="name">Name of the template to create.</param>
    /// <param name="levelPercentage">Level Percentage of the light.</param>
    /// <param name="temperature">Color temperature of the light.</param>
    /// <param name="ains">List of lamp devices.</param>
    /// <param name="colorpreset">>User color preset or not.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException">On of the argument are out of range.</exception>
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

    /// <summary>
    /// Provides a proposal for the color selection values.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<ColorDefaults?> GetColorDefaultsAsync(CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getcolordefaults"), cancellationToken);
        return res.XDeserialize<ColorDefaults>("colordefaults");
    }

    /// <summary>
    /// Provides a proposal for the color selection values as XML.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<XmlDocument?> GetColorDefaultsXmlAsync(CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getcolordefaults"), cancellationToken);
        return res?.ToXml();
    }

    /// <summary>
    /// Activate HKR Boost with end time for the disable: endtimestamp = null.
    /// The end time may not exceed to 24 hours in the future lie.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <param name="endtimestamp">End time to set.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public async Task<DateTime?> SetHkrBoostAsync(string ain, DateTime? endtimestamp = null, CancellationToken cancellationToken = default)
    {
        if (endtimestamp.HasValue && (endtimestamp < DateTime.Now || endtimestamp > DateTime.Now + new TimeSpan(24, 0, 0)))
        {
            throw new ArgumentOutOfRangeException(nameof(endtimestamp));
        }
        var res = await GetStringAsync(BuildUrl("sethkrboost", ain, $"endtimestamp={endtimestamp.ToUnixTime()}"), cancellationToken);
        return res?.ToNullableDateTime();
    }

    /// <summary>
    /// HKR window open mode activate with end time for the disable: endtimestamp = null.
    /// The end time may not exceed to 24 hours in the future lie.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <param name="endtimestamp">End time to set.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public async Task<DateTime?> SetHkrWindowOpenAsync(string ain, DateTime? endtimestamp = null, CancellationToken cancellationToken = default)
    {
        if (endtimestamp.HasValue && (endtimestamp < DateTime.Now || endtimestamp > DateTime.Now + new TimeSpan(24, 0, 0)))
        {
            throw new ArgumentOutOfRangeException(nameof(endtimestamp));
        }
        var res = await GetStringAsync(BuildUrl("sethkrwindowopen", ain, $"endtimestamp={endtimestamp.ToUnixTime()}"), cancellationToken);
        return res?.ToNullableDateTime();
    }

    /// <summary>
    /// Close, open or stop the blind.
    /// Blinds have the HANFUN unit type Blind (281).
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <param name="target">Target to set.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<Target?> SetBlindAsync(string ain, Target target, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("setblind", ain, $"target={target.ToString().ToLower()}"), cancellationToken);
        return res?.ToTarget();
    }

    /// <summary>
    /// Change device or group name.
    /// Attention: the user session must have the smart home and app right.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <param name="name">New name, maximum 40 characters.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <remarks>Requires the "Restricted FRITZ!Box settings for apps" permission.</remarks>
    public async Task<string?> SetNameAsync(string ain, string name, CancellationToken cancellationToken)
    {
        if (name.Length > 40)
        {
            throw new ArgumentOutOfRangeException(nameof(name));
        }
        var res = await GetStringAsync(BuildUrl("setname", ain, $"name={name}"), cancellationToken);
        return res?.TrimEnd();
    }

    /// <summary>
    /// json metadata of the template or change/set empty string
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <param name="metaData">Metadata to set.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public async Task SetMetaDataAsync(string ain, MetaData metaData, CancellationToken cancellationToken)
    {
        string md = ""; // metaData.AsToJson();
        var res = await GetStringAsync(BuildUrl("setmetadata", ain, $"metadata={md}"), cancellationToken);
        //return res;
    }

    /// <summary>
    /// Start DECT ULE device registration.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <remarks>Requires the "Restricted FRITZ!Box settings for apps" permission.</remarks>
    public async Task StartUleSubscriptionAsync(CancellationToken cancellationToken)
    {
        await GetStringAsync(BuildUrl("startulesubscription"), cancellationToken);
    }

    /// <summary>
    /// Query DECT-ULE device registration status.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <remarks>Requires the "Restricted FRITZ!Box settings for apps" permission.</remarks>
    public async Task<SubscriptionState?> GetSubscriptionStateAsync(CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getsubscriptionstate"), cancellationToken);
        return res.XDeserialize<SubscriptionState>("state");
    }

    /// <summary>
    /// Query DECT-ULE device registration status as XML.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <remarks>Requires the "Restricted FRITZ!Box settings for apps" permission.</remarks>
    public async Task<XmlDocument?> GetSubscriptionStateXmlAsync(CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getsubscriptionstate"), cancellationToken);
        return res.ToXml();
    }

    /// <summary>
    /// Provides the basic information of one SmartHome devices.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<Device?> GetDeviceInfosAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getdeviceinfos", ain), cancellationToken);
        return res.XDeserialize<Device>("device");
    }

    /// <summary>
    /// Provides the basic information of one SmartHome devices.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<XmlDocument?> GetDeviceInfosXmlAsync(string ain, CancellationToken cancellationToken)
    {
        var res = await GetStringAsync(BuildUrl("getdeviceinfos", ain), cancellationToken);
        return res.ToXml();
    }

    /// <summary>
    /// Create a bug report file.
    /// </summary>
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
