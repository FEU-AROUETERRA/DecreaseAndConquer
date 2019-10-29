using Discrete_Solution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecreaseAndConquer
{
    class Program
    {
        public static bool DecreaseAndConquer(int limit, List<int> numbers)
        {
            //Natural number = new Natural();
            //Natural gcd;
            //int relativelyprime = 1;
            List<Natural> list = new List<Natural>();
            List<bool> pairwise = new List<bool>();
            var pairs = new Dictionary<int, List<int>>();
            foreach (var n in numbers)
            {
                list.Add(new Natural(n));
            }
            for (int i = 0; i <= limit-1; i++)
            {
                var current = new Natural(list[i].GetIntValue());
                
                for (int j=0; j <= limit-1; j++)
                {
                    if ((j == i) && (j != limit - 1))
                    {
                        j++;
                    }
                    else if (i == limit - 1 && j == limit - 1)
                    {
                        continue;
                    }
                    if (pairs.ContainsKey(list[i].GetIntValue()))
                    {
                        pairs[list[i].GetIntValue()].Add(list[j].GetIntValue());
                    }
                    else
                    {
                        pairs.Add(list[i].GetIntValue(), new List<int> { list[j].GetIntValue() });
                    }
                    if (pairs.ContainsKey(list[j].GetIntValue())){
                        if (pairs[list[j].GetIntValue()].Contains(list[i].GetIntValue()))
                        {
                            continue;
                        }
                    }
                    

                    
                    var sub = new Natural(current.GetIntValue());
                    
                    //Console.WriteLine("DOING: " + sub.GetIntValue() + " GCD ON " + list[j].GetIntValue());
                    var subprogram = sub.Gcd(list[j]);
                    //Console.WriteLine("EQUAL TO: " + subprogram.GetIntValue());
                    //GCD({0},{1}) = {3}
                    if (subprogram.GetIntValue() == 1)
                    {
                        pairwise.Add(true);
                    }
                    else
                    {
                        pairwise.Add(false);
                    }
                    Console.WriteLine("GCD(" + list[i].GetIntValue()+","+list[j].GetIntValue() + ") = " + subprogram.GetIntValue()) ;
                }
            }
            bool PairwiseRelativelyPrime;
            if (pairwise.Contains(false))
            {
                PairwiseRelativelyPrime = false;
            }
            else
            {
                PairwiseRelativelyPrime = true;
            }
            
            return PairwiseRelativelyPrime;
        }
        static void Main(string[] args)
        {
            // Natural op;
            List<int> numbers = new List<int>();
            List<string> str = new List<string>();
            Console.WriteLine("Enter the limit: "); //4
            int limit = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a space delimited set of numbers: "); // 13 7 11 4
            string s = Console.ReadLine();
            str = s.Split(' ').ToList();
            numbers = str.Select(int.Parse).ToList();
            Console.WriteLine(" ");
            if (!DecreaseAndConquer(limit, numbers))
            {
                foreach (var i in str)
                {
                    Console.Write(i + ",");
                }
                Console.Write(" are NOT Pairwise Relatively Prime.");
            }
            else
            {
                foreach (var i in str)
                {
                    Console.Write(i + ", ");
                }
                Console.Write("are Pairwise Relatively Prime.");
            }
            Console.ReadLine();
        }
    }
}
