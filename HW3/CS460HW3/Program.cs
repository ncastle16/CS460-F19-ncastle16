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
            String inputFilename = (@"C:\Users\ncast\OneDrive\Desktop\CS460\CS460-F19-ncastle16\HW3\CS460HW3\WarOfTheWorlds.txt");
            String outputFilename;
            String[] test = null;
            String line = null;
            using (StreamReader sr = new StreamReader(inputFilename))
            {
                // Read the stream to a string, and write the string to the console.
                line = sr.ReadToEnd();
            }

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
                inputFilename = args[1];
                outputFilename = args[2];
                
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

            // Read words and their lengths into these vectors
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

            int spacesRemaining = WrapSimply(words, C, outputFilename);
            Console.WriteLine("Total spaces remaining (Greedy): " + spacesRemaining);
            return 0;
        } // End main()

        /*-----------------------------------------------------------------------
            Greedy Algorithm (Non-optimal i.e. approximate or heuristic solution)
          -----------------------------------------------------------------------*/

        /**
            As an example only, write out the file directly to the output with _simple_ wrapping,
            i.e. adding spaces between words and moving to the next line if a word would go past the
            indicated column number C.  This will fail if any word length exceeds the column limit C,
            but it still goes ahead and just puts one word on that line.
        */
        private static int WrapSimply(IQueueInterface<String> words, int columnLength, String outputFilename)
        {
            StreamWriter outp;
            outp = null;
                try
            {
                outp = new StreamWriter(outputFilename);
            }
            catch (FileNotFoundException)
            {
                System.Console.WriteLine("Cannot create or " +
                    "open " + outputFilename +
                            " for writing.  Using standard output instead.");
            }

            int col = 1;
            int spacesRemaining = 0;            // Running count of spaces left at the end of lines
            while (!words.IsEmpty())
            {
                String str = words.Peek();
                int len = str.Length;
                // See if we need to wrap to the next line
                if (col == 1)
                {
                    outp.Write(str);
                    col += len;
                    words.Pop();
                }
                else if ((col + len) >= columnLength)
                {
                    // go to the next line
                    outp.WriteLine();
                    spacesRemaining += (columnLength - col) + 1;
                    col = 1;
                }
                else
                {   // Typical case of printing the next word on the same line
                    outp.Write(" ");
                    outp.Write(str);
                    col += (len + 1);
                    words.Pop();
                }

            }
            outp.WriteLine();
            outp.Close();
            return spacesRemaining;
        } // end wrapSimply
    }
}
