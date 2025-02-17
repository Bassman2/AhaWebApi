namespace AVMHomeAutomationTest
{
    [TestClass]
    public partial class UnitTestDect440Switch : UnitTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            this.testDevice = TestSettings.DeviceDect440Switch;
        }
    }
}
