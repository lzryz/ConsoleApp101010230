using ConsoleApp1;
using System.Text;

List<Versenyzo> versenyzok = [];

using StreamReader sr = new("..\\..\\..\\src\\forras.txt", Encoding.UTF8);
while (!sr.EndOfStream)
{
    versenyzok.Add(new(sr.ReadLine()));
}

Console.WriteLine($"versenyzok szama: {versenyzok.Count}");

var f1 = versenyzok.Count(v => v.Kategoria == "elit junior");
Console.WriteLine($"elit junior versenyzok szama: {f1} fo");

var f2 = versenyzok.Where(v => v.Nem).Average(v => 2014 - v.Szul);
Console.WriteLine($"ferfiak atlageletkora: {f2:0.00} ev");

var f3 = versenyzok.Sum(v => v.VersenyIdok["futás"].TotalHours);
Console.WriteLine($"futassal toltott osszido: {f3:0.00} ora");

var f4 = versenyzok.Where(v => v.Kategoria == "20-24").Average(v => v.VersenyIdok["úszás"].TotalMinutes);
Console.WriteLine($"20-24 kategoriaban az atlagos uszassal toltott ido: {f4:0.00} perc");

var f5 = versenyzok.Where(v => !v.Nem).MinBy(v => v.OsszIdo);
Console.WriteLine($"noi gyoztes: {f5}");

var f6 = versenyzok.GroupBy(v => v.Nem);
Console.WriteLine($"a versenyt befejezok nemek szerint:");
foreach(var grp in f6)
{
    Console.WriteLine($"\t{(grp.Key ? "férfi" : "nő")}: {grp.Count()} fő");
}
//////////////////////////////////////////////////////////////////////////////////////////////////
Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////////////");
Console.WriteLine("csop1");
//csop1
var f1cs1 = versenyzok.Count(v => v.Kategoria == "elit");
Console.WriteLine($"elit versenyzok szama: {f1cs1} fo");

var f2cs1 = versenyzok.Where(v => !v.Nem).Average(v => 2014 - v.Szul);
Console.WriteLine($"nok atlageletkora: {f2cs1:0.00} ev");

var f3cs1 = versenyzok.Sum(v => v.VersenyIdok["kerékpár"].TotalHours);
Console.WriteLine($"kerekparozassal toltott osszido: {f3cs1:0.00} ora");

var f4cs1 = versenyzok.Where(v => v.Kategoria == "elit junior").Average(v => v.VersenyIdok["úszás"].TotalMinutes);
Console.WriteLine($"elit junior kategoriaban az atlagos uszassal toltott ido: {f4cs1:0.00} perc");

var f5cs1 = versenyzok.Where(v => v.Nem).MinBy(v => v.OsszIdo);
Console.WriteLine($"ferfi gyoztes: {f5cs1}");

var f6cs1 = versenyzok.GroupBy(v => v.Kategoria).OrderBy(g => g.Key);
Console.WriteLine("korkategóriánként a versenyt befejezők száma:");
foreach (var grp in f6cs1) Console.WriteLine(
    $"{grp.Key,11}: " +
    $"{grp.Count(),2} fo   ");

/////////////////////////////////////////////////////////////////////////////////////////////////////
Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////////////");
Console.WriteLine("csop3");
//csop3
var f1cs3 = versenyzok.Count(v => v.Kategoria == "25-29");
Console.WriteLine($"25-29 kategoria versenyzok szama: {f1cs3} fo");

var f2cs3 = versenyzok.Average(v => 2014 - v.Szul);
Console.WriteLine($"versenyzok atlageletkora: {f2cs3:0.00} ev");

var f3cs3 = versenyzok.Sum(v => v.VersenyIdok["úszás"].TotalHours);
Console.WriteLine($"uszassal toltott osszido: {f3cs3:0.00} ora");

var f4cs3 = versenyzok.Where(v => v.Kategoria == "elit").Average(v => v.VersenyIdok["úszás"].TotalMinutes);
Console.WriteLine($"elit kategoriaban az atlagos uszassal toltott ido: {f4cs3:0.00} perc");

var f5cs3 = versenyzok.Where(v => v.Nem).MinBy(v => v.OsszIdo);
Console.WriteLine($"ferfi gyoztes: {f5cs3}");

var f6cs3 = versenyzok.GroupBy(v => v.Kategoria).OrderBy(g => g.Key);
Console.WriteLine("korkategóriánként a versenyt befejezők száma:");
foreach (var grp in f6cs3) Console.WriteLine(
    $"{grp.Key,11}: " +
    $"{grp.Count(),2} fo   ");

/////////////////////////////////////////////////////////////////////////////////////////////////////
Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////////////");
Console.WriteLine("+feladat");


var f7 = versenyzok.GroupBy(v => v.Kategoria).OrderBy(g => g.Key).ToDictionary(g => g.Key, g => g.Average(v => v.VersenyIdok["I. depó"].TotalMinutes + v.VersenyIdok["II. depó"].TotalMinutes));
Console.WriteLine("kategoriankent atlag depoban toltott ido:");
foreach(var kvp in f7)
{
    Console.WriteLine($"\t{kvp.Key,11}: {kvp.Value:0.00} perc");
}