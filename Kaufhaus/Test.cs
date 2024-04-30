using System;
using System.Globalization;
using System.Threading;
using System.IO;
using System.Security.Cryptography.X509Certificates;

/**********************************************
 * Name: Jannis Schenk *
 * Mat. Nr.: 70480743 *
 **********************************************/

namespace Kaufhaus
{
    

    public class Test
    {
        


        //global definierter String, der den pfad enthaelt. Gehoert ausserhalb der main-Methode (und jeder anderen Methode)
        static string pfad = Directory.GetCurrentDirectory() + "/LOG";
        static string append = "";
        public void PrintOverview()
        {
            // Variable german_translation wird initialisiert --> wird benötigt um das Datum in Deutsch auszugeben
            var german_translation = new System.Globalization.CultureInfo("de-DE");

            // Kaufhaus erstellen
            Kaufhaus NeuesKaufhaus = new Kaufhaus("Kaufhaus Wittingen", "Spittastraße 30", new List<Abteilung>(), new List<string>(), new List<Artikel>());

            // Abteilungen erstellen
            Abteilung elektroartikel = new Abteilung("Elektroartikel", 20, NeuesKaufhaus, new List<Angestellter>(), new List<Artikel>());
            Abteilung lebensmittel = new Abteilung("Lebensmittel", 40, NeuesKaufhaus, new List<Angestellter>(), new List<Artikel>());
            Abteilung schmuckwaren = new Abteilung("Schmuckwaren", 10, NeuesKaufhaus, new List<Angestellter>(), new List<Artikel>());
            Abteilung kleidung = new Abteilung("Kleidung", 50, NeuesKaufhaus, new List<Angestellter>(), new List<Artikel>());
            Abteilung moebel = new Abteilung("Möbel", 70, NeuesKaufhaus, new List<Angestellter>(), new List<Artikel>());

            // Lager erstellen
            Lager lager = new Lager("Lager Kaufhaus", new List<Artikel>(), new List<string>());

            NeuesKaufhaus.Lager = lager;

            // Artikel Elektrowaren
            Artikel art01 = new Artikel("Iphone 14", 200.0, 400.0, 100, elektroartikel, lager, NeuesKaufhaus);
            Artikel art02 = new Artikel("Iphone 13 mini", 100.0, 300.0, 101, elektroartikel, lager, NeuesKaufhaus);
            Artikel art03 = new Artikel("Iphone 12", 50.0, 250.0, 102, elektroartikel, lager, NeuesKaufhaus);

            // Artikel Lebensmittel
            Artikel art04 = new Artikel("Äpfel", 2.0, 4.0, 200, lebensmittel, lager, NeuesKaufhaus);
            Artikel art05 = new Artikel("Birnen", 1.0, 3.0, 201, lebensmittel, lager, NeuesKaufhaus);
            Artikel art06 = new Artikel("Bananen", 4.0, 5.0, 202, elektroartikel, lager, NeuesKaufhaus);

            //Artikel Schmuckwaren
            Artikel art07 = new Artikel("Kette", 50.0, 100.0, 300, schmuckwaren, lager, NeuesKaufhaus);
            Artikel art08 = new Artikel("Armband", 70.0, 100.0, 301, schmuckwaren, lager, NeuesKaufhaus);
            Artikel art09 = new Artikel("Ring", 100.0, 400.0, 302, schmuckwaren, lager, NeuesKaufhaus);

            // Artikel Kleidung
            Artikel art10 = new Artikel("T-Shirt", 50.0, 100.0, 400, kleidung, lager, NeuesKaufhaus);
            Artikel art11 = new Artikel("Pullover", 70.0, 100.0, 401, kleidung, lager, NeuesKaufhaus);
            Artikel art12 = new Artikel("Jacke", 100.0, 400.0, 402, kleidung, lager, NeuesKaufhaus);

            // Artikel Möbel
            Artikel art13 = new Artikel("Sessel", 100.0, 400.0, 500, moebel, lager, NeuesKaufhaus);
            Artikel art14 = new Artikel("Couch", 200.0, 500.0, 501, moebel, lager, NeuesKaufhaus);
            Artikel art15 = new Artikel("Tisch", 100.0, 400.0, 502, moebel, lager, NeuesKaufhaus);

            // Angestellte erstellen --> Elektroartikel
            Angestellter angestellter01 = new Angestellter("Jan Schulz", 20, 1700.0, elektroartikel);
            Angestellter angestellter02 = new Angestellter("Jan Schimdt", 20, 1700.0, elektroartikel);

            // Angestellte erstellen --> Lebensmittel
            Angestellter angestellter03 = new Angestellter("Jonas Schulz", 20, 1700.0, lebensmittel);
            Angestellter angestellter04 = new Angestellter("Justus Schimdt", 20, 1700.0, lebensmittel);

            // Angestellte erstellen --> Schmuckwaren
            Angestellter angestellter05 = new Angestellter("Janos Schulz", 20, 1700.0, schmuckwaren);
            Angestellter angestellter06 = new Angestellter("Jeremias Schimdt", 20, 1700.0, schmuckwaren);

            // Angestellte erstellen --> Kleidung
            Angestellter angestellter07 = new Angestellter("Jens Schulz", 20, 1700.0, kleidung);
            Angestellter angestellter08 = new Angestellter("Jamal Schimdt", 20, 1700.0, kleidung);

            // Angestellte erstellen --> Möbel
            Angestellter angestellter09 = new Angestellter("Jana Schulz", 20, 1700.0, moebel);
            Angestellter angestellter10 = new Angestellter("Jasmin Schimdt", 20, 1700.0, moebel);

            // Abteilungsleiter erstellen
            // Abteilungsleiter der Elektroartikel-Abteilung
            Abteilungsleiter LeiterElektroartikel = new Abteilungsleiter("Jannis Schenk", 25, 2200.0, "Raum 110", elektroartikel);
            elektroartikel.SetzeAbteilungsleiter(LeiterElektroartikel);

            // Abteilungsleiter der Lebensmittel-Abteilung
            Abteilungsleiter LeiterLebensmittel = new Abteilungsleiter("Hans Meister", 27, 2200.0, "Raum 210", lebensmittel);
            lebensmittel.SetzeAbteilungsleiter(LeiterLebensmittel);

            // Abteilungsleiter der Schmuckwaren-Abteilung
            Abteilungsleiter LeiterSchmuckwaren = new Abteilungsleiter("Jens Jeremias", 25, 2200.0, "Raum 220", schmuckwaren);
            schmuckwaren.SetzeAbteilungsleiter(LeiterSchmuckwaren);

            // Abteilungsleiter der Elektroartikel-Kleidung
            Abteilungsleiter LeiterKleidung = new Abteilungsleiter("Jannis Schenk", 25, 2200.0, "Raum 110", kleidung);
            kleidung.SetzeAbteilungsleiter(LeiterKleidung);

            // Abteilungsleiter der Möbel-Abteilung
            Abteilungsleiter LeiterMoebel = new Abteilungsleiter("Lena Mustermann", 25, 2200.0, "Raum 110", moebel);
            moebel.SetzeAbteilungsleiter(LeiterMoebel);

            // Print-Overview
            Console.WriteLine(NeuesKaufhaus.InformationenKaufhaus());
            append += NeuesKaufhaus.InformationenKaufhaus() + "\n";
            Console.WriteLine("####################################################################################################################################");
            append += "####################################################################################################################################:\n";
            Console.WriteLine("\n");
            append += "\n";
            // Ausgabe der Abteilungen
            foreach (Abteilung abteilung in NeuesKaufhaus.Abteilungen)
            {
                Console.WriteLine(abteilung.Name);
                append += abteilung.Name + "\n";
                Console.WriteLine("--------------");
                append += "--------------\n";
                Console.WriteLine(abteilung.InformationenAbteilung());
                append += abteilung.InformationenAbteilung() + "\n";
                Console.WriteLine("\n");
                append += "\n";
                Console.WriteLine("Abteilungsleiter:");
                append += "Abteilungsleiter:\n";
                Console.WriteLine("-----------------");
                append += "-----------------:\n";
                Console.Write(abteilung.Abteilungsleiter_Lesezugriff.InformationenAbteilungsleiter());
                append += abteilung.Abteilungsleiter_Lesezugriff.InformationenAbteilungsleiter() + "\n";
                Console.WriteLine("\n");
                append += "\n";
                Console.WriteLine("Artikelliste");
                append += "Artikelliste\n";
                Console.WriteLine("------------");
                append += "------------\n";
                // Innerhalb der Abteilungen --> Ausgabe der Artikel und deren Informationen
                foreach (Artikel artikel in abteilung.Artikelliste)
                {
                    Console.WriteLine(artikel.InformationenArtikel1());
                    append += artikel.InformationenArtikel1() + "\n";
                    Console.WriteLine(artikel.InformationenArtikel2());
                    append += artikel.InformationenArtikel2() + "\n";
                    Console.WriteLine("\n");
                    append += "\n";
                }

                // Innerhalb der Abteilungen --> Ausgabe der Mitarbeiter und deren Informationen
                Console.WriteLine("Mitarbeiterliste");
                append += "Mitarbeiterliste\n";
                Console.WriteLine("----------------");
                append += "----------------\n";
                foreach (Angestellter angestellter in abteilung.Angestelltenliste)
                {
                    Console.WriteLine(angestellter.InformationenAngestellter1());
                    append += angestellter.InformationenAngestellter1() + "\n";
                    Console.WriteLine(angestellter.InformationenAngestellter2());
                    append += angestellter.InformationenAngestellter2() + "\n";
                    Console.WriteLine("\n");
                    append += "\n";
                }
                Console.WriteLine("####################################################################################################################################");
                append += "####################################################################################################################################:\n";
            }
            //Ausgabe des Lagers und Artikel, welche sich darin befinden
            Console.WriteLine(lager.Name);
            append += lager.Name + "\n";
            Console.WriteLine("-----------------");
            append += "-----------------\n";
           
            Console.WriteLine("####################################################################################################################################");
            append += "####################################################################################################################################:\n";

            Console.WriteLine("Lagerliste:");
            append += "Lagerliste\n";
            foreach (Artikel artikel in NeuesKaufhaus.KaufhausKatalog)
            {
                Console.WriteLine(artikel.ArtikelName + " Aktuelle Anzahl an Artikeln: " +  artikel.Bestand);
                append += artikel.ArtikelName + " Aktuelle Anzahl an Artikeln: " + artikel.Bestand + "\n";
                
            } 
            Console.WriteLine("Lagerliste:");
            append += "Lagerliste\n";

            Console.WriteLine("####################################################################################################################################");
            append += "####################################################################################################################################:\n";


            // Liste mit Verweisen auf einzelne Kundenobjekte wird angelegt
            List<Kunde> _kunden = new List<Kunde>();

            // Datum wird initialisiert für die simulation der Woche
            string dateinput = "Jan, 05, 2009";
            var parsedate = DateTime.Parse(dateinput);
             
            // Pfad für die Erstellung des LOG-Ordners
            string pfad = @"C:\Users\Jannis Arbeit\source\repos\SS23_OOProg_Jannis_Schenk\SS23_OOProg_Jannis_Schenk\";          
            string pfad_ordner = System.IO.Path.Combine(pfad, "LOG");
            // Erstelle jeweils einen Ordner, der dem aktuellen Geschäftstag zugeordnet ist
            Directory.CreateDirectory(pfad_ordner);

            // Simuliert 5 Arbeitstage --> Sprich eine Arbeitswoche in der das Kaufhaus geöffnet hat
            for (int wochentag = 1; wochentag <=5; wochentag++)
            {
                // Datum.ToShortDateString() --> Gibt lediglich das Datum des Tages aus, ohne Uhrzeit --> für Speichern der LOG Datei wird nur das Datum des Tages benötigt           
                string logdatei_name_wochentag = parsedate.ToShortDateString();

                // Die jeweiligen strings für jeden einzelnen Wochentag werden gecleard --> am Ende jedes Durchlaufs werden die Informationen in die jeweiligen LOG-Dateien geschrieben
                string pfad_log_datei_tagX = pfad_ordner + "/" + logdatei_name_wochentag + ".txt";
                string append_log_datei_tagX = "";
               
                // Wochentag aus dem Date-Time extrahieren
                string werktag_datetime = german_translation.DateTimeFormat.GetDayName(parsedate.DayOfWeek).ToString();
                // Tasgesumsatz wird auf null gesetzt
                double tagesumsatz = 0;
                // Die Tages-Kundenliste wird gecleard --> keine Objektverweise mehr sichtbar
                _kunden.Clear();
                
                int counting_kunden = 1;
                int Stunde = 8;
                
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                append_log_datei_tagX += "\n";
                append_log_datei_tagX += "\n";
                Console.WriteLine("Wochentag: " + werktag_datetime + logdatei_name_wochentag);
                append_log_datei_tagX += "Wochentag: " + " " + werktag_datetime;
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                Console.WriteLine("\n");
                append_log_datei_tagX += "\n";
                append_log_datei_tagX += "\n";
                append_log_datei_tagX += "\n";

                Console.WriteLine("Das Kaufhaus öffnet um 8 Uhr");
                append_log_datei_tagX += "Das Kaufhaus öffnet um 8 Uhr";
                append_log_datei_tagX += "\n";

                // Am Ersten Wochentag müssen die Bestände nicht aufgefüllt werden --> passiert dann "Am jeweiligen Morgen" des nächsten Tages
                if (wochentag != 1)
                {                    
                    // Re-Order Funktion wird für alle Artikel aufgerufen ab Wochentag 2
                    foreach (Artikel tagesartikel in NeuesKaufhaus.Lager.Artikelliste)
                    {
                        lager.artikel_nachbestellen(tagesartikel);

                        append_log_datei_tagX += tagesartikel.Append;

                        tagesartikel.Setze_Verkaufte_Anzahl_Artikel_Auf_Bestand();
                    }
                }

                foreach (Artikel tagesartikel in NeuesKaufhaus.Lager.Artikelliste)
                {
                    Console.WriteLine(tagesartikel.ArtikelName + " Aktuelle Anzahl an Artikeln: " + tagesartikel.Bestand);
                }

                // Simuliert einen Tag --> 12 Stunden offen von 8 - 20 Uhr
                for (int a = 1; a <= 43200; a++)
                {
                    // Zu jeder vollen Stunde mit einer Wahrscheinlichkeit von 70% kommt ein Kunde
                    if (a % 3600 == 0)
                    {

                        int x = a / 3600;
                        string s = Convert.ToString(x);
                        int random_zahl = new Random().Next(1, 100);
                        if (random_zahl >= 25)
                        {
                            // Ausgabe der Uhrzeit zu der, der Kunde das Kaufhaus betritt
                            int Minute = new Random().Next(1, 60);
                            append_log_datei_tagX += "\n";
                            Console.WriteLine("Uhrzeit: " + Stunde + " : " + Minute + " Uhr");
                            append_log_datei_tagX += "Uhrzeit: " + Stunde + " : " + Minute + " Uhr" + "\n";
                            int random_zahl_gleicher_kunde = new Random().Next(1, 100);

                            // Ein gleicher Kunde der am Tag schon einmal da war kommt mit der Wahrscheinlichkeit von 20%
                            if ((random_zahl_gleicher_kunde >= 80) && (_kunden.Count() > 1))
                            {
                                int random_index = new Random().Next(0, _kunden.Count());
                                _kunden[random_index].erstelle_einkaufsliste();
                                _kunden.Add(_kunden[random_index]);

                                // Die jeweils letzte Einkaufsliste wird hierüber ausgewählt --> wenn Kunden mehrfach das Kaufhaus besuchen, sollen sie mehrere/ neue einkaufslisten haben
                                List<Artikel> aktuelle_einkaufsliste = _kunden[random_index].Einkaufslisten_Kunde.Last();

                                Console.WriteLine(_kunden[random_index].Name);
                                append_log_datei_tagX += _kunden[random_index].Name + "\n";

                                // Menge an gewünschten Artikelexemplaren wird initialisiert und mit Werten gefüllt
                                int[] _menge_artikel_einkaufsliste = new int[] { 0, 0, 0 };
                                for (int element = 0; element < _menge_artikel_einkaufsliste.Length; element++)
                                {
                                    int menge = new Random().Next(1, 10);
                                    _menge_artikel_einkaufsliste[element] = menge;
                                }

                                // Für alle Werte der Einkaufsliste werden die jeweiligen Anzahlen von den Beständen abgezogen und in der Konsole/Log Datei ausgegeben
                                int counting_artikel_menge = 0;
                                foreach (Artikel artikel in aktuelle_einkaufsliste)
                                {
                                    Console.WriteLine(artikel.ArtikelName + " gewünschte Anzahl   " + _menge_artikel_einkaufsliste[counting_artikel_menge]);
                                    append_log_datei_tagX += artikel.ArtikelName + " gewünschte Anzahl   " + _menge_artikel_einkaufsliste[counting_artikel_menge] + "\n";
                                    artikel.Artikelkaufen(_menge_artikel_einkaufsliste[counting_artikel_menge]);
                                    append_log_datei_tagX += artikel.Append + "\n";

                                    counting_artikel_menge++;
                                }
                            }

                            else
                            {
                                // Initialisierung eines neuen Kundenobjektes
                                Kunde kunde = new Kunde(NeuesKaufhaus);
                                _kunden.Add(kunde);

                                // Die jeweils letzte Einkaufsliste wird hierüber ausgewählt --> wenn Kunden mehrfach das Kaufhaus besuchen, sollen sie mehrere/ neue einkaufslisten haben
                                List<Artikel> aktuelle_einkaufsliste = kunde.Einkaufslisten_Kunde.Last();

                                Console.WriteLine(kunde.Name);
                                append_log_datei_tagX += kunde.Name + "\n";

                                // Menge an gewünschten Artikelexemplaren wird initialisiert und mit Werten gefüllt
                                int[] _menge_artikel_einkaufsliste = new int[] { 0, 0, 0 };
                                for (int element = 0; element < _menge_artikel_einkaufsliste.Length; element++)
                                {
                                    int menge = new Random().Next(1, 10);
                                    _menge_artikel_einkaufsliste[element] = menge;
                                }

                                // Für alle Werte der Einkaufsliste werden die jeweiligen Anzahlen von den Beständen abgezogen und in der Konsole/Log Datei ausgegeben
                                int counting_artikel_menge = 0;
                                foreach (Artikel artikel in aktuelle_einkaufsliste)
                                {
                                    Console.WriteLine(artikel.ArtikelName + " gewünschte Anzahl   " + _menge_artikel_einkaufsliste[counting_artikel_menge]);
                                    append_log_datei_tagX += artikel.ArtikelName + " gewünschte Anzahl   " + _menge_artikel_einkaufsliste[counting_artikel_menge] + "\n";
                                    counting_artikel_menge++;
                                    artikel.Artikelkaufen(_menge_artikel_einkaufsliste[counting_artikel_menge - 1]);
                                    append_log_datei_tagX += artikel.Append + "\n";
                                }
                            }
                        }
                        Stunde++;
                        Console.WriteLine("####################################################################################################################################");
                        append_log_datei_tagX += "####################################################################################################################################:\n";          
                    }                
                }
               
                // Ausgabe der Lagerliste
                Console.WriteLine("Lagerliste:");
                append_log_datei_tagX += "Lagerliste:\n";
                foreach (Artikel artikel in NeuesKaufhaus.KaufhausKatalog)
                {
                    Console.WriteLine(artikel.ArtikelName + " Aktuelle Anzahl an Artikeln: " + artikel.Bestand);
                    append_log_datei_tagX += artikel.ArtikelName + " Aktuelle Anzahl an Artikeln: " + artikel.Bestand + "\n";
                    // Berechnung des Tagesumsatzes aus der Differenz der Lagerbeständer der Artikel am Anfang des Tages und am Ende
                    tagesumsatz += (artikel.AnzahlverkaufteExemplare - artikel.Bestand) * artikel.BerechneGewinn();
                }
                Console.WriteLine("Lagerliste:");
                append_log_datei_tagX += "Lagerliste:";

                // Ausgabe des Tagesumsatzes in der Konsole und in der LOG-Datei
                Console.WriteLine(tagesumsatz + " Euro Tagesumsatz\n");
                append_log_datei_tagX += tagesumsatz + " Euro Tagesumsatz\n";
                File.AppendAllText(pfad_log_datei_tagX, append_log_datei_tagX);

                // Ausagbe wann das Kaufhaus schließt+
                Console.WriteLine("\n");
                append_log_datei_tagX += "\n";
                append_log_datei_tagX += "\n";
                Console.WriteLine("Das Kaufhause schließt 20:00 Uhr");
                append_log_datei_tagX += "Das Kaufhause schließt 20:00 Uhr";
                Console.WriteLine("\n");
                append_log_datei_tagX += "\n";
                append_log_datei_tagX += "\n";
                Console.WriteLine("####################################################################################################################################");
                append_log_datei_tagX += "####################################################################################################################################";
                // Der Tag wird am Ende immer um einen erhöht --> Nächster Tag wird dann immer zu Beginn geloggt --> in der Konsole ausgegeben
                parsedate = parsedate.AddDays(1);                                                
            }
        }

        static void Main(string[] args)
        {
            // Schaut, ob Datei vorhanden ist, falls ja, loescht das Programm dieses. In jedem Fall legt es aber eine neue Datei an diesem Pfad an
            if (File.Exists(pfad)) //pruefen, ob Datei an Pfad existiert
            {
                File.Delete(pfad); //Datei an Pfad loeschen
            }
            File.WriteAllText(pfad, ""); //Legt leere Datei an Zielpfad an.
            //Erstellen einer neuen Testklasse
            Test test = new Test();
            test.PrintOverview();
            Console.ReadKey();

            

        }
    }
}
