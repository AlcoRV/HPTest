// See https://aka.ms/new-console-template for more information

using HPTest.Tools;

var list = new List<string>() { "ток", "рост", "кот", "торс", "Кто", "фывап", "рок" };

var list2 = new DataDevider().Devide(list);

foreach(var item in list2)
{
    Console.WriteLine(string.Join(' ', item));
}