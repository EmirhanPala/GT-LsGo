using System;
using System.Collections.Generic;
using System.Text;

namespace LFS_External_Client
{
    static class Dealer
    {
        static public int GetCarPrice(string CarName)
        {
            switch (CarName.ToUpper())
            {
                case "UF1": return 0;
                case "XFG": return 16000;
                case "XRG": return 20500;
                case "LX4": return 30000;
                case "LX6": return 35000;
                case "RB4": return 55500;
                case "FXO": return 74500;
                case "VWS": return 127000;
                case "XRT": return 82000;
                case "RAC": return 92000;
                case "FZ5": return 128000;
                case "UFR": return 552000;
                case "XFR": return 655000;
                case "FXR": return 720000;
                case "XRR": return 780000;
                case "FZR": return 720000;
                case "MRT": return 12000;
                case "FOX": return 650000;
                case "FBM": return 700000;
            }
            return 0;
        }

        static public int GetCarValue(string CarName)
        {
            return (int)(GetCarPrice(CarName) * .70);
        }
    }
}
