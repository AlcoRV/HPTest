using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace HPTest.Tools.Tests
{
    [TestClass()]
    public class StringExtentionsTests
    {
        [TestMethod]
        [DataRow("word", "word", true)] //Идентичные строки
        [DataRow("", "", true)] //Пустые строки
        [DataRow("hello", "hi", false)] //Разный набор символов и разная длина
        [DataRow("qwer", "asdf", false)] //Разный набор символов и одинаковая длина
        [DataRow("qwert", "wrteq", true)] //Одинаковые набор символов и длина
        [DataRow("", "word", false)] //С пустой строкой
        [DataRow("w", "w", true)] //С одним символом
        [DataRow("Word", "wOrD", true)] //С разным регистром
        [DataRow("Hello!", "Hello?", false)] //С разными спецсимволами
        [DataRow("qwweerrtt", "qwert", false)] //Одинаковый набор символов и разная длина
        [DataRow(null, "", false)] // С null
        public void IsSimilarTest(string first, string second, bool expected)
        {
            var actual = first.IsSimilar(second);

            Assert.AreEqual(expected, actual);
        }
    }
}