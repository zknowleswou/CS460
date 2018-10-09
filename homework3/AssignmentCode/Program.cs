using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            if (args.Length < 1)
            {
                Console.WriteLine("Please invoke with the max value to print binary up to, like this:");
                Console.WriteLine("Homework3.exe 12");
                return;
            }
            try
            {
                n = Int32.Parse(args[0]);
            }
            catch (FormatException e)
            {
                Console.WriteLine("I'm sorry, I can't understand the number: " + args[0]);
                return;
            }
            List<string> output = GenerateBinaryRepresentationList(n);
            // Print it right justified.  Longest string is the last one.
            // Print enough spaces to move it over the correct distance
            int maxLength = output.Last().Length;
            foreach (var s in output)
            {
                for (int i = 0; i < maxLength - s.Length; ++i)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(s);
            }
        }

        static List<string> GenerateBinaryRepresentationList(int n)
        {
            // Create an empty queue of strings with which to perform the traversal
            LinkedQueue<StringBuilder> q = new LinkedQueue<StringBuilder>();

            // A list for returning the binary values
            List<string> output = new List<string>();

            if (n < 1)
            {
                // binary representation of negative values is not supported
                // return an empty list
                return output;
            }

            // Enqueue the first binary number.  Use a dynamic string to avoid string concat
            q.Push(new StringBuilder("1"));

            // BFS 
            while (n-- > 0)
            {
                // print the front of queue 
                StringBuilder sb = q.Pop();
                output.Add(sb.ToString());

                // Make a copy
                StringBuilder sbc = new StringBuilder(sb.ToString());

                // Left child
                sb.Append('0');
                q.Push(sb);
                // Right child
                sbc.Append('1');
                q.Push(sbc);
            }
            return output;
        }
    }
}
