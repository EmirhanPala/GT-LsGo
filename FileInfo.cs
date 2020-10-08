using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LFS_External_Client
{
    static class FileInfo
    {
        const string UserInfo = @"users";

        #region ' Reset, New User, SaveInfo '

        static public void NewUser(string Username)
        {
            if (System.IO.File.Exists(UserInfo + "\\" + Username + ".txt") == false)
            {
                System.IO.StreamWriter Sr = new System.IO.StreamWriter(UserInfo + "\\" + Username + ".txt");
                Sr.WriteLine("////// Account Stats");
                Sr.WriteLine("Cash = 1000");
                Sr.WriteLine("BBal = 0");
                Sr.WriteLine("Cars = UF1 XFG XRG");
                Sr.WriteLine("Distance = -1");
                Sr.WriteLine("Health = 100");
                Sr.WriteLine("License = 0");
                Sr.WriteLine("Jobs Done = 0");
                Sr.WriteLine("LLotto = 0");
                Sr.WriteLine("Tickets = 0");
                Sr.WriteLine("LChannel = 0");
                /*Sr.WriteLine("///// Cop Stats");
                Sr.WriteLine("CChases Won = 0");
                Sr.WriteLine("CChases Lost = 0");
                Sr.WriteLine("///// Robber Stats");
                Sr.WriteLine("RChases Won = 0");
                Sr.WriteLine("RChases Lost = 0");*/
                Sr.WriteLine("///// Player Settings");
                Sr.WriteLine("Speedo = 0");
                Sr.WriteLine("Odometer = 0");
                Sr.WriteLine("DistView = 0");
                Sr.WriteLine("Displays = 0");
                Sr.WriteLine("OfcrBox = 0");
                Sr.WriteLine("Bonus Level = 0");
                Sr.WriteLine("Cigarettes = 0");
                Sr.WriteLine("GUIX2 = 0");
                Sr.WriteLine("GUIY2 = 90");
                Sr.WriteLine("GUIStyle = 2");
                Sr.WriteLine("///// Player Authorization");
                Sr.WriteLine("Officer = 0");
                Sr.WriteLine("TowTruck = 0");
                Sr.WriteLine("Member = 0");
                Sr.WriteLine("Cadet = 0");
                Sr.WriteLine("Mafia = 0");
                //Sr.WriteLine("VIP = 0");
                Sr.WriteLine("///// Items");
                Sr.WriteLine("Item1 = 0");
                Sr.WriteLine("Item2 = 0");
                Sr.WriteLine("Item3 = 0");
                Sr.WriteLine("Item4 = 0");
                Sr.WriteLine("///// Renting");
                Sr.WriteLine("Renting = 0");
                Sr.WriteLine("Rented = 0");
                Sr.WriteLine("Renter = 0");
                Sr.WriteLine("Renterr = 0");
                Sr.WriteLine("Rentee = 0");
                Sr.WriteLine("///// Player Info");
                Sr.WriteLine("Registered : ");
                Sr.WriteLine("Last Login : ");
                Sr.WriteLine("Last Seen : ");
                Sr.WriteLine("Registerd at: " + System.DateTime.Now);
                Sr.Flush();
                Sr.Close();
            }
        }

        static public void AccountReset(clsConnection C)
        {
            if (File.Exists(UserInfo + "\\" + C.Username + ".txt"))
            {
                StreamWriter Sw = new StreamWriter(UserInfo + "\\" + C.Username + ".txt");
                Sw.WriteLine("////// Account Stats");
                Sw.WriteLine("Cash = 1000");
                Sw.WriteLine("BBal = 500");
                Sw.WriteLine("Cars = UF1 XFG XRG");
                Sw.WriteLine("Distance = 0");
                Sw.WriteLine("Health = 0");
                Sw.WriteLine("JobsDone = 0");
                Sw.WriteLine("License = 0");
                Sw.WriteLine("LLotto = 0");
                Sw.WriteLine("Tickets = 0");
                Sw.WriteLine("LChannel = 0");
                /* Sw.WriteLine("///// Cop Stats");
                 Sw.WriteLine("CChases Won = 0");
                 Sw.WriteLine("CChases Lost = 0");
                 Sw.WriteLine("///// Robber Stats");
                 Sw.WriteLine("RChases Won = 0");
                 Sw.WriteLine("RChases Lost = 0");*/
                Sw.WriteLine("///// Player Authorization");
                Sw.WriteLine("Officer = 0");
                Sw.WriteLine("TowTruck = 0");
                Sw.WriteLine("Member = 0");
                Sw.WriteLine("Cadet = 0");
                Sw.WriteLine("Mafia = 0");
                // Sw.WriteLine("VIP = 0");
                Sw.WriteLine("///// Player Settings");
                Sw.WriteLine("Speedo = 0");
                Sw.WriteLine("Odometer = 0");
                Sw.WriteLine("DistView = 0");
                Sw.WriteLine("Displays = 0");
                Sw.WriteLine("OfcrBox = 0");
                Sw.WriteLine("Bonus Level = 0");
                Sw.WriteLine("Cigarettes = 0");
                Sw.WriteLine("GUIX2 = 0");
                Sw.WriteLine("GUIY2 = 90");
                Sw.WriteLine("GUIStyle = 1");
                Sw.WriteLine("///// Renting");
                Sw.WriteLine("Renting = " + C.Renting);
                Sw.WriteLine("Rented = " + C.Rented);
                Sw.WriteLine("Renter = " + C.Renter);
                Sw.WriteLine("Renterr = " + C.Renterr);
                Sw.WriteLine("Rentee = " + C.Rentee);
                Sw.WriteLine("///// Items");
                Sw.WriteLine("Item1 = 0");
                Sw.WriteLine("Item2 = 0");
                Sw.WriteLine("Item3 = 0");
                Sw.WriteLine("Item4 = 0");
                Sw.WriteLine("///// Player Info");
                Sw.WriteLine("Registered : " + C.PlayerName + " (" + C.Username + ")");
                Sw.WriteLine("Last Login : " + System.DateTime.Now);
                Sw.WriteLine("LastSeen : " + C.LastSeen);
                Sw.Flush();
                Sw.Close();
            }
        }

        static public void UpdateUserLeave(clsConnection C)
        {
            StreamWriter Sw = new StreamWriter(UserInfo + "\\" + C.Username + ".txt");
            Sw.WriteLine("////// Account Stats");
            Sw.WriteLine("Cash = " + C.Cash);
            Sw.WriteLine("BBal = " + C.BankBalance);
            Sw.WriteLine("Cars = " + C.Cars);
            Sw.WriteLine("Distance = " + C.TotalDistance);
            Sw.WriteLine("Health = " + C.Health);
            Sw.WriteLine("License = " + C.License);
            Sw.WriteLine("JobsDone = " + C.JobsDone);
            Sw.WriteLine("LLotto = " + C.LottoTimer);
            Sw.WriteLine("Tickets = " + C.TowTicket);
            Sw.WriteLine("LChannel = " + C.ChannelLanguage);
            /* Sw.WriteLine("///// Cop Stats");
             Sw.WriteLine("CChases Won = " + C.CopWin);
             Sw.WriteLine("CChases Lost = " + C.CopLost);
             Sw.WriteLine("///// Robber Stats");
             Sw.WriteLine("RChases Won = " + C.RobWin);
             Sw.WriteLine("RChases Lost = " + C.RobLost);*/
            Sw.WriteLine("///// Player Authorization");
            Sw.WriteLine("Officer = " + C.CanBeOfficer);
            Sw.WriteLine("TowTruck = " + C.CanBeTow);
            Sw.WriteLine("Member = " + C.IsMember);
            Sw.WriteLine("Cadet = " + C.CanBeCadet);
            Sw.WriteLine("Mafia = " + C.CanBeMafia);
            // Sw.WriteLine("VIP = " + C.IsVIP);
            Sw.WriteLine("///// Player Settings");
            Sw.WriteLine("Speedo = " + C.KMHtoMPH);
            Sw.WriteLine("Odometer = " + C.MilesOrKilometers);
            Sw.WriteLine("DistView = " + C.DistanceToTodays);
            Sw.WriteLine("Displays = " + C.HideGUIorNOT);
            Sw.WriteLine("OfcrBox = " + C.OndutyBox);
            Sw.WriteLine("Bonus Level = " + C.BonusDone);
            Sw.WriteLine("Cigarettes = " + C.Cigarettes);
            Sw.WriteLine("GUIX2 = " + C.GIUX2);
            Sw.WriteLine("GUIY2 = " + C.GIUY2);
            Sw.WriteLine("GUIStyle = " + C.GUIStyle);
            Sw.WriteLine("///// Renting");
            Sw.WriteLine("Renting = " + C.Renting);
            Sw.WriteLine("Rented = " + C.Rented);
            Sw.WriteLine("Renter = " + C.Renter);
            Sw.WriteLine("Renterr = " + C.Renterr);
            Sw.WriteLine("Rentee = " + C.Rentee);
            Sw.WriteLine("///// Items");
            Sw.WriteLine("Item1 = " + C.Item1);
            Sw.WriteLine("Item2 = " + C.Item2);
            Sw.WriteLine("Item3 = " + C.Item3);
            Sw.WriteLine("Item4 = " + C.Item4);
            Sw.WriteLine("///// Player Info");
            Sw.WriteLine("Registered : " + C.PlayerName + " (" + C.Username + ")");
            Sw.WriteLine("Last Login : " + System.DateTime.Now);
            Sw.WriteLine("LastSeen : " + C.LastSeen);
            Sw.Flush();
            Sw.Close();
        }

        #endregion


        #region ' Load Player Settings '

        static public byte GetChannelLanguage(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 8) == "LChannel")
                {
                    string[] Msg = line.Split('=');
                    if (Msg[1].Trim() == "7")
                    {
                        Sr.Close();
                        return 7;
                    }
                    if (Msg[1].Trim() == "6")
                    {
                        Sr.Close();
                        return 6;
                    }
                    if (Msg[1].Trim() == "5")
                    {
                        Sr.Close();
                        return 5;
                    }
                    if (Msg[1].Trim() == "4")
                    {
                        Sr.Close();
                        return 4;
                    }
                    if (Msg[1].Trim() == "3")
                    {
                        Sr.Close();
                        return 3;
                    }
                    if (Msg[1].Trim() == "2")
                    {
                        Sr.Close();
                        return 2;
                    }
                    if (Msg[1].Trim() == "1")
                    {
                        Sr.Close();
                        return 1;
                    }
                    if (Msg[1].Trim() == "0")
                    {
                        Sr.Close();
                        return 0;
                    }
                }
            }
            Sr.Close();
            return 0;
        }
        static public byte GetSpeedometer(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 6) == "Speedo")
                {
                    string[] Msg = line.Split('=');
                    if (Msg[1].Trim() == "1")
                    {
                        Sr.Close();
                        return 1;
                    }
                    if (Msg[1].Trim() == "0")
                    {
                        Sr.Close();
                        return 0;
                    }
                }
            }
            Sr.Close();
            return 0;
        }

        static public byte GetOdometer(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 8) == "Odometer")
                {
                    string[] Msg = line.Split('=');
                    if (Msg[1].Trim() == "1")
                    {
                        Sr.Close();
                        return 1;
                    }
                    if (Msg[1].Trim() == "0")
                    {
                        Sr.Close();
                        return 0;
                    }
                }
            }
            Sr.Close();
            return 0;
        }

        static public byte GetDistView(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 8) == "DistView")
                {
                    string[] Msg = line.Split('=');
                    if (Msg[1].Trim() == "1")
                    {
                        Sr.Close();
                        return 1;
                    }
                    if (Msg[1].Trim() == "0")
                    {
                        Sr.Close();
                        return 0;
                    }
                }
            }
            Sr.Close();
            return 0;
        }

        static public byte GetDisplayView(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 8) == "Displays")
                {
                    string[] Msg = line.Split('=');
                    if (Msg[1].Trim() == "2")
                    {
                        Sr.Close();
                        return 2;
                    }
                    if (Msg[1].Trim() == "1")
                    {
                        Sr.Close();
                        return 1;
                    }
                    if (Msg[1].Trim() == "0")
                    {
                        Sr.Close();
                        return 0;
                    }
                }
            }
            Sr.Close();
            return 0;
        }

        static public byte GetOfficerBox(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 7) == "OfcrBox")
                {
                    string[] Msg = line.Split('=');
                    if (Msg[1].Trim() == "1")
                    {
                        Sr.Close();
                        return 1;
                    }
                    if (Msg[1].Trim() == "0")
                    {
                        Sr.Close();
                        return 0;
                    }
                }
            }
            Sr.Close();
            return 0;
        }

        static public byte GetUserGUIX(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 4) == "GUIX")
                {
                    string[] Msg = line.Split('=');
                    Sr.Close();
                    return byte.Parse(Msg[1].Trim());
                }
            }
            Sr.Close();
            return 0;
        }

        static public byte GetUserGUIY(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 4) == "GUIY")
                {
                    string[] Msg = line.Split('=');
                    Sr.Close();
                    return byte.Parse(Msg[1].Trim());
                }
            }
            Sr.Close();
            return 0;
        }

        static public byte GetUserGUIX2(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 5) == "GUIX2")
                {
                    string[] Msg = line.Split('=');
                    Sr.Close();
                    return byte.Parse(Msg[1].Trim());
                }
            }
            Sr.Close();
            return 0;
        }

        static public byte GetUserGUIY2(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 5) == "GUIY2")
                {
                    string[] Msg = line.Split('=');
                    Sr.Close();
                    return byte.Parse(Msg[1].Trim());
                }
            }
            Sr.Close();
            return 0;
        }

        static public int GetUserGUIStyle(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 8) == "GUIStyle")
                {
                    string[] Msg = line.Split('=');
                    Sr.Close();
                    return int.Parse(Msg[1].Trim());
                }
            }
            Sr.Close();
            return 0;
        }

        #endregion

        #region ' Load Player Status '

        static public string GetUserCars(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 4) == "Cars")
                {
                    string[] Msg = line.Split('=');
                    Sr.Close();
                    return Msg[1].Trim();
                }
            }
            Sr.Close();
            return "";
        }

        static public long GetUserCash(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 4) == "Cash")
                {
                    string[] Msg = line.Split('=');
                    Sr.Close();
                    return long.Parse(Msg[1].Trim());
                }
            }
            Sr.Close();
            return 0;
        }

        static public int GetUserLicense(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 7) == "License")
                {
                    string[] Msg = line.Split('=');
                    Sr.Close();
                    return int.Parse(Msg[1].Trim());
                }
            }
            Sr.Close();
            return 0;
        }

        static public long GetUserBankBalance(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 4) == "BBal")
                {
                    string[] Msg = line.Split('=');
                    Sr.Close();
                    return long.Parse(Msg[1].Trim());
                }
            }
            Sr.Close();
            return 0;
        }

        static public int GetUserDistance(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 8) == "Distance")
                {
                    string[] Msg = line.Split('=');
                    Sr.Close();
                    return Int32.Parse(Msg[1].Trim());
                }
            }
            Sr.Close();
            return 0;
        }

        static public int GetUserHealth(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 6) == "Health")
                {
                    string[] Msg = line.Split('=');
                    Sr.Close();
                    return int.Parse(Msg[1].Trim());
                }
            }
            Sr.Close();
            return 0;
        }

        static public byte GetUserOfficer(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 7) == "Officer")
                {
                    string[] Msg = line.Split('=');
                    if (Msg[1].Trim() == "1")
                    {
                        Sr.Close();
                        return 1;
                    }
                    if (Msg[1].Trim() == "0")
                    {
                        Sr.Close();
                        return 0;
                    }
                }
            }
            Sr.Close();
            return 0;
        }

        static public byte GetUserTowTruck(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 8) == "TowTruck")
                {
                    string[] Msg = line.Split('=');
                    if (Msg[1].Trim() == "1")
                    {
                        Sr.Close();
                        return 1;
                    }
                    if (Msg[1].Trim() == "0")
                    {
                        Sr.Close();
                        return 0;
                    }
                }
            }
            Sr.Close();
            return 0;
        }

        static public byte GetUserCadet(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 5) == "Cadet")
                {
                    string[] Msg = line.Split('=');
                    if (Msg[1].Trim() == "3")
                    {
                        Sr.Close();
                        return 3;
                    }
                    if (Msg[1].Trim() == "2")
                    {
                        Sr.Close();
                        return 2;
                    }
                    if (Msg[1].Trim() == "1")
                    {
                        Sr.Close();
                        return 1;
                    }
                    if (Msg[1].Trim() == "0")
                    {
                        Sr.Close();
                        return 0;
                    }
                }
            }
            Sr.Close();
            return 0;
        }

        static public byte GetUserMember(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 6) == "Member")
                {
                    string[] Msg = line.Split('=');
                    if (Msg[1].Trim() == "1")
                    {
                        Sr.Close();
                        return 1;
                    }
                    if (Msg[1].Trim() == "0")
                    {
                        Sr.Close();
                        return 0;
                    }
                }
            }
            Sr.Close();
            return 0;
        }

        static public byte GetUserMafia(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 5) == "Mafia")
                {
                    string[] Msg = line.Split('=');
                    if (Msg[1].Trim() == "1")
                    {
                        Sr.Close();
                        return 1;
                    }
                    if (Msg[1].Trim() == "0")
                    {
                        Sr.Close();
                        return 0;
                    }
                }
            }
            Sr.Close();
            return 0;
        }

        /*static public byte GetUserVIP(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 3) == "VIP")
                {
                    string[] Msg = line.Split('=');
                    if (Msg[1].Trim() == "2")
                    {
                        Sr.Close();
                        return 1;
                    }
                    if (Msg[1].Trim() == "1")
                    {
                        Sr.Close();
                        return 1;
                    }
                    if (Msg[1].Trim() == "0")
                    {
                        Sr.Close();
                        return 0;
                    }
                }
            }
            Sr.Close();
            return 0;
        }*/

        static public int GetUserLastLotto(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 6) == "LLotto")
                {
                    string[] Msg = line.Split('=');
                    Sr.Close();
                    return int.Parse(Msg[1].Trim());
                }
            }
            Sr.Close();
            return 0;
        }

        static public int GetUserTicket(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 7) == "Tickets")
                {
                    string[] Msg = line.Split('=');
                    Sr.Close();
                    return int.Parse(Msg[1].Trim());
                }
            }
            Sr.Close();
            return 0;
        }
        /* static public long GetUserCopWon(string Username)
         {
             StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

             string line = null;
             while ((line = Sr.ReadLine()) != null)
             {
                 if (line.Substring(0, 11) == "CChases Won")
                 {
                     string[] Msg = line.Split('=');
                     Sr.Close();
                     return long.Parse(Msg[1].Trim());
                 }
             }
             Sr.Close();
             return 0;
         }
         static public long GetUserRobberWon(string Username)
         {
             StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

             string line = null;
             while ((line = Sr.ReadLine()) != null)
             {
                 if (line.Substring(0, 11) == "RChases Won")
                 {
                     string[] Msg = line.Split('=');
                     Sr.Close();
                     return long.Parse(Msg[1].Trim());
                 }
             }
             Sr.Close();
             return 0;
         }
         static public long GetUserRobberLost(string Username)
         {
             StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

             string line = null;
             while ((line = Sr.ReadLine()) != null)
             {
                 if (line.Substring(0, 12) == "RChases Lost")
                 {
                     string[] Msg = line.Split('=');
                     Sr.Close();
                     return long.Parse(Msg[1].Trim());
                 }
             }
             Sr.Close();
             return 0;
         }
         static public long GetUserCopLost(string Username)
         {
             StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

             string line = null;
             while ((line = Sr.ReadLine()) != null)
             {
                 if (line.Substring(0, 12) == "CChases Lost")
                 {
                     string[] Msg = line.Split('=');
                     Sr.Close();
                     return long.Parse(Msg[1].Trim());
                 }
             }
             Sr.Close();
             return 0;
         }*/
        static public long GetUserJobDone(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 8) == "JobsDone")
                {
                    string[] Msg = line.Split('=');
                    Sr.Close();
                    return long.Parse(Msg[1].Trim());
                }
            }
            Sr.Close();
            return 0;
        }

        #endregion

        #region ' Load Items '

        static public long GetUserItem1(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 5) == "Item1")
                {
                    string[] Msg = line.Split('=');
                    Sr.Close();
                    return long.Parse(Msg[1].Trim());
                }
            }
            Sr.Close();
            return 0;
        }

        static public long GetUserItem2(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 5) == "Item2")
                {
                    string[] Msg = line.Split('=');
                    Sr.Close();
                    return long.Parse(Msg[1].Trim());
                }
            }
            Sr.Close();
            return 0;
        }

        static public long GetUserItem3(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 5) == "Item3")
                {
                    string[] Msg = line.Split('=');
                    Sr.Close();
                    return long.Parse(Msg[1].Trim());
                }
            }
            Sr.Close();
            return 0;
        }

        static public long GetUserItem4(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 5) == "Item4")
                {
                    string[] Msg = line.Split('=');
                    Sr.Close();
                    return long.Parse(Msg[1].Trim());
                }
            }
            Sr.Close();
            return 0;
        }

        #endregion

        #region ' Load Banlist '
        static public byte GetUserPermBan(string Username)
        {
            StreamReader Sr = new StreamReader("users/banlist/BanList.txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 3) == "Ban")
                {
                    string[] Msg = line.Split('=');
                    if (Msg[1].Trim().ToLower() == Username)
                    {
                        Sr.Close();
                        return 1;
                    }
                }
            }
            Sr.Close();
            return 0;
        }

        static public string AddBanList(string Username)
        {
            StreamReader ApR = new StreamReader("users/banlist/BanList.txt");
            string TempAPR = ApR.ReadToEnd();
            ApR.Close();
            StreamWriter Ap = new StreamWriter("users/banlist/BanList.txt");
            Ap.WriteLine(TempAPR + "Ban = " + Username);
            Ap.Flush();
            Ap.Close();
            return "";
        }
        #endregion

        static public string AddBanListTemporary(string Username)
        {
            StreamReader ApR = new StreamReader("users/groups/BanList.txt");
            string TempAPR = ApR.ReadToEnd();
            ApR.Close();
            StreamWriter Ap = new StreamWriter("users/groups/BanList.txt");
            Ap.WriteLine(TempAPR + "Ban = " + Username);
            Ap.Flush();
            Ap.Close();
            return "";
        }

        #region ' Load Users in TXT FILE! '
        static public byte GetUserAdmin(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\groups\\SuperAdmin.txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 6) == "SAdmin")
                {
                    string[] Msg = line.Split('=');
                    if (Msg[1].Trim() == Username)
                    {
                        Sr.Close();
                        return 1;
                    }
                }
            }
            Sr.Close();
            return 0;
        }
        #endregion

    }
}
