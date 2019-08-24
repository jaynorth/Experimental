using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculate;
using Xunit;

namespace Calculate.XunitTests
{
    public class CalculateTests
    {
        [Theory]
        //Arrange
        [InlineData(13, 4, 2 , 104)]
        [InlineData(13, 2, 2, 52)]
        [InlineData(11, 2, 3, 66)]
        [InlineData(13, 2, 0, 0)]
        [MemberData(nameof(TestValues))]
        public void MoneySavedCalc_testValid_multiple(decimal NumberOfDays,decimal AverageDrinksPerDay, decimal AverageCostPerDrink, decimal expected)
        {
            //Act
            decimal actual = Calculate.MoneySavedCalc(NumberOfDays, AverageDrinksPerDay, AverageCostPerDrink);

            //Assert
            Assert.Equal(expected, actual);
        }
        public static IEnumerable<object[]> TestValues =
            new List<object[]>
        {
            new object[]{ Decimal.MaxValue, 4, 0, Decimal.MaxValue },
        };

        [Fact]
        public void ConvertTodecimalTest_Valid()
        {
            //Arrange
            decimal whatever = 13m;
            decimal expected = 13m;
            
            //Act
            var actual = Calculate.ConvertTodecimal(whatever);
            
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertTodecimalTest_String_Valid()
        {
            //Arrange
            string whatever = "14";
            decimal expected = 14m;
            
            //Act
            var actual = Calculate.ConvertTodecimal(whatever);
           
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
