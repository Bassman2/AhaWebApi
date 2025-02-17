using System.Net;

namespace AVMHomeAutomationTest
{
    public partial class UnitTestHanFunWallButton : UnitTestBase
    {
        #region Radiator Controller
                
        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodGetHkrtSollAsyncError()
        {
            double temp;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temp = await client.GetHkrtSollAsync(testDevice!.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodGetHkrKomfortAsyncError()
        {
            double temp;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temp = await client.GetHkrKomfortAsync(testDevice!.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodGetHkrAbsenkAsyncError()
        {
            double temp;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temp = await client.GetHkrAbsenkAsync(testDevice!.Ain);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetHkrtSollAsyncError()
        {
            double temp;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                temp = await client.SetHkrtSollAsync(testDevice!.Ain, 17.5);
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetHkrBoostAsyncError()
        {
            DateTime? res;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                res = await client.SetHkrBoostAsync(testDevice!.Ain, DateTime.Now + new TimeSpan(0, 10, 0));
            }
        }

        [TestMethod]
        [ExpectedHttpRequestException(HttpStatusCode.InternalServerError)]
        public async Task TestMethodSetHkrWindowOpenAsyncError()
        {
            DateTime? res;
            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                res = await client.SetHkrWindowOpenAsync(testDevice!.Ain, DateTime.Now + new TimeSpan(0, 10, 0));
            }
        }

        #endregion
    }
}       
                