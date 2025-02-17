namespace AVMHomeAutomationTest
{
    public partial class UnitTestDect301Radiator : UnitTestBase
    {
        #region Blind

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetBlindAsyncError()
        {
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetBlindAsync(testDevice!.Ain, Target.Stop);
            }
        }

        #endregion
    }
}       
                