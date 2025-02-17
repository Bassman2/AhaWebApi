namespace AVMHomeAutomationTest
{
    public partial class UnitTestHanFunDoorWindowContact : UnitTestBase
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