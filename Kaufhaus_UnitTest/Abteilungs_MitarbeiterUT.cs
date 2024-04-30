using Kaufhaus;

namespace Kaufhaus

{
    [TestClass]
    public class Abteilungs_MitarbeiterUT

    {
        [TestMethod]
        public void TestMethod1()
        {
            // Ein Test Objekt vom Typ Kaufhaus anlegen
            Kaufhaus TestKaufhaus = new Kaufhaus("Kaufhaus Wittingen", "Spittastraﬂe 30", new List<Abteilung>(), new List<string>(), new List<Artikel>());

            // Eine Test Abteilung wird erstellt
            Abteilung TestAbteilung = new Abteilung("Testabteilung", 20, TestKaufhaus, new List<Angestellter>(), new List<Artikel>());

            // Ein Abteilungsleiter Objekt anlegen
            Abteilungsleiter LeiterTestAbteilung = new Abteilungsleiter("Jannis Schenk", 25, 2200.0, "Raum 110", TestAbteilung);

            // Der Testabteilung den Abteilungsleiter hinzuf¸gen
            TestAbteilung.SetzeAbteilungsleiter(LeiterTestAbteilung);

            // ‹berpr¸fen ob die Methode Artikel_Kaufen funktioniert --> Sie muss als R¸ckgabewert die Zahl 0 haben
            Assert.AreEqual(TestAbteilung.Abteilungsleiter_Lesezugriff.Name, "Jannis Schenk");
            Assert.AreEqual(TestAbteilung.Abteilungsleiter_Lesezugriff.Gehalt, 2200.0);
            Assert.AreEqual(TestAbteilung.Abteilungsleiter_Lesezugriff.Alter, 25);
            Assert.AreEqual(TestAbteilung.Abteilungsleiter_Lesezugriff.Buero, "Raum 110");

            // Zwei Angestellten Objekte anlegen
            Angestellter TestAngestellter1 = new Angestellter("Jana Schulz", 20, 1700.0, TestAbteilung);
            Angestellter TestAngestellter2 = new Angestellter("Jasmin Schimdt", 20, 1700.0, TestAbteilung);

            // Mitarbeiter zur Angestellten-Liste hinzuf¸gen
            TestAbteilung.Add_Angestellter_Angestelltenliste(TestAngestellter1);
            TestAbteilung.Add_Angestellter_Angestelltenliste(TestAngestellter2);

            // Mithilfe einer For-Schleife werden alle Angestellten durchgegangen und es werden die jeweiligen Objekt-Attribute ¸berpr¸ft --> Name, Gehalt, Alter --> alles was das jeweilige Objekt kennzeichnet
            int i = 0;
            foreach (Angestellter testangestellter in TestAbteilung.Angestelltenliste)
            {
                switch (i)
                {
                    case 0:
                        Assert.AreEqual(testangestellter.Name, "Jana Schulz");
                        Assert.AreEqual(testangestellter.Alter, 20);
                        Assert.AreEqual(testangestellter.Gehalt, 1700.0);
                        break;
                    case 1:
                        Assert.AreEqual(testangestellter.Name, "Jasmin Schimdt");
                        Assert.AreEqual(testangestellter.Alter, 20);
                        Assert.AreEqual(testangestellter.Gehalt, 1700.0);
                        break;                   
                }
                i++;
            }         
        }
    }
}