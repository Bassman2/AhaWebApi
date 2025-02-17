namespace AVMHomeAutomationTest;

public partial class UnitTestDect500Light : UnitTestBase
{
    #region Light

    [TestMethod]
    public async Task TestMethodGetColorDefaultsAsync()
    {
        ColorDefaults? colorDefaults;

        using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        {
            colorDefaults = await client.GetColorDefaultsAsync();
        }

        Assert.IsNotNull(colorDefaults);
        CollectionAssert.AreEquivalent(new int[] { 2700, 3000, 3400, 3800, 4200, 4700, 5300, 5900, 6500 }, colorDefaults.TemperatureDefaults?.Select((t) => t.Value).ToList());
    }

    [TestMethod]
    public async Task TestMethodSetSimpleOnOffAsync()
    {
        Device? device;

        using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        {
            await client.SetSimpleOnOffAsync(testDevice!.Ain, OnOff.On);
            Thread.Sleep(2000);
            device = await client.GetDeviceInfosAsync(testDevice!.Ain);
            await client.SetSimpleOnOffAsync(testDevice!.Ain, OnOff.Off);
            Thread.Sleep(2000);
            await client.SetSimpleOnOffAsync(testDevice!.Ain, OnOff.Toggle);
        }
    }

    [TestMethod]
    public async Task TestMethodSetLevelAsync()
    {
        Device? device;

        using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        {
            await client.SetLevelAsync(testDevice!.Ain, 50);
            Thread.Sleep(2000);
            await client.SetLevelAsync(testDevice!.Ain, 255);
            device = await client.GetDeviceInfosAsync(testDevice!.Ain);
        }
    }

    [TestMethod]
    public async Task TestMethodSetLevelPercentageAsync()
    {
        Device? device;

        using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        {
            await client.SetLevelPercentageAsync(testDevice!.Ain, 20);
            Thread.Sleep(2000);
            await client.SetLevelPercentageAsync(testDevice!.Ain, 100);
            device = await client.GetDeviceInfosAsync(testDevice!.Ain);
        }
    }

    [TestMethod]
    public async Task TestMethodSetColorAsync()
    {
        Device? device;

        using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        {
            await client.SetColorAsync(testDevice!.Ain, 212, 169);
            Thread.Sleep(2000);
            await client.SetLevelAsync(testDevice!.Ain, 255);
            device = await client.GetDeviceInfosAsync(testDevice!.Ain);

            await client.SetColorAsync(testDevice!.Ain, 358, 180);

        }
    }

    [TestMethod]
    public async Task TestMethodSetColorTemperatureAsync()
    {
        Device? device;

        using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        {
            await client.SetColorTemperatureAsync(testDevice!.Ain, 2800);
            Thread.Sleep(2000);
            device = await client.GetDeviceInfosAsync(testDevice!.Ain);
        }
    }

    #endregion
}
   
            