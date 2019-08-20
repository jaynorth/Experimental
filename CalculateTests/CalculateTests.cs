using Calculate;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculateTests
{
    [TestClass]
    public class CalculateTests
    {
        [TestMethod]
        public void MoneySavedCalc_testValid()
        {
            //Arrange
            decimal NumberOfDays = 13M;
            decimal AverageDrinksPerDay = 4m;
            decimal AverageCostPerDrink = 2m;

            decimal expected = 104M;
            //Act
            var actual = Calculate.Calculate.MoneySavedCalc(NumberOfDays, AverageDrinksPerDay, AverageCostPerDrink);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MoneySavedCalc_testValidAndSame()
        {
            //Arrange
            decimal NumberOfDays = 13M;
            decimal AverageDrinksPerDay = 2m;
            decimal AverageCostPerDrink = 2m;

            decimal expected = 52M;
            //Act
            var actual = Calculate.Calculate.MoneySavedCalc(NumberOfDays, AverageDrinksPerDay, AverageCostPerDrink);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MoneySavedCalc_testValidAndSameXXX()
        {
            //Arrange
            decimal NumberOfDays = 11M;
            decimal AverageDrinksPerDay = 2m;
            decimal AverageCostPerDrink = 3m;

            decimal expected = 66M;
            //Act
            var actual = Calculate.Calculate.MoneySavedCalc(NumberOfDays, AverageDrinksPerDay, AverageCostPerDrink);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MoneySavedCalc_testValidActualIsZero()
        {
            //Arrange
            decimal NumberOfDays = 13M;
            decimal AverageDrinksPerDay = 2m;
            decimal AverageCostPerDrink = 0m;

            decimal expected = 0M;
            //Act
            var actual = Calculate.Calculate.MoneySavedCalc(NumberOfDays, AverageDrinksPerDay, AverageCostPerDrink);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void ConvertTodecimalTest_Valid()
        {
            //Arrange
            decimal whatever = 13m;
            decimal expected = 13m;
            //Act
            var actual = Calculate.Calculate.ConvertTodecimal(whatever);
            //Assert
            Assert.AreEqual(expected, actual);
        }





        [TestMethod]

        public void ConvertTodecimalTest_String_Valid()
        {
            //Arrange
            string whatever = "14";
            decimal expected = 14m;
            //Act
            var actual = Calculate.Calculate.ConvertTodecimal(whatever);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void MoneySavedCalcTest_isString_null()
        {
            //Arrange
            string NumberOfDays = "13M";
            string AverageDrinksPerDay = "2m";
            string AverageCostPerDrink = null;

            //Act
            var actual = Calculate.Calculate.MoneySavedCalc(NumberOfDays, AverageDrinksPerDay, AverageCostPerDrink);
            //Assert

        }

    }
}
