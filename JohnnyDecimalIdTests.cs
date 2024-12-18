namespace Community.PowerToys.Run.Plugin.JohnnyDecimal.Tests
{
    [TestClass()]
    public class JohnnyDecimalIdTests
    {
        [TestMethod()]
        public void NullQuery_TryParse_fail()
        {
            string query = null;

            var isParsed = JohnnyDecimalId.TryParse(query, out var result);

            Assert.IsFalse(isParsed);
            Assert.IsNotNull(result);
            Assert.IsTrue(string.IsNullOrEmpty(result.GetCategory()));
            Assert.IsTrue(string.IsNullOrEmpty(result.GetId()));
        }

        [TestMethod()]
        public void EmptyQuery_TryParse_fail()
        {
            string query = "";

            var isParsed = JohnnyDecimalId.TryParse(query, out var result);

            Assert.IsFalse(isParsed);
            Assert.IsNotNull(result);
            Assert.IsTrue(string.IsNullOrEmpty(result.GetCategory()));
            Assert.IsTrue(string.IsNullOrEmpty(result.GetId()));
        }

        [TestMethod()]
        public void ValidQuery1_TryParse_success()
        {
            var query = "1234 Foo";

            var isParsed = JohnnyDecimalId.TryParse(query, out var result);

            Assert.IsTrue(isParsed);
            Assert.IsNotNull(result);
            Assert.AreEqual('1', result.GetArea());
            Assert.AreEqual("12", result.GetCategory());
            Assert.AreEqual("34", result.GetId());
        }

        [TestMethod()]
        public void ValidQuery2_TryParse_success()
        {
            var query = "12.34 Foo";

            var isParsed = JohnnyDecimalId.TryParse(query, out var result);

            Assert.IsTrue(isParsed);
            Assert.IsNotNull(result);
            Assert.AreEqual('1', result.GetArea());
            Assert.AreEqual("12", result.GetCategory());
            Assert.AreEqual("34", result.GetId());
        }

        [TestMethod()]
        public void ValidQuery3_TryParse_success()
        {
            string query = "123456789";

            var isParsed = JohnnyDecimalId.TryParse(query, out var result);

            Assert.IsTrue(isParsed);
            Assert.IsNotNull(result);
            Assert.AreEqual('1', result.GetArea());
            Assert.AreEqual("12", result.GetCategory());
            Assert.AreEqual("34", result.GetId());
        }
    }
}