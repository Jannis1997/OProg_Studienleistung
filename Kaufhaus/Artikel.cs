using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
/**********************************************
 * Name: Jannis Schenk *
 * Mat. Nr.: 70480743 *
 **********************************************/

namespace Kaufhaus
{
    public class Artikel
    {
        private string append = "";

        #region fields
        // Objektvariablen
        private string _artikel_name;
        private string _artikel_nummer;
        private double _einkaufspreis;
        private double _verkaufspreis;
        private double _gewinn;
        private int _regalnummer;
        private int _mindestbestand;
        private int _bestand;
        private int _anzahl_gekaufte_artikel;
        private int _anzahl_verkaufter_exemplare;
        protected int _nachbestellte_menge;
        // Assoziationsvariablen

        // Artikel --> Abteilung [1]
        private Abteilung _abteilung;
        // Artikel --> Lager [1]
        private Lager _lager;

        private Kaufhaus _kaufhaus;

        #endregion

        #region properties
        // Lesezugriff auf den Artkelnamen
        public string ArtikelName
        {
            get { return _artikel_name; }
        }
        
        // Lesezugriff auf die Artkelnummer
        public string Artikelnummer
        {
            get { return _artikel_nummer;}
        }

        // Lesezugriff auf den Einkaufspreis
        public double Einkaufspreis
        {
            get { return _einkaufspreis; }
        }

        // Lesezugriff auf den Verkaufspreis, sowie Schreib-Zugriff, falls sich ein Verkaufspreis ändert
        public double Verkaufspreis
        {
            get { return _verkaufspreis; }
            set { _verkaufspreis = value;}
        }

        // Lesezugriff auf den Verkaufspreis, sowie Schreib-Zugriff, falls sich ein Verkaufspreis ändert
        public int Regalnummer
        {
            get { return _regalnummer; }
            set { _regalnummer = value; }
        }

        // Lesezugriff auf den Mindestbestand, sowie Schreib-Zugriff, falls sich Mindestbestand ändert
        public int Mindestbestand
        {
            get { return _mindestbestand;}
            set { _mindestbestand = value;}
        }

        // Lesezugriff auf Abteilung, in der Artikel angeboten wird
        public Abteilung Abteilung
        {
            get { return _abteilung; }
        }

        // Lesezugriff für Apppend --> Wichtig für die Log-Datei
        public string Append
        {
            get { return append; }
        }

        // Lesezugriff auf das Lager in dem die Artikel in einer Liste abgespeichert werden sollen
        public Lager Lager
        {
            get { return _lager; }
        }

        // Lesezugriff auf den Bestand --> aktueller Bestand --> ist immer in der aktuellsten Version 
        public int Bestand
        {
            get { return _bestand; }
        }

        // Lesezugriff auf die Anzahl an gekauften Artikeln
        public int GekaufteArtikel
        {
            get { return _anzahl_gekaufte_artikel; }
        }

        // Lesezugriff auf den allgemeinen Bestand - Wird in der Testklasse verwendet um dann den Tagesgewinn für alle verkauften Exemplare zu berechnen
        public int AnzahlverkaufteExemplare
        {
            get { return _anzahl_verkaufter_exemplare; }
        }

        // Lesezugriff auf die Nachbestellte Menge --> Aufgerufen von der Reorder-Methode
        public int Nachbestellte_Menge
        {
            get { return _nachbestellte_menge; }            
        }


        #endregion

        // Konstruktor --> Gewinn wird berechnet aus Verkaufs- und Einkaufspreis (Methode wird aufgerufen)
        // Bei Aufruf und Erstellung der Objekte --> Artikel werden direkt zur Abteilungs- und Lagerliste hinzugefügt
        #region ctor
        public Artikel(string artikelname, double einkaufspreis, double verkaufspreis, int regalnummer, Abteilung abteilung, Lager lager, Kaufhaus kaufhaus)
        {
            _artikel_name = artikelname;
            _einkaufspreis= einkaufspreis;
            _verkaufspreis= verkaufspreis;
            _regalnummer= regalnummer;
            _mindestbestand = new Random().Next(4, 10);
            _abteilung= abteilung;
            _lager = lager;
            _kaufhaus= kaufhaus;
            BerechneGewinn();
            BerechneArtikelnummer();
            _abteilung.Add_Artikel_Abteilungsliste(this);
            _lager.Add_Lagerliste(this);
            _kaufhaus.SetzeAngebotskatalog(this);
            _bestand = SetzeBestand();
            _anzahl_verkaufter_exemplare = _bestand;

        }
        #endregion

        #region methods

        // Methode berechnet den Gewinn eines Artikels aus den Werten Verkaufspeis und Einkaufspreis (Beides Übergabeparameter aus dem Konstruktor)
        public double BerechneGewinn()
        {
            _gewinn = _verkaufspreis - _einkaufspreis;
            return _gewinn;    
        }

        // Methode berechnet eine zufällige fünfstellige Artkelnummer
        public string BerechneArtikelnummer()
        {
            _artikel_nummer = _lager.BerechneArtikelnummer();
            return _artikel_nummer;                  
        }

        // Methode die zufällig für einen Artikel den Bestand setzt
        public int SetzeBestand()
        {
            int bestand = new Random().Next(4,10);            
            return bestand;
        }

        // Eine Methode die den Bestand setzt auf null setzt, um zu überprüfen, dass kein Artikel gekauft wird, wenn der Bestand = 0 ist --> Wenn der Artikel ausverkauft ist
        public void SetzeBestand_Testklasse()
        {
            int bestand = 0;
            _bestand= bestand;  
        }

        // Methode die das Kaufen eines Artikels simuliert --> Prüft ob der Bestand asureicht um alle angeforderten Artkel auch kaufen zu können oder Sonderfälle beachtet werden müssen
        public int Artikelkaufen(int anzahl)
        {
            _anzahl_gekaufte_artikel = 0;
            
            if (_bestand== 0)
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Der Artikel ist ausverkauft");
                Console.ForegroundColor= ConsoleColor.White;
                append += "Der Artikel ist ausverkauft\n";
                _anzahl_gekaufte_artikel = 0;
                
            }
            else if (_bestand - anzahl < 0) 
            {
                
                _anzahl_gekaufte_artikel = _bestand;
                _bestand = 0;
                string leerer_bestand = Convert.ToString(anzahl);
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Nicht alle Artikel konnten gekauft werden: Der Restbestand wurde verbaucht --> Der Artikel ist jetzt ausverkauft");
                append += "Nicht alle Artikel konnten gekauft werden: Der Restbestand wurde verbaucht --> Der Artikel ist jetzt ausverkauft";
                Console.ForegroundColor= ConsoleColor.White;
            }

            else if (_bestand - anzahl >= 0)
            {
                
                string voller_bestand = Convert.ToString(anzahl);
                Console.WriteLine("Es wurden: " + anzahl + " gekauft" );
                append = "Es wurden:" + anzahl + " gekauft\n";
                _anzahl_gekaufte_artikel = anzahl;
                _bestand = _bestand - anzahl;
                
            }

            
            else if (_bestand - anzahl == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Der Artikel ist jetzt ausverkauft");
                append += "Der Artikel ist jetzt ausverkauft";
                _anzahl_gekaufte_artikel = anzahl;
                Console.ForegroundColor = ConsoleColor.White;

            }
            
            // append wird über die Getter Methode an die Test-Klasse übergeben und dort dem String beigefügt, wrelcher in die Log-Datei geschrieben wird
            //append = "Es wurden:" + anzahl + " gekauft\n";
            
            return _anzahl_gekaufte_artikel;
        }


        // Methode die den aktuellen Bestand auf das doppelte des Mindestbestand setzt --> falls der Bestand des Artikels kleiner als der Mindestbestand ist --> Funktion wird aufgerufen zu Beginn eines jeden Tages --> in der Test Klasse in PrintOverview

        public int reorder_artikel()
        {
            append = "";
            int nachbestellte_menge;
            if (_bestand < _mindestbestand)
            {
                _bestand += (_mindestbestand * 2);
                nachbestellte_menge = _mindestbestand * 2;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Der Artikel " +_artikel_name + " wurde nachbestellt: " + nachbestellte_menge);
                append = "Der Artikel " + _artikel_name + " wurde nachbestellt: " + nachbestellte_menge + "\n";
                Console.ForegroundColor = ConsoleColor.White;
                _nachbestellte_menge = nachbestellte_menge;
            }
            
            return _nachbestellte_menge;
        }

        public void Setze_Verkaufte_Anzahl_Artikel_Auf_Bestand()
        {
            _anzahl_verkaufter_exemplare = _bestand;
        }

        // Methode gibt die Informationen über die Artikel als String zurück --> Aufrufen der Methode in der PrintOverview Methode
        public string InformationenArtikel1()
        {
            string s1_artikel = $"Name des Artikels: {_artikel_name}, Artikelnummer: {_artikel_nummer} Regalnummer: {_regalnummer}";    
            return s1_artikel;
        }

        public string InformationenArtikel2()
        {            
            string s2_artikel = $"Einkaufspreis: {_einkaufspreis}, Verkaufspreis: {_verkaufspreis}, Gewinn: {_gewinn}, Mindestbestand: {_mindestbestand}";
            return s2_artikel;
        }
        #endregion

    }
}
