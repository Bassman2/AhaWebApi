namespace AVMHomeAutomationTest;

public partial class UnitTestDectGlobal
{

    [TestMethod]
    [ExpectedHttpRequestException(HttpStatusCode.BadRequest)]
    public async Task TestMethodGetTriggerListInfosAsync()
    {
        TriggerList? triggerList;

        using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        {
            triggerList = await client.GetTriggerListInfosAsync();
        }

        Assert.IsNotNull(triggerList);
    }

    [TestMethod]
    [ExpectedHttpRequestException(HttpStatusCode.BadRequest)]
    public async Task TestMethodSetTriggerActiveAsync()
    {
        using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
        {
            await client.SetTriggerActiveAsync(TestSettings.TriggerAin, true);
        }
    }
}

