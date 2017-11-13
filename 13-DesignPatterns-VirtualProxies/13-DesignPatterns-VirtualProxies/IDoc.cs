using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns_VirtualProxies
{   // interface for a text-DesignPatterns_VirtualProxies-formatter data structure
    public interface IDoc
    {
        // returns Line number  i  in the formatted text DesignPatterns_VirtualProxies
        string getLine(int i);
    }
}
