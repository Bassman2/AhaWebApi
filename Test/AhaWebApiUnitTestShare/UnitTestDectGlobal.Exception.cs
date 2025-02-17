namespace AVMHomeAutomationTest
{
    public partial class UnitTestDectGlobal
    {

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.BadRequest)]
        public async Task TestMethodSwitchNameErrorAsync()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.GetSwitchNameAsync(TestSettings.UnknownDeviceAin);
            }
        }

        // Exception with old Fritz!OS 
        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.BadRequest)]
        public async Task TestMethodSetMetaDataErrorAsync()
        {
            MetaData metaData = new MetaData() { Icon = 1, Type = TypeEnum.Generic };

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetMetaDataAsync(TestSettings.TemplateAin, metaData);
            }
        }
    }
}

