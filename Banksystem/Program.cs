using System;
using System.Collections.Generic;

class Passwort
{
    static void Main()
    {
        string passwort;

        const string korrektesPasswort = "1234";

        do
        {
            Console.WriteLine("Bitte Passwort eingeben: ");
            passwort = Console.ReadLine();

            if (passwort != korrektesPasswort)
            {
                Console.WriteLine("Falsches Passwort. Bitte nochmal eingeben.");
            }

        } while (passwort != korrektesPasswort);

        Console.WriteLine("Passwort akzeptiert.");

        double kontostand = 1000;
        List<string> transaktionen = new List<string>();

        do
        {
            Console.WriteLine(" 1. Einzahlung\n 2. Auszahlung \n 3. Transaktionen \n 4. Saldo ");

            int option;
            int.TryParse(Console.ReadLine(), out option);

            double betrag = 0;

            switch (option)
            {
                case 1:
                    Console.WriteLine("Wie viel Geld möchtest du einzahlen?");
                    double.TryParse(Console.ReadLine(), out betrag);
                    kontostand += betrag;
                    transaktionen.Add($"Einzahlung: +{betrag} Fr.");
                    break;
                case 2:
                    Console.WriteLine("Wie viel Geld möchtest du abheben?");
                    double.TryParse(Console.ReadLine(), out betrag);
                    if (betrag > kontostand)
                    {
                        Console.WriteLine("Unzureichende Mittel. Transaktion kann nicht abgeschlossen werden.");
                        continue;
                    }
                    kontostand -= betrag;
                    transaktionen.Add($"Auszahlung: -{betrag} Fr.");
                    break;
                case 3:
                    Console.WriteLine("Deine letzten Transaktionen sind:");
                    foreach (var transaktion in transaktionen)
                    {
                        Console.WriteLine(transaktion);
                    }
                    break;
                case 4:
                    Console.WriteLine($"Dein Kontostand beträgt: {kontostand} Fr.");
                    break;
            }

            Console.Write("Möchtest du weitere Änderungen an deinem Konto vornehmen? (ja/nein): ");
            string weiterOption = Console.ReadLine().ToLower();

            if (weiterOption != "ja")
            {
                Console.WriteLine("Du hast dich aus deinem Konto ausgeloggt.");
                break;
            }

        } while (true);
    }
}
