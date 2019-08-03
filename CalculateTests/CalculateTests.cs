using System;
using Calculate;
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

        [TestMethod()]
        public void MoneySavedCalcTest()
        {
            Assert.Fail();
        }

        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        //public void MoneySavedCalcTest_isString()
        //{
        //    //Arrange
        //    string NumberOfDays = 13M;
        //    string AverageDrinksPerDay = "2m";
        //    string AverageCostPerDrink = null;

        //    //Act
        //    var actual = Calculate.Calculate.MoneySavedCalc(NumberOfDays, AverageDrinksPerDay, AverageCostPerDrink);
        //    //Assert

        //}

        //[TestMethod()]
        //public void ConvertTodecimalTest()
        //{
        //    Assert.Fail();
        //}
    }
}
