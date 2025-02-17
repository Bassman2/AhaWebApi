namespace AVMHomeAutomationTest;

public class UnitTestBase
{
    protected TestDevice? testDevice;

    protected static void Sleep()
    {
        Thread.Sleep(1000);
    }

    [TestMethod]
    public async Task TestMethodGetDeviceInfosAsync()
    {
        // Arrange
        Device? device;

        // Act
        using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        {
            device = await client.GetDeviceInfosAsync(testDevice!.Ain);
        }

        // Assert
        Assert.AreEqual(testDevice!.Ain, device?.Identifier, "Identifier");
        Assert.AreEqual(testDevice.Name, device?.Name, "Name");
        Assert.AreEqual(testDevice.Product, device?.ProductName, "ProductName");
        Assert.AreEqual(testDevice.Manufacturer, device?.Manufacturer, "Manufacturer");
        Assert.AreEqual(testDevice.FirmwareVersion, device?.FirmwareVersion, "FirmwareVersion");
    }

    [TestMethod]
    public async Task TestMethodGetNameAsync()
    {
        // Arrange
        string? name;

        // Act
        using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        {
            name = await client.GetSwitchNameAsync(testDevice!.Ain);
        }

        // Assert
        Assert.AreEqual(testDevice.Name, name);
    }

    [TestMethod]
    public async Task TestMethodPresentAsync()
    {
        // Arrange
        bool? isPresent;

        // Act
        using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        {
            isPresent = await client.GetSwitchPresentAsync(testDevice!.Ain);
        }

        // Assert
        Assert.IsTrue(isPresent);
    }
}
