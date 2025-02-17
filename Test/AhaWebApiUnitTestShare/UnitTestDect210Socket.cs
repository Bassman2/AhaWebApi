namespace AVMHomeAutomationTest
{
    [TestClass]
    public partial class UnitTestDect210Socket : UnitTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            this.testDevice = TestSettings.DeviceDect210Socket;
        }
    }
}
