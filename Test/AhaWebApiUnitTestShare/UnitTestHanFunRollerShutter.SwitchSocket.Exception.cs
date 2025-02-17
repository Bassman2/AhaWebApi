using System.Net;

namespace AVMHomeAutomationTest
{
    public partial class UnitTestHanFunRollerShutter : UnitTestBase
    {
        #region Switch Socket

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetSwitchOnAsyncError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetSwitchOnAsync(testDevice!.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetSwitchOffAsyncError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetSwitchOffAsync(testDevice!.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetSwitchToggleAsyncError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetSwitchToggleAsync(testDevice!.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodGetSwitchStateAsyncError()
        {
            bool? val;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                val = await client.GetSwitchStateAsync(testDevice!.Ain);
            }

            Assert.IsTrue(val);
        }

        #endregion
    }
}       
                