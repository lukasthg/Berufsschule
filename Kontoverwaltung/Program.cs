using System;
using System.Collections.Generic;

class Program
{
    static List<Bankkonto> konten = new List<Bankkonto>();

    static void Main()
    {
        bool beenden = false;
        while (!beenden)
        {
            Console.WriteLine("Hauptmenü:");
            Console.WriteLine("1. Neues Konto anlegen");
            Console.WriteLine("2. Kontoauszug");
            Console.WriteLine("3. Einzahlung");
            Console.WriteLine("4. Auszahlung");
            Console.WriteLine("5. Konto löschen");
            Console.WriteLine("6. Programm beenden");

            Console.Write("Bitte wählen Sie eine Option: ");
            string auswahl = Console.ReadLine();
            Console.WriteLine();

            switch (auswahl)
            {
                case "1":
                    KontoAnlegen();
                    break;
                case "2":
                    Kontoauszug();
                    break;
                case "3":
                    Einzahlung();
                    break;
                case "4":
                    Auszahlung();
                    break;
                case "5":
                    KontoLoeschen();
                    break;
                case "6":
                    beenden = true;
                    Console.WriteLine("Programm wird beendet...");
                    break;
                default:
                    Console.WriteLine("Ungültige Auswahl. Bitte versuchen Sie es erneut.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void KontoAnlegen()
    {
        Console.WriteLine("Neues Konto anlegen:");
        Console.Write("Geben Sie die Kontonummer ein: ");
        string kontonummer = Console.ReadLine();

        Bankkonto neuesKonto = new Bankkonto(kontonummer);
        konten.Add(neuesKonto);

        Console.WriteLine("Konto erfolgreich angelegt.");
    }

    static void Kontoauszug()
    {
        Console.WriteLine("Kontoauszug:");
        Console.Write("Geben Sie die Kontonummer ein: ");
        string kontonummer = Console.ReadLine();

        Bankkonto konto = konten.Find(x => x.Kontonummer == kontonummer);
        if (konto != null)
        {
            Console.WriteLine($"Kontostand: {konto.Kontostand} Euro");
        }
        else
        {
            Console.WriteLine("Konto nicht gefunden.");
        }
    }

    static void Einzahlung()
    {
        Console.WriteLine("Einzahlung:");
        Console.Write("Geben Sie die Kontonummer ein: ");
        string kontonummer = Console.ReadLine();

        Bankkonto konto = konten.Find(x => x.Kontonummer == kontonummer);
        if (konto != null)
        {
            Console.Write("Geben Sie den Einzahlungsbetrag ein: ");
            decimal betrag = Convert.ToDecimal(Console.ReadLine());

            konto.Einzahlung(betrag);
            Console.WriteLine("Einzahlung erfolgreich.");
        }
        else
        {
            Console.WriteLine("Konto nicht gefunden.");
        }
    }

    static void Auszahlung()
    {
        Console.WriteLine("Auszahlung:");
        Console.Write("Geben Sie die Kontonummer ein: ");
        string kontonummer = Console.ReadLine();

        Bankkonto konto = konten.Find(x => x.Kontonummer == kontonummer);
        if (konto != null)
        {
            Console.Write("Geben Sie den Auszahlungsbetrag ein: ");
            decimal betrag = Convert.ToDecimal(Console.ReadLine());

            bool erfolg

bool erfolg = konto.Auszahlung(betrag);
            if (erfolg)
            {
                Console.WriteLine("Auszahlung erfolgreich.");
            }
            else
            {
                Console.WriteLine("Auszahlung fehlgeschlagen. Nicht genügend Guthaben.");
            }
        }
        else
        {
            Console.WriteLine("Konto nicht gefunden.");
        }
    }

    static void KontoLoeschen()
    {
        Console.WriteLine("Konto löschen:");
        Console.Write("Geben Sie die Kontonummer ein: ");
        string kontonummer = Console.ReadLine();

        Bankkonto konto = konten.Find(x => x.Kontonummer == kontonummer);
        if (konto != null)
        {
            konten.Remove(konto);
            Console.WriteLine("Konto erfolgreich gelöscht.");
        }
        else
        {
            Console.WriteLine("Konto nicht gefunden.");
        }
    }
}

class Bankkonto
{
    public string Kontonummer { get; set; }
    public decimal Kontostand { get; set; }

    public Bankkonto(string kontonummer)
    {
        Kontonummer = kontonummer;
        Kontostand = 0;
    }

    public void Einzahlung(decimal betrag)
    {
        Kontostand += betrag;
    }

    public bool Auszahlung(decimal betrag)
    {
        if (betrag <= Kontostand)
        {
            Kontostand -= betrag;
            return true;
        }
        else
        {
            return false;
        }
    }
}
