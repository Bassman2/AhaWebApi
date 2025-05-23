namespace AhaWebApi;

/// <summary>
/// AVM Home Automation service class.
/// </summary>
public sealed class HomeAutomation(string login, string password, Uri? host = null) : IDisposable
{
    private HomeAutomationService? service = new(login, password, host);

    /// <summary>
    /// Releases all resources used by the <see cref="HomeAutomation"/> instance.
    /// </summary>
    /// <remarks>
    /// This method disposes the underlying <see cref="HomeAutomationService"/> and suppresses finalization.
    /// </remarks>
    public void Dispose()
    {
        if (this.service != null)
        {
            this.service.Dispose();
            this.service = null;
        }
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Special value for setting a device or actuator to "On" state (e.g., for switches or thermostats).
    /// </summary>
    public const int On = 254;

    /// <summary>
    /// Special value for setting a device or actuator to "Off" state (e.g., for switches or thermostats).
    /// </summary>
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
    /// Turns on the specified power socket or actuator.
    /// </summary>
    /// <param name="ain">Identification of the actor or template (AIN/MAC).</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is <c>true</c> if the socket was successfully turned on, <c>false</c> if the operation failed, or <c>null</c> if the state is unknown.
    /// </returns>
    public async Task<bool?> SetSwitchOnAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.SetSwitchOnAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Turns off the specified power socket or actuator.
    /// </summary>
    /// <param name="ain">Identification of the actor or template (AIN/MAC).</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is <c>true</c> if the socket was successfully turned off, <c>false</c> if the operation failed, or <c>null</c> if the state is unknown.
    /// </returns>
    public async Task<bool?> SetSwitchOffAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.SetSwitchOffAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Toggles the state of the specified power socket or actuator.
    /// </summary>
    /// <param name="ain">Identification of the actor or template (AIN/MAC).</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is <c>true</c> if the socket was successfully toggled, <c>false</c> if the operation failed, or <c>null</c> if the state is unknown.
    /// </returns>
    public async Task<bool?> SetSwitchToggleAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.SetSwitchToggleAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Determines the current switching state of the specified power socket or actuator.
    /// </summary>
    /// <param name="ain">Identification of the actor or template (AIN/MAC).</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is <c>true</c> if the socket is on, <c>false</c> if it is off, or <c>null</c> if the state is unknown.
    /// </returns>
    /// <remarks>
    /// If the connection is lost, the state may only change to <c>false</c> after a delay of several minutes.
    /// </remarks>
    public async Task<bool?> GetSwitchStateAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetSwitchStateAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Determines whether the specified power socket or actuator is currently connected (present).
    /// </summary>
    /// <param name="ain">Identification of the actor or template (AIN/MAC).</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is <c>true</c> if the device is present, <c>false</c> if not, or <c>null</c> if the state is unknown.
    /// </returns>
    public async Task<bool?> GetSwitchPresentAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetSwitchPresentAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Determines the current power consumption (in watts) of the specified power socket or actuator.
    /// </summary>
    /// <param name="ain">Identification of the actor or template (AIN/MAC).</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is the current power in watts, or <c>null</c> if the value is unavailable.
    /// </returns>
    public async Task<double?> GetSwitchPowerAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetSwitchPowerAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Retrieves the total energy consumption (in watt-hours) measured by the specified power socket or actuator since commissioning or the last reset of energy statistics.
    /// </summary>
    /// <param name="ain">Identification of the actor or template (AIN/MAC).</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is the total energy consumption in watt-hours, or <c>null</c> if the value is unavailable.
    /// </returns>
    public async Task<double?> GetSwitchEnergyAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetSwitchEnergyAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Retrieves the name of the specified power socket or actuator.
    /// </summary>
    /// <param name="ain">Identification of the actor or template (AIN/MAC).</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is the name of the device, or <c>null</c> if the name is unavailable.
    /// </returns>
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
    /// Retrieves the latest measured temperature (in degrees Celsius) from the specified actuator or sensor.
    /// </summary>
    /// <param name="ain">Identification of the actor or template (AIN/MAC).</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is the current temperature in degrees Celsius, or <c>null</c> if the value is unavailable.
    /// </returns>
    public async Task<double?> GetTemperatureAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetTemperatureAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Retrieves the setpoint temperature currently configured for the specified radiator regulator (HKR).
    /// </summary>
    /// <param name="ain">Identification of the actuator or template (AIN/MAC).</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is the setpoint temperature in degrees Celsius.
    /// </returns>
    public async Task<double> GetHkrtSollAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetHkrtSollAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Retrieves the comfort temperature configured for the specified radiator regulator (HKR) timer.
    /// </summary>
    /// <param name="ain">Identification of the actuator or template (AIN/MAC).</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is the comfort temperature in degrees Celsius.
    /// </returns>
    public async Task<double> GetHkrKomfortAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetHkrKomfortAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Retrieves the economy (lowering) temperature configured for the specified radiator regulator (HKR) timer.
    /// </summary>
    /// <param name="ain">Identification of the actuator or template (AIN/MAC).</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is the economy temperature in degrees Celsius.
    /// </returns>
    public async Task<double> GetHkrAbsenkAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetHkrAbsenkAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Sets the setpoint temperature for the specified radiator regulator (HKR).
    /// </summary>
    /// <param name="ain">Identification of the actuator or template (AIN/MAC).</param>
    /// <param name="temperature">
    /// Temperature value in degrees Celsius (8°C - 28°C), or use <see cref="On"/>/<see cref="Off"/> for special states.
    /// </param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is the setpoint temperature in degrees Celsius after the operation.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if <paramref name="temperature"/> is not within the valid range (8–28), and is not <see cref="On"/> or <see cref="Off"/>.
    /// </exception>
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
    /// Retrieves the basic statistics (such as temperature, voltage, and power) for the specified actuator or device.
    /// </summary>
    /// <param name="ain">Identification of the actor or template (AIN/MAC).</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is a <see cref="DeviceStats"/> object containing the basic statistics, or <c>null</c> if the data is unavailable.
    /// </returns>
    public async Task<DeviceStats?> GetBasicDeviceStatsAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetBasicDeviceStatsAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Retrieves the basic statistics (such as temperature, voltage, and power) for the specified actuator or device as an XML document.
    /// </summary>
    /// <param name="ain">Identification of the actor or template (AIN/MAC).</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is an <see cref="XmlDocument"/> containing the basic statistics, or <c>null</c> if the data is unavailable.
    /// </returns>
    public async Task<XmlDocument?> GetBasicDeviceStatsXmlAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetBasicDeviceStatsXmlAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Retrieves the basic information of all routines and triggers available in the Smart Home system.
    /// </summary>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is a <see cref="TriggerList"/> containing the routines and triggers information, or <c>null</c> if the data is unavailable.
    /// </returns>
    /// <remarks>Requires FRITZ!OS 7.39 or higher.</remarks>
    public async Task<TriggerList?> GetTriggerListInfosAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetTriggerListInfosAsync(cancellationToken);
    }

    /// <summary>
    /// Retrieves the basic information of all routines and triggers available in the Smart Home system as an XML document.
    /// </summary>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is an <see cref="XmlDocument"/> containing the routines and triggers information, or <c>null</c> if the data is unavailable.
    /// </returns>
    /// <remarks>Requires FRITZ!OS 7.39 or higher.</remarks>
    public async Task<XmlDocument?> GetTriggerListInfosXmlAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.GetTriggerListInfosXmlAsync(cancellationToken);
    }

    /// <summary>
    /// Activates or deactivates the specified trigger in the Smart Home system.
    /// </summary>
    /// <param name="ain">Identification of the actor or template (AIN/MAC).</param>
    /// <param name="active">Set to <c>true</c> to activate the trigger, or <c>false</c> to deactivate it.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is <c>true</c> if the trigger was successfully updated, <c>false</c> if the operation failed, or <c>null</c> if the state is unknown.
    /// </returns>
    /// <remarks>Requires FRITZ!OS 7.39 or higher.</remarks>
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
    /// Applies the specified template to the associated device or group.
    /// </summary>
    /// <param name="ain">Identification of the actor or template (AIN/MAC).</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is an integer indicating the result of the operation, or <c>null</c> if the operation failed.
    /// </returns>
    public async Task<int?> ApplyTemplateAsync(string ain, CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(this.service);

        return await service!.ApplyTemplateAsync(ain, cancellationToken);
    }

    /// <summary>
    /// Switches a device, actuator, or lamp on, off, or toggles its state.
    /// </summary>
    /// <param name="ain">Identification of the actor or template (AIN/MAC).</param>
    /// <param name="onOff">
    /// The desired state to set:
    /// <list type="bullet">
    /// <item><description><see cref="OnOff.On"/> to switch on</description></item>
    /// <item><description><see cref="OnOff.Off"/> to switch off</description></item>
    /// <item><description><see cref="OnOff.Toggle"/> to toggle the current state</description></item>
    /// </list>
    /// </param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is the new state (<see cref="OnOff"/>) after the operation, or <c>null</c> if the state is unknown.
    /// </returns>
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
    /// Adjusts the hue and saturation color of a lamp or actuator using the HSV color space.
    /// The brightness (value) can be configured separately using <see cref="SetLevelAsync"/> or <see cref="SetLevelPercentageAsync"/>.
    /// This method allows you to set the hue and saturation values directly.
    /// </summary>
    /// <param name="ain">Identification of the actor or template (AIN/MAC).</param>
    /// <param name="hue">Hue value of the color (0–359).</param>
    /// <param name="saturation">Saturation value of the color (0–255).</param>
    /// <param name="duration">Optional. The speed of the color change as a <see cref="TimeSpan"/>. If <c>null</c>, the default speed is used.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is an integer indicating the result of the operation, or <c>null</c> if the operation failed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if <paramref name="hue"/> is not in the range 0–359, or <paramref name="saturation"/> is not in the range 0–255.
    /// </exception>
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
    /// Creates a color template for lamps with specified brightness and color settings.
    /// </summary>
    /// <param name="name">The name of the template to create.</param>
    /// <param name="levelPercentage">The brightness level percentage of the light (0–1000).</param>
    /// <param name="hue">The hue value of the color (0–359).</param>
    /// <param name="saturation">The saturation value of the color (0–255).</param>
    /// <param name="ains">A collection of lamp device identifiers (AIN/MAC) to which the template will be applied.</param>
    /// <param name="colorpreset">Set to <c>true</c> to mark as a user color preset; otherwise, <c>false</c>.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result is an integer indicating the result of the operation, or <c>null</c> if the operation failed.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if <paramref name="levelPercentage"/> is not in the range 0–1000,
    /// <paramref name="hue"/> is not in the range 0–359,
    /// or <paramref name="saturation"/> is not in the range 0–255.
    /// </exception>
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
