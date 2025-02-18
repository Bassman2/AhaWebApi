
using System.Net;

namespace AhaWebApiUnitTest
{
    [TestClass]
    public partial class UnitTestDect200Socket : UnitTestBase
    {
        [TestInitialize]
        public void Initialize()
        {
            this.testDevice = TestSettings.DeviceDect200Socket;
        }
    }
}