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
    public class Kaufhaus
    {

        #region fields
        // Objektvariablen
        private string _name;
        private string _adresse;
        string? str;
        // Assoziationsvariablen
        // Kaufhaus --> Abteilung [5]
        private List<Abteilung> _abteilung;

        // Initialisierung einer Liste mit allen Kundennummern --> Damit IDs sich nicht doppeln
        private List<string> _kundennummern;
        private List<Artikel> _angebotskatalog;
        private Lager _lager;
        #endregion

        #region properties

        // Lesezugriff auf den Kaufhaus-Namen
        public string Name
        {
            get { return _name; }
        }

        // Lesezugriff auf die Kaufhaus-Adresse
        public string Adresse
        {
            get { return _adresse; }
        }

        //Lesezugriff auf die Liste aller Abteilungen
        public List<Abteilung> Abteilungen
        {
            get { return _abteilung; }
        }        

        public List<string> Kundennummern
        {
            get { return _kundennummern; }
        }

        public Lager Lager
        {
            get { return _lager; }
            set { _lager = value; }

        }

        public List<Artikel> KaufhausKatalog
        {
            get { return _angebotskatalog; }
        }
        #endregion

        // Konstruktor --> Werte die übergeben werden müssen: Name und Adresse Kaufhaus, sowie eine neue Liste mit "Abteilungs"-Objekten
        #region ctor
        public Kaufhaus(string name, string adresse, List<Abteilung> abteilung, List<string> kundennummern, List<Artikel> angebotskatalog)
        {
            _name = name;
            _adresse = adresse;
            _abteilung = abteilung;
            _kundennummern = kundennummern;
            _angebotskatalog= angebotskatalog;
            
        }
        #endregion
        #region methods
        // Methode wird im Konstruktor der Klasse Abteilung aufgerufen --> Direktes Hinzufügen der Objekte bei der Erstellung
        public void Add_Abteilung_Kaufhaus(Abteilung abteilung)
        {
            _abteilung.Add(abteilung);
        }

        // Methode gibt die Informationen über das Kaufhaus als String zurück --> Aufrufen der Methode in der PrintOverview Methode
        public string InformationenKaufhaus()
        {
            string s_kaufhaus = $"Name des Kaufhauses: {_name}, Adresse: {_adresse}";
            return s_kaufhaus;
        }

        public void SetzeAngebotskatalog(Artikel artikel)
        {

            _angebotskatalog.Add(artikel);
            
        }

        // Methode für die Berechnung von Kundennummern
        public string BerechneKundenID()
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
                for (int j = 0; j < _kundennummern.Count; j++)
                {
                    if ((String.Equals(_kundennummern[j], s)) == true)
                    {
                        count += 1;
                        break;
                    }
                }
                
                if (count > 1)
                {
                    Console.WriteLine("Nummer ist schon vergeben - Funktion wird neu aufgerufen");

                }
                else
                {
                    str = "ID:" + s;
                    _kundennummern.Add(str); 
                    
                }

            } while (count > 0);

            return str;
        }

        #endregion
    }
}
