using System.Net;

namespace AVMHomeAutomationTest
{
    public partial class UnitTestHanFunRollerShutter : UnitTestBase
    {
        #region Temperature Sensor

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodTemperatureErrorAsync()
        {
            double? temperature;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temperature = await client.GetTemperatureAsync(testDevice!.Ain);
            }
        }

        #endregion
    }
}       
                