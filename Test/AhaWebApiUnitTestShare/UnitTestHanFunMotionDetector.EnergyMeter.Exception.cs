
using System.Net;

namespace AVMHomeAutomationTest
{
    public partial class UnitTestHanFunMotionDetector : UnitTestBase
    {
        #region Energy Meter

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodEnergyErrorAsync()
        {
            double? energy;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                energy = await client.GetSwitchEnergyAsync(testDevice!.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodPowerErrorAsync()
        {
            double? power;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                power = await client.GetSwitchPowerAsync(testDevice!.Ain);
            }
        }

        #endregion
    }
}