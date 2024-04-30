using Kaufhaus;

namespace Kaufhaus

{
    [TestClass]
    public class Artikel_AusverkauftUT
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Ein Test Objekt vom Typ Kaufhaus anlegen
            Kaufhaus TestKaufhaus = new Kaufhaus("Kaufhaus Wittingen", "Spittastra�e 30", new List<Abteilung>(), new List<string>(), new List<Artikel>());

            // Eine Test Abteilung wird erstellt
            Abteilung TestAbteilung = new Abteilung("Testabteilung", 20, TestKaufhaus, new List<Angestellter>(), new List<Artikel>());

            // Ein Test Lager erstellen
            Lager TestLager = new Lager("Lager Kaufhaus", new List<Artikel>(), new List<string>());

            // Einen Test-Artikel erstellen
            Artikel TestArtikel = new Artikel("Iphone 14", 200.0, 400.0, 100, TestAbteilung, TestLager, TestKaufhaus);

            // Manuell den Bestand des Artikels auf 0 setzen, damit �berpr�ft werden kann, welchen R�ckgabewert die Methode Artikel-Kaufen zur�ckgibt --> R�ckgabewert h�ngt vom Bestand ab
            TestArtikel.SetzeBestand_Testklasse();

            // �berpr�fen ob die Methode Artikel_Kaufen funktioniert --> Sie muss als R�ckgabewert die Zahl 0 haben
            Assert.AreEqual(TestArtikel.Artikelkaufen(2), 0);

        }
    }
}