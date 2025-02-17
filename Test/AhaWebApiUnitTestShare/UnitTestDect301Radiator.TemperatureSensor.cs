namespace AVMHomeAutomationTest;

public partial class UnitTestDect301Radiator : UnitTestBase
{
    #region Temperature Sensor

    [TestMethod]
    public async Task TestMethodTemperatureAsync()
    {
        Device? deviceInfos;
        double? temperature;

        using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        {
            deviceInfos = await client.GetDeviceInfosAsync(testDevice!.Ain);
            temperature = await client.GetTemperatureAsync(testDevice!.Ain);
        }

        Assert.IsTrue(temperature > 14.0 && temperature < 25.0, "Range");
        Assert.IsNotNull(deviceInfos, "deviceInfo");
        Assert.IsNotNull(deviceInfos.Temperature, "Temperature");
        Assert.AreEqual(deviceInfos.Temperature.Celsius, temperature, "Compare");
    }

    #endregion
}
   
            