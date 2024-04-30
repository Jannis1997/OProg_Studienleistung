using Kaufhaus;

namespace Kaufhaus

{
    [TestClass]
    public class Artikel_nachbestellenUT
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Ein Test Objekt vom Typ Kaufhaus anlegen
            Kaufhaus TestKaufhaus = new Kaufhaus("Kaufhaus Wittingen", "Spittastraße 30", new List<Abteilung>(), new List<string>(), new List<Artikel>());

            // Eine Test Abteilung wird erstellt
            Abteilung TestAbteilung = new Abteilung("Testabteilung", 20, TestKaufhaus, new List<Angestellter>(), new List<Artikel>());

            // Ein Test Lager erstellen
            Lager TestLager = new Lager("Lager Kaufhaus", new List<Artikel>(), new List<string>());

            // Einen Test-Artikel erstellen
            Artikel TestArtikel = new Artikel("Iphone 14", 200.0, 400.0, 100, TestAbteilung, TestLager, TestKaufhaus);
            
            // Artikel nachbestellen
            TestLager.artikel_nachbestellen(TestArtikel);

            // Überprüfen ob die Methode Artikel Reorder funktioniert
            Assert.AreEqual(TestArtikel.Nachbestellte_Menge, TestArtikel.reorder_artikel());

        }
    }
}