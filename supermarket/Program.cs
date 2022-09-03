using System;
using System.Linq;

namespace Tinkov
{
    public class Programm
    {
        public static void Count(string text, int q, string[] lines)
        {
            int steps = 0;
            int j = 0;
            int start = 0;
            int end = 0;
            var line = new string[2];
            string tempText = String.Empty;
            for (int k = 0; k < q; k++)
            {
                line = lines[k].Split(' ');
                start = int.Parse(line[0]);
                end = int.Parse(line[1]);
                if (start < 1 || start > end || end > text.Length)
                {
                    throw new ArgumentOutOfRangeException("bad line");
                }
                tempText = text[(start - 1)..end];
                var textLine = new char[tempText.Length];
                textLine = tempText.ToArray();
                Array.Sort(textLine);
                for (int i = 0; ; i++)
                {
                    if (textLine[j] == tempText[i])
                    {
                        j++;
                    }
                    if (j == textLine.Length - 1)
                    {
                        steps++;
                        break;
                    }
                    if (i == textLine.Length - 1)
                    {
                        i = -1;
                    }
                    steps++;
                }
                Console.WriteLine(steps);
                steps = 0; j = 0;
            }
        }

        public static void Main()
        {
            string s = Console.ReadLine();
            if (s.Any(n => n < 'a' || n > 'z'))
            {
                throw new ArgumentException("bad line");
            }
            if (s.Length < 1 || s.Length > Math.Pow(10, 5))
            {
                throw new ArgumentOutOfRangeException("text is incorrect");
            }
            int q = int.Parse(Console.ReadLine());
            if (q < 1 || q > Math.Pow(10, 5))
            {
                throw new ArgumentOutOfRangeException("q is incorrect");
            }
            var lines = new string[q];
            for (int i = 0; i < q; i++)
            {
                lines[i] = Console.ReadLine();
            }
            Count(s, q, lines);
        }
    }
}
