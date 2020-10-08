using System;
//using System.Collections.Generic;
//using System.Text;
using System.IO;
using System.Windows.Forms;
using Dizplay_Cruise;

namespace Dizplay_Cruise
{
    public class Globals
    {
        public static readonly long StartupTimeBinary = System.DateTime.Now.ToBinary();
        public static bool Locked = false;
        public static readonly string nl = Environment.NewLine;
        public static readonly string dnl = nl + nl;
        public enum xAlign { left, center, right }
        public enum yAlign { top, middle, bottom }
        static public bool dbCanConnect = true;
        static public bool dbBlockOutgoing = false;
        
        
        
    }
}