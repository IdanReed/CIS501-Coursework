using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns_VirtualProxies
{
    // data structure that holds a formatted text document
    public class AllDoc : IDoc
    {
        private List<string> allLines;  // all the formatted lines in the document
        private WordIterator it;  // the iterator from which the words are read
        //    to construct the formatted lines
        private int lineLength;   // the (approximate) length of the formatted lines


        // constructs the document, all at once, where
        //   filename is the path to the textfile on the disk, and
        //   lineLength is the approximate length of the formatted lines
        public AllDoc(string filename, int lineLength)
        {
            this.lineLength = lineLength;
            allLines = new List<string>();
            it = new WordIterator(filename);
            while (it.more())
            {
                addLine();
            }
            it.close();
        }

        // helper method that reads the text file, builds the next formatted line,
        //   and adds it to the end of  allLines
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

        // returns line #i  in the formatted document, allLines
        public string getLine(int i)
        {
            string ans = null;
            if (i >= 0 && i < allLines.Count)
            { ans = allLines[i]; }
            return ans;
        }
    }
}
