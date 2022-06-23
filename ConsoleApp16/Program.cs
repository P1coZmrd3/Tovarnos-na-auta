using projekt_továren.Tridy;
using ConsoleApp;

Továrna továrnaTesla = new Továrna();
string input = továrnaTesla.Menu();


if (input == "1")
{
    Console.WriteLine("Chceš to zkusit spustit  znovu? y/n");

    string output = Console.ReadLine();
    if (input == "y")
    {
        Console.Clear();
    }

}
if (input == "2")
{
    Auto vytvorenyAuto = new Auto();
    vytvorenyAuto = továrnaTesla.VytvorAuto();

    továrnaTesla.VytvorStranku(vytvorenyAuto);

    Console.WriteLine("Chceš tebou vytvořené auto: y/n");
    string input2 = Console.ReadLine();
    if (input2 == "y")
    {
        továrnaTesla.ZobrazStranku("index.html");
    }
}