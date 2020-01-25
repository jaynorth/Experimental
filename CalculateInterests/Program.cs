using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateInterests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("montant de départ ?");
            var BaseAmount = Console.ReadLine();

            Console.WriteLine("montant ajouté chaque année");
            var AddedAmount = Console.ReadLine();

            Console.WriteLine("nombre d'année");
            var years = Console.ReadLine();

            Console.WriteLine("pourcent interet");
            var interest = Console.ReadLine();


            Console.WriteLine("Taux Impot sur benef?");
            var impotSource = Console.ReadLine();

            OutputCalculations(BaseAmount, AddedAmount, years, interest, impotSource);

        }

        private static void OutputCalculations(string baseAmount, string addedAmount, string years, string interest, string impotSource)
        {
            decimal Baseamount = Convert.ToDecimal(baseAmount);
            decimal AddedAmount = Convert.ToDecimal(addedAmount);
            int Years = Convert.ToInt16(years);
            decimal Interest = Convert.ToDecimal(interest);
            decimal ImpotSource = Convert.ToDecimal(impotSource);

            decimal Capital = Baseamount;
            Console.WriteLine("Capital Year 0 : " + Capital);
            decimal YearInterest = 0;

            for (int i = 1; i <= Years; i++)
            {
                YearInterest = (Capital * (Interest / 100));
                var Tax = YearInterest * (ImpotSource / 100);
                Capital = YearInterest + AddedAmount + Capital - Tax;

                Console.WriteLine("Capital Year {0}: {1} ",i,Math.Round(Capital, 2));
                Console.WriteLine("Interest Year {0} : {1}", i, Math.Round(YearInterest, 2));
                Console.WriteLine("Tax Year {0} : {1}", i, Math.Round(Tax, 2));
            }

            Console.ReadKey();

        }
    }
}
