using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// Definice Banky
public class Banka
{
    public string Symbol { get; set; }
    public string Jmeno { get; set; }
}

// Definice Zákazníka
public class Zakaznik
{
    public string Jmeno { get; set; }
    public double Zustatek { get; set; }
    public string Banka { get; set; }
}

// Definice Skupiny milionářů
public class SkupinaMilionaru
{
    public string Banka { get; set; }
    public IEnumerable<string> Milionari { get; set; }
    public string Key { get; }
    public IEnumerable<char> Enumerable { get; }

    public SkupinaMilionaru(string Banka, IEnumerable<string> Milionari)
    {
        this.Banka = Banka;
        this.Milionari = Milionari;
    }
}
public class Program
{
    public static void Main()
    {
        // 4. Seřaďte jména vzestupně
        List<string> jmena = new List<string>()
        {
            "Hana", "Jaroslav", "Xenie", "Michaela", "Borivoj", "Nela",
            "Katerina", "Sofie", "Adam", "David", "Zuzana", "Barbara",
            "Tereza", "Lenka", "Svetlana", "Cecilie", "Renata",
            "Evzen", "Pavel", "Eliska", "Viktor", "Antonin",
            "Frantisek", "Radek"
        };

        // 4. Řešení
        List<string> vzestupne = new List<string>(jmena);
        vzestupne.Sort();

        foreach (string text in vzestupne)
        {
            Console.WriteLine(text);
        }

        // 7. Zobrazte vsechny milionare v kazde bance
        // Napr. 
        // CS: Jan Novak a Josef Novotny
        // KB: Jana Nova

        List<Zakaznik> zakaznici = new List<Zakaznik>() {
            new Zakaznik(){ Jmeno="Jan Maly", Zustatek=10345.50, Banka="CS"},
            new Zakaznik(){ Jmeno="Jiri Hladny", Zustatek=452.10, Banka="KB"},
            new Zakaznik(){ Jmeno="Lenka Sporiva", Zustatek=523665.13, Banka="CS"},
            new Zakaznik(){ Jmeno="Marie Bohata", Zustatek=7482184.38, Banka="FIO"},
            new Zakaznik(){ Jmeno="Michal Marny", Zustatek=745234.93, Banka="KB"},
            new Zakaznik(){ Jmeno="Lada Vychytraly", Zustatek=8832937.34, Banka="CS"},
            new Zakaznik(){ Jmeno="Sandra Nedostatecna", Zustatek=942488.48, Banka="KB"},
            new Zakaznik(){ Jmeno="Silvie Zavodou", Zustatek=56198334.72, Banka="FIO"},
            new Zakaznik(){ Jmeno="Tereza Presna", Zustatek=1000000.00, Banka="CITI"},
            new Zakaznik(){ Jmeno="Stefan Pilny", Zustatek=48282.73, Banka="CITI"}
        };
        // 7. Řešení

        List<SkupinaMilionaru> skupinyPodleBanky = zakaznici.Where(zakaznik => zakaznik.Zustatek >= 1000000.00).GroupBy(zakaznik => zakaznik.Banka).Select(milionariVBankach => new SkupinaMilionaru(milionariVBankach.Key, milionariVBankach.Select(zakaznik => zakaznik.Jmeno))).ToList();

        foreach (var polozka in skupinyPodleBanky)
        {
            Console.WriteLine(polozka.Banka + ": " + string.Join(" a ", polozka.Milionari));
        }

        // ==========================================		
        // 8. Vytisknete jmeno kazdeho milionare a jeho banky
        // Napr
        // Jan Novak v Ceska Sporitelna
        // Josef Novotny v Komercni Banka
        List<Banka> banky = new List<Banka>() {
            new Banka(){ Jmeno="Ceska Sporitelna", Symbol="CS"},
            new Banka(){ Jmeno="Komercni Banka", Symbol="KB"},
            new Banka(){ Jmeno="Fio Banka", Symbol="FIO"},
            new Banka(){ Jmeno="Citibank", Symbol="CITI"},
        };

        // 8. Řešení


        List<Zakaznik> reportMilionaru = new List<Zakaznik>
        {
            new Zakaznik { Jmeno = "Jan Novak", Banka = "Česká spořitelna" },
            new Zakaznik { Jmeno = "Petr Svoboda", Banka = "Komerční banka" },
            new Zakaznik { Jmeno = "Anna Dvořáková", Banka = "Raiffeisenbank" }
        };


        foreach (Zakaznik zakaznik in reportMilionaru)
        {
            Console.WriteLine(zakaznik.Jmeno + " v " + zakaznik.Banka);
        }
    }
}