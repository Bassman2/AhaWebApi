namespace AVMHomeAutomationTest
{
    public partial class UnitTestHanFunRollerShutter : UnitTestBase
    {
        #region Blind 

        [TestMethod]
        public async Task TestMethodBlindAsync()
        {
            //ColorDefaults colorDefaults;

            using (HomeAutomation client = new HomeAutomation(TestSettings.Login, TestSettings.Password))
            {
                await client.SetBlindAsync(this.testDevice!.Ain, Target.Close);
                Sleep();
                await client.SetBlindAsync(this.testDevice!.Ain, Target.Open);
            }

            //Assert.IsNotNull(colorDefaults);
            //CollectionAssert.AreEquivalent(new int[] { 2700, 3000, 3400, 3800, 4200, 4700, 5300, 5900, 6500 }, colorDefaults.TemperatureDefaults.Select((t) => t.Value).ToList());
        }

        #endregion
    }
}
