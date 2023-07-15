using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace HPTest.Tools.Tests
{
    [TestClass()]
    public class DataDeviderTests
    {
        [TestMethod]
        [DataRow("[]", "[]")] //Пустые множества
        [DataRow("[\"apple\", \"banana\", \"cherry\"]", "[[\"apple\"], [\"banana\"], [\"cherry\"]]")] //Непохожие данные
        [DataRow("[\"apple\", \"apple\", \"apple\"]", "[[\"apple\"]]")] //Идентичные данные
        [DataRow("[\"cat\", \"god\", \"dog\"]", "[[\"cat\"], [\"god\", \"dog\"]]")] //С похожими данными
        [DataRow("[\"cat\", \"god\", \"dog\", \"tac\"]", "[[\"cat\", \"tac\"], [\"god\", \"dog\"]]")] //Пара похожих данных
        [DataRow("[\"cat\", \"\", \"god\", \"\", \"dog\", \"\", \"tac\"]", "[[\"cat\", \"tac\"], [\"\"], [\"god\", \"dog\"]]")] //С пустыми строками
        public void DevideTest(string input, string expected)
        {
            var inputCollection = JsonConvert.DeserializeObject<string[]>(input);
            var expectedCollection = JsonConvert.DeserializeObject<string[][]>(expected);

            var actual = new DataDevider().Devide(inputCollection).Select(inner => inner.ToArray()).ToArray();

            for (int i = 0; i < actual.Length; i++)
            {
                for (int j = 0; j < actual[i].Length; j++)
                {
                    Assert.AreEqual(actual[i][j], expectedCollection[i][j]);
                }
            }
        }

        [TestMethod]
        public void DevideTest_WithNull_ReturnsNull()
        {
            var actual = new DataDevider().Devide(null);

            Assert.IsNull(actual);
        }
    }
}