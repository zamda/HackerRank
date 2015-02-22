using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strplay
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = ReadInput();
            int max = 0;
            int[,] mem = new int[input.Length, input.Length];
            for (int i = 1; i < input.Length-1; i++)
            {
                int out1 = LongestPalindrome(input, 0, i, mem);
                int out2 = LongestPalindrome(input, i + 1, input.Length - 1, mem);
                if (out1 * out2 > max)
                {
                    max = out1 * out2;
                }
            }

            Console.WriteLine(max);
        }


        static int LongestPalindrome(string input, int start, int end, int[,] mem)
        {
            if (mem[start, end] > 0)
            {
                return mem[start, end];
            }
            if (end < start)
            {
                return 0;
            }
            if (end == start)
            {
                return 1;
            }

            if (input[start] == input[end])
            {
                if (mem[start + 1, end - 1] == 0)
                {
                    mem[start + 1, end - 1] = LongestPalindrome(input, start + 1, end - 1, mem);
                }
                return 2 + mem[start + 1, end - 1];
            }
            else
            {
                if (mem[start + 1, end] == 0)
                {
                    mem[start + 1, end] = LongestPalindrome(input, start + 1, end, mem);
                }

                if (mem[start, end - 1] == 0)
                {
                    mem[start, end - 1] = LongestPalindrome(input, start, end - 1, mem);
                }
                return Math.Max(mem[start + 1, end], mem[start, end - 1]);
            }
        }


        private static string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}
