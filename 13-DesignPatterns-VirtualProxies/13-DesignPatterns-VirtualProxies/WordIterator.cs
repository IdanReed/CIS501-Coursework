using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace DesignPatterns_VirtualProxies
{
    // Iterator that reads a text file and enumerates the words therein, one at a time
    public class WordIterator
    {
        private StreamReader reader;  // handle to the textfile on disk
        private List<string> buffer;  // holds the words in the most recently read textline
        private string nextword;  // the next word to return when someone asks for a word

        public WordIterator(string path)
        {  // path is the directory path to the textfile
            reader = new StreamReader(path);
            buffer = new List<string>();
            getNextword();
        }

        // returns the next unread word in the file
        public string next()
        {
            string ans = nextword;
            getNextword();
            return ans;
        }

        // reloads  nextword  from  buffer  and reads from the textfile as needed
        private void getNextword()
        {
            while (buffer.Count == 0)
            {
                string line = reader.ReadLine();
                Thread.Sleep(500); Console.Write("!");
                if (line != null)
                {
                    buffer = new List<string>(line.Split(' '));
                    buffer.RemoveAll(item => item == "");
                }
                else
                {  // no more lines )-:
                    nextword = null;
                    return;
                }
            }
            nextword = buffer[0];
            buffer.RemoveAt(0);
        }

        // returns if there are more words in the textfile
        public bool more()
        {
            return nextword != null;
        }

        // closes the iterator (and the textfile)
        public void close()
        {
            reader.Close(); reader.Dispose(); nextword = null;
        }
    }
}
