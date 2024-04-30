using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**********************************************
 * Name: Jannis Schenk *
 * Mat. Nr.: 70480743 *
 **********************************************/

namespace Kaufhaus
{
    public class Lager
    {

        #region fields
        // Objektvariablen
        private string _name;
        List<int> _menge_artikel_lager_bestand = new List<int>();
        string? str;
        private List<string> _artikelnummern;
        // Assoziationsvariablen 
        // Assoziation auf einen Artikel:
        Artikel _artikel;
        // Assoziation Lager --> Artikel [0...*]
        private List<Artikel> _artikel_liste;        
        #endregion

        #region properties
        // Lesezugriff auf den Namen des Lagers
        public string Name
        {
            get { return _name; }
        }

        // Lesezugriff auf die Artikelliste
        public List<Artikel> Artikelliste
        {
            get { return _artikel_liste; }
        }

        public List<string> Artikelnummern
        {
            get { return _artikelnummern; }
        }

        public List<int> Bestandsmenge
        {
            get { return _menge_artikel_lager_bestand; }
        }
        #endregion

        // Aufruf des Konstruktors
        #region ctor
        public Lager(string name, List<Artikel> artikelliste, List<string> artikelnummern)
        {
            _name = name;
            _artikel_liste= artikelliste;
            _artikelnummern= artikelnummern;
            GetRegalNummer();
            GetMindestbestand();
        }
        #endregion

        #region methods
        /* Ohne Sicherheits-Mechanismus --> Problem: Do-While Schleife würde unendlich lange brauchen
         * --> Jedoch: fünstelliger Code --> mit jeweils 10 möglichen Ziffern
         * --> Wahrscheinlichkeit wird berechnet mit "Ziehen  mit Zurücklegen" --> Jede Ziffer kann mehrmal gezogen werden
         * Daher gibt es 100.000 verschieden Möglichkeiten (10^5 Möglichkeiten
         * Ersteinmal ist kein Sicherheitsmechanismus implementiert*/
        public string BerechneArtikelnummer()
        {
            int count;
            do
            {
                count = 0;
                int ziffer;
                string s = "";
                Random random = new Random();

                for (int i = 0; i < 5; i++)
                {
                    ziffer = random.Next(0, 9);
                    s += ziffer.ToString();
                }
                for (int j = 0; j < _artikelnummern.Count; j++)
                {
                    if ((String.Equals(_artikelnummern[j], s)) == true)
                    {
                        count += 1;
                        break;
                    }
                }
                str = s;
                if (count > 1)
                {
                    Console.WriteLine("Nummer ist schon vergeben - Funktion wird neu aufgerufen");
                }
                else
                {
                    _artikelnummern.Add(s);
                }
            } while (count > 0);
            return str;
        }

        // Methode welche die Regalnummern aller Artikel in der Artikelliste in einer weiteren Liste speichert, die die gleiche Indizierung wie die Artikelliste hat
        // Regaknummern können anhand des Index des Artikels in der Artikelliste in der Regalnummern-Liste gefunden werden
        public List<int> GetRegalNummer()
        {
            List<int> list_artikel_regalnummern = new List<int>(); 
            foreach (Artikel artikel in _artikel_liste)
            {
                list_artikel_regalnummern.Add(artikel.Regalnummer);
            }
            return list_artikel_regalnummern;
        }

        // Methode welche für alle Artikel in der Liste der Artikel den Mindestbestand in eine neue Liste mit gleicher Indizierung speichert
        public List<int> GetMindestbestand()
        {
            List<int> _list_artikel_mindestbestand= new List<int>();
            foreach (Artikel artikel in _artikel_liste)
            {
                _list_artikel_mindestbestand.Add(artikel.Mindestbestand);                               
            }
            return _list_artikel_mindestbestand;            
        }

        // Methode ruft für die ´übergebenen Artikel die Nachbestell-Funktion in Artikel auf
        public void artikel_nachbestellen(Artikel artikel_nachbestellen)
        {
            artikel_nachbestellen.reorder_artikel();
        }

        // Hinzufügen des Artikels in die Lagerliste
        // Methode wird aufgerufen im Konstruktor des Artikels --> automatisches hinzufügen in der Lagerliste
        public void Add_Lagerliste(Artikel artikel)
        {
            _artikel_liste.Add(artikel);
        }
        
        #endregion
    }
}
