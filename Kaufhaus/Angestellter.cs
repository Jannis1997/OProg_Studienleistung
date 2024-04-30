using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
/**********************************************
 * Name: Jannis Schenk *
 * Mat. Nr.: 70480743 *
 **********************************************/

namespace Kaufhaus
{
    public class Angestellter
    {

        #region fields
        // Objektvariablen
        private string _name;
        private int _alter;
        private double _gehalt;
        //Assoziationsvariablen
        // Assoziation: Angestellter --> Abteilung [1]
        private Abteilung? _abteilung;
        // Assoziation: Angestellter --> Abteilung(Abteilungsleiter) [1]
        private Abteilungsleiter? _vorgesetzter;
        #endregion

        #region properties
        // Lesezugriff auf den Namen des Angestellten
        public string Name
        {
            get { return _name; }
        }

        // Lesezugriff auf das Alter des Angestellten
        public int Alter
        {
            get { return _alter; }
            set { _alter = value; }
        }

        // Lesezugriff auf das Gehalt des Angestellten
        public double Gehalt
        {
            get { return _gehalt; }
            set { _gehalt = value; }
        }

        // Lesezugriff auf die Abteilung
        public Abteilung Abteilung
        {
            get { return _abteilung; }
        }
        #endregion

        // Aufruf des Konstruktors
        #region ctor
        public Angestellter(string name, int alter, double gehalt, Abteilung abteilung)
        {
            _name = name;
            _alter = alter;
            _gehalt = gehalt;
            _abteilung = abteilung;
            _abteilung.Add_Angestellter_Angestelltenliste(this);
        }
        #endregion

        #region mehtods

        // Methode die über die Klasse Abteilung den Lesezgriff auf das Abteilungsleiter Objekt herstellt
        public Abteilungsleiter GetVorgesetzten()
        {
            if (_vorgesetzter == null) 
            {
                throw new Exception("Es existiert kein Vorgesetzter");
            }
            else
            {
                _vorgesetzter = _abteilung.Abteilungsleiter_Lesezugriff;
                return _vorgesetzter;
            }   
        }

        // Methode Erweiterung zur GetVorgesetzten-Methode --> gibt den Namen des Abteilungsleiters als String zurück
        public string GetVorgesetztenName()
        {
            return _abteilung.Abteilungsleiter_Lesezugriff.Name;
        }

        // Beide Methoden geben gebündelt Informationen gespeichert in einem String zurück --> werden in PrintOverview aufgerufen
        public string InformationenAngestellter1()
        {
            string s1_angestellter = $"Name: {_name}, Alter: {_alter} Jahre, Gehalt: {_gehalt} Euro";
            return s1_angestellter;
        }

        public string InformationenAngestellter2()
        {
            string s2_angestellter = $"Abteilung: {_abteilung.Name}, Vorgesetzter: {GetVorgesetztenName()}";
            return s2_angestellter;
        }
        #endregion
    }
}
