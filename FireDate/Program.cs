using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculate;

namespace FireDate
{
    class Program
    {


        static void Main(string[] args)
        {

            Program.StartConsole();

            
        }

        public static void StartConsole()
        {
            Console.Clear();

            Console.WriteLine(DateTime.Now);

            Console.WriteLine("montant déja investi ?");
            var AmountInvested = Console.ReadLine();

            Console.WriteLine("montant prévu ajouté chaque mois");
            var MonthlyContribution = Console.ReadLine();

            Console.WriteLine("Futur budget souhaité par mois");
            var MonthlyProjectedspendings = Console.ReadLine();

            Console.WriteLine("Impot source");
            var ImpotSource = Console.ReadLine();

            Console.WriteLine("retour moyen en pourcent");
            var AverageReturnPercent = Console.ReadLine();

            Console.WriteLine("montant projeté retiré par année (Withdrawal Rate) en %");
            var withdrawalRatePercent = Console.ReadLine();

            var firedate = Calculate.Calculate.ReturnFireDate(AmountInvested, MonthlyContribution, MonthlyProjectedspendings, ImpotSource, withdrawalRatePercent, AverageReturnPercent);

            Console.WriteLine("Fire Date : Year {0} Month {1}", firedate.Year, firedate.Month);

            Console.WriteLine();

            Console.WriteLine("Restart ?");

            Console.ReadKey();

            StartConsole();

        }

    }
        
}
