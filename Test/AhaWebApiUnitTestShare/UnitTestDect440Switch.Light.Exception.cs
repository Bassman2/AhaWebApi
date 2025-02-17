namespace AVMHomeAutomationTest
{
    public partial class UnitTestDect440Switch : UnitTestBase
    {
        #region Light

        [TestMethod]
        //[ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetSimpleOnOffErrorAsync()
        {
            OnOff? onOff;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                onOff = await client.SetSimpleOnOffAsync(testDevice!.Ain, OnOff.On);
            }

            Assert.AreEqual(OnOff.On, onOff);
        }

        [TestMethod]
        //[ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetLevelErrorAsync()
        {
            int? level;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                level = await client.SetLevelAsync(testDevice!.Ain, 200);
            }

            Assert.AreEqual(200, level);
        }

        [TestMethod]
        //[ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetLevelPercentageErrorAsync()
        {
            int? percent;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                percent = await client.SetLevelPercentageAsync(testDevice!.Ain, 70);
            }

            Assert.AreEqual(70, percent);
        }

        [TestMethod]
        //[ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetColorErrorAsync()
        {
            int? hue;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                hue = await client.SetColorAsync(testDevice!.Ain, 200, 210);
            }

            Assert.AreEqual(200, hue);
        }

        [TestMethod]
        //[ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetUnmappedColorErrorAsync()
        {
            int? hue;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                hue = await client.SetUnmappedColorAsync(testDevice!.Ain, 200, 200);
            }

            Assert.AreEqual(200, hue);
        }

        [TestMethod]
        //[ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetColorTemperatureErrorAsync()
        {
            int? temp;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temp = await client.SetColorTemperatureAsync(testDevice!.Ain, 5000);
            }

            Assert.AreEqual(5000, temp);
        }

        #endregion
    }
}       
                