using System.Net;

namespace AVMHomeAutomationTest
{
    public partial class UnitTestHanFunWallButton : UnitTestBase
    {
        #region Blind

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetBlindErrorAsync()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetBlindAsync(testDevice!.Ain, Target.Stop);
            }
        }

        #endregion
    }
}