using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Threading;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using LFS_External.InSim;
using LFS_External;
using MySql.Data;
using MySql.Data.MySqlClient;
using Dizplay_Cruise;

namespace LFS_External_Client
{
    public partial class dbProcess
    {
        static public string dbServer = "mysql.lnb-hosting.nl";
        static public string dbPort = "21";
        static public string dbUser = "u469292953_insim";
        static public string dbPass = "insimdb";
        static public string dbDatabase = "u469292953_insim";

        static public bool dbConnectCheck()
        {
            string dbConnInfo = "server=" + dbServer + ";userid=" + dbUser + ";password=" + dbPass + ";database=" + dbDatabase;
            MySqlConnection dbConnection = new MySqlConnection(dbConnInfo);
            try
            {
                dbConnection.Open(); // connection must be openned for command
                Console.WriteLine("MySQL version: " + dbConnection.ServerVersion);
                Console.ReadKey();
                try
                {
                    dbConnection.Close();
                }
                catch
                {
                    MessageBox.Show("/msg ^8» ^1Error: ^7Database connection couldn't be closed!");
                }
                if (Globals.dbCanConnect == false)
                {
                    Globals.dbBlockOutgoing = true;
                    Globals.dbCanConnect = true;
                    MessageBox.Show("/msg ^8» ^3Attention: ^7Database opened successfully!");
                    MessageBox.Show("/msg ^8» ^1All outgoing database connections blocked!");
                    MessageBox.Show("/msg ^8» ^7Synchronizing users' stats with database!");
                    try
                    {
                        //.InSim.Request_NCN_AllConnections(30);
                        Globals.dbBlockOutgoing = false;
                    }
                    catch
                    {
                        MessageBox.Show("/msg ^8» ^1Error: ^7C. list was not be rebuilt!");
                    }
                }
                return true;
            }
            catch
            {
                if (Globals.dbCanConnect == true)
                {
                    MessageBox.Show("/msg ^8» ^1Critical error: ^7Database could not be open.");
                    MessageBox.Show("/msg ^8» ^1Warning: ^7Stats system not available.");
                    Globals.dbCanConnect = false;
                }
                return false;
            }
        }

      


        static public bool userExists(string Username)
        {
            #region dbFailurePrecautions
            string dbConnInfo = "server=" + dbServer + ";userid=" + dbUser + ";password=" + dbPass + ";database=" + dbDatabase;
            MySqlConnection dbConnection = new MySqlConnection(dbConnInfo);
            try
            {
                dbConnection.Open(); // connection must be openned for command
                if (Globals.dbCanConnect == false)
                {
                    Globals.dbBlockOutgoing = true;
                    Globals.dbCanConnect = true;
                    //.InSim.Send_MST_Message("/msg ^8» ^3Attention: ^7Database opened successfully!");
                    //.InSim.Send_MST_Message("/msg ^8» ^1All outgoing database connections blocked!");
                    //.InSim.Send_MST_Message("/msg ^8» ^7Synchronizing users' stats with database!");
                    try
                    {
                        //.InSim.Request_NCN_AllConnections(30);
                        Globals.dbBlockOutgoing = false;
                    }
                    catch
                    {
                        //.InSim.Send_MST_Message("/msg ^8» ^1Error: ^7C. list was not be rebuilt!");
                    }
                }
            }
            catch
            {
                if (Globals.dbCanConnect == true)
                {
                    //.InSim.Send_MST_Message("/msg ^8» ^1Critical error: ^7Database could not be open.");
                    //.InSim.Send_MST_Message("/msg ^8» ^1Warning: ^7Stats system not available.");
                    Globals.dbCanConnect = false;
                }
                return false;
            }
            #endregion
            int personalId = 0;
            MySqlCommand cmd = new MySqlCommand("SELECT id FROM uc_users WHERE LOWER(username) = LOWER('" + Username + "')", dbConnection);
            try
            {
                cmd.Prepare();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    personalId = reader.GetInt32("id");
                }
            }
            catch (Exception E)
            {
                //.buildErrorReportOnCrash(E, "SQL-UEX", "SQL(UEX)", ("Username = " + Username + "|personalId = " + personalId).Split('|'), Username);
            }
            dbConnection.Close();

            if (personalId > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static public bool userRegister(clsConnection C)
        {
            #region dbFailurePrecautions
            if (Globals.dbBlockOutgoing == true)
            {
                return false;
            }
            string dbConnInfo = "server=" + dbServer + ";userid=" + dbUser + ";password=" + dbPass + ";database=" + dbDatabase;
            MySqlConnection dbConnection = new MySqlConnection(dbConnInfo);
            try
            {
                dbConnection.Open(); // connection must be openned for command
                if (Globals.dbCanConnect == false)
                {
                    Globals.dbBlockOutgoing = true;
                    Globals.dbCanConnect = true;
                    //.InSim.Send_MST_Message("/msg ^8» ^3Attention: ^7Database opened successfully!");
                    //.InSim.Send_MST_Message("/msg ^8» ^1All outgoing database connections blocked!");
                    //.InSim.Send_MST_Message("/msg ^8» ^7Synchronizing users' stats with database!");
                    try
                    {
                        //.InSim.Request_NCN_AllConnections(30);
                        Globals.dbBlockOutgoing = false;
                    }
                    catch
                    {
                        //.InSim.Send_MST_Message("/msg ^8» ^1Error: ^7C. list was not be rebuilt!");
                    }
                    dbConnection.Close();
                    return false;
                }
            }
            catch
            {
                if (Globals.dbCanConnect == true)
                {
                    //.InSim.Send_MST_Message("/msg ^8» ^1Critical error: ^7Database could not be open.");
                    //.InSim.Send_MST_Message("/msg ^8» ^1Warning: ^7Stats system not available.");
                    Globals.dbCanConnect = false;
                }
                return false;
            }
            #endregion
            MySqlCommand cmd = new MySqlCommand("INSERT INTO uc_users (username, nickname, cash) VALUES ('" + C.Username + "', '" + C.PlayerName + "', '" + C.Cash + "')", dbConnection);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                //.buildErrorReportOnCrash(E, "SQL-URG", "SQL(URG)", ("Username = " + C.Username + "|Nickname = " + C.PlayerName + "|DateTime = " + DateTime.Now.ToBinary()).Split('|'), C.Username);
                dbConnection.Close();
                return false;
            }
            dbConnection.Close();
            return true;
        }
        
        static public bool userUpdateStats(clsConnection C)
        {
            #region dbFailurePrecautions
            if (Globals.dbBlockOutgoing == true)
            {
                return false;
            }
            string dbConnInfo = "server=" + dbServer + ";userid=" + dbUser + ";password=" + dbPass + ";database=" + dbDatabase;
            MySqlConnection dbConnection = new MySqlConnection(dbConnInfo);
            try
            {
                dbConnection.Open(); // connection must be openned for command
                if (Globals.dbCanConnect == false)
                {
                    Globals.dbBlockOutgoing = true;
                    Globals.dbCanConnect = true;
                  //  Form1.InSim.Send_MST_Message("/msg ^8» ^3Attention: ^7Database opened successfully!");
                    //Form1.InSim.Send_MST_Message("/msg ^8» ^1All outgoing database connections blocked!");
                  //  Form1.InSim.Send_MST_Message("/msg ^8» ^7Synchronizing users' stats with database!");
                    try
                    {
                       // Form1.InSim.Request_NCN_AllConnections(30);
                        Globals.dbBlockOutgoing = false;
                    }
                    catch
                    {
                       // Form1.InSim.Send_MST_Message("/msg ^8» ^1Error: ^7C. list was not be rebuilt!");
                    }
                    dbConnection.Close();
                    return false;
                }
            }
            catch
            {
                if (Globals.dbCanConnect == true)
                {
                 //   Form1.InSim.Send_MST_Message("/msg ^8» ^1Critical error: ^7Database could not be open.");
                 //   Form1.InSim.Send_MST_Message("/msg ^8» ^1Warning: ^7Stats system not available.");
                    Globals.dbCanConnect = false;
                }
                return false;
            }
            #endregion
            MySqlCommand cmd = new MySqlCommand("UPDATE uc_users SET " +
                "nickname='" + C.PlayerName + "', " +
                "cash='" + C.Cash + "', " +
                "bankbalance='" + C.BankBalance + "', " +
                "license='" + C.License + "', " +
                "cars='" + C.Cars + "', " +
                "totaldistance='" + C.TotalDistance + "', " +
                "health='" + C.Health + "', " + 
                "jobsdone='" + C.JobsDone + "', " +
                "lchannel='" + C.ChannelLanguage + "', " +
                "giux='" + C.GIUX + "', " +
                "giuy='" + C.GIUY + "', " +
                "giux2='" + C.GIUX2 + "', " +
                "giuy2='" + C.GIUY2 + "', " +
                "guistyle='" + C.GUIStyle + "', " +
                "goods1='" + C.Item1 + "', " +
                "goods2='" + C.Item2 + "', " +
                "goods3='" + C.Item3 + "', " +
                "goods4='" + C.Item4 + "', " +
                "member='" + C.IsMember + "', " +
                "officer='" + C.CanBeOfficer + "', " +
                "cadet='" + C.CanBeCadet + "', " +
                "towtruck='" + C.CanBeTow + "', " +
                "maffia='" + C.CanBeMafia + "', " +
                //"raffle='" + C.LastRaffle + "', " +
                "lotto='" + C.LottoTimer + "', " +
                "panel='" + C.OndutyBox + "', " +
                "speedo= " + C.KMHtoMPH + "', " +
                "odometer= " + C.MilesOrKilometers + "', " +
                "distview= " + C.DistanceToTodays + "', " +
                "displays= " + C.HideGUIorNOT + "', " +
                "renting='" + C.Renting + "', " +
                "rented='" + C.Rented + "', " +
                "renter='" + C.Renter + "', " +
                "renterr='" + C.Renterr + "', " +
                "rentee='" + C.Rentee + "', " +
                "lastseen='" + C.LastSeen + "', " +
                "WHERE id='" + C.personalId + "'", dbConnection);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception E)
            {
                dbConnection.Close();
                C.statsLoadedSuccessfully = false;
                return false;
            }
            dbConnection.Close();
            return true;
        }

        static public bool userGetStats(clsConnection C)
        {
            #region dbFailurePrecautions
            string dbConnInfo = "server=" + dbServer + ";userid=" + dbUser + ";password=" + dbPass + ";database=" + dbDatabase;
            MySqlConnection dbConnection = new MySqlConnection(dbConnInfo);
            try
            {
                dbConnection.Open(); // connection must be openned for command
                if (Globals.dbCanConnect == false)
                {
                    Globals.dbBlockOutgoing = true;
                    Globals.dbCanConnect = true;
                    //.InSim.Send_MST_Message("/msg ^8» ^3Attention: ^7Database opened successfully!");
                    //.InSim.Send_MST_Message("/msg ^8» ^1All outgoing database connections blocked!");
                    //.InSim.Send_MST_Message("/msg ^8» ^7Synchronizing users' stats with database!");
                    try
                    {
                        //.InSim.Request_NCN_AllConnections(30);
                        Globals.dbBlockOutgoing = false;
                    }
                    catch
                    {
                        //.InSim.Send_MST_Message("/msg ^8» ^1Error: ^7C. list was not be rebuilt!");
                    }
                    dbConnection.Close();
                    return false;
                }
            }
            catch
            {
                if (Globals.dbCanConnect == true)
                {
                    //.InSim.Send_MST_Message("/msg ^8» ^1Critical error: ^7Database could not be open.");
                    //.InSim.Send_MST_Message("/msg ^8» ^1Warning: ^7Stats system not available.");
                    Globals.dbCanConnect = false;
                }
                return false;
            }
            #endregion

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM uc_users WHERE LOWER(username) = LOWER('" + C.Username + "')", dbConnection);
            try
            {
                cmd.Prepare();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    C.personalId = reader.GetInt32("id");
                    C.Cash = reader.GetInt32("cash");
                    C.BankBalance = reader.GetInt32("bankbalance");
                    C.License = reader.GetInt32("License");
                    C.Cars = reader.GetString("cars");
                    C.TotalDistance = reader.GetInt32("totaldistance");
                    C.Health = reader.GetByte("Health");
                    C.JobsDone = reader.GetByte("JobsDone");
                    C.GIUX = reader.GetByte("giux");
                    C.GIUY = reader.GetByte("giuy");
                    C.GIUX2 = reader.GetByte("giux2");
                    C.GIUY2 = reader.GetByte("giuy2");
                    C.GUIStyle = reader.GetInt32("guistyle");
                    C.Item1 = reader.GetByte("goods1");
                    C.Item2 = reader.GetByte("goods2");
                    C.Item3 = reader.GetByte("goods3");
                    C.Item4 = reader.GetByte("goods4");
                    C.IsMember = reader.GetByte("member");
                    C.CanBeOfficer = reader.GetByte("officer");
                    C.CanBeCadet = reader.GetByte("cadet");
                    C.CanBeTow = reader.GetByte("towtruck");
                    C.CanBeMafia = reader.GetByte("maffia");
                    C.LottoTimer = reader.GetByte("lotto");
                    C.OndutyBox = reader.GetByte("panel");
                    C.KMHtoMPH = reader.GetByte("speedo");
                    C.MilesOrKilometers = reader.GetByte("odometer");
                    C.DistanceToTodays = reader.GetByte("distview");
                    C.HideGUIorNOT = reader.GetByte("displays");
                    C.Renting = reader.GetByte("renting");
                    C.Rented = reader.GetByte("rented");
                    C.Renter = reader.GetString("renter");
                    C.Renterr = reader.GetString("renterr");
                    C.Rentee = reader.GetString("rentee");
                    C.statsLoadedSuccessfully = true;
                }
            }
            catch (Exception E)
            {
                dbConnection.Close();
                C.statsLoadedSuccessfully = false;
                return false;
            }
            dbConnection.Close();
            return true;
        }

        static public bool userAddStats(clsConnection C)
        {
            #region dbFailurePrecautions
            string dbConnInfo = "server=" + dbServer + ";userid=" + dbUser + ";password=" + dbPass + ";database=" + dbDatabase;
            MySqlConnection dbConnection = new MySqlConnection(dbConnInfo);
            try
            {
                dbConnection.Open(); // connection must be openned for command
                if (Globals.dbCanConnect == false)
                {
                    Globals.dbBlockOutgoing = true;
                    Globals.dbCanConnect = true;
                    //.InSim.Send_MST_Message("/msg ^8» ^3Attention: ^7Database opened successfully!");
                    //.InSim.Send_MST_Message("/msg ^8» ^1All outgoing database connections blocked!");
                    //.InSim.Send_MST_Message("/msg ^8» ^7Synchronizing users' stats with database!");
                    try
                    {
                        //.InSim.Request_NCN_AllConnections(30);
                        Globals.dbBlockOutgoing = false;
                    }
                    catch
                    {
                        //.InSim.Send_MST_Message("/msg ^8» ^1Error: ^7C. list was not be rebuilt!");
                    }
                    dbConnection.Close();
                    return false;
                }
            }
            catch
            {
                if (Globals.dbCanConnect == true)
                {
                    //.InSim.Send_MST_Message("/msg ^8» ^1Critical error: ^7Database could not be open.");
                    //.InSim.Send_MST_Message("/msg ^8» ^1Warning: ^7Stats system not available.");
                    Globals.dbCanConnect = false;
                }
                return false;
            }
            #endregion
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM uc_users WHERE LOWER(username) = LOWER('" + C.Username + "')", dbConnection);
            try
            {
                cmd.Prepare();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    C.personalId = reader.GetInt32("id");
                    C.Cash = C.Cash;
                    C.BankBalance = C.BankBalance;
                    C.License = C.License;
                    C.Cars = C.Cars;
                    C.TotalDistance = C.TotalDistance;
                    C.Health = C.Health;
                    C.JobsDone = C.JobsDone;
                    C.GIUX = C.GIUX;
                    C.GIUY = C.GIUY;
                    C.GIUX2 = C.GIUX2;
                    C.GIUY2 = C.GIUY2;
                    C.GUIStyle = C.GUIStyle;
                    C.Item1 = C.Item1;
                    C.Item3 = C.Item3;
                    C.IsMember = C.IsMember;
                    C.CanBeOfficer = C.CanBeOfficer;
                    C.CanBeCadet = C.CanBeCadet;
                    C.CanBeTow = C.CanBeTow;
                    C.CanBeMafia = C.CanBeMafia;
                    C.LottoTimer = C.LottoTimer;
                    C.OndutyBox = C.OndutyBox;
                    C.KMHtoMPH = C.KMHtoMPH;
                    C.MilesOrKilometers = C.MilesOrKilometers;
                    C.DistanceToTodays = C.DistanceToTodays;
                    C.HideGUIorNOT = C.HideGUIorNOT;
                    C.Renting = C.Renting;
                    C.Rented = C.Rented;
                    C.Renter = C.Renter;
                    C.Renterr = C.Renterr;
                    C.Rentee = C.Rentee;
                    C.LastSeen = C.LastSeen;
                    //  C.accLoggedTill = reader.GetString("acc_loggedtill");
                    C.statsLoadedSuccessfully = true;
                }
            }
            catch (Exception E)
            {
                dbConnection.Close();
                return false;
            }
            dbConnection.Close();
            return true;
        }

       
        
    }
}