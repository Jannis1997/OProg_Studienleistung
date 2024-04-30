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
    public class Abteilungsleiter
    {

        #region fields
        // Objektvariablen
        private string _name;        
        private int _alter;
        private double _gehalt;
        private string _buero;
        //Assoziationsvariablen
        private Abteilung _abteilung;
        #endregion

        #region properties
        // Lese- und Schreibberechtigung für den Namen des Abteilungsleiters
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Lese- und Schreibberechtigung für das Alter des Abteilungsleiters
        public int Alter
        {
            get { return _alter; }
            set { _alter = value; }
        }

        // Lese- und Schreibberechtigung für das Gehalt des Abteilungsleiters
        public double Gehalt
        {
            get { return _gehalt; }
            set { _gehalt = value; }                     
        }

        // Lese- und Schreibberechtigung für das Büro des Abteilungsleiters
        public string Buero
        {
            get { return _buero; }
            set { _buero = value; }
        }

        // Lese- und Schreibberechtigung für die Abteilung des Abteilungsleiters
        public Abteilung Abteilung
        {
            get { return _abteilung; }            
        }
        #endregion

        #region ctor

        // Aufruf des Konstruktors
        public Abteilungsleiter(string name, int alter, double gehalt, string buero, Abteilung abteilung)
        {
            _name = name;
            _alter = alter;
            _gehalt = gehalt;
            _buero = buero;
            _abteilung=abteilung;
        }
        #endregion

        #region mehtods

        // Methode gibt gebündelt die Informationen der Abteilungsleiter gespeichert in einem String zurück --> werden in PrintOverview aufgerufen
        public string InformationenAbteilungsleiter()
        {
            string s_abteilung_leiter = $"Name: {_name}, Alter: {_alter} Jahre, Gehalt: {_gehalt} Euro, Büro-Raum: {_buero}, Leiter der Abteilung: {_abteilung}";
            return s_abteilung_leiter;
        }



        #endregion
    }
}
