using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LumpSumVsDCA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lumpsum amount ");
            var lumpSum = Console.ReadLine();

            Console.WriteLine("Share Price Low");
            var shareCostLow = Console.ReadLine();

            Console.WriteLine("Share Price High");
            var shareCostHigh = Console.ReadLine();

            Console.WriteLine("LowShareCost Return, Price of Share: {0}",shareCostLow );
            var amountOfSharesLow = CalculatShareReturn(lumpSum, shareCostLow);
            Console.WriteLine("LowShareCost Return, Price of Share: {0}", shareCostHigh);
            var amountOfSharesHigh = CalculatShareReturn(lumpSum, shareCostHigh);

            var differenceInShares = amountOfSharesLow - amountOfSharesHigh;
            Console.WriteLine("Difference in Shares : {0}", differenceInShares);

            Console.ReadKey();
        }



        private static int CalculatShareReturn(string lumpSum, string shareCost)
        {
            decimal LumpSum = decimal.Parse(lumpSum, CultureInfo.InvariantCulture);
            decimal ShareCost = decimal.Parse(shareCost, CultureInfo.InvariantCulture);

            int NumberOfShares = Convert.ToInt16(Math.Round((LumpSum / ShareCost), 0));

            var CashLeftOver = LumpSum % ShareCost;

            Console.WriteLine("Amount of shares : {0}", NumberOfShares);
            Console.WriteLine("Cash Leftover : {0}", CashLeftOver);

            return NumberOfShares;
        }
    }
}
