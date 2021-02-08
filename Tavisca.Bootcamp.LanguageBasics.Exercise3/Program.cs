using System;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int[] calorie = new int[protein.Length];
            for (int i = 0; i < protein.Length; i++)
            {
                calorie[i] = 9 * fat[i] + 5 * (carbs[i] + protein[i]);

            }
           
            int[] result = new int[dietPlans.Length];
            for (int i=0; i < dietPlans.Length; i++)
            {
                int[] effectiveIndex = new int[protein.Length];
                for (int j = 0; j < protein.Length; j++)
                {
                    effectiveIndex[j] = j;
                }
                foreach (char p in dietPlans[i])
                {
                    if (p == 'P')
                    {
                        effectiveIndex = GetMax(protein, effectiveIndex);
                        if (effectiveIndex.Length == 1)
                        {
                            break;
                        }
                    }
                    if (p == 'p')
                    {
                        effectiveIndex = GetMin(protein, effectiveIndex);
                        if (effectiveIndex.Length == 1)
                        {
                            break;
                        }
                    }
                    if (p == 'C')
                    {
                        effectiveIndex = GetMax(carbs, effectiveIndex);
                        if (effectiveIndex.Length == 1)
                        {
                            break;
                        }
                    }
                    if (p == 'c')
                    {
                        effectiveIndex = GetMin(carbs, effectiveIndex);
                        if (effectiveIndex.Length == 1)
                        {
                            break;
                        }
                    }
                    if (p == 'F')
                    {
                        effectiveIndex = GetMax(fat, effectiveIndex);
                        if (effectiveIndex.Length == 1)
                        {
                            break;
                        }
                    }
                    if (p == 'f')
                    {
                        effectiveIndex = GetMin(fat, effectiveIndex);
                        if (effectiveIndex.Length == 1)
                        {
                            break;
                        }
                    }
                    if (p == 'T')
                    {
                        effectiveIndex = GetMax(calorie, effectiveIndex);
                        if (effectiveIndex.Length == 1)
                        {
                            break;
                        }
                    }
                    if (p == 't')
                    {
                        effectiveIndex = GetMin(calorie, effectiveIndex);
                        if (effectiveIndex.Length == 1)
                        {
                            break;
                        }
                    }

                }

           
                result[i] = effectiveIndex[0];

            }




            return result;
        }

        public static int[] GetMin(int[] arr, int[] effectiveIndex)
        {
            List<int> result = new List<int>();
            int min = int.MaxValue;
            foreach (int i in effectiveIndex)
            {
                if (min > arr[i])
                {
                    min = arr[i];
                }
            }
            foreach (int i in effectiveIndex)
            {
                if (arr[i] == min)
                {
                    result.Add(i);
                }
            }

            return result.ToArray();
        }
        public static int[] GetMax(int[] arr, int[] effectiveIndex)
        {
            List<int> result = new List<int>();
            int max = int.MinValue;
            foreach (int i in effectiveIndex)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                }
            }
            foreach (int i in effectiveIndex)
            {
                if (arr[i] == max)
                {
                    result.Add(i);
                }
            }

            return result.ToArray();
        }
    }
}
