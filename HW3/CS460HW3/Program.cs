using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS460HW3
{
    public class Program
    {
        private static string word;

        private static void PrintUsage()
        {
            Console.WriteLine("Usage is:\n" +
                "\tjava Main C inputfile outputfile\n\n" +
                "Where:" +
                "  C is the column number to fit to\n" +
                "  inputfile is the input text file \n" +
                "  outputfile is the new output file base name containing the wrapped text.\n" +
                "e.g. java Main myfile.txt myfile_wrapped.txt");
        }

        public static int Main(String[] args)
        {
            int C = 1000;                     // Column length to wrap to
            String InputFilename;
            String OutputFilename;
            String line = null;
           
            // Read the command line arguments ...
            if (args.Length != 3)
            {
                Console.WriteLine(args.Length);
                PrintUsage();
                Environment.Exit(1);
            }
            try
            {
                C = int.Parse(args[0]);
                InputFilename = args[1];
                OutputFilename = args[2];
                
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not find the input file.");
                Console.WriteLine(line);
                return (1);
            }
            catch (Exception)
            {
                Console.WriteLine("Something is wrong with the input.");
                PrintUsage();
                return (2);
            }

            using (StreamReader sr = new StreamReader(InputFilename))
            {
                // Read the stream to a string, and write the string to the console.
                line = sr.ReadToEnd();
            }

            line = line.Replace("\r\n", " ");
            IQueueInterface<String> words = new LinkedQueue<string>();

            int WordStart = 0;
            for (int k = 0; k < line.Length; k++)
            {
                if (line[k] == ' ') {
                    words.Push(line.Substring(WordStart, k - WordStart));
                    WordStart = k;
                }

            }

            int spacesRemaining = WrapSimply(words, C, OutputFilename);
            Console.WriteLine("Total spaces remaining (Greedy): " + spacesRemaining);
            return 0;
        } // End main()

        /*-----------------------------------------------------------------------
            Greedy Algorithm (Non-optimal i.e. approximate or heuristic solution)
          -----------------------------------------------------------------------*/
        private static int WrapSimply(IQueueInterface<String> Words, int ColumnLength, String OutputFilename)
        {
            StreamWriter Outp;
            Outp = null;
                try
            {
                Outp = new StreamWriter(OutputFilename);
            }
            catch (FileNotFoundException)
            {
                System.Console.WriteLine("Cannot create or " +
                    "open " + OutputFilename +
                            " for writing.  Using standard output instead.");
            }

            int Col = 1;
            int spacesRemaining = 0;            // Running count of spaces left at the end of lines
            while (!Words.IsEmpty())
            {
                String str = Words.Peek();
                int Len = str.Length;
                // See if we need to wrap to the next line
                if (Col == 1)
                {
                    Outp.Write(str);
                    Col += Len;
                    Words.Pop();
                }
                else if ((Col + Len) >= ColumnLength)
                {
                    // go to the next line
                    Outp.WriteLine();
                    spacesRemaining += (ColumnLength - Col) + 1;
                    Col = 1;
                }
                else
                {   // Typical case of printing the next word on the same line
                    Outp.Write(" ");
                    Outp.Write(str);
                    Col += (Len + 1);
                    Words.Pop();
                }

            }
            Outp.WriteLine();
            Outp.Close();
            return spacesRemaining;
        } // end wrapSimply
    }
}
