using System;
using System.Collections.Generic;
using System.Linq;

namespace ATMDenomination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> amount = new List<int>() { 100, 30, 50, 60, 80, 140, 230, 370, 610, 980 };

            List<List<int>> denominationsList = new List<List<int>>();

            denominationsList.Add(new List<int> { 10 });
            denominationsList.Add(new List<int> { 50, 10 });
            denominationsList.Add(new List<int> { 100, 50, 10 });


            foreach (var item in amount)
            {
                Console.WriteLine(item + " Denominations are as Below :");
                foreach (List<int> denominations in denominationsList)
                {
                    if (item >= denominations[0])
                    {
                        var result = FindDenominations(item, denominations);
                        PrintDenominations(result);
                        Console.WriteLine("");
                    }
                }
                Console.WriteLine("");


            }

            Console.ReadLine();

        }

         static void PrintDenominations(List<int> result)
        {
            int xcnt = 0;
            foreach (var r in result)
            {
                Console.Write(r);
                if ((xcnt % 2) == 0)
                    Console.Write(" * ");
                else
                {
                    Console.Write(" EUR");
                }

                xcnt++;
                if (xcnt < result.Count - 1)
                    Console.Write(" + ");

            }
        }

         static List<int> FindDenominations(int amount, List<int> denominations)
        {
            var result = new List<int>();
            var count = 0;
            for (var i = 0; i < denominations.Count; i++)
            {
                if (amount >= denominations[i])
                {
                    count = amount / denominations[i];
                    amount = amount % denominations[i];
                    result.Add(count);
                    result.Add(denominations[i]);
                }
            }
            return result;
        }


    }
}
