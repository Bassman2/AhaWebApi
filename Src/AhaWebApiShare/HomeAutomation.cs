namespace AVMHomeAutomation;

/// <summary>
/// AVM Home Automation service class.
/// </summary>
public sealed class HomeAutomation(string login, string password, Uri? host = null) : IDisposable
{
    private HomeAutomationService? service = new(login, password, host);

    public void Dispose()
    {
        if (this.service != null)
        {
            this.service.Dispose();
            this.service = null;
        }
        GC.SuppressFinalize(this);
    }

    public const int On = 254;
    public const int Off = 253;

    #region Public Methods

    /// <summary>
    /// Returns the AIN / MAC list of all known sockets.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<string[]?> GetSwitchListAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetSwitchListAsync(cancellationToken);
    }
    
    /// <summary>
    /// Turns on the socket.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<bool?> SetSwitchOnAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.SetSwitchOnAsync(ain, cancellationToken);
    }
    
    /// <summary>
    /// Switches off the socket.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<bool?> SetSwitchOffAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.SetSwitchOffAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Toggle the power socket on / off.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<bool?> SetSwitchToggleAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.SetSwitchToggleAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Determines the switching state of the socket.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <remarks>Changes if the connection is lost the condition only with some Minutes delay to false.</remarks>
    public async Task<bool?> GetSwitchStateAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetSwitchStateAsync(ain, cancellationToken);
    }
    
    /// <summary>
    /// Determines the connection status of the actuator.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<bool?> GetSwitchPresentAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetSwitchPresentAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Determines current power taken from the power outlet.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<double?> GetSwitchPowerAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetSwitchPowerAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Delivers the amount of energy taken from the socket since commissioning or resetting the energy statistics.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<double?> GetSwitchEnergyAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetSwitchEnergyAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Returns identifiers of the actor.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<string?> GetSwitchNameAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetSwitchNameAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Provides the basic information of all SmartHome devices.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<DeviceList?> GetDeviceListInfosAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        var res = await service!.GetDeviceListInfosAsync(cancellationToken);
        return res;
    }

    /// <summary>
    /// Provides the basic information of all SmartHome devices as XML.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<XmlDocument?> GetDeviceListInfosXmlAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetDeviceListInfosXmlAsync(cancellationToken);
    }

    /// <summary>
    /// Last temperature information of the actuator.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<double?> GetTemperatureAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetTemperatureAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Setpoint temperature currently set for HKR.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<double> GetHkrtSollAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetHkrtSollAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Comfort temperature set for HKR timer.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<double> GetHkrKomfortAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetHkrKomfortAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Economy temperature set for HKR timer.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<double> GetHkrAbsenkAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetHkrAbsenkAsync(ain, cancellationToken);
    }

    /// <summary>
    /// HKR set temperature. The setpoint temperature is transferred with the "param" Get parameter.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <param name="temperature">Temperature value °C (8°C - 28°C), On or Off.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<double> SetHkrtSollAsync(string ain, double temperature, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        if ((temperature < 8 || temperature > 28) && (temperature != On) && (temperature != Off))
        {
            throw new ArgumentOutOfRangeException(nameof(temperature));
        }
        return await service!.SetHkrtSollAsync(ain, temperature, cancellationToken);
    }

    /// <summary>
    /// Provides the basic statistics (temperature, voltage, power) of the actuator.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<DeviceStats?> GetBasicDeviceStatsAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetBasicDeviceStatsAsync(ain, cancellationToken);
    }
    
    /// <summary>
    /// Provides the basic statistics (temperature, voltage, power) of the actuator as XML.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<XmlDocument?> GetBasicDeviceStatsXmlAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetBasicDeviceStatsXmlAsync(ain, cancellationToken);
    }
    
    /// <summary>
    /// Provides the basics information of all routines/triggers.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <remarks>Needs FRITZ!OS 7.39 or higher.</remarks>
    public async Task<TriggerList?> GetTriggerListInfosAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetTriggerListInfosAsync(cancellationToken);
    }
    
    /// <summary>
    /// Provides the basics information of all routines/triggers as XML.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <remarks>Needs FRITZ!OS 7.39 or higher.</remarks>
    public async Task<XmlDocument?> GetTriggerListInfosXmlAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetTriggerListInfosXmlAsync(cancellationToken);
    }

    /// <summary>
    /// Activate or deactivate trigger.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <param name="active">True to activate, false to deactivate.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <remarks>Needs FRITZ!OS 7.39 or higher.</remarks>
    public async Task<bool?> SetTriggerActiveAsync(string ain, bool active, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.SetTriggerActiveAsync(ain, active, cancellationToken);
    }

    /// <summary>
    /// Returns the basic information of all templates / templates.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<TemplateList?> GetTemplateListInfosAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetTemplateListInfosAsync(cancellationToken);
    }

    /// <summary>
    /// Returns the basic information of all templates / templates as XML.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<XmlDocument?> GetTemplateListInfosXmlAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetTemplateListInfosXmlAsync(cancellationToken);
    }

    /// <summary>
    /// Apply template, the ain parameter is evaluated.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<int?> ApplyTemplateAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.ApplyTemplateAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Device/actuator/lamp switch on/off or toggle. 
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <param name="onOff">Switch on, off or toggle.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<OnOff?> SetSimpleOnOffAsync(string ain, OnOff onOff, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.SetSimpleOnOffAsync(ain, onOff, cancellationToken);
    }

    /// <summary>
    /// Set dimming, height, brightness or level.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <param name="level">Level (0 - 255) to set.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public async Task<int?> SetLevelAsync(string ain, int level, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThan(level, 0, nameof(level));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(level, 255, nameof(level));

        return await service!.SetLevelAsync(ain, level, cancellationToken);
    }

    /// <summary>
    /// Set dimming, height, brightness or level level in percent.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <param name="level">Level in percent (0 - 100) to set.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public async Task<int?> SetLevelPercentageAsync(string ain, int level, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThan(level, 0, nameof(level));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(level, 100, nameof(level));

        return await service!.SetLevelPercentageAsync(ain, level, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThan(hue, 0, nameof(hue));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(hue, 359, nameof(hue));
        ArgumentOutOfRangeException.ThrowIfLessThan(saturation, 0, nameof(saturation));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(saturation, 255, nameof(saturation));
        
        return await service!.SetColorAsync(ain, hue, saturation, duration, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThan(hue, 0, nameof(hue));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(hue, 359, nameof(hue));
        ArgumentOutOfRangeException.ThrowIfLessThan(saturation, 0, nameof(saturation));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(saturation, 255, nameof(saturation));

        return await service!.SetUnmappedColorAsync(ain, hue, saturation, duration, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThan(temperature, 2700, nameof(temperature));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(temperature, 6500, nameof(temperature));
                
        return await service!.SetColorTemperatureAsync(ain, temperature, duration, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThan(levelPercentage, 0, nameof(levelPercentage));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(levelPercentage, 1000, nameof(levelPercentage));
        ArgumentOutOfRangeException.ThrowIfLessThan(hue, 0, nameof(hue));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(hue, 359, nameof(hue));
        ArgumentOutOfRangeException.ThrowIfLessThan(saturation, 0, nameof(saturation));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(saturation, 255, nameof(saturation));

        return await service!.AddColorLevelTemplateAsync(name, levelPercentage, hue, saturation, ains, colorpreset, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfLessThan(levelPercentage, 0, nameof(levelPercentage));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(levelPercentage, 1000, nameof(levelPercentage));
        ArgumentOutOfRangeException.ThrowIfLessThan(temperature, 2700, nameof(temperature));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(temperature, 6500, nameof(temperature));

        return await service!.AddColorLevelTemplateAsync(name, levelPercentage, temperature, ains, colorpreset, cancellationToken);
    }

    /// <summary>
    /// Provides a proposal for the color selection values.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<ColorDefaults?> GetColorDefaultsAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetColorDefaultsAsync(cancellationToken);
    }

    /// <summary>
    /// Provides a proposal for the color selection values as XML.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<XmlDocument?> GetColorDefaultsXmlAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetColorDefaultsXmlAsync( cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        if (endtimestamp.HasValue && (endtimestamp < DateTime.Now || endtimestamp > DateTime.Now + new TimeSpan(24, 0, 0)))
        {
            throw new ArgumentOutOfRangeException(nameof(endtimestamp));
        }
        return await service!.SetHkrBoostAsync(ain, endtimestamp, cancellationToken);
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
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        if (endtimestamp.HasValue && (endtimestamp < DateTime.Now || endtimestamp > DateTime.Now + new TimeSpan(24, 0, 0)))
        {
            throw new ArgumentOutOfRangeException(nameof(endtimestamp));
        }
        return await service!.SetHkrWindowOpenAsync(ain, endtimestamp, cancellationToken);
    }

    /// <summary>
    /// Close, open or stop the blind.
    /// Blinds have the HANFUN unit type Blind (281).
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <param name="target">Target to set.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<Target?> SetBlindAsync(string ain, Target target, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.SetBlindAsync(ain, target, cancellationToken);
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
    public async Task<string?> SetNameAsync(string ain, string name, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(name.Length, 40, nameof(name));

        var res = await service!.SetNameAsync(ain, name, cancellationToken);
        return res;
    }
    
    /// <summary>
    /// json metadata of the template or change/set empty string
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <param name="metaData">Metadata to set.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <remarks>New in Fritz!OS 7.39</remarks>
    public async Task SetMetaDataAsync(string ain, MetaData metaData, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        await service!.SetMetaDataAsync(ain, metaData, cancellationToken);
    }

    /// <summary>
    /// Start DECT ULE device registration.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <remarks>Requires the "Restricted FRITZ!Box settings for apps" permission.</remarks>
    public async Task StartUleSubscriptionAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        await service!.StartUleSubscriptionAsync(cancellationToken);
    }

    /// <summary>
    /// Query DECT-ULE device registration status.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <remarks>Requires the "Restricted FRITZ!Box settings for apps" permission.</remarks>
    public async Task<SubscriptionState?> GetSubscriptionStateAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetSubscriptionStateAsync(cancellationToken);
    }

    /// <summary>
    /// Query DECT-ULE device registration status as XML.
    /// </summary>
    /// <returns>The task object representing the asynchronous operation.</returns>
    /// <remarks>Requires the "Restricted FRITZ!Box settings for apps" permission.</remarks>
    public async Task<XmlDocument?> GetSubscriptionStateXmlAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetSubscriptionStateXmlAsync(cancellationToken);
    }

    /// <summary>
    /// Provides the basic information of one SmartHome devices.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<Device?> GetDeviceInfosAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetDeviceInfosAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Provides the basic information of one SmartHome devices.
    /// </summary>
    /// <param name="ain">Identification of the actor or template.</param>
    /// <returns>The task object representing the asynchronous operation.</returns>
    public async Task<XmlDocument?> GetDeviceInfosXmlAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetDeviceInfosXmlAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Create a bug report file.
    /// </summary>
    public void CreateBugReportFile()
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);
        
        service!.CreateBugReportFile();
    }
            
    #endregion
}
