using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multi_Threaded_RW
{
    // a controller for a sequential text file:
    // allows a thread to read or write the file
    public class FileController
    {
        private File thefile;  // the file controlled by this controller

        // I.  DECLARE AND USE A STATE VARIABLE THAT REMEMBERS STATE OF thefile's USE
        // II. ADD CODE TO PREVENT TWO THREADS FROM OPENING THE FILE AT THE SAME INSTANT.
        public Status state;

        public FileController(File f) { thefile = f; }

        // opens the file for read use; returns handle to file.  
        // If file cannot be opened, returns null.
        public Reader openRead()
        {
            lock (this)
            {
                if (state == Status.Closed)
                {

                    state = Status.Reading;
                    Reader r = null;
                    thefile.initRead();
                    r = thefile;
                    return r;
                }
                else
                {
                    return null;
                }
            }
        }

        // opens the file for write use; returns handle to file.  
        //   If file cannot be opened, returns null.
        public Writer openWrite()
        {
            lock (this)
            {
                if (state == Status.Closed)
                {
                    state = Status.Writing;
                    Writer w = thefile;
                    thefile.initWrite();
                    w = thefile;
                    return w;
                }
                else
                {
                    return null;
                }
            }
        }

        // closes file
        public void close()
        {
            state = Status.Closed;
        }
    }
}
