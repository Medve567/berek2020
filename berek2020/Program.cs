using berek2020;
using System.Text;

const string FILE = @"..\..\..\src\berek2020.txt";
List<Adatok> adatok = new();

using StreamReader sr = new(FILE, Encoding.UTF8);
_=sr.ReadLine();
while (!sr.EndOfStream) adatok.Add(new(sr.ReadLine()));


foreach (Adatok i in adatok)
{
    Console.WriteLine(i.ToString());
}

Console.WriteLine($"\nEnnyi dogozó adatai találhatóak: {adatok.Count}");

var f2 = adatok
    .Average(x => x.Ber);
var kerekites = Math.Round(f2);

Console.WriteLine($"\n2020 átlag bér: {kerekites}");


Console.Write("\nÍrjon be egy részleget: ");
string bekertReszleg = Console.ReadLine();

var legnagyobbBer = adatok
    .Where(x => x.Szakma == bekertReszleg)
    .OrderByDescending(x => x.Ber)
    .FirstOrDefault();

if (legnagyobbBer == null)
{
    Console.WriteLine("\nA megadott részleg nem létezik a cégnél");
}
else
{
    Console.WriteLine($"\nFeladat: A legnagyobb bérrel rendelkező {bekertReszleg} részlegen dolgozó:");
    Console.WriteLine(legnagyobbBer);
}

Console.WriteLine("\nStatisztika az egyes részlegeken dolgozók számáról:");
var statisztika = adatok
    .GroupBy(x => x.Szakma)
    .Select(x => new { Reszleg = x.Key, DolgozokSzama = x.Count() })
    .OrderBy(x => x.Reszleg);

foreach (var reszlegStat in statisztika)
{
    Console.WriteLine($"\t{reszlegStat.Reszleg}: {reszlegStat.DolgozokSzama} fő");
}

