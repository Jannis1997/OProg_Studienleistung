using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Kaufhaus
{
    public class Kunde
    {
        #region fields
        // Objektvariablen
        private string? _vorname;
        private string? _nachname;
        private string? _strasse;
        private string? _stadt;
        private string? _geburtstag;
        private string _kundennummer;
        private List<List<Artikel>> _einkaufslisten = new List<List<Artikel>>();

        private List<int[]> Mengen_der_Artikellisten = new List<int[]>();
        //private int[] _menge_artikel_einkaufsliste = new int[] { 0, 0, 0 };
        // Array mit der Abteilungsliste
        string[] _abteilungen = new string[] { "Elektroartikel", "Lebensmittel", "Schmuckwaren", "Kleidung", "Möbel" };


        //Assoziationsvariablen
        //private List<Artikel> _einkaufsliste;
   
        private Kaufhaus _kaufhaus;
        #endregion


        #region properties
        // Lesezugriff auf den Namen --> Vor- und Nachnamen
        public string Name
        {
            get { return _vorname + " " + _nachname; }
        }

        // Direkter Lesezugriff Zugriff auf die vollständige Adresse --> Straße + Stadt
        public string Adresse
        {
            get { return _strasse + " " + _stadt; }
        }

        // Lesezugriff auf den Geburtstag
        public string Geburtstag
        {
            get { return _geburtstag; }
        }

        // Lesezugriff auf die Kundennummer
        public string GetKundennummer
        {
            get { return _kundennummer; }
        }

        // Lesezugriff auf die Wunschmenge der Artikel
        public List<int[]> Wunschmenge_Kaufen
        {
            get { return Mengen_der_Artikellisten; }
        }

        // Lesezugriff auf die jeweiligen Einkaufslisten
        public List<List<Artikel>> Einkaufslisten_Kunde
        {
            get { return _einkaufslisten; }
        }

        public Kaufhaus Kaufhaus
        {
            get { return _kaufhaus; }
        }
        #endregion

        // Konstruktor --> Kunde "kennt" das Kaufhaus und bei der Erstellung wird eine leere Einkaufsliste initialisiert
        #region ctor
        public Kunde(Kaufhaus kaufhaus)
        {
            //_einkaufsliste = einkaufsliste;
            _kaufhaus = kaufhaus;
            DynamischerKunde();
            Kundennummer();
            // Einkaufsliste wird mit Aufruf des Objekts mit Artikeln gemäß den Anforderungen gefüllt
            erstelle_einkaufsliste();
        }
        #endregion

        #region methods
        // Aufruf zur Berechnung der Kundennummer --> Methode ist in der Klasse Kaufhaus implementiert
        public string Kundennummer()
        {
            _kundennummer = _kaufhaus.BerechneKundenID();
            return _kundennummer;
        }

        // Methode, die die Einkaufsliste des Kunden erstellt
        public void erstelle_einkaufsliste()
        {
            List<Artikel> _einkaufsliste = new List<Artikel>();
            // Array welches die gleiche Dimension hat was string Array mit den Abteilungsnamen [Dimension = 5] wird erstellt
            int[] counter_abteilungen = new int[] { 0, 0, 0, 0, 0 };            

            // Variable vom Typ Artikel wird initialisiert
            Artikel _zufaelliger_artikel;
            int i = 0;
            // int count = 0;
            do
            {
                int count = 0;
                // Ein zufälliger Artikel aus der Angebotsliste des Kaufhauses wird erstellt --> Angebotsliste Kaufhaus ist übereinstimmend mit den
                int Random_artikel_index = new Random().Next(0, _kaufhaus.Lager.Artikelliste.Count());
                _zufaelliger_artikel = _kaufhaus.Lager.Artikelliste[Random_artikel_index];

                // Einkaufsliste wird durchlaufen --> Wenn ein zufällig ausgewählter Artikel doppelt ist --> wird nicht zur Einkaufsliste hinzugefügt
                for (int j = 0; j < _einkaufsliste.Count(); j++)
                {
                    if (_einkaufsliste[j] == _zufaelliger_artikel)
                    {
                        count++;

                    }
                }

                //Abteilung des Artikels wird gespeichert --> über ein Array, welches die absolute Abteilungshäufigkeiten speichert
                for (int x = 0; x < _abteilungen.Length; x++)
                {
                    if ((String.Equals(_abteilungen[x], _zufaelliger_artikel.Abteilung.Name)) == true)
                    {
                        counter_abteilungen[x] = + 1;
                        break;
                    }
                }

                // Geht das Abteilungshäufigkeiten Array durch --> wenn eine Abteilung öfter als einmal vorhanden ist --> Abbruch --> neuer Artikel muss ausgesucht werden --> count wird erhöht
                for (int y = 0; y < counter_abteilungen.Length; y++)
                {
                    if (counter_abteilungen[y] > 1)
                    {
                        count++;
                        break;
                    }
                }

                // Wenn die Überprüfungsvariable count = 0 --> Dann kann der Artikel in die Einkaufsliste aufgenommen werden und der nächste Artikel mit dem Index i kann aufgenommen werden --> ansonsten wird while Schleife wiederholt, i wird aber nicht erhöht 
                if (count == 0)
                {
                    _einkaufsliste.Add(_zufaelliger_artikel);
                    //int menge = new Random().Next(1, 5);
                    //_menge_artikel_einkaufsliste[i] = menge;
                    i++;
                }
                else
                {
                    continue;
                }
            } while (i < 3);
            _einkaufslisten.Add(_einkaufsliste);
            //Mengen_der_Artikellisten.Add(_menge_artikel_einkaufsliste);
        }

        // Methode für die dynamische/ zufällige Erstellung von Kunden --> Zugriff über die bereitgestellte API
        public void DynamischerKunde()
        {
            // Erstelle einen neuen Web Client
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;

            // Daten werden als string heruntergeladen
            string xml = wc.DownloadString("https://randomuser.me/api/?inc=name,location,dob&nat=de&format=xml&noinfo");

            // Parsing in XML Format
            XDocument xdoc = XDocument.Parse(xml);

            // Werte werden gespeichert in den Objektvariablen
            _vorname = xdoc.Root.Element("results").Element("name").Element("first").Value;
            _nachname = xdoc.Root.Element("results").Element("name").Element("last").Value;
            _strasse = xdoc.Root.Element("results").Element("location").Element("street").Value;
            _stadt = xdoc.Root.Element("results").Element("location").Element("city").Value;
            _geburtstag = xdoc.Root.Element("results").Element("dob").Element("date").Value.Split('T')[0];  
        }

        #endregion
    }
}
