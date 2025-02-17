namespace AVMHomeAutomationTest
{
    [TestClass]
    public partial class UnitTestDect400Switch : UnitTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            this.testDevice = TestSettings.DeviceDect400Switch;
        }
    }
}
