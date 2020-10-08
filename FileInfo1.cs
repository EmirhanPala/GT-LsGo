using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LFS_External_Client
{
    static class FileInfo
    {
        const string UserInfo = @"users";

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

        static public int GetUserGoods(string Username)
        {
            StreamReader Sr = new StreamReader(UserInfo + "\\" + Username + ".txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 5) == "Goods")
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
            StreamReader Sr = new StreamReader(UserInfo + "\\groups\\police.txt");

            string line = null;
            while ((line = Sr.ReadLine()) != null)
            {
                if (line.Substring(0, 7) == "Officer")
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

        static public void NewUser(string Username)
        {
            if (System.IO.File.Exists(UserInfo + "\\" + Username + ".txt") == false)
            {
                System.IO.StreamWriter Sr = new System.IO.StreamWriter(UserInfo + "\\" + Username + ".txt");
                Sr.WriteLine("Cash = 1000");
                Sr.WriteLine("Cars = UF1");
                Sr.WriteLine("Goods = 0");
                Sr.WriteLine("Distance = 0");
                Sr.Flush();
                Sr.Close();
            }
        }

        static public void UpdateUserLeave(string Username, long Cash, string Cars, int Goods, Int32 Distance)
        {
            StreamWriter Sw = new StreamWriter(UserInfo + "\\" + Username + ".txt");
            Sw.WriteLine("Cash = " + Cash);
            Sw.WriteLine("Cars = " + Cars);
            Sw.WriteLine("Goods = " + Goods);
            Sw.WriteLine("Distance = " + Distance);
            Sw.WriteLine("");
            Sw.WriteLine("//// " + System.DateTime.Now);
            Sw.Flush();
            Sw.Close();
        }

        static public void AccountReset(string Username)
        {
            if (File.Exists(UserInfo + "\\" + Username + ".txt"))
            {
                StreamWriter Sw = new StreamWriter(UserInfo + "\\" + Username + ".txt");
                Sw.WriteLine("Cash = 1000");
                Sw.WriteLine("Cars = UF1");
                Sw.WriteLine("Goods = 0");
                Sw.WriteLine("Distance = 0");
                Sw.WriteLine("");
                Sw.WriteLine("//// " + System.DateTime.Now);
                Sw.Flush();
                Sw.Close();
            }
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

        static public Int32 GetUserDistance(string Username)
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
    }
}
