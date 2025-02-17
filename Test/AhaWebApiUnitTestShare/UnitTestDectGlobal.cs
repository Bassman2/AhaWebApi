namespace AVMHomeAutomationTest;

[TestClass]
public partial class UnitTestDectGlobal
{
    [TestMethod]
    public async Task TestMethodGetDeviceListInfosAsync()
    {
        DeviceList? deviceList;

        using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        {
            deviceList = await client.GetDeviceListInfosAsync();
        }

        Assert.IsNotNull(deviceList);
        AssertDevice(TestSettings.DeviceDect100Repeater, deviceList.DevicesList!.Single((d) => d.Identifier == TestSettings.DeviceDect100Repeater.Ain));
    }

    private static void AssertDevice(TestDevice expected, Device actual)
    {
        Assert.AreEqual(expected.Ain, actual.Identifier);
        Assert.AreEqual(expected.Name, actual.Name);
        Assert.AreEqual(expected.Product, actual.ProductName);
        Assert.AreEqual(expected.Manufacturer, actual.Manufacturer);
        Assert.AreEqual(expected.FirmwareVersion, actual.FirmwareVersion);
    }

    [TestMethod]
    public async Task TestMethodSubscriptionAsync()
    {
        SubscriptionState? runState;

        using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        {
            await client.StartUleSubscriptionAsync();
            do
            {
                Thread.Sleep(30000);
                runState = await client.GetSubscriptionStateAsync();
            } while (runState?.Code == SubscriptionCode.SubscriptionRunning);
        }

        Assert.AreEqual(SubscriptionCode.Timeout, runState?.Code);
    }

    [TestMethod]
    public async Task TestMethodChangeNameAsync()
    {
        TestDevice testDevice = TestSettings.DeviceDect400Switch;
        string? orgName, testName, resName;

        using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        {
            orgName = await client.GetSwitchNameAsync(testDevice!.Ain);
            await client.SetNameAsync(testDevice!.Ain, "Dummy");
            testName = await client.GetSwitchNameAsync(testDevice!.Ain);
            await client.SetNameAsync(testDevice!.Ain, orgName!);
            resName = await client.GetSwitchNameAsync(testDevice!.Ain);
        }

        Assert.AreEqual(testDevice.Name, orgName);
        Assert.AreEqual("Dummy", testName);
        Assert.AreEqual(testDevice.Name, resName);
    }

    [TestMethod]
    public async Task TestMethodGetSwitchListAsync()
    {
        string[]? devices;

        using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        {
            devices = await client.GetSwitchListAsync();
        }

        Assert.IsNotNull(devices);
        CollectionAssert.AreEquivalent(new string[] { "087610500005", "116300323828", "116570143095", "grp280D89-3E4209CD1" }, devices);
    }

    [TestMethod]
    public async Task TestMethodGetTemplateListInfosAsync()
    {
        TemplateList? templateList;
        
        using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        {
            templateList = await client.GetTemplateListInfosAsync();
        }

        Assert.IsNotNull(templateList);
        //CollectionAssert.AreEquivalent(new string[] { "087610500005", "116300323828", "116570143095", "grp280D89-3E4209CD1" }, devices);
    }

    [TestMethod]
    public async Task TestMethodApplyTemplateAsync()
    {
        //TemplateList templateList;

        using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        {
            await client.ApplyTemplateAsync(TestSettings.TemplateAin);
        }

        //Assert.IsNotNull(templateList);
        //CollectionAssert.AreEquivalent(new string[] { "087610500005", "116300323828", "116570143095", "grp280D89-3E4209CD1" }, devices);
    }
}

