namespace AVMHomeAutomationTest
{
    [TestClass]
    public partial class UnitTestDect500Light : UnitTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            this.testDevice = TestSettings.DeviceDect500Light;
        }
    }
}