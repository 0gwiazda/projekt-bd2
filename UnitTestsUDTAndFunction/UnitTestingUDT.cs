using System.Data.SqlClient;
using Projekt;

namespace UnitTestsUDTAndFunction
{
    [TestClass]
    public class AddressUnitTests 
    {
        [TestMethod]
        public void AddressParseTest()
        {
            Address addr = Address.Parse("ul. testowa 32,,12-345,Toster");

            Assert.AreEqual("ul. testowa 32, , 12-345 Toster", addr.ToString());
        }

        [TestMethod]
        public void AddressFilterTests()
        {
            Address addr = Address.Parse("ul. testing 23,test,12-345,test york");

            Xunit.Assert.Multiple(
                    () => Xunit.Assert.Equal(1, addr.Filter("addr_line1", "ul. testing 23")),
                    () => Xunit.Assert.Equal(1, addr.Filter("addr_line2", "test")),
                    () => Xunit.Assert.Equal(1, addr.Filter("city", "test york")),
                    () => Xunit.Assert.Equal(1, addr.Filter("code","12-345")) 
                );
        }
    }
    [TestClass]
    public class AnimalUnitTests
    {
        [TestMethod]
        public void AnimalParseTest()
        {
            Animal animal = Animal.Parse("Testing,test,0,1,3,0,3,false");

            Assert.AreEqual("Testing test, Spider, Male, Adult, Danger: Safe, Not Endangered", animal.ToString());
        }

        [TestMethod]
        public void AnimalCheckDangerTest()
        {
            Animal animal = Animal.Parse("Testing,test,2,1,3,0,2,false");
            Animal animal2 = Animal.Parse("Testing,test,2,1,3,0,6,false");

            Xunit.Assert.Multiple(
                () => Assert.AreEqual(1, animal2.checkDanger(animal.Danger)),
                () => Assert.AreEqual(0, animal2.checkDanger(6)),
                () => Assert.AreEqual(-1, animal.checkDanger(animal2.Danger)),
                () => Assert.AreEqual(-2, animal.checkDanger(8)),
                () => Assert.AreEqual(-3, animal.checkDanger(10))
                ) ;
        }

        [TestMethod]
        public void AnimalFilterTests()
        {
            Animal animal = Animal.Parse("Testing,test,2,1,3,0,2,false");

            Xunit.Assert.Multiple(
                () => Assert.AreEqual(1, animal.Filter("family", "Testing")),
                () => Assert.AreEqual(1, animal.Filter("species", "Test")),
                () => Assert.AreEqual(1, animal.Filter("type", "2")),
                () => Assert.AreEqual(1, animal.Filter("gender", "1")),
                () => Assert.AreEqual(1, animal.Filter("numofchildren", "0")),
                () => Assert.AreEqual(1, animal.Filter("danger", "Safe")),
                () => Assert.AreEqual(1, animal.Filter("endangered", "false"))
                );
        }
    }
    [TestClass]
    public class CITESDocumentUnitTests
    {
        [TestMethod]
        public void CITESDocumentParseTest() 
        {
            CITESDocument cites = CITESDocument.Parse("Adam Kowalski;Testing,test,0,1,3,0,3,true;20.01.2001");

            Assert.AreEqual("000300101422190418190418310200120015",cites.ToString());
        }

        [TestMethod]
        public void CITESDocumentFilterTest()
        {
            CITESDocument cites = new CITESDocument("Testing,test,0,1,3,0,3,false", "Adam Kowalski", "20.01.2001");

            Xunit.Assert.Multiple(
                () => Assert.AreEqual(1, cites.Filter("owner", "Adam Kowalski")),
                () => Assert.AreEqual(1, cites.Filter("date", "20.01.2001")),
                () => Assert.AreEqual(1, cites.Filter("animal.family", "Testing"))
                );
        }
    }
    [TestClass]
    public class DangerDocumentUnitTests 
    {
        [TestMethod]
        public void DangerDocumentParseTest() 
        {
            DangerDocument dan = DangerDocument.Parse("Adam Kowalski;Testing,test,0,1,3,0,3,false;20.01.2001");

            Assert.AreEqual("00030010142219041819041803200120017", dan.ToString());
        }

        [TestMethod]
        public void DangerDocumentFilterTest() 
        {
            DangerDocument dan = new DangerDocument("Adam Kowalski", "Testing,test,0,1,3,0,3,false", "20.01.2001");

            Xunit.Assert.Multiple(
                () => Assert.AreEqual(1, dan.Filter("owner", "Adam Kowalski")),
                () => Assert.AreEqual(1, dan.Filter("date", "20.01.2001")),
                () => Assert.AreEqual(1, dan.Filter("animal.species", "test"))
                );
        }
    }
    [TestClass]
    public class EmailAddressUnitTests 
    {
        [TestMethod]
        public void EmailAddressParseTest() 
        {
            EmailAddress email = EmailAddress.Parse("test@test.com");

            Assert.AreEqual("test@test.com", email.ToString());
        }

        [TestMethod]
        public void EmailAddressFilterTests() 
        {
            EmailAddress email = new EmailAddress("test@test.com");

            Xunit.Assert.Multiple(
                () => Assert.AreEqual(1, email.Filter("email", "test@test.com")),
                () => Assert.AreEqual(1, email.Filter("domain", "test.com"))
                );
        }
    }

    [TestClass]
    public class EnclosureUnitTests 
    {

        [TestMethod]
        public void EnclosureParseTest() 
        {
            Enclosure enc = Enclosure.Parse("terrarium,30x30x30,false,");

            Assert.AreEqual("terrarium 30cm x 30cm x 30cm ", enc.ToString());
        }

        [TestMethod]
        public void EnclosureFilterTests() 
        {
            Enclosure enc = new Enclosure() { Type = "terrarium", Length = 30, Height = 30, Width = 30, Enviroment = "desert", Decorated = true };
            Enclosure enc2 = new Enclosure() { Type = "terrarium", Length = 30, Height = 30, Width = 30, Enviroment = "desert", Decorated = true };

            Xunit.Assert.Multiple(
                () => Assert.AreEqual(1, enc.Filter("type", "terrarium")),
                () => Assert.AreEqual(1, enc.Filter("length", "30")),
                () => Assert.AreEqual(1, enc.Filter("width", "30")),
                () => Assert.AreEqual(1, enc.Filter("height", "30")),
                () => Assert.AreEqual(1, enc.Filter("decorated", "true")),
                () => Assert.AreEqual(1, enc.Filter("enviroment", "desert"))
                );
        }
    }
}