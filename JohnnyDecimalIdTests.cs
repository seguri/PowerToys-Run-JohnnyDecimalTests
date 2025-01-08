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
            Assert.IsTrue(string.IsNullOrEmpty(result.Area));
            Assert.AreEqual("", result.AreaGlob);
            Assert.IsTrue(string.IsNullOrEmpty(result.Category));
            Assert.AreEqual("", result.CategoryGlob);
            Assert.IsTrue(string.IsNullOrEmpty(result.Id));
            Assert.AreEqual("", result.IdGlob);
        }

        [TestMethod()]
        public void EmptyQuery_TryParse_fail()
        {
            string query = "";

            var isParsed = JohnnyDecimalId.TryParse(query, out var result);

            Assert.IsFalse(isParsed);
            Assert.IsNotNull(result);
            Assert.IsTrue(string.IsNullOrEmpty(result.Area));
            Assert.AreEqual("", result.AreaGlob);
            Assert.IsTrue(string.IsNullOrEmpty(result.Category));
            Assert.AreEqual("", result.CategoryGlob);
            Assert.IsTrue(string.IsNullOrEmpty(result.Id));
            Assert.AreEqual("", result.IdGlob);
        }

        [TestMethod()]
        public void PartialId1_TryParse_success()
        {
            var query = "123";

            var isParsed = JohnnyDecimalId.TryParse(query, out var result);

            Assert.IsTrue(isParsed);
            Assert.IsNotNull(result);
            Assert.AreEqual("1", result.Area);
            Assert.AreEqual("10-19*", result.AreaGlob);
            Assert.AreEqual("12", result.Category);
            Assert.AreEqual("12*", result.CategoryGlob);
            Assert.AreEqual("3", result.Id);
            Assert.AreEqual("12.3*", result.IdGlob);
        }

        [TestMethod()]
        public void ValidId1_TryParse_success()
        {
            var query = "1234 Foo";

            var isParsed = JohnnyDecimalId.TryParse(query, out var result);

            Assert.IsTrue(isParsed);
            Assert.IsNotNull(result);
            Assert.AreEqual("1", result.Area);
            Assert.AreEqual("10-19*", result.AreaGlob);
            Assert.AreEqual("12", result.Category);
            Assert.AreEqual("12*", result.CategoryGlob);
            Assert.AreEqual("34", result.Id);
            Assert.AreEqual("12.34*", result.IdGlob);
        }

        [TestMethod()]
        public void ValidId2_TryParse_success()
        {
            var query = "12.34 Foo";

            var isParsed = JohnnyDecimalId.TryParse(query, out var result);

            Assert.IsTrue(isParsed);
            Assert.IsNotNull(result);
            Assert.AreEqual("1", result.Area);
            Assert.AreEqual("10-19*", result.AreaGlob);
            Assert.AreEqual("12", result.Category);
            Assert.AreEqual("12*", result.CategoryGlob);
            Assert.AreEqual("34", result.Id);
            Assert.AreEqual("12.34*", result.IdGlob);
        }

        [TestMethod()]
        public void ValidId3_TryParse_success()
        {
            string query = "123456789";

            var isParsed = JohnnyDecimalId.TryParse(query, out var result);

            Assert.IsTrue(isParsed);
            Assert.IsNotNull(result);
            Assert.AreEqual("1", result.Area);
            Assert.AreEqual("10-19*", result.AreaGlob);
            Assert.AreEqual("12", result.Category);
            Assert.AreEqual("12*", result.CategoryGlob);
            Assert.AreEqual("34", result.Id);
            Assert.AreEqual("12.34*", result.IdGlob);
        }

        [TestMethod()]
        public void ValidCat1_TryParse_success()
        {
            var query = "12";

            var isParsed = JohnnyDecimalId.TryParse(query, out var result);

            Assert.IsTrue(isParsed);
            Assert.IsNotNull(result);
            Assert.AreEqual("1", result.Area);
            Assert.AreEqual("10-19*", result.AreaGlob);
            Assert.AreEqual("12", result.Category);
            Assert.AreEqual("12*", result.CategoryGlob);
            Assert.IsTrue(string.IsNullOrEmpty(result.Id));
            Assert.IsTrue(string.IsNullOrEmpty(result.IdGlob));
        }

        [TestMethod()]
        public void ValidCat2_TryParse_success()
        {
            var query = "12foo";

            var isParsed = JohnnyDecimalId.TryParse(query, out var result);

            Assert.IsTrue(isParsed);
            Assert.IsNotNull(result);
            Assert.AreEqual("1", result.Area);
            Assert.AreEqual("10-19*", result.AreaGlob);
            Assert.AreEqual("12", result.Category);
            Assert.AreEqual("12*", result.CategoryGlob);
            Assert.IsTrue(string.IsNullOrEmpty(result.Id));
            Assert.IsTrue(string.IsNullOrEmpty(result.IdGlob));
        }

        [TestMethod()]
        public void ValidArea1_TryParse_success()
        {
            var query = "1";

            var isParsed = JohnnyDecimalId.TryParse(query, out var result);

            Assert.IsTrue(isParsed);
            Assert.IsNotNull(result);
            Assert.AreEqual("1", result.Area);
            Assert.AreEqual("10-19*", result.AreaGlob);
            Assert.IsTrue(string.IsNullOrEmpty(result.Category));
            Assert.IsTrue(string.IsNullOrEmpty(result.CategoryGlob));
            Assert.IsTrue(string.IsNullOrEmpty(result.Id));
            Assert.IsTrue(string.IsNullOrEmpty(result.IdGlob));
        }

        [TestMethod()]
        public void ValidArea2_TryParse_success()
        {
            var query = "1foo";

            var isParsed = JohnnyDecimalId.TryParse(query, out var result);

            Assert.IsTrue(isParsed);
            Assert.IsNotNull(result);
            Assert.AreEqual("1", result.Area);
            Assert.AreEqual("10-19*", result.AreaGlob);
            Assert.IsTrue(string.IsNullOrEmpty(result.Category));
            Assert.IsTrue(string.IsNullOrEmpty(result.CategoryGlob));
            Assert.IsTrue(string.IsNullOrEmpty(result.Id));
            Assert.IsTrue(string.IsNullOrEmpty(result.IdGlob));
        }
    }
}