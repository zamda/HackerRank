using System;
using System.Collections.Generic;

namespace longest_increasing_subsequence
{
    public static class Ext
    {
        public static int BinarySearch<T>(this IList<T> list, int index, int length, T value, IComparer<T> comparer)
        {
            if (list == null) throw new ArgumentNullException("list");
            else if (index < 0 || length < 0)
                throw new ArgumentOutOfRangeException((index < 0) ? "index" : "length");
            else if (list.Count - index < length) throw new ArgumentException();
            int lower = index; int upper = (index + length) - 1;
            while (lower <= upper)
            {
                int adjustedIndex = lower + ((upper - lower) >> 1);
                int comparison = comparer.Compare(list[adjustedIndex], value);
                if (comparison == 0) return adjustedIndex;
                else if (comparison < 0) lower = adjustedIndex + 1;
                else upper = adjustedIndex - 1;
            }
            return ~lower;
        }

        public static int BinarySearch<T>(this IList<T> list, T value, IComparer<T> comparer)
        {
            return list.BinarySearch(0, list.Count, value, comparer);
        }
        public static int BinarySearch<T>(this IList<T> list, T value) where T : IComparable<T>
        {
            return list.BinarySearch(value, Comparer<T>.Default);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            List<int> input = ReadInput();
            Console.WriteLine(Solve(input));
        }

        public static int FindPredecessor(IList<int> list, int elem)
        {
            int pos = list.BinarySearch(elem);
            return pos > 0 ? pos : ~pos - 1;
        }

        private static int Solve(List<int> input)
        {
            if (input.Count == 0)
            {
                return 0;
            }

            SortedList<int, int> mem = new SortedList<int, int>(input.Count);
            int max = 0;
            for (int i = 0; i < input.Count; i++)
            {
                int pos = FindPredecessor(mem.Keys, input[i]);
                int currentLen = 1;
                if (pos < 0)
                {
                    if (mem.Count > 0)
                    {
                        mem.Remove(mem.Keys[0]);
                    }
                }
                else
                {
                    currentLen = mem[mem.Keys[pos]];

                    if (mem.ContainsKey(input[i]))
                    {
                        mem.Remove(mem.Keys[pos]);
                    }
                    else if (pos + 1 < mem.Count && mem.Keys[pos + 1] > input[i] && mem[mem.Keys[pos + 1]] <= currentLen + 1)
                    {
                        mem.Remove(mem.Keys[pos + 1]);
                        currentLen += 1;
                    }
                    else
                    {
                        currentLen += 1;
                    }
                }

                mem.Add(input[i], currentLen);
                if (max < currentLen)
                {
                    max = currentLen;
                }
            }
            return max;
        }

        private static List<int> ReadInput()
        {
            int listLength = int.Parse(Console.ReadLine());
            List<int> input = new List<int>();
            for (int i = 0; i < listLength; i++)
            {
                input.Add(int.Parse(Console.ReadLine()));
            }
            return input;
        }
    }
}
