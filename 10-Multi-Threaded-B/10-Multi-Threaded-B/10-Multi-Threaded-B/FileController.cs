using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Multi_Threaded_B
{
    // a controller for a sequential text file:
    // allows a thread to read or write the file
    public class FileController
    {
        private File thefile;  // the file controlled by this controller

        private Status state = Status.Closed;

        private Object accessor;

        public FileController(File f) { thefile = f; }

        // opens the file for read use; returns handle to file.  
        // If file cannot be opened, returns null.
        public Reader openRead(Object t)
        {
            lock (this)
            {
                Reader r = null;
                
                if (state == Status.Closed)
                {
                    accessor = t;
                    thefile.initRead();
                    r = thefile;
                    state = Status.Reading;
                }
                return r;
            }
        }

        // opens the file for write use; returns handle to file.  
        //   If file cannot be opened, returns null.
        public Writer openWrite(Object t)
        {
            lock (this)
            {
                Writer w = null;
                
                if (state == Status.Closed)
                {
                    accessor = t;
                    thefile.initWrite();
                    w = thefile;
                    state = Status.Writing;
                }
                return w;
            }
        }

        // closes file
        public void close(Object t)
        {
            lock (this)
            {
                if (accessor == t || accessor == null)
                {
                    state = Status.Closed;
                }
                else
                {
                    Object s = t;
                }
            }
        }
    }
}
