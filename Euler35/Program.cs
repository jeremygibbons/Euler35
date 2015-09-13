using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler35
{
    public class Program
    {
        static List<int> circularPrimes;

        static void Main(string[] args)
        {
            circularPrimes = new List<int>();
            circularPrimes.Add(2);
            circularPrimes.Add(3);
            circularPrimes.Add(5);
            circularPrimes.Add(7);

            //Any circular primes larger than 7 can only be composed of
            //digits 1, 3, 7 and 9.
            //0, 2, 4, 6 and 8 will lead to at least 1 even - thus non prime - permutation
            //5 will lead to at least one multiple of 5 which is not prime

            List<int> candidates = new List<int>();
            
            int[] digits = new int[] { 1, 3, 7, 9 };

            List<int> prevGen = new List<int>(digits);

            List<int> thisGen = new List<int>();

            int stages = 5;

            while (stages > 0)
            {
                foreach (int d in digits)
                {
                    thisGen.AddRange(prevGen.Select(x => x * 10 + d));
                }
                candidates.AddRange(thisGen);
                prevGen = thisGen.ToList();
                thisGen.Clear();
                stages--;
            }

            candidates.Sort();

            foreach(int a in candidates)
            {
                if (SmallestPermutation(a) != a)
                    continue; //we already checked this number's permutations

                if(IsCircularPrime(a) == true)
                {
                    foreach(int b in Permutations(a))
                    {
                        circularPrimes.Add(b);
                    }
                }
            }
            Console.WriteLine(circularPrimes.Count);
            Console.ReadLine();
        }

        public static int SmallestPermutation(int a)
        {
            int smallest = a;
            foreach(int b in Permutations(a))
            {
                if (b < smallest)
                    smallest = b;
            }
            return smallest;
        }

        public static IEnumerable<int> Permutations(int a)
        {
            yield return a;

            int[] set = NumbersIn(a);

            Queue<int> q = new Queue<int>(set);

            for (int i = 1; i < set.Length; i++)
            {
                q.Enqueue(q.Dequeue());
                int r = NumberFrom(q.ToArray<int>());
                if (r == a) // number is all the same digits
                    yield break;
                yield return r;
            }
            yield break;
        }

        static bool IsPrime(int n)
        {
            if (n % 2 == 0)
                return false;
            for(int i = 3; i <= (int) Math.Sqrt(n); i += 2)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        static bool IsCircularPrime(int n)
        {
            foreach (int b in Permutations(n))
            {
                if (IsPrime(b) == false)
                    return false;
            }
            return true;
        }

        public static int[] NumbersIn(int value)
        {
            var numbers = new List<int>();

            for (; value > 0; value /= 10)
                numbers.Add(value % 10);

            int[] resultArr = numbers.ToArray();
            Array.Reverse(resultArr);
            return resultArr;
        }

        public static int NumberFrom(int[] digits)
        {
            int value = 0;
            foreach (int d in digits)
            {
                value = value * 10 + d;
            }
            return value;
        }
    }
}
