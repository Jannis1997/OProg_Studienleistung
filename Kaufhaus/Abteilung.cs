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
    public class Abteilung
    {

        #region fields
        // Objektvariablen
        private string _name;
        private int _groesse;
        // Assoziationsvariablen
        // Abteilung --> Kaufhaus [1]
        private Kaufhaus _kaufhaus;
        // Abteilung --> Abteilungsleiter [1]
        private Abteilungsleiter _abteilungsleiter;
        // Abteilung --> Angestellter [2...*]
        private List<Angestellter> _angestellten_liste;
        // Abteilung --> Artikel [0...*]
        private List<Artikel> _artikel_liste_abteilung;
       
        #endregion

        #region properties

        // Lesezugriff vom Namen der Abteilung
        public string Name
        {
            get { return _name; }
        }

        // Lesezugriff auf die Größe der Abteilung
        public int Groesse
        {
            get { return _groesse; }
        }

        // Lesezugriff auf die Angestelltenliste
        public List<Angestellter> Angestelltenliste
        {
            get { return _angestellten_liste; }
        }

        // Lesezugriff auf die Artikelliste
        public List<Artikel> Artikelliste
        {
            get { return _artikel_liste_abteilung;}
        }

        // Lesezugriff auf den Abteilungsleiter
        public Abteilungsleiter Abteilungsleiter_Lesezugriff
        {
            get { return _abteilungsleiter; }             
        }
        #endregion

        #region ctor
        // Aufruf des Konstruktors
        public Abteilung(string name, int groesse, Kaufhaus kaufhaus, List<Angestellter> angestelltenliste, List<Artikel> artikelliste)
        {
            _name = name;
            _groesse = groesse;
            _kaufhaus= kaufhaus;
            _kaufhaus.Add_Abteilung_Kaufhaus(this);
            _angestellten_liste= angestelltenliste;            
            _artikel_liste_abteilung = artikelliste;
        }
        #endregion

        #region methods
        // Methode: Hinzufügen von Artikeln zur Abteilungsliste --> Aufruf im Konstruktor der Klasse Artikel
        // Automatisches Hinzufügen bei der Erstellung der Objekte
        public void Add_Artikel_Abteilungsliste(Artikel artikel)
        {
            _artikel_liste_abteilung.Add(artikel);
        }

        // Methode: Hinzufügen von Angestellten zur Angestellten-Liste der Abteilung --> wird im Konstruktor der Klasse Angestellter aufgerufen
        // Automatisches Hinzufügen bei der Erstellung der Objekte
        public void Add_Angestellter_Angestelltenliste(Angestellter angestellter)
        {
            _angestellten_liste.Add(angestellter);
        }

        // Methode wird beim Erstellen der Objekte aufgerufen und setzt damit den Abteilungsleiter, der zur Abteilung x gehört fest
        public Abteilungsleiter SetzeAbteilungsleiter(Abteilungsleiter abteilungsleiter)
        {
            _abteilungsleiter = abteilungsleiter;
            return _abteilungsleiter;
        }

        // Methode gibt die Informationen über die Abteilungen als String zurück --> Aufrufen der Methode in der PrintOverview Methode
        public string InformationenAbteilung()
        {
            string s_abteilung = $"Abteilungsgröße: {_groesse} qm, Abteilungsleiter: {_abteilungsleiter.Name}";
            return s_abteilung;
        }    
        #endregion
    }
}
