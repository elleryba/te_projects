using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Classes;

namespace TDD.Tests.Classes
{
    [TestClass]
    public class KataRomanNumeralTests
    {
        KataRomanNumeral kata;

        [TestInitialize]
        public void Initialize()
        {
            kata = new KataRomanNumeral();
        }

        [TestMethod]
        public void RomanNumeral_Ones()
        {

            Assert.AreEqual("I", kata.GetRomanNumeral(1));
            Assert.AreEqual("II", kata.GetRomanNumeral(2));
            Assert.AreEqual("III", kata.GetRomanNumeral(3));
        }

        
        [TestMethod]
        public void RomanNumeral_Fives()
        {
            //Assert
            Assert.AreEqual("V", kata.GetRomanNumeral(5));
            Assert.AreEqual("VI", kata.GetRomanNumeral(6));
            Assert.AreEqual("VII", kata.GetRomanNumeral(7));
        }

        [TestMethod]
        public void RomanNumeral_Tens()
        {
            //Assert
            Assert.AreEqual("X", kata.GetRomanNumeral(10));
            Assert.AreEqual("XI", kata.GetRomanNumeral(11));
            Assert.AreEqual("XV", kata.GetRomanNumeral(15));
            Assert.AreEqual("XXVI", kata.GetRomanNumeral(26));
        }

        [TestMethod]
        public void RomanNumeral_Fifties()
        {
            Assert.AreEqual("L", kata.GetRomanNumeral(50));
            Assert.AreEqual("LX", kata.GetRomanNumeral(60));
            Assert.AreEqual("LXXVIII", kata.GetRomanNumeral(78));
        }

        [TestMethod]
        public void RomanNumeral_OtherPlaceholders()
        {
            Assert.AreEqual("C", kata.GetRomanNumeral(100));
            Assert.AreEqual("D", kata.GetRomanNumeral(500));
            Assert.AreEqual("M", kata.GetRomanNumeral(1000));
        }

        [TestMethod]
        public void RomanNumeral_Subtractive()
        {
            Assert.AreEqual("MIV", kata.GetRomanNumeral(1004));
            Assert.AreEqual("DIV", kata.GetRomanNumeral(504));
            Assert.AreEqual("CDLXII", kata.GetRomanNumeral(462));
            Assert.AreEqual("CDXCIX", kata.GetRomanNumeral(499));
            Assert.AreEqual("XLI", kata.GetRomanNumeral(41));
            Assert.AreEqual("XCV", kata.GetRomanNumeral(95));
        }


        /* Solve it long form first */
        //[TestMethod]
        //public void RomanNumeral_Subtractive()
        //{
        //    Assert.AreEqual("MIIII", kata.GetRomanNumeral(1004));
        //    Assert.AreEqual("DIIII", kata.GetRomanNumeral(504));
        //    Assert.AreEqual("CCCCLXII", kata.GetRomanNumeral(462));
        //    Assert.AreEqual("CCCCLXXXXVIIII", kata.GetRomanNumeral(499));
        //    Assert.AreEqual("XXXXI", kata.GetRomanNumeral(41));
        //    Assert.AreEqual("LXXXXV", kata.GetRomanNumeral(95));
        //}
    }
}
