using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns_VirtualProxies
{
    class Program
    {
        static void Main(string[] args)
        {
            runDocReader();  // run a demo document-reader program
        }

        // Two fields for the document reader:
        private static int lineNumber = 0;  // current line number
        // open text file,  hamlet.txt,  and format it for reading at approx 40 chars per line:  
        private static IDoc doc = new VProxyDoc("..\\..\\..\\hamlet.txt", 40);   // document-formatter object

        // once you write the virtual proxy for IDoc, comment out the previous line and use the following instead:
        //private static IDoc doc = new VProxyDoc("..\\..\\..\\hamlet.txt", 40);

        // console-window app for reading a formatted text document:
        private static void runDocReader()
        {
            Console.WriteLine();
            showLine(0);   // see below
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "") { showNextLine(); }  // see below
                else if (command == "q") { return; }     // quit!
                else
                {  // parse the number in the command and show that line number:
                    int num = -1;   // see the line below:
                    if (int.TryParse(command, out num))
                    {
                        showLine(num);
                    }
                }
            }
        }
        // displays line #n in the console window:
        private static void showLine(int n)
        {
            lineNumber = n;
            Console.Write(lineNumber + ": ");
            Console.Write(doc.getLine(lineNumber));
        }
        // displays the next line in the console window:
        private static void showNextLine()
        {
            showLine(lineNumber + 1);
        }
    }
}
