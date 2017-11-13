using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns_VirtualProxies
{   // Virtual proxy for a  formatted-text-Document data structure:
    // It reads the text file and builds formatted lines only when forced to do so.
    // It saves the lines it does build in case they are needed again in the future.

    public class VProxyDoc : IDoc
    {
        // opens the text file at position  path  on the disk  
        // and remembers the desired  lineLength.  Doesn't read any words yet,
        // doesn't build any formatted lines just yet.

        private List<string> allLines;  // all the formatted lines in the document
        private WordIterator it;
        private int lineLength;

        public VProxyDoc(string path, int lineLength)
        {
            this.it = new WordIterator(path);
            this.lineLength = lineLength;
            allLines = new List<string>();
        }

        // returns Line number  i  in the formatted text DesignPatterns_VirtualProxies
        public string getLine(int i)
        {
            while((allLines.Count <= i) )
            {
                addLine();
            }
            return allLines[i];
        }
        private void addLine()
        {
            string nextLine = "";
            while (nextLine.Length < lineLength && it.more())
            {
                string word = it.next();
                nextLine = nextLine + " " + word;
            }
            allLines.Add(nextLine);
        }
    }
}
