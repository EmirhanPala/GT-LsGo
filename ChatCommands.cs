using System;
using System.Windows.Forms;
using System.Collections.Generic;
using LFS_External;
using LFS_External.InSim;
using System.Threading;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Net;

namespace LFS_External_Client
{
    public partial class Form1 //Chat commands
    {
        public struct CommandList
        {
            public MethodInfo MethodInf;
            public CommandAttribute CommandArg;
        }
        public List<CommandList> Commands = new List<CommandList>();
        public class CommandAttribute : Attribute
        {
            public string Command;
            public string Syntax;
            public string Description;
            public CommandAttribute(string command, string syntax, string desc)
            {
                Command = command;
                Syntax = syntax;
                Description = desc;
            }
            public CommandAttribute(string command, string syntax)
            {
                Command = command;
                Syntax = syntax;
                Description = "";
            }
        }
        #region ' Help's '
        [Command("help", "help")]
        public void help(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length == 1)
            {


                //InSim.Send_BTN_CreateButton("", Flags.ButtonStyles.ISB_LIGHT, 85, 100, 50, 50, 170, (Conn.UniqueID), 2, false);
                InSim.Send_BTN_CreateButton("", Flags.ButtonStyles.ISB_LIGHT, 58, 50, 51, 75, 171, (Conn.UniqueID), 2, false);
                InSim.Send_BTN_CreateButton("^7HELP MENU WINDOW", Flags.ButtonStyles.ISB_DARK, 6, 48, 53, 76, 172, (Conn.UniqueID), 2, false);
                //InSim.Send_BTN_CreateButton("^1^J‚w", Flags.ButtonStyles.ISB_DARK | Flags.ButtonStyles.ISB_CLICK, 6, 6, 52, 142, 173, Conn.UniqueID, 2, false);


                InSim.Send_BTN_CreateButton("^2SERVER HELP", Flags.ButtonStyles.ISB_DARK | Flags.ButtonStyles.ISB_CLICK, 5, 48, 60, 76, 222, (Conn.UniqueID), 2, false);
                InSim.Send_BTN_CreateButton("^2SHOWOFF", Flags.ButtonStyles.ISB_DARK | Flags.ButtonStyles.ISB_CLICK, 5, 48, 66, 76, 224, (Conn.UniqueID), 2, false);

                InSim.Send_BTN_CreateButton("^1PITLANE", Flags.ButtonStyles.ISB_DARK | Flags.ButtonStyles.ISB_CLICK, 5, 48, 72, 76, 221, (Conn.UniqueID), 2, false);
                InSim.Send_BTN_CreateButton("^2LOCATION", Flags.ButtonStyles.ISB_DARK | Flags.ButtonStyles.ISB_CLICK, 5, 48, 78, 76, 225, (Conn.UniqueID), 2, false);

                InSim.Send_BTN_CreateButton("^2COPS ONLINE", Flags.ButtonStyles.ISB_DARK | Flags.ButtonStyles.ISB_CLICK, 5, 48, 84, 76, 230, (Conn.UniqueID), 2, false);
                InSim.Send_BTN_CreateButton("^2TOW TRUCKS ONLINE", Flags.ButtonStyles.ISB_DARK | Flags.ButtonStyles.ISB_CLICK, 5, 48, 90, 76, 229, (Conn.UniqueID), 2, false);
                InSim.Send_BTN_CreateButton("^2THE TEAM", Flags.ButtonStyles.ISB_DARK | Flags.ButtonStyles.ISB_CLICK, 5, 48, 96, 76, 164, (Conn.UniqueID), 2, false);
                InSim.Send_BTN_CreateButton("^1Close Menu", Flags.ButtonStyles.ISB_DARK | Flags.ButtonStyles.ISB_CLICK, 5, 48, 102, 76, 173, (Conn.UniqueID), 2, false);
            }
            else
            {
                MsgPly("^1*^7 Invalid Command. ^2!help ^7for help.", MSO.UCID);
            }
            //Connections[GetConnIdx(MSO.UCID)].WaitCMD = 4;
        }

        [Command("settings", "settings")]
        public void settings(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            InSim.Send_BTN_CreateButton("" + ServerName + " ^6Settings ^3Menu", Flags.ButtonStyles.ISB_DARK, 7, 78, 51, 59, 172, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);
            InSim.Send_BTN_CreateButton("", Flags.ButtonStyles.ISB_LIGHT, 65, 80, 50, 58, 170, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);
            InSim.Send_BTN_CreateButton("", Flags.ButtonStyles.ISB_DARK, 63, 78, 51, 59, 171, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);
            InSim.Send_BTN_CreateButton("^1•", Flags.ButtonStyles.ISB_CLICK | Flags.ButtonStyles.ISB_LIGHT, 4, 10, 100, 67, 215, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);
            InSim.Send_BTN_CreateButton("^3•", Flags.ButtonStyles.ISB_CLICK | Flags.ButtonStyles.ISB_LIGHT, 4, 10, 100, 79, 216, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);
            InSim.Send_BTN_CreateButton("^4•", Flags.ButtonStyles.ISB_CLICK | Flags.ButtonStyles.ISB_LIGHT, 4, 10, 100, 91, 217, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);
            InSim.Send_BTN_CreateButton("^0•", Flags.ButtonStyles.ISB_CLICK | Flags.ButtonStyles.ISB_LIGHT, 4, 10, 100, 103, 218, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);
            InSim.Send_BTN_CreateButton("^2•", Flags.ButtonStyles.ISB_CLICK | Flags.ButtonStyles.ISB_LIGHT, 4, 10, 100, 115, 220, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);
            // InSim.Send_BTN_CreateButton("^6", Flags.ButtonStyles.ISB_C1, 5, 20, 75, 96, 93, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);

            InSim.Send_BTN_CreateButton("^7This extras still in developement", Flags.ButtonStyles.ISB_C1, 7, 30, 85, 82, 225, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);//Down
            InSim.Send_BTN_CreateButton("^1^J‚w", Flags.ButtonStyles.ISB_C1 | Flags.ButtonStyles.ISB_CLICK, 4, 6, 53, 130, 173, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);


        }


        [Command("modhelp", "modhelp <page>")]
        public void modhelp(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            if (Connections[GetConnIdx(MSO.UCID)].IsMember == 1 || Connections[GetConnIdx(MSO.UCID)].IsAdmin == 1)
            {
                if (StrMsg.Length > 1)
                {
                    string page = Msg.Remove(0, 9);
                    if (page == "1")
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3Help page 1 of 3", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3!mod <username>^6 - Moderate someone", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3To kick|warn|ban|fine use^6 !mod <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3!showoff^6 <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3!switch advert^6 - Enable/disable info every minute", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3!mc <message>^6 - Moderator chat", MSO.UCID, 0);

                    }
                    else if (page == "2")
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3Help page 2 of 3:", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3!addcadet^6 <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3!addofficer^6 <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3!addtow^6 <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3!addmafia^6 <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3!remmafia^6 <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3!removecop^6 <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3!remtow^6 <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3!checkusers^6 - See everyone's stats (Bugged)", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3!ann <message>^6 - Announce a message", MSO.UCID, 0);
                    }
                    else if (page == "3")
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3Help page 3 of 3:", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3!tow ^6 <username> - to pitlaned any player", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3!spectate ^6 <username> - to spectated any player", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3No further commands", MSO.UCID, 0);

                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3No more help pages", MSO.UCID, 0);
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3Use !modhelp <Page>", MSO.UCID, 0);
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
        }

        [Command("vippanel", "vippanel")]
        public void vippanel(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            if (Connections[GetConnIdx(MSO.UCID)].IsMafia == 1 || Connections[GetConnIdx(MSO.UCID)].IsAdmin == 1)
            {


                InSim.Send_BTN_CreateButton("" + ServerName + " ^1VIP ^3Extras", Flags.ButtonStyles.ISB_DARK, 7, 78, 51, 59, 172, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);
                InSim.Send_BTN_CreateButton("", Flags.ButtonStyles.ISB_LIGHT, 65, 80, 50, 58, 170, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);
                InSim.Send_BTN_CreateButton("", Flags.ButtonStyles.ISB_DARK, 63, 78, 51, 59, 171, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);
                InSim.Send_BTN_CreateButton("^1^J‚w", Flags.ButtonStyles.ISB_C1 | Flags.ButtonStyles.ISB_CLICK, 4, 6, 53, 130, 173, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                //To Miharu
                InSim.Send_BTN_CreateButton("^1*^3 Get Reserve Health Pack 100% ", Flags.ButtonStyles.ISB_DARK, 4, 60, 59, 59, 174, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);
                InSim.Send_BTN_CreateButton("^7GET ", Flags.ButtonStyles.ISB_CLICK | Flags.ButtonStyles.ISB_DARK, 4, 18, 59, 119, 125, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);
                //To Aarons
                InSim.Send_BTN_CreateButton("^1*^3 Free Pitlane", Flags.ButtonStyles.ISB_DARK, 4, 60, 63, 59, 175, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);
                InSim.Send_BTN_CreateButton("^1Pitlane ", Flags.ButtonStyles.ISB_DARK | Flags.ButtonStyles.ISB_CLICK, 4, 18, 63, 119, 126, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);
                //To Jades
                InSim.Send_BTN_CreateButton("", Flags.ButtonStyles.ISB_DARK, 4, 60, 67, 59, 176, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);
                InSim.Send_BTN_CreateButton("", Flags.ButtonStyles.ISB_DARK | Flags.ButtonStyles.ISB_CLICK, 4, 18, 67, 119, 115, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);



            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }

        }
        [Command("cophelp", "cophelp")]
        public void cophelp(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            if (Connections[GetConnIdx(MSO.UCID)].IsCadet == 1 || Connections[GetConnIdx(MSO.UCID)].IsOfficer == 1 || Connections[GetConnIdx(MSO.UCID)].IsMember == 1 || Connections[GetConnIdx(MSO.UCID)].IsAdmin == 1)
            {
                InSim.Send_MTC_MessageToConnection("^1*^3Help:", MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^1*^3!cc <message> ^6- Cop chat", MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^1*^3!laser ^6- Get speed of driver infront", MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^1*^3!chase ^6- Start a chase", MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^1*^3!lost ^6- Leave a chase", MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^1*^3!switch ondutybox ^6- See dutybox", MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^1*^3!busted ^6- Bust the car", MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^1*^3!joinchase ^6- Join a chase", MSO.UCID, 0);
                if (Connections[GetConnIdx(MSO.UCID)].IsOfficer == 1 || Connections[GetConnIdx(MSO.UCID)].IsAdmin == 1 || Connections[GetConnIdx(MSO.UCID)].IsMember == 1)
                {
                    //InSim.Send_MTC_MessageToConnection("^1*^3!robbable ^6- Enable a rob", MSO.UCID, 0);
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^1 Maybe you need to get onduty?", MSO.UCID, 0);
            }
        }
        [Command("mafiahelp", "mafiahelp")]
        public void mafiahelp(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            if (Connections[GetConnIdx(MSO.UCID)].IsMafia == 1 || Connections[GetConnIdx(MSO.UCID)].CanBeMafia == 1)
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Help:", MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^1*^3 !dlaser ^6- Disable laser of cops", MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^1*^3 This command is still in beta", MSO.UCID, 0);
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1Maybe you need to get onduty?", MSO.UCID, 0);
            }
        }
        [Command("howtoVIP", "howtoVIP")]
        public void howtoVIP(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {

            InSim.Send_MTC_MessageToConnection("^1*^3 How to VIP ?:", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3 1: Talk with admin", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3 2: Donate", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3 3: Enjoy ;)", MSO.UCID, 0);

        }
        [Command("tags", "tags")]
        public void tags(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            InSim.Send_MTC_MessageToConnection("^1**********************************", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3 " + ServerName + " ^7Tags", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1**********************************", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3 Officer Tag : ^0Officer^7•^3NAME", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3 Officer Plate : Police", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1**********************************", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3 Cadet Tag : ^0Cadet^7•^3NAME", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3 Cadet Plate : Police", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1**********************************", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3 Tow Tag : ^0Tow^7•^3NAME", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3 Tow Plate : Tow", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1**********************************", MSO.UCID, 0);


        }
        [Command("report", "report <msg>")]
        public void report(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            if (StrMsg.Length > 1)
            {
                MsgPly("^1*^7 Your message will be forwarded to the administrator!", MSO.UCID);
                clsConnection Conn = Connections[GetConnIdx(MSO.UCID)];

                foreach (clsConnection C in Connections)
                {

                    string Message2 = Msg.Remove(0, 7);

                    if ((C.IsAdmin == 1) && C.UniqueID != MSO.UCID)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^7 Report by: ^7" + Conn.PlayerName, C.UniqueID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^7" + Message2, C.UniqueID, 0);
                    }


                }

            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
        }
        [Command("distance", "distance")]
        public void distance(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            InSim.Send_MTC_MessageToConnection("^1**********************************", MSO.UCID, 0);
            if (Connections[GetConnIdx(MSO.UCID)].MilesOrKilometers == 0)
            {
                InSim.Send_MTC_MessageToConnection("^1*^3^7 Distance: ^2" + string.Format("{0:n0}", Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000) + " km", MSO.UCID, 0);
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3^7 Distance: ^2" + string.Format("{0:n0}", Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1609) + " mi", MSO.UCID, 0);
            }
            InSim.Send_MTC_MessageToConnection("^1**********************************", MSO.UCID, 0);


        }
        [Command("cash", "cash")]
        public void cash(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            InSim.Send_MTC_MessageToConnection("^1**********************************", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3 Cash: ^2$" + string.Format("{0:n0}", Connections[GetConnIdx(MSO.UCID)].Cash), MSO.UCID, 0);//Connections[GetConnIdx(MSO.UCID)].Cash);
            InSim.Send_MTC_MessageToConnection("^1**********************************", MSO.UCID, 0);


        }
        [Command("donate", "donate")]
        public void donate(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            InSim.Send_MTC_MessageToConnection("^1**********************************", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3 This option in progress", MSO.UCID, 0);//Connections[GetConnIdx(MSO.UCID)].Cash);
            InSim.Send_MTC_MessageToConnection("^1**********************************", MSO.UCID, 0);


        }
        [Command("cmds", "cmds")]
        public void cmds(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            MsgPly("^1*^3 Welcome to " + ServerName + "^3 Command List", MSO.UCID);
            InSim.Send_MTC_MessageToConnection("^1*^3!modhelp ^6- To see mod cmds (For Members)", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3!adminhelp ^6- To see Admin cmds (For Admins)", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3!donate ^6- You can donate to get car,money,distance", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3!cash ^6- To see your cash", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3!distance ^6- To see your Total Distance", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3!report <msg> ^6- Report Any player to Admin", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3!location ^6- Show your location", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3!prices ^6- See all car prices", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3!version ^6- See insim version", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3!pitlane ^6- Return to pitlane for €500", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3!switch kmh|mph|todays|total|display|ondutybox ^6-Display", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3!showoff ^6- Show your stats", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3!towrequest ^6- Request a towtruck", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3!cophelp ^6- See all Police Cmds", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3!towhelp ^6- See all Tow Cmds", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3!changes ^6- See all recent insim changes", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3!send ^6- You can send money to other people", MSO.UCID, 0);
            //InSim.Send_MTC_MessageToConnection("^1*^3!redeemhelp ^6- See available commands for redeem keys", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3!gps ^6- Navigate a route", MSO.UCID, 0);
            //InSim.Send_MTC_MessageToConnection("^9!licenseinfo ^6- See all Licenses", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3!trade <car> <cash> <username> ^6- Trade a car to someone", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3!channel <language channel> ^6- Choose Language channel", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3!ch <message> ^6- Talk in Language channel", MSO.UCID, 0);

        }
        [Command("gps", "gps")]
        public void gpsoff(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            if (StrMsg.Length == 1)
            {
                var Conn = Connections[GetConnIdx(MSO.UCID)];
                InSim.Send_BTN_CreateButton("", Flags.ButtonStyles.ISB_DARK, 40, 75, 50, 60, 172, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                InSim.Send_BTN_CreateButton("^7GPS", Flags.ButtonStyles.ISB_LIGHT, 5, 73, 51, 61, 185, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                InSim.Send_BTN_CreateButton("^2Location", Flags.ButtonStyles.ISB_DARK, 4, 30, 56, 61, 116, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                InSim.Send_BTN_CreateButton("^2Distance.", Flags.ButtonStyles.ISB_DARK, 4, 27, 56, 91, 174, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                InSim.Send_BTN_CreateButton("^2Select", Flags.ButtonStyles.ISB_DARK, 4, 16, 56, 118, 115, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                InSim.Send_BTN_CreateButton("^7Bank of " + ServerName, Flags.ButtonStyles.ISB_LIGHT, 4, 30, 60, 61, 171, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                InSim.Send_BTN_CreateButton("^7" + Connections[GetConnIdx(MSO.UCID)].InBankDist + " m", Flags.ButtonStyles.ISB_LIGHT, 4, 27, 60, 91, 113, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                if (Conn.GPS == 0 || Conn.GPSToCityBank == 0)
                {
                    InSim.Send_BTN_CreateButton("^2GO", Flags.ButtonStyles.ISB_LIGHT | Flags.ButtonStyles.ISB_CLICK, 4, 16, 60, 118, 119, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                }
                else
                {
                    InSim.Send_BTN_CreateButton("^1STOP GPS", Flags.ButtonStyles.ISB_LIGHT | Flags.ButtonStyles.ISB_CLICK, 4, 16, 60, 118, 119, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                }
                InSim.Send_BTN_CreateButton("^7The Pawn Shop", Flags.ButtonStyles.ISB_LIGHT, 4, 30, 64, 61, 109, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                InSim.Send_BTN_CreateButton("^7" + Connections[GetConnIdx(MSO.UCID)].InShopDist + " m", Flags.ButtonStyles.ISB_LIGHT, 4, 27, 64, 91, 182, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                if (Conn.GPS == 0 || Conn.GPSToPizzaHouse == 0)
                {
                    InSim.Send_BTN_CreateButton("^2GO", Flags.ButtonStyles.ISB_LIGHT | Flags.ButtonStyles.ISB_CLICK, 4, 16, 64, 118, 120, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                }
                else
                {
                    InSim.Send_BTN_CreateButton("^1STOP GPS", Flags.ButtonStyles.ISB_LIGHT | Flags.ButtonStyles.ISB_CLICK, 4, 16, 64, 118, 120, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                }
                InSim.Send_BTN_CreateButton("^1N^3i^6ght Club", Flags.ButtonStyles.ISB_LIGHT, 4, 30, 68, 61, 177, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                InSim.Send_BTN_CreateButton("^7" + Connections[GetConnIdx(MSO.UCID)].InSchoolDist + " m", Flags.ButtonStyles.ISB_LIGHT, 4, 27, 68, 91, 114, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                InSim.Send_BTN_CreateButton("^3^J‚w", Flags.ButtonStyles.ISB_LEFT | Flags.ButtonStyles.ISB_CLICK, 3, 6, 52, 131, 173, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                if (Conn.GPS == 0 || Conn.GPSToKinderGarten == 0)
                {
                    InSim.Send_BTN_CreateButton("^2GO", Flags.ButtonStyles.ISB_LIGHT | Flags.ButtonStyles.ISB_CLICK, 4, 16, 68, 118, 118, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                }
                else
                {
                    InSim.Send_BTN_CreateButton("^1STOP GPS", Flags.ButtonStyles.ISB_LIGHT | Flags.ButtonStyles.ISB_CLICK, 4, 16, 68, 118, 118, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                }
                InSim.Send_BTN_CreateButton("^7Car Dealer Race", Flags.ButtonStyles.ISB_LIGHT, 4, 30, 72, 61, 184, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                InSim.Send_BTN_CreateButton("^7" + Connections[GetConnIdx(MSO.UCID)].InCarDealerRaceDist + " m", Flags.ButtonStyles.ISB_LIGHT, 4, 27, 72, 91, 181, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                if (Conn.GPS == 0 || Conn.GPSToRaceDealer == 0)
                {
                    InSim.Send_BTN_CreateButton("^2GO", Flags.ButtonStyles.ISB_LIGHT | Flags.ButtonStyles.ISB_CLICK, 4, 16, 72, 118, 123, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                }
                else
                {
                    InSim.Send_BTN_CreateButton("^1STOP GPS", Flags.ButtonStyles.ISB_LIGHT | Flags.ButtonStyles.ISB_CLICK, 4, 16, 72, 118, 123, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                }
                InSim.Send_BTN_CreateButton("^7Car Dealer Stock", Flags.ButtonStyles.ISB_LIGHT, 4, 30, 76, 61, 178, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                InSim.Send_BTN_CreateButton("^7" + Connections[GetConnIdx(MSO.UCID)].InCarDealerStockDist + " m", Flags.ButtonStyles.ISB_LIGHT, 4, 27, 76, 91, 121, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                if (Conn.GPS == 0 || Conn.GPSToStockDealer == 0)
                {
                    InSim.Send_BTN_CreateButton("^2GO", Flags.ButtonStyles.ISB_LIGHT | Flags.ButtonStyles.ISB_CLICK, 4, 16, 76, 118, 122, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                }
                else
                {
                    InSim.Send_BTN_CreateButton("^1STOP GPS", Flags.ButtonStyles.ISB_LIGHT | Flags.ButtonStyles.ISB_CLICK, 4, 16, 76, 118, 122, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                }


            }
            else
            {
                MsgPly("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID);
            }

        }
        [Command("towhelp", "towhelp")]
        public void towhelp(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            if (Connections[GetConnIdx(MSO.UCID)].CanBeTow == 1 || Connections[GetConnIdx(MSO.UCID)].IsTowTruck == 1)
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Help:", MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^1*^3 !respond ^6- Go to Task", MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^1*^3 !starttow ^6- Start a towjob", MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^1*^3 !endtow ^6- End your job", MSO.UCID, 0);
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1»^1 Maybe you need to get onduty?", MSO.UCID, 0);
            }
        }
        [Command("adminhelp", "adminhelp <page>")]
        public void adminhelp(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            if (Connections[GetConnIdx(MSO.UCID)].IsAdmin == 1)
            {
                if (StrMsg.Length > 1)
                {
                    string page = Msg.Remove(0, 11);
                    if (page == "1")
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Help page 1 of 3", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3 !mod <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3 !restart", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3 !stopinsim", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3 To add admin: Add username to Groups>SuperAdmin ", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3 To kick|warn|ban|fine use !mod <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3 !showoff <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3 !switch advert - Enable/disable info every minute", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3 !ac <message>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3 !sethud <1,2>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3 !refdist <distance> <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3 !finedist <distance> <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3 !refcar <car> <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3 !remcar <car> <username>", MSO.UCID, 0);
                    }
                    else if (page == "2")
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Help page 2 of 3:", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3 !addcadet <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3 !addofficer <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3 !addtow <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3 !addmafia <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3 !remmafia <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3 !addmember <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3 !removecop <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3 !remtow <username>", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1*^3 !remmember <username>", MSO.UCID, 0);
                        //InSim.Send_MTC_MessageToConnection("^1*^3 !redeemhelp <key> <packet> <username>", MSO.UCID, 0);

                    }
                    else if (page == "3")
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 No more help pages", MSO.UCID, 0);
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 No more help pages", MSO.UCID, 0);
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Use !adminhelp <Page>", MSO.UCID, 0);
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid command. See ^2!help^7 for a command list", MSO.UCID, 0);
            }

        }

        #endregion

        [Command("res", "res")]
        public void newew(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (TrackName == "AU1" || TrackName == "AU2" || TrackName == "AU4")
            {
                MsgPly("^1*^3 Reset the car  not allowed in Event.", MSO.UCID);
            }
            else
            {
                if (Conn.IsMember == 1 || Conn.Username == "80quattro")
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Can reset is ^2ON", MSO.UCID, 0);
                    InSim.Send_MST_Message("/canreset yes");
                    Thread.Sleep(5000);
                    InSim.Send_MST_Message("/canreset no");
                    InSim.Send_MTC_MessageToConnection("^1*^3 Can reset is ^1OFF", MSO.UCID, 0);
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 You not a member!", MSO.UCID, 0);
                }
            }

        }

        [Command("bonus", "bonus")]
        public void givebonus(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];

            if (Conn.IsAdmin == 1)
            {

                foreach (clsConnection C in Connections)
                {
                    C.Cash += 2500;

                }

                InSim.Send_MST_Message("/msg ^3>>>>>>>>^3 All users receive 2500$ <<<<<<<<<<<");
                InSim.Send_MST_Message("/msg ^3>>>>>>>>^3 Bonus by Admin: " + Conn.Username);

            }
        }



        [Command("teststring", "teststring")]
        public void daskaal(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            clsConnection C = Connections[GetConnIdx(MSO.UCID)];
            MsgAll(C.BackupCallerUsername);
            MsgAll(C.JoinedBackupUsername);
        }

        [Command("restart", "restart")]
        public void restart(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length == 1)
                if (Conn.IsAdmin == 1)
                {
                    {
                        #region ' Save Users '
                        if (Connections.Count > 1)
                        {

                            //FileInfo.SaveUser(Conn);
                            MsgAll("^2Stats Saved!");
                        }
                        #endregion

                        if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                            Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !restart");
                            Ap.Flush();
                            Ap.Close();
                        }
                        MsgAll("^1[GT] Recovery:^7 Insim Restarting!");
                        MsgAll("^1[GT] Recovery:^7 Done by: " + Conn.PlayerName);
                        Application.Restart();
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
                }


        }
        [Command("stopinsim", "stopinsim")]
        public void stopinsim(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length == 2)
            {
                if (Conn.Username == "80quattro" || Conn.Username == "joordy599")
                {
                    {
                        string password = Msg.Remove(0, 11);
                        if (password == AdminPW)
                        {
                            #region ' Save Users '
                            if (Connections.Count > 1)
                            {

                                //FileInfo.SaveUser(Conn);
                                MsgAll("^2Stats Saved!");
                            }
                            #endregion

                            MsgAll("^1[GT] Recovery:^7 Insim quit!");
                            MsgAll("^1[GT] Recovery:^7 Done by: " + Conn.PlayerName);
                            Application.Exit();
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1Password is wrong", MSO.UCID, 0);
                        }
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
                }

            }
        }
        [Command("fixplid", "fixplid")]
        public void fixplid(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            if (StrMsg.Length > 0)
            {
                foreach (clsConnection C in Connections)
                {
                    if (C.UniqueID == MSO.UCID)
                    {
                        C.PlayerID = MSO.PLID;
                    }
                }
            }
            else
            {
            }
        }
        [Command("changes", "changes")]
        public void changes(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            InSim.Send_MTC_MessageToConnection("^1*^3 All Recent Changes:", MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3 Current System version: ^2" + VERSION, MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^1*^3 Current Cop System: ^2" + CopVersion, MSO.UCID, 0);
            InSim.Send_MTC_MessageToConnection("^6Please check Menu Panel Changes", MSO.UCID, 0);

        }
        [Command("cops", "cops")]
        public void cops(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            bool Found = false;

            foreach (clsConnection i in Connections)
            {
                if (i.IsOfficer == 1 && i.CanBeOfficer == 1)
                {
                    Found = true;
                    MsgPly("^1*^3 Officer: ^7" + i.PlayerName + " (" + i.Username + ") ^7- ^2ON-DUTY", MSO.UCID);
                }
                if (i.IsOfficer == 0 && i.CanBeOfficer == 1)
                {
                    Found = true;
                    MsgPly("^1*^3 Officer: ^7" + i.PlayerName + " (" + i.Username + ") ^7- ^1OFF-DUTY", MSO.UCID);
                }

                if (i.IsCadet == 1 && i.CanBeCadet == 1)
                {
                    Found = true;
                    MsgPly("^1*^3 Cadet: ^7" + i.PlayerName + " (" + i.Username + ") ^7- ^2ON-DUTY", MSO.UCID);
                }
                if (i.IsCadet == 0 && i.CanBeCadet == 1)
                {
                    Found = true;
                    MsgPly("^1*^3 Cadet: ^7" + i.PlayerName + " (" + i.Username + ") ^7- ^1OFF-DUTY", MSO.UCID);
                }
            }

            if (Found == false)
            {
                MsgPly("^1*^3 There are no currently Cops online", MSO.UCID);
            }
        }

        [Command("towtruck", "towtruck")]
        public void towtruck(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            bool Found = false;

            foreach (clsConnection i in Connections)
            {
                if (i.IsTowTruck == 1 && i.CanBeTow == 1)
                {
                    Found = true;
                    MsgPly("^1*^3 Tow Truck: ^7" + i.PlayerName + " (" + i.Username + ") ^7- ^2ON-DUTY", MSO.UCID);
                }
                if (i.IsTowTruck == 0 && i.CanBeTow == 1)
                {
                    Found = true;
                    MsgPly("^1*^3 Tow Truck: ^7" + i.PlayerName + " (" + i.Username + ") ^7- ^1OFF-DUTY", MSO.UCID);
                }
            }

            if (Found == false)
            {
                MsgPly("^1*^3 There are no currently TowTrucks online", MSO.UCID);
            }
        }

        [Command("members", "members")]
        public void members(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            bool Found = false;

            foreach (clsConnection i in Connections)
            {
                if (i.IsMember == 1)
                {
                    Found = true;
                    MsgPly("^1*^3 Member: ^7" + i.PlayerName + " (" + i.Username + ") ^7- ^2ONLINE", MSO.UCID);
                }
            }

            if (Found == false)
            {
                MsgPly("^1*^3 There are no currently Members online", MSO.UCID);
            }
        }

        [Command("admins", "admins")]
        public void admins(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            bool Found = false;

            foreach (clsConnection i in Connections)
            {
                if (i.IsAdmin == 1)
                {
                    Found = true;
                    MsgPly("^1*^3 Admin: ^7" + i.PlayerName + " (" + i.Username + ") ^7- ^2ONLINE", MSO.UCID);
                }
            }
            if (Found == false)
            {
                MsgPly("^1*^3 There are no currently Admins online", MSO.UCID);
            }
        }
        [Command("vips", "vips")]
        public void vips(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            bool Found = false;

            foreach (clsConnection i in Connections)
            {
                if (i.IsMafia == 1)
                {
                    Found = true;
                    MsgPly("^2>^1 VIP: ^7" + i.PlayerName + " (" + i.Username + ") ^7- ^2ONLINE", MSO.UCID);
                }
            }
            if (Found == false)
            {
                MsgPly("^1*^3 There are no currently ^1VIP's ^7online", MSO.UCID);
            }
        }
        [Command("version", "version")]
        public void version(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            if (StrMsg.Length > 0)
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Current ^7[^6GT^7]^3InSim Version:", MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^1*^3 Cop System: ^2" + CopVersion, MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^1*^3 Tow System: ^2" + TowVersion, MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^1*^3 System Version: ^2" + VERSION, MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^1*^3 Website: " + Website, MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^1*^3 InSim by: " + CreatedB, MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^1*^3 InSim edited by: " + EditedB, MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^1*^3 InSim Written in: " + WrittenIn, MSO.UCID, 0);
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
        }
        [Command("send", "send <amount> <username>")]
        public void send(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            if (StrMsg.Length > 2)
            {
                try
                {
                    int Send = int.Parse(StrMsg[1]);
                    bool SendComplete = false;
                    if (Connections[GetConnIdx(MSO.UCID)].Username == Msg.Remove(0, 7 + StrMsg[1].Length))
                    {
                        InSim.Send_MTC_MessageToConnection("^1You can't send money to yourself!", MSO.UCID, 0);
                    }
                    else
                    {
                        foreach (clsConnection i in Connections)
                        {
                            if (i.Username == Msg.Remove(0, 7 + StrMsg[1].Length))
                            {
                                SendComplete = true;
                                if (StrMsg[1].Contains("-"))
                                {
                                    InSim.Send_MTC_MessageToConnection("^1Send Error. Please don't use minus values!", MSO.UCID, 0);
                                }
                                else if (Connections[GetConnIdx(MSO.UCID)].Cash >= Send)
                                {
                                    i.Cash += Send;
                                    Connections[GetConnIdx(MSO.UCID)].Cash -= Send;
                                    InSim.Send_MST_Message("/msg ^6>^7 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " sent €" + Send + " to " + i.PlayerName);
                                }
                                else if (Connections[GetConnIdx(MSO.UCID)].Cash < Send)
                                {
                                    InSim.Send_MTC_MessageToConnection("^1You don't have enough cash to complete the transaction.", MSO.UCID, 0);
                                }
                            }
                        }
                        if (SendComplete == false)
                        {
                            InSim.Send_MTC_MessageToConnection("^1Send Error. User not found.", MSO.UCID, 0);
                        }

                    }
                }
                catch
                {
                    InSim.Send_MTC_MessageToConnection("^1Error has occured. Amount too high.", MSO.UCID, 0);
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1Invalid send command. Please try again.", MSO.UCID, 0);
            }

        }
        [Command("trade", "trade <car> <cash> <username>")]
        public void trade(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            if (StrMsg.Length >= 4)
            {

                int TradeCash = 0;
                try
                {
                    TradeCash = Convert.ToInt32(StrMsg[2]);

                    if (TradeCash >= 0)
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].Cars.Contains(StrMsg[1].ToUpper()))
                        {
                            foreach (clsConnection R in Connections)
                            {
                                bool Found = false;
                                string TradeCar = (StrMsg[1].ToUpper());
                                if (R.Username == Msg.Remove(0, (9 + StrMsg[1].Length + StrMsg[2].Length)))
                                {
                                    Found = true;
                                    if (R.Cars.Contains(TradeCar))
                                    {
                                        if (TradeCar == "UF1")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> UF1000 (UF1) ^7is already exist on the Garage", MSO.UCID, 0);
                                        }
                                        else if (TradeCar == "XFG")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> XF GTi (XFG) ^7is already exist on the Garage", MSO.UCID, 0);
                                        }
                                        else if (TradeCar == "XRG")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> XR GTi (XRG) ^7is already exist on the Garage", MSO.UCID, 0);
                                        }
                                        else if (TradeCar == "LX4")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> LX4 (LX4) ^7is already exist on the Garage", MSO.UCID, 0);
                                        }
                                        else if (TradeCar == "LX6")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> LX6 (LX6) ^7is already exist on the Garage", MSO.UCID, 0);
                                        }
                                        else if (TradeCar == "RB4")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> RB GT Turbo (RB4) ^7is already exist on the Garage", MSO.UCID, 0);
                                        }
                                        else if (TradeCar == "FXO")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> FX GT Turbo (FXO) ^7is already exist on the Garage", MSO.UCID, 0);
                                        }
                                        /*else if (TradeCar == "VWS")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> Volkswagen Scirroco (VWS) ^7is already exist on the Garage", MSO.UCID, 0);
                                        }*/
                                        else if (TradeCar == "XRT")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> XR GT Turbo (XRT) ^7is already exist on the Garage", MSO.UCID, 0);
                                        }
                                        else if (TradeCar == "RAC")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> Raceabout (RAC) ^7is already exist on the Garage", MSO.UCID, 0);
                                        }
                                        else if (TradeCar == "FZ5")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> FZ50 (FZ5) ^7is already exist on the Garage", MSO.UCID, 0);
                                        }
                                        else if (TradeCar == "UFR")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> UF GTR (UFR) ^7is already exist on the Garage", MSO.UCID, 0);
                                        }
                                        else if (TradeCar == "XFR")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> XF GTR (XFR) ^7is already exist on the Garage", MSO.UCID, 0);
                                        }
                                        else if (TradeCar == "FXR")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> FX GTR (FXR) ^7is already exist on the Garage", MSO.UCID, 0);
                                        }
                                        else if (TradeCar == "XRR")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> XR GTR (XRR) ^7is already exist on the Garage", MSO.UCID, 0);
                                        }
                                        else if (TradeCar == "FZR")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> FZ GTR (FZR) ^7is already exist on the Garage", MSO.UCID, 0);
                                        }
                                        else if (TradeCar == "MRT")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> McGill Racing Kart (MRT) ^7is already exist on the Garage", MSO.UCID, 0);
                                        }
                                        else if (TradeCar == "FOX")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> Formula XR (FOX) ^7is already exist on the Garage", MSO.UCID, 0);
                                        }
                                        else if (TradeCar == "FBM")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> Formula BMW FB02 (MRT) ^7is already exist on the Garage", MSO.UCID, 0);
                                        }
                                        else if (TradeCar == "FO8")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> Formula V8 (FO8) ^7is already exist on the Garage", MSO.UCID, 0);
                                        }
                                        else if (TradeCar == "BF1")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> BMW Sauber 1.06 (BF1) ^7is already exist on the Garage", MSO.UCID, 0);
                                        }
                                    }
                                    else if (R.Cash >= TradeCash)
                                    {
                                        string UserCars = Connections[GetConnIdx(SenderUCID)].Cars;
                                        int IdxCar = UserCars.IndexOf(StrMsg[1].ToUpper());
                                        Connections[GetConnIdx(MSO.UCID)].IdxCar = IdxCar;
                                        InSim.Send_BTN_CreateButton("", Flags.ButtonStyles.ISB_DARK, 25, 50, 30, 72, 133, R.UniqueID, 40, false);
                                        InSim.Send_BTN_CreateButton("^7" + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7wants to trade with you.", Flags.ButtonStyles.ISB_LEFT, 5, 100, 30, 72, 132, R.UniqueID, 40, false);
                                        InSim.Send_BTN_CreateButton("^7Car: " + TradeCar + ", Price: €" + TradeCash, Flags.ButtonStyles.ISB_LEFT, 5, 100, 35, 72, 211, R.UniqueID, 40, false);
                                        InSim.Send_BTN_CreateButton("^7Do you want to buy this car?", Flags.ButtonStyles.ISB_LEFT, 5, 100, 40, 72, 212, R.UniqueID, 40, false);
                                        InSim.Send_BTN_CreateButton("^2Yes", Flags.ButtonStyles.ISB_C1 | Flags.ButtonStyles.ISB_DARK | Flags.ButtonStyles.ISB_CLICK, 5, 10, 47, 77, 130, R.UniqueID, 40, false);
                                        InSim.Send_BTN_CreateButton("^1No", Flags.ButtonStyles.ISB_C1 | Flags.ButtonStyles.ISB_DARK | Flags.ButtonStyles.ISB_CLICK, 5, 10, 47, 97, 131, R.UniqueID, 40, false);
                                        InSim.Send_MTC_MessageToConnection("^7You have send your offer to: " + R.PlayerName, MSO.UCID, 0);
                                        InSim.Send_MTC_MessageToConnection("^7Car: " + TradeCar + " for: €" + TradeCash, MSO.UCID, 0);
                                        InSim.Send_MTC_MessageToConnection("^7Please wait till he/she decides...", MSO.UCID, 0);
                                        SenderUCID = MSO.UCID;
                                        SentCar = TradeCar;
                                        SentMoney = TradeCash;
                                    }
                                    else
                                    {
                                        InSim.Send_MTC_MessageToConnection("^7The recipient doesn't have enough cash!", MSO.UCID, 0);
                                    }
                                }
                            }
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^7You don't have that car for this transaction", MSO.UCID, 0);
                        }
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^7Error", MSO.UCID, 0);
                    }
                }
                catch
                {
                    InSim.Send_MTC_MessageToConnection("^7Invalid car", MSO.UCID, 0);
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^7Invalid command. Please see ^2!help^7 for a command list", MSO.UCID, 0);
            }
        }
        [Command("switch", "switch")]
        public void swtch(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            bool CommandFound = false;
            if (StrMsg.Length > 1)
            {
                if (StrMsg[1] == "kmh")
                {
                    CommandFound = true;
                    if (Connections[GetConnIdx(MSO.UCID)].KMHtoMPH == 1)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Switched to Kilometers per Hour", MSO.UCID, 0);
                        Connections[GetConnIdx(MSO.UCID)].KMHtoMPH = 0;
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Already Switched to Kilometers per Hour!", MSO.UCID, 0);
                    }
                }
                if (StrMsg[1] == "mph")
                {
                    CommandFound = true;
                    if (Connections[GetConnIdx(MSO.UCID)].KMHtoMPH == 0)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Switched to Miles per Hour", MSO.UCID, 0);
                        Connections[GetConnIdx(MSO.UCID)].KMHtoMPH = 1;
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Already Switched to Miles per Hour!", MSO.UCID, 0);
                    }
                }
                if (StrMsg[1] == "todays")
                {
                    CommandFound = true;
                    if (Connections[GetConnIdx(MSO.UCID)].DistanceToTodays == 0)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Switched to Todays Distance", MSO.UCID, 0);
                        Connections[GetConnIdx(MSO.UCID)].DistanceToTodays = 1;
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Already Switched to Todays Distance!", MSO.UCID, 0);
                    }
                }
                if (StrMsg[1] == "total")
                {
                    CommandFound = true;
                    if (Connections[GetConnIdx(MSO.UCID)].DistanceToTodays == 1)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Switched to Total Distance", MSO.UCID, 0);
                        Connections[GetConnIdx(MSO.UCID)].DistanceToTodays = 0;
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Already Switched to Total Distance!", MSO.UCID, 0);
                    }
                }
                if (StrMsg[1] == "miles")
                {
                    CommandFound = true;
                    if (Connections[GetConnIdx(MSO.UCID)].MilesOrKilometers == 0)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Switched to Miles", MSO.UCID, 0);
                        Connections[GetConnIdx(MSO.UCID)].MilesOrKilometers = 1;
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Already Switched to Miles!", MSO.UCID, 0);
                    }
                }
                if (StrMsg[1] == "kms")
                {
                    CommandFound = true;
                    if (Connections[GetConnIdx(MSO.UCID)].MilesOrKilometers == 1)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Switched to Kilometers", MSO.UCID, 0);
                        Connections[GetConnIdx(MSO.UCID)].MilesOrKilometers = 0;
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Already Switched to Kilometers!", MSO.UCID, 0);
                    }
                }
                if (StrMsg[1] == "display")
                {
                    CommandFound = true;
                    if (Connections[GetConnIdx(MSO.UCID)].HideGUIorNOT == 0)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Closed the Half of Displays", MSO.UCID, 0);
                        Connections[GetConnIdx(MSO.UCID)].HideGUIorNOT = 1;
                    }
                    else if (Connections[GetConnIdx(MSO.UCID)].HideGUIorNOT == 1)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Closed the Displays", MSO.UCID, 0);
                        Connections[GetConnIdx(MSO.UCID)].HideGUIorNOT = 2;
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Opened the Displays", MSO.UCID, 0);
                        Connections[GetConnIdx(MSO.UCID)].HideGUIorNOT = 0;
                    }
                }
                if (StrMsg[1] == "ondutybox")
                {
                    CommandFound = true;
                    if (Connections[GetConnIdx(MSO.UCID)].OndutyBox == 0)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 You have choose to turn on the Onduty Box", MSO.UCID, 0);
                        Connections[GetConnIdx(MSO.UCID)].OndutyBox = 1;
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 You have choose to turn off the Onduty Box", MSO.UCID, 0);
                        Connections[GetConnIdx(MSO.UCID)].OndutyBox = 0;
                    }
                }
                if (StrMsg[1] == "ads" && Connections[GetConnIdx(MSO.UCID)].IsAdmin == 1 || Connections[GetConnIdx(MSO.UCID)].IsMember == 1)
                {
                    CommandFound = true;
                    if (Connections[GetConnIdx(MSO.UCID)].Advert == 0)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 You have choose to turn on the Server Adverts", MSO.UCID, 0);
                        Connections[GetConnIdx(MSO.UCID)].Advert = 1;
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 You have choose to turn off the Server Adverts", MSO.UCID, 0);
                        Connections[GetConnIdx(MSO.UCID)].Advert = 0;
                    }
                }
                if (CommandFound == false)
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Command is not on the Switch list!", MSO.UCID, 0);
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
        }

        [Command("pitlane", "pitlane")]
        public void tow(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            if (StrMsg.Length > 0)
            {
                if (Connections[GetConnIdx(MSO.UCID)].Spectators == 0)
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 You are already in Spectators/Pit Garage!", MSO.UCID, 0);
                }
                else
                {
                    if (Connections[GetConnIdx(MSO.UCID)].IsBeingChased == 0 && MSO.UCID != RobberUCID)
                    {

                        if (Connections[GetConnIdx(MSO.UCID)].Cash < 500)
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not enough cash", MSO.UCID, 0);
                        }
                        else
                        {
                            if (Connections[GetConnIdx(MSO.UCID)].IsCadet == 1 || Connections[GetConnIdx(MSO.UCID)].IsOfficer == 1 || Connections[GetConnIdx(MSO.UCID)].IsTowTruck == 1 || Connections[GetConnIdx(MSO.UCID)].IsMafia == 1)
                            {
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " pitlaned");
                                InSim.Send_MST_Message("/pitlane " + Connections[GetConnIdx(MSO.UCID)].Username);
                            }
                            else
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Please wait for awhile", MSO.UCID, 0);
                                Connections[GetConnIdx(MSO.UCID)].TowTimer = 2;
                            }
                        }
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 You can't pitlane during a chase!", MSO.UCID, 0);
                    }
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
        }
        [Command("location", "location")]
        public void location(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            if (StrMsg.Length > 0)
            {
                if (Connections[GetConnIdx(MSO.UCID)].Spectators == 0)
                {
                    MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7is at Spectators");
                }
                else
                {
                    MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7is at " + Connections[GetConnIdx(MSO.UCID)].Location);
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
        }
        [Command("ticket", "ticket <amount>")]
        public void buyticket(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                string tickets = Msg.Remove(0, 8);
                if (tickets == "1")
                {
                    MsgAll("" + Conn.PlayerName + "^1*^3  Bought a ticket");
                    InSim.Send_MTC_MessageToConnection("^2You can now enter the Paid Parking", Conn.UniqueID, 0);
                    InSim.Send_MTC_MessageToConnection("^2Paid for 1 hour", Conn.UniqueID, 0);
                    Conn.Cash -= 100;
                    Conn.ParkTicket = 2;
                }
                else if (tickets == "2")
                {
                    InSim.Send_MTC_MessageToConnection("^1You can't pay for 2 tickets", Conn.UniqueID, 0);
                    InSim.Send_MTC_MessageToConnection("^1Please buy 1 ticket or more than 2 to enter", Conn.UniqueID, 0);
                }
                else if (tickets == "3")
                {
                    MsgAll("^1*^3 " + Conn.PlayerName + " Bought 3 tickets");
                    InSim.Send_MTC_MessageToConnection("^2You can now enter the Paid Parking", Conn.UniqueID, 0);
                    InSim.Send_MTC_MessageToConnection("^2Paid for 3 hours", Conn.UniqueID, 0);
                    Conn.Cash -= 300;
                    Conn.ParkTicket = 3;
                }
                else if (tickets == "4")
                {
                    MsgAll("" + Conn.PlayerName + "^1*^3  Bought 4 tickets");
                    InSim.Send_MTC_MessageToConnection("^2You can now enter the Paid Parking", Conn.UniqueID, 0);
                    InSim.Send_MTC_MessageToConnection("^2Paid for 4 hours", Conn.UniqueID, 0);
                    Conn.Cash -= 400;
                    Conn.ParkTicket = 4;
                }
                else if (tickets == "5")
                {
                    MsgAll("" + Conn.PlayerName + "^1*^3  Bought 5 tickets");
                    InSim.Send_MTC_MessageToConnection("^2You can now enter the Paid Parking", Conn.UniqueID, 0);
                    InSim.Send_MTC_MessageToConnection("^2Paid for 5 hours", Conn.UniqueID, 0);
                    Conn.Cash -= 500;
                    Conn.ParkTicket = 5;
                }
                else if (tickets == "6")
                {
                    MsgAll("" + Conn.PlayerName + "^1*^3  Bought 6 tickets");
                    InSim.Send_MTC_MessageToConnection("^2You can now enter the Paid Parking", Conn.UniqueID, 0);
                    InSim.Send_MTC_MessageToConnection("^2Paid for 6 hours", Conn.UniqueID, 0);
                    Conn.Cash -= 600;
                    Conn.ParkTicket = 6;
                }
                else if (tickets == "7")
                {
                    MsgAll("" + Conn.PlayerName + "^1*^3  Bought 7 tickets");
                    InSim.Send_MTC_MessageToConnection("^2You can now enter the Paid Parking", Conn.UniqueID, 0);
                    InSim.Send_MTC_MessageToConnection("^2Paid for 7 hours", Conn.UniqueID, 0);
                    Conn.Cash -= 700;
                    Conn.ParkTicket = 7;
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 You can't buy more then 7 tickets", MSO.UCID, 0);
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Use ^2!ticket <number>", MSO.UCID, 0);
            }
        }

        [Command("showoff", "showoff")]
        public void showoff(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {

            if (StrMsg.Length > 0)
            {
                MsgAll("^1*^3************************************");
                MsgAll("^1*^3^7 Showoff: " + Connections[GetConnIdx(MSO.UCID)].PlayerName + "^7 (" + Connections[GetConnIdx(MSO.UCID)].Username + "^7)");
                MsgAll("^1*^3^7 Cash: ^2$" + string.Format("{0:n0}", Connections[GetConnIdx(MSO.UCID)].Cash));//Connections[GetConnIdx(MSO.UCID)].Cash);
                MsgAll("^1*^3^7 Bank Balance: ^2$" + string.Format("{0:n0}", Connections[GetConnIdx(MSO.UCID)].BankBalance));
                if (Connections[GetConnIdx(MSO.UCID)].MilesOrKilometers == 0)
                {
                    MsgAll("^1*^3^7 Distance: ^2" + string.Format("{0:n0}", Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000) + " km");
                }
                else
                {
                    MsgAll("^1*^3^7 Distance: ^2" + string.Format("{0:n0}", Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1609) + " mi");
                }

                MsgAll("^1*^3^7 Jobs Done: ^2" + Connections[GetConnIdx(MSO.UCID)].JobsDone);
                if (Connections[GetConnIdx(MSO.UCID)].Cars.Length == 83)
                {
                    MsgAll("^1*^3^7 Cars: ^2ALL");
                }
                else if ((Connections[GetConnIdx(MSO.UCID)].Cars.Length > 52) && (Connections[GetConnIdx(MSO.UCID)].Cars.Length < 83))
                {
                    MsgAll("^1*^3^7 Cars: ^2" + Connections[GetConnIdx(MSO.UCID)].Cars.Remove(39, Connections[GetConnIdx(MSO.UCID)].Cars.Length - 39));
                    MsgAll("^1*^3^7 ^2" + Connections[GetConnIdx(MSO.UCID)].Cars.Remove(0, 40));
                }
                else if (Connections[GetConnIdx(MSO.UCID)].Cars.Length < 52)
                {
                    MsgAll("^1*^3^7 Cars: ^2" + Connections[GetConnIdx(MSO.UCID)].Cars);
                }
                if (Connections[GetConnIdx(MSO.UCID)].IsAdmin == 1 && Connections[GetConnIdx(MSO.UCID)].CanBeOfficer == 1 && Connections[GetConnIdx(MSO.UCID)].IsMafia == 1 && Connections[GetConnIdx(MSO.UCID)].CanBeTow == 1 && Connections[GetConnIdx(MSO.UCID)].IsMember == 1)
                {
                    MsgAll("^1*^3^7 Status: Admin/Tow/VIP/Officer");
                }
                else if (Connections[GetConnIdx(MSO.UCID)].CanBeOfficer == 1 && Connections[GetConnIdx(MSO.UCID)].IsMafia == 1 && Connections[GetConnIdx(MSO.UCID)].CanBeTow == 1 && Connections[GetConnIdx(MSO.UCID)].IsMember == 1)
                {
                    MsgAll("^1*^3^7 Status: Member/Tow/VIP/Officer");
                }
                else if (Connections[GetConnIdx(MSO.UCID)].CanBeOfficer == 1 && Connections[GetConnIdx(MSO.UCID)].IsMafia == 1 && Connections[GetConnIdx(MSO.UCID)].IsMember == 1)
                {
                    MsgAll("^1*^3^7 Status: Member/VIP/Officer");
                }
                else if (Connections[GetConnIdx(MSO.UCID)].CanBeTow == 1 && Connections[GetConnIdx(MSO.UCID)].IsMafia == 1 && Connections[GetConnIdx(MSO.UCID)].IsMember == 1)
                {
                    MsgAll("^1*^3^7 Status: Member/VIP/Tow");
                }
                else if (Connections[GetConnIdx(MSO.UCID)].CanBeTow == 1 && Connections[GetConnIdx(MSO.UCID)].CanBeOfficer == 1 && Connections[GetConnIdx(MSO.UCID)].IsMember == 1)
                {
                    MsgAll("^1*^3^7 Status: Member/Officer/Tow");
                }
                else if (Connections[GetConnIdx(MSO.UCID)].CanBeTow == 1 && Connections[GetConnIdx(MSO.UCID)].CanBeOfficer == 1 && Connections[GetConnIdx(MSO.UCID)].IsVIP == 1)
                {
                    MsgAll("^1*^3^7 Status: VIP/Officer/Tow");
                }

                else if (Connections[GetConnIdx(MSO.UCID)].CanBeOfficer == 1 && Connections[GetConnIdx(MSO.UCID)].CanBeTow == 1)
                {
                    MsgAll("^1*^3^7 Status: Officer/Tow");
                }
                else if (Connections[GetConnIdx(MSO.UCID)].CanBeOfficer == 1 && Connections[GetConnIdx(MSO.UCID)].IsMember == 1)
                {
                    MsgAll("^1*^3^7 Status: Officer/Member");
                }
                else if (Connections[GetConnIdx(MSO.UCID)].CanBeOfficer == 1 && Connections[GetConnIdx(MSO.UCID)].CanBeCadet == 1)
                {
                    MsgAll("^1*^3^7 Status: Officer/Cadet");
                }
                else if (Connections[GetConnIdx(MSO.UCID)].CanBeOfficer == 1 && Connections[GetConnIdx(MSO.UCID)].IsMafia == 1)
                {
                    MsgAll("^1*^3^7 Status: Officer/VIP");
                }
                else if (Connections[GetConnIdx(MSO.UCID)].CanBeTow == 1 && Connections[GetConnIdx(MSO.UCID)].IsMember == 1)
                {
                    MsgAll("^1*^3^7 Status: Tow/Member");
                }
                else if (Connections[GetConnIdx(MSO.UCID)].CanBeTow == 1 && Connections[GetConnIdx(MSO.UCID)].CanBeCadet == 1)
                {
                    MsgAll("^1*^3^7 Status: Tow/Cadet");
                }
                else if (Connections[GetConnIdx(MSO.UCID)].CanBeTow == 1 && Connections[GetConnIdx(MSO.UCID)].IsMember == 1)
                {
                    MsgAll("^1*^3^7 Status: Tow/Member");
                }
                else if (Connections[GetConnIdx(MSO.UCID)].IsMember == 1 && Connections[GetConnIdx(MSO.UCID)].CanBeCadet == 1)
                {
                    MsgAll("^1*^3^7 Status: Member/Cadet");
                }
                else if (Connections[GetConnIdx(MSO.UCID)].IsMember == 1 && Connections[GetConnIdx(MSO.UCID)].IsMafia == 1)
                {
                    MsgAll("^1*^3^7 Status: Member/VIP");
                }

                else if (Connections[GetConnIdx(MSO.UCID)].IsMember == 1)
                {
                    MsgAll("^1*^3^7 Status: Member");
                }
                else if (Connections[GetConnIdx(MSO.UCID)].CanBeCadet == 1)
                {
                    MsgAll("^1*^3^7 Status: Cadet");
                }
                else if (Connections[GetConnIdx(MSO.UCID)].IsMafia == 1)
                {
                    MsgAll("^1*^3^7 Status: VIP");
                }
                else if (Connections[GetConnIdx(MSO.UCID)].CanBeOfficer == 1)
                {
                    MsgAll("^1*^3^7 Status: Officer");
                }
                else if (Connections[GetConnIdx(MSO.UCID)].CanBeTow == 1)
                {
                    MsgAll("^1*^3^7 Status: Tow");
                }
                else if (Connections[GetConnIdx(MSO.UCID)].IsAdmin == 1)
                {
                    MsgAll("^1*^3^7 Status: Admin");
                }
                else
                {
                    MsgAll("^1*^3^7 Status: Civillian");
                }
                if (Connections[GetConnIdx(MSO.UCID)].IsOnline == 1)
                {
                    string Minutes = "0";
                    string Seconds = "0";
                    Minutes = "" + (Connections[GetConnIdx(MSO.UCID)].TotalConnectTime / 60);
                    if ((Connections[GetConnIdx(MSO.UCID)].TotalConnectTime - ((Connections[GetConnIdx(MSO.UCID)].TotalConnectTime / 60) * 60)) < 10)
                    {
                        Seconds = "0" + (Connections[GetConnIdx(MSO.UCID)].TotalConnectTime - ((Connections[GetConnIdx(MSO.UCID)].TotalConnectTime / 60) * 60));
                    }
                    else
                    {
                        Seconds = "" + (Connections[GetConnIdx(MSO.UCID)].TotalConnectTime - ((Connections[GetConnIdx(MSO.UCID)].TotalConnectTime / 60) * 60));
                    }

                    MsgAll("^1*^3^7 Current Connect Time: " + Minutes + ":" + Seconds);
                    //InSim.Send_BTN_CreateButton("^7Total Connect Time: ^1" + Minutes + ":" + Seconds, Flags.ButtonStyles.ISB_DARK, 4, 25, 82, 1, 104, C.UniqueID, 2, false);

                }
                MsgAll("^1*^3************************************");
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
        }
        [Command("job", "job")]
        public void job(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            clsConnection Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 0)
            {
                if (Conn.InHouse1 == 1 || Conn.InHouse2 == 1 || Conn.InHouse3 == 1 || Conn.InHouse4 == 1 || Conn.InHouse5 == 1)
                {
                    if (Conn.IsBeingChased == 0 && MSO.UCID != RobberUCID)
                    {
                        if (Conn.IsOfficer == 0 && Conn.IsCadet == 0 && Conn.IsMafia == 0 && Conn.IsTowTruck == 0)
                        {
                            if (Conn.JobToHouse1 == 1 || Conn.JobToHouse2 == 1 || Conn.JobToHouse3 == 1 || Conn.JobToHouse4 == 1 || Conn.JobToHouse5 == 1 || Conn.JobToSchool == 1)
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 You can only do 1 Job at a time!", Conn.UniqueID, 0);
                            }
                            else if (Conn.CurrentCar == "UFR" || Conn.CurrentCar == "XFR" || Conn.CurrentCar == "FXR" || Conn.CurrentCar == "XRR" || Conn.CurrentCar == "FZR" || Conn.CurrentCar == "MRT" || Conn.CurrentCar == "FBM")
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Jobs can be done only in Roadcars!", MSO.UCID, 0);
                            }
                            else
                            {
                                MsgAll("^1*^3 " + Conn.PlayerName + " ^6Accepted a Job!");
                                if (Conn.InHouse1 == 1)
                                {
                                    InSim.Send_MTC_MessageToConnection("^1*^3 Escort the Vodka ^1N^3i^6ght Club !", MSO.UCID, 0);
                                    Conn.JobFromHouse1 = 1;
                                    Conn.JobToSchool = 1;
                                    Conn.GPS = 1;
                                }
                                if (Conn.InHouse2 == 1)
                                {
                                    InSim.Send_MTC_MessageToConnection("^1*^3 Escort the Vodka ^1N^3i^6ght Club !", MSO.UCID, 0);
                                    Conn.JobFromHouse2 = 1;
                                    Conn.JobToSchool = 1;
                                    Conn.GPS = 1;
                                }
                                if (Conn.InHouse3 == 1)
                                {
                                    InSim.Send_MTC_MessageToConnection("^1*^3 Escort the Vodka ^1N^3i^6ght Club !", MSO.UCID, 0);
                                    Conn.JobFromHouse3 = 1;
                                    Conn.JobToSchool = 1;
                                    Conn.GPS = 1;
                                }
                                if (Conn.InHouse4 == 1)
                                {
                                    InSim.Send_MTC_MessageToConnection("^1*^3 Escort the Vodka ^1N^3i^6ght Club !", MSO.UCID, 0);
                                    Conn.JobFromHouse4 = 1;
                                    Conn.JobToSchool = 1;
                                    Conn.GPS = 1;
                                }
                                if (Conn.InHouse5 == 1)
                                {
                                    InSim.Send_MTC_MessageToConnection("^1*^3 Escort the Vodka ^1N^3i^6ght Club !", MSO.UCID, 0);
                                    Conn.JobFromHouse5 = 1;
                                    Conn.JobToSchool = 1;
                                    Conn.GPS = 1;
                                }
                            }
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Can't take a Job while in Active Duties!", MSO.UCID, 0);
                        }
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Can't Take a Job while in Chase", MSO.UCID, 0);
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Go To the Houses before you can do the Jobs!", MSO.UCID, 0);
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
        }
        [Command("canceljob", "canceljob")]
        public void canceljob(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {

            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length == 1)
            {
                if (Conn.Spectators == 0)
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 You must be in vehicle before you access this command!", MSO.UCID, 0);
                }
                if (Conn.JobToHouse1 == 0 && Conn.JobToHouse2 == 0 && Conn.JobToHouse3 == 0 && Conn.JobToSchool == 0)
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3* You don't have any jobs to be canceled!", MSO.UCID, 0);
                }
                else
                {
                    MsgAll("^1* " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^1canceled their current job");
                    if (TrackName == "BL1X" || TrackName == "WE1X" || TrackName == "SO4X" || TrackName == "KY3X" || TrackName == "AS5X" || TrackName == "FE4X" || TrackName == "RO1X")
                    {
                        #region ' JobFromHouses '
                        if (Conn.JobToSchool == 1)
                        {
                            if (Conn.JobFromHouse1 == 1)
                            {
                                InSim.Send_MTC_MessageToConnection("^1* Job Canceled!", MSO.UCID, 0);
                                //DeleteBTN(6, Conn.UniqueID);
                                //DeleteBTN(7, Conn.UniqueID);
                                Conn.JobFromHouse1 = 0;
                                Conn.GPS = 0;
                            }
                            if (Conn.JobFromHouse2 == 1)
                            {
                                InSim.Send_MTC_MessageToConnection("^1* Job Canceled", MSO.UCID, 0);
                                //DeleteBTN(6, Conn.UniqueID);
                                //DeleteBTN(7, Conn.UniqueID);
                                Conn.JobFromHouse2 = 0;
                                Conn.GPS = 0;
                            }
                            if (Conn.JobFromHouse3 == 1)
                            {
                                InSim.Send_MTC_MessageToConnection("^1* Job Canceled", MSO.UCID, 0);
                                //DeleteBTN(6, Conn.UniqueID);
                                //DeleteBTN(7, Conn.UniqueID);
                                Conn.JobFromHouse3 = 0;
                                Conn.GPS = 0;
                            }
                            if (Conn.JobFromHouse4 == 1)
                            {
                                InSim.Send_MTC_MessageToConnection("^1* Job Canceled", MSO.UCID, 0);
                                //DeleteBTN(6, Conn.UniqueID);
                                //DeleteBTN(7, Conn.UniqueID);
                                Conn.JobFromHouse4 = 0;
                                Conn.GPS = 0;
                            }
                            if (Conn.JobFromHouse5 == 1)
                            {
                                InSim.Send_MTC_MessageToConnection("^1* Job Canceled", MSO.UCID, 0);
                                //DeleteBTN(6, Conn.UniqueID);
                                //DeleteBTN(7, Conn.UniqueID);
                                Conn.JobFromHouse5 = 0;
                                Conn.GPS = 0;
                            }
                            Conn.JobToSchool = 0;
                        }
                        #endregion

                        #region ' JobFromShop '

                        if (Conn.JobFromShop == 1)
                        {
                            if (Conn.JobToHouse1 == 1)
                            {
                                InSim.Send_MTC_MessageToConnection("^1* Job Canceled", MSO.UCID, 0);
                                Conn.JobToHouse1 = 0;
                                //Conn.JobFromShop = 0;
                                Conn.GPS = 0;
                                //DeleteBTN(6, Conn.UniqueID);
                                //DeleteBTN(7, Conn.UniqueID);
                            }

                            if (Conn.JobToHouse2 == 1)
                            {
                                InSim.Send_MTC_MessageToConnection("^1* Job Canceled", MSO.UCID, 0);
                                Conn.JobToHouse2 = 0;
                                //Conn.JobFromShop = 0;
                                Conn.GPS = 0;
                                //DeleteBTN(6, Conn.UniqueID);
                                //DeleteBTN(7, Conn.UniqueID);
                            }

                            if (Conn.JobToHouse3 == 1)
                            {
                                InSim.Send_MTC_MessageToConnection("^1* Job Canceled", MSO.UCID, 0);
                                Conn.JobToHouse3 = 0;
                                Conn.JobFromShop = 0;
                                Conn.GPS = 0;
                                //DeleteBTN(6, Conn.UniqueID);
                                //DeleteBTN(7, Conn.UniqueID);
                            }
                            if (Conn.JobToHouse4 == 1)
                            {
                                InSim.Send_MTC_MessageToConnection("^1* Job Canceled", MSO.UCID, 0);
                                Conn.JobToHouse4 = 0;
                                //Conn.JobFromShop = 0;
                                Conn.GPS = 0;
                                //DeleteBTN(6, Conn.UniqueID);
                                //DeleteBTN(7, Conn.UniqueID);
                            }
                            if (Conn.JobToHouse5 == 1)
                            {
                                InSim.Send_MTC_MessageToConnection("^1* Job Canceled", MSO.UCID, 0);
                                Conn.JobToHouse5 = 0;
                                //Conn.JobFromShop = 0;
                                Conn.GPS = 0;
                                //DeleteBTN(6, Conn.UniqueID);
                                //DeleteBTN(7, Conn.UniqueID);
                            }

                            Conn.JobFromShop = 0;
                        }

                        #endregion

                    }
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1* ^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
            //Conn.WaitCMD = 4;

        }

        [Command("buy", "buy")]
        public void buy(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (TrackName == "BL1")
            {
                #region ' Buy Vehicle '
                if (StrMsg.Length == 2)
                {

                    #region ' Check if Exist '
                    if (Connections[GetConnIdx(MSO.UCID)].Cars.Contains(StrMsg[1].ToUpper()))
                    {
                        if (StrMsg[1].ToUpper() == "UF1")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> UF1000 (UF1) ^7already exist on the Garage", MSO.UCID, 0);
                        }
                        else if (StrMsg[1].ToUpper() == "XFG")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> XF GTi (XFG) ^7already exist on the Garage", MSO.UCID, 0);
                        }
                        else if (StrMsg[1].ToUpper() == "XRG")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> XR GTi (XRG) ^7already exist on the Garage", MSO.UCID, 0);
                        }
                        else if (StrMsg[1].ToUpper() == "LX4")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> LX4 (LX4) ^7already exist on the Garage", MSO.UCID, 0);
                        }
                        else if (StrMsg[1].ToUpper() == "LX6")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> LX6 (LX6) ^7already exist on the Garage", MSO.UCID, 0);
                        }
                        else if (StrMsg[1].ToUpper() == "RB4")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> RB GT Turbo (RB4) ^7already exist on the Garage", MSO.UCID, 0);
                        }
                        else if (StrMsg[1].ToUpper() == "FXO")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> FX GT Turbo (FXO) ^7already exist on the Garage", MSO.UCID, 0);
                        }
                        else if (StrMsg[1].ToUpper() == "VWS")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> Volkswagen Scirroco (VWS) ^7already exist on the Garage", MSO.UCID, 0);
                        }
                        else if (StrMsg[1].ToUpper() == "XRT")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> XR GT Turbo (XRT) ^7already exist on the Garage", MSO.UCID, 0);
                        }
                        else if (StrMsg[1].ToUpper() == "RAC")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> Raceabout (RAC) ^7already exist on the Garage", MSO.UCID, 0);
                        }
                        else if (StrMsg[1].ToUpper() == "FZ5")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> FZ50 (FZ5) ^7already exist on the Garage", MSO.UCID, 0);
                        }
                        else if (StrMsg[1].ToUpper() == "UFR")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> UF GTR (UFR) ^7already exist on the Garage", MSO.UCID, 0);
                        }
                        else if (StrMsg[1].ToUpper() == "XFR")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> XF GTR (XFR) ^7already exist on the Garage", MSO.UCID, 0);
                        }
                        else if (StrMsg[1].ToUpper() == "FXR")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> FX GTR (FXR) ^7already exist on the Garage", MSO.UCID, 0);
                        }
                        else if (StrMsg[1].ToUpper() == "XRR")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> XR GTR (XRR) ^7already exist on the Garage", MSO.UCID, 0);
                        }
                        else if (StrMsg[1].ToUpper() == "FZR")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> FZ GTR (FZR) ^7already exist on the Garage", MSO.UCID, 0);
                        }
                        else if (StrMsg[1].ToUpper() == "MRT")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> McGill Racing Kart (MRT) ^7already exist on the Garage", MSO.UCID, 0);
                        }
                        else if (StrMsg[1].ToUpper() == "FOX")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> Formula XR (FOX) ^7already exist on the Garage", MSO.UCID, 0);
                        }
                        else if (StrMsg[1].ToUpper() == "FBM")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> Formula BMW FB02 (FBM) ^7already exist on the Garage", MSO.UCID, 0);
                        }
                        else if (StrMsg[1].ToUpper() == "FO8")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> Formula V8 (FO8) ^7already exist on the Garage", MSO.UCID, 0);
                        }
                        else if (StrMsg[1].ToUpper() == "BF1")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> BMW Sauber 1.06 (BF1) ^7already exist on the Garage", MSO.UCID, 0);
                        }
                    }
                    #endregion

                    #region ' Check if doesn't Exist '
                    else if (Dealer.GetCarPrice(StrMsg[1]) == 0)
                    {

                        if (StrMsg[1].ToUpper() == "FO8")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> Formula V8 (FO8) ^7is not available in Dealership", MSO.UCID, 0);
                        }
                        else if (StrMsg[1].ToUpper() == "FOX")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> Formula XR (FOX) ^7is not available in Dealership", MSO.UCID, 0);
                        }
                        else if (StrMsg[1].ToUpper() == "BF1")
                        {
                            InSim.Send_MTC_MessageToConnection("^2> BMW Sauber F1.06 (BF1) ^7is not available in Dealership", MSO.UCID, 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^2> " + StrMsg[1].ToUpper() + " ^7does not exist on Dealership", MSO.UCID, 0);
                        }
                    }
                    #endregion

                    #region ' Check if Insuffient Cash '
                    else if (Connections[GetConnIdx(MSO.UCID)].Cash <= Dealer.GetCarPrice(StrMsg[1]))
                    {
                        if (StrMsg[1].ToUpper() == "UF1")
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not Enough Cash for ^1UF1000 (UF1)", MSO.UCID, 0);
                            if (Connections[GetConnIdx(MSO.UCID)].Cash <= Dealer.GetCarPrice(StrMsg[1]))
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price: ^1$" + Dealer.GetCarPrice(StrMsg[1]) + " ^7You need: ^2$" + (0 - Connections[GetConnIdx(MSO.UCID)].Cash), MSO.UCID, 0);
                            }

                        }
                        if (StrMsg[1].ToUpper() == "XFG")
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not Enough Cash for ^1XF GTi (XFG)", MSO.UCID, 0);
                            if (Connections[GetConnIdx(MSO.UCID)].Cash <= Dealer.GetCarPrice(StrMsg[1]))
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price: ^1$" + Dealer.GetCarPrice(StrMsg[1]) + " ^7You need: ^2$" + (6000 - Connections[GetConnIdx(MSO.UCID)].Cash), MSO.UCID, 0);
                            }

                        }
                        if (StrMsg[1].ToUpper() == "XRG")
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not Enough Cash for ^1XR GTi (XRG)", MSO.UCID, 0);
                            if (Connections[GetConnIdx(MSO.UCID)].Cash <= Dealer.GetCarPrice(StrMsg[1]))
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price: ^1$" + Dealer.GetCarPrice(StrMsg[1]) + " ^7You need: ^2$" + (6500 - Connections[GetConnIdx(MSO.UCID)].Cash), MSO.UCID, 0);
                            }

                        }
                        else if (StrMsg[1].ToUpper() == "LX4")
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not Enough Cash for ^1LX4 (LX4)", MSO.UCID, 0);
                            if (Connections[GetConnIdx(MSO.UCID)].Cash <= Dealer.GetCarPrice(StrMsg[1]))
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price: ^1$" + Dealer.GetCarPrice(StrMsg[1]) + " ^7You need: ^2$" + (17000 - Connections[GetConnIdx(MSO.UCID)].Cash), MSO.UCID, 0);
                            }

                        }
                        else if (StrMsg[1].ToUpper() == "LX6")
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not Enough Cash for ^1LX6 (LX6)", MSO.UCID, 0);
                            if (Connections[GetConnIdx(MSO.UCID)].Cash <= Dealer.GetCarPrice(StrMsg[1]))
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price: ^1$" + Dealer.GetCarPrice(StrMsg[1]) + " ^7You need: ^2$" + (30000 - Connections[GetConnIdx(MSO.UCID)].Cash), MSO.UCID, 0);
                            }

                        }
                        else if (StrMsg[1].ToUpper() == "RB4")
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not Enough Cash for ^1RB GT Turbo (RB4)", MSO.UCID, 0);
                            if (Connections[GetConnIdx(MSO.UCID)].Cash <= Dealer.GetCarPrice(StrMsg[1]))
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price: ^1$" + Dealer.GetCarPrice(StrMsg[1]) + " ^7You need: ^2$" + (15500 - Connections[GetConnIdx(MSO.UCID)].Cash), MSO.UCID, 0);
                            }

                        }
                        else if (StrMsg[1].ToUpper() == "FXO")
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not Enough Cash for ^1FX GT Turbo (FXO)", MSO.UCID, 0);
                            if (Connections[GetConnIdx(MSO.UCID)].Cash <= Dealer.GetCarPrice(StrMsg[1]))
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price: ^1$" + Dealer.GetCarPrice(StrMsg[1]) + " ^7You need: ^2$" + (14000 - Connections[GetConnIdx(MSO.UCID)].Cash), MSO.UCID, 0);
                            }

                        }
                        else if (StrMsg[1].ToUpper() == "VWS")
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not Enough Cash for ^1Volkswagen Scirroco (VWS)", MSO.UCID, 0);
                            if (Connections[GetConnIdx(MSO.UCID)].Cash <= Dealer.GetCarPrice(StrMsg[1]))
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price: ^1$" + Dealer.GetCarPrice(StrMsg[1]) + " ^7You need: ^2$" + (27000 - Connections[GetConnIdx(MSO.UCID)].Cash), MSO.UCID, 0);
                            }

                        }
                        else if (StrMsg[1].ToUpper() == "XRT")
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not Enough Cash for ^1XR GT Turbo (XRT)", MSO.UCID, 0);
                            if (Connections[GetConnIdx(MSO.UCID)].Cash <= Dealer.GetCarPrice(StrMsg[1]))
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price: ^1$" + Dealer.GetCarPrice(StrMsg[1]) + " ^7You need: ^2$" + (12000 - Connections[GetConnIdx(MSO.UCID)].Cash), MSO.UCID, 0);
                            }

                        }
                        else if (StrMsg[1].ToUpper() == "RAC")
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not Enough Cash for ^1Raceabout (RAC)", MSO.UCID, 0);
                            if (Connections[GetConnIdx(MSO.UCID)].Cash <= Dealer.GetCarPrice(StrMsg[1]))
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price: ^1$" + Dealer.GetCarPrice(StrMsg[1]) + " ^7You need: ^2$" + (32000 - Connections[GetConnIdx(MSO.UCID)].Cash), MSO.UCID, 0);
                            }

                        }
                        else if (StrMsg[1].ToUpper() == "FZ5")
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not Enough Cash for ^1FZ50 GT (FZ5)", MSO.UCID, 0);
                            if (Connections[GetConnIdx(MSO.UCID)].Cash <= Dealer.GetCarPrice(StrMsg[1]))
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price: ^1$" + Dealer.GetCarPrice(StrMsg[1]) + " ^7You need: ^2$" + (28000 - Connections[GetConnIdx(MSO.UCID)].Cash), MSO.UCID, 0);
                            }

                        }
                        else if (StrMsg[1].ToUpper() == "UFR")
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not Enough Cash for ^1UF GTR (UFR)", MSO.UCID, 0);
                            if (Connections[GetConnIdx(MSO.UCID)].Cash <= Dealer.GetCarPrice(StrMsg[1]))
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price: ^1$" + Dealer.GetCarPrice(StrMsg[1]) + " ^7You need: ^2$" + (52000 - Connections[GetConnIdx(MSO.UCID)].Cash), MSO.UCID, 0);
                            }

                        }
                        else if (StrMsg[1].ToUpper() == "XFR")
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not Enough Cash for ^1XF GTR (XFR)", MSO.UCID, 0);
                            if (Connections[GetConnIdx(MSO.UCID)].Cash <= Dealer.GetCarPrice(StrMsg[1]))
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price: ^1$" + Dealer.GetCarPrice(StrMsg[1]) + " ^7You need: ^2$" + (55000 - Connections[GetConnIdx(MSO.UCID)].Cash), MSO.UCID, 0);
                            }

                        }
                        else if (StrMsg[1].ToUpper() == "FXR")
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not Enough Cash for ^1FX GTR (FXR)", MSO.UCID, 0);
                            if (Connections[GetConnIdx(MSO.UCID)].Cash <= Dealer.GetCarPrice(StrMsg[1]))
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price: ^1$" + Dealer.GetCarPrice(StrMsg[1]) + " ^7You need: ^2$" + (220000 - Connections[GetConnIdx(MSO.UCID)].Cash), MSO.UCID, 0);
                            }

                        }
                        else if (StrMsg[1].ToUpper() == "XRR")
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not Enough Cash for ^1XR GTR (XRR)", MSO.UCID, 0);
                            if (Connections[GetConnIdx(MSO.UCID)].Cash <= Dealer.GetCarPrice(StrMsg[1]))
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price: ^1$" + Dealer.GetCarPrice(StrMsg[1]) + " ^7You need: ^2$" + (180000 - Connections[GetConnIdx(MSO.UCID)].Cash), MSO.UCID, 0);
                            }

                        }
                        else if (StrMsg[1].ToUpper() == "FZR")
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not Enough Cash for ^1FZ GTR (FZR)", MSO.UCID, 0);
                            if (Connections[GetConnIdx(MSO.UCID)].Cash <= Dealer.GetCarPrice(StrMsg[1]))
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price: ^1$" + Dealer.GetCarPrice(StrMsg[1]) + " ^7You need: ^2$" + (220000 - Connections[GetConnIdx(MSO.UCID)].Cash), MSO.UCID, 0);
                            }

                        }
                        else if (StrMsg[1].ToUpper() == "MRT")
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not Enough Cash for ^1McGill Racing Kart (MRT)", MSO.UCID, 0);
                            if (Connections[GetConnIdx(MSO.UCID)].Cash <= Dealer.GetCarPrice(StrMsg[1]))
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price: ^1$" + Dealer.GetCarPrice(StrMsg[1]) + " ^7You need: ^2$" + (12000 - Connections[GetConnIdx(MSO.UCID)].Cash), MSO.UCID, 0);
                            }

                        }
                        else if (StrMsg[1].ToUpper() == "FBM")
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not Enough Cash for ^1Formula BMW FB02 (FBM)", MSO.UCID, 0);
                            if (Connections[GetConnIdx(MSO.UCID)].Cash <= Dealer.GetCarPrice(StrMsg[1]))
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price: ^1$" + Dealer.GetCarPrice(StrMsg[1]) + " ^7You need: ^2$" + (220000 - Connections[GetConnIdx(MSO.UCID)].Cash), MSO.UCID, 0);
                            }
                        }
                    }
                    #endregion

                    #region ' if Cash is flow '
                    else if (Connections[GetConnIdx(MSO.UCID)].Cash >= Dealer.GetCarPrice(StrMsg[1]))
                    {
                        string Cars = Connections[GetConnIdx(MSO.UCID)].Cars;
                        switch (StrMsg[1].ToUpper())
                        {

                            case "UF1":

                                Cars = Cars + " " + "UF1";
                                Connections[GetConnIdx(MSO.UCID)].Cars = Cars;
                                Connections[GetConnIdx(MSO.UCID)].Cash -= Dealer.GetCarPrice("UF1");
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7bought a ^1UF1");
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have bought ^1UF GT (XRG) ^7in Garage", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price Tag: ^1$" + Dealer.GetCarPrice("UF1") + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash + " ^7left", MSO.UCID, 0);

                                break;



                            case "XFG":

                                Cars = Cars + " " + "XFG";
                                Connections[GetConnIdx(MSO.UCID)].Cars = Cars;
                                Connections[GetConnIdx(MSO.UCID)].Cash -= Dealer.GetCarPrice("XFG");
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7bought a ^1XFG");
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have bought ^1XF GTi (XRG) ^7in Garage", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price Tag: ^1$" + Dealer.GetCarPrice("XFG") + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash + " ^7left", MSO.UCID, 0);

                                break;


                            case "XRG":

                                Cars = Cars + " " + "XRG";
                                Connections[GetConnIdx(MSO.UCID)].Cars = Cars;
                                Connections[GetConnIdx(MSO.UCID)].Cash -= Dealer.GetCarPrice("XRG");
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7bought a ^1XRG");
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have bought ^1XR GTi (XRG) ^7in Garage", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price Tag: ^1$" + Dealer.GetCarPrice("XRG") + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash + " ^7left", MSO.UCID, 0);

                                break;

                            case "LX4":

                                Cars = Cars + " " + "LX4";
                                Connections[GetConnIdx(MSO.UCID)].Cars = Cars;
                                Connections[GetConnIdx(MSO.UCID)].Cash -= Dealer.GetCarPrice("LX4");
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7bought a ^1LX4");
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have bought ^1LX4 (LX4) ^7in Garage", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price Tag: ^1$" + Dealer.GetCarPrice("LX4") + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash + " ^7left", MSO.UCID, 0);

                                break;

                            case "LX6":

                                Cars = Cars + " " + "LX6";
                                Connections[GetConnIdx(MSO.UCID)].Cars = Cars;
                                Connections[GetConnIdx(MSO.UCID)].Cash -= Dealer.GetCarPrice("LX6");
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7bought a ^1LX6");
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have bought ^1LX6 (LX6) ^7in Garage", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price Tag: ^1$" + Dealer.GetCarPrice("LX6") + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash + " ^7left", MSO.UCID, 0);

                                break;

                            case "RB4":

                                Cars = Cars + " " + "RB4";
                                Connections[GetConnIdx(MSO.UCID)].Cars = Cars;
                                Connections[GetConnIdx(MSO.UCID)].Cash -= Dealer.GetCarPrice("RB4");
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7bought a ^1RB4");
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have bought ^1RB GT Turbo (RB4) ^7in Garage", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price Tag: ^1$" + Dealer.GetCarPrice("RB4") + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash + " ^7left", MSO.UCID, 0);

                                break;

                            case "FXO":

                                Cars = Cars + " " + "FXO";
                                Connections[GetConnIdx(MSO.UCID)].Cars = Cars;
                                Connections[GetConnIdx(MSO.UCID)].Cash -= Dealer.GetCarPrice("FXO");
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7bought a ^1FXO");
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have bought ^1FX GT Turbo (FXO) ^7in Garage", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price Tag: ^1$" + Dealer.GetCarPrice("FXO") + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash + " ^7left", MSO.UCID, 0);

                                break;

                            case "VWS":

                                Cars = Cars + " " + "VWS";
                                Connections[GetConnIdx(MSO.UCID)].Cars = Cars;
                                Connections[GetConnIdx(MSO.UCID)].Cash -= Dealer.GetCarPrice("VWS");
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7bought a ^1VWS");
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have bought ^1Volkswagen Scirocco (VWS) ^7in Garage", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price Tag: ^1$" + Dealer.GetCarPrice("VWS") + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash + " ^7left", MSO.UCID, 0);

                                break;

                            case "XRT":

                                Cars = Cars + " " + "XRT";
                                Connections[GetConnIdx(MSO.UCID)].Cars = Cars;
                                Connections[GetConnIdx(MSO.UCID)].Cash -= Dealer.GetCarPrice("XRT");
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7bought a ^1XRT");
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have bought ^1XR GT Turbo (XRT) ^7in Garage", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price Tag: ^1$" + Dealer.GetCarPrice("XRT") + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash + " ^7left", MSO.UCID, 0);

                                break;

                            case "RAC":

                                Cars = Cars + " " + "RAC";
                                Connections[GetConnIdx(MSO.UCID)].Cars = Cars;
                                Connections[GetConnIdx(MSO.UCID)].Cash -= Dealer.GetCarPrice("RAC");
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7bought a ^1RAC");
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have bought ^1Raceabout (RAC) ^7in Garage", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price Tag: ^1$" + Dealer.GetCarPrice("RAC") + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash + " ^7left", MSO.UCID, 0);

                                break;

                            case "FZ5":

                                Cars = Cars + " " + "FZ5";
                                Connections[GetConnIdx(MSO.UCID)].Cars = Cars;
                                Connections[GetConnIdx(MSO.UCID)].Cash -= Dealer.GetCarPrice("FZ5");
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7bought a ^1FZ5");
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have bought ^1FZ50 GT (FZ5) ^7in Garage", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price Tag: ^1$" + Dealer.GetCarPrice("LX6") + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash + " ^7left", MSO.UCID, 0);

                                break;

                            case "UFR":

                                Cars = Cars + " " + "UFR";
                                Connections[GetConnIdx(MSO.UCID)].Cars = Cars;
                                Connections[GetConnIdx(MSO.UCID)].Cash -= Dealer.GetCarPrice("UFR");
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7bought a ^1UFR");
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have bought ^1UF GTR (UFR) ^7in Garage", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price Tag: ^1$" + Dealer.GetCarPrice("UFR") + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash + " ^7left", MSO.UCID, 0);

                                break;

                            case "XFR":

                                Cars = Cars + " " + "XFR";
                                Connections[GetConnIdx(MSO.UCID)].Cars = Cars;
                                Connections[GetConnIdx(MSO.UCID)].Cash -= Dealer.GetCarPrice("XFR");
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7bought a ^1XFR");
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have bought ^1XF GTR (XFR) ^7in Garage", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price Tag: ^1$" + Dealer.GetCarPrice("XFR") + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash + " ^7left", MSO.UCID, 0);

                                break;

                            case "FXR":

                                Cars = Cars + " " + "FXR";
                                Connections[GetConnIdx(MSO.UCID)].Cars = Cars;
                                Connections[GetConnIdx(MSO.UCID)].Cash -= Dealer.GetCarPrice("FXR");
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7bought a ^1FXR");
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have bought ^1FX GTR (FXR) ^7in Garage", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price Tag: ^1$" + Dealer.GetCarPrice("FXR") + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash + " ^7left", MSO.UCID, 0);

                                break;

                            case "XRR":

                                Cars = Cars + " " + "XRR";
                                Connections[GetConnIdx(MSO.UCID)].Cars = Cars;
                                Connections[GetConnIdx(MSO.UCID)].Cash -= Dealer.GetCarPrice("XRR");
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7bought a ^1XRR");
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have bought ^1XR GTR (XRR) ^7in Garage", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price Tag: ^1$" + Dealer.GetCarPrice("XRR") + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash + " ^7left", MSO.UCID, 0);


                                break;

                            case "FZR":

                                Cars = Cars + " " + "FZR";
                                Connections[GetConnIdx(MSO.UCID)].Cars = Cars;
                                Connections[GetConnIdx(MSO.UCID)].Cash -= Dealer.GetCarPrice("FZR");
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7bought a ^1FZR");
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have bought ^1FZ GTR (FZR) ^7in Garage", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price Tag: ^1$" + Dealer.GetCarPrice("FZR") + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash + " ^7left", MSO.UCID, 0);

                                break;

                            case "MRT":

                                Cars = Cars + " " + "MRT";
                                Connections[GetConnIdx(MSO.UCID)].Cars = Cars;
                                Connections[GetConnIdx(MSO.UCID)].Cash -= Dealer.GetCarPrice("MRT");
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7bought a ^1MRT");
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have bought ^1McGill Racing Kart (MRT) ^7in Garage", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price Tag: ^1$" + Dealer.GetCarPrice("MRT") + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash + " ^7left", MSO.UCID, 0);

                                break;
                            case "FOX":

                                Cars = Cars + " " + "FOX";
                                Connections[GetConnIdx(MSO.UCID)].Cars = Cars;
                                Connections[GetConnIdx(MSO.UCID)].Cash -= Dealer.GetCarPrice("FOX");
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7bought a ^1FOX");
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have bought the Formula XR ^1(FOX) ^7in Garage", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price Tag: ^1$" + Dealer.GetCarPrice("FOX") + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash + " ^7left", MSO.UCID, 0);

                                break;
                            case "FO8":

                                Cars = Cars + " " + "FO8";
                                Connections[GetConnIdx(MSO.UCID)].Cars = Cars;
                                Connections[GetConnIdx(MSO.UCID)].Cash -= Dealer.GetCarPrice("FO8");
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7bought a ^1FO8");
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have bought the Formula V8 ^1(FO8) ^7in Garage", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price Tag: ^1$" + Dealer.GetCarPrice("FO8") + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash + " ^7left", MSO.UCID, 0);

                                break;

                            case "FBM":

                                Cars = Cars + " " + "FBM";
                                Connections[GetConnIdx(MSO.UCID)].Cars = Cars;
                                Connections[GetConnIdx(MSO.UCID)].Cash -= Dealer.GetCarPrice("FBM");
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7bought a ^1FBM");
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have bought ^1Formula BMW FB02 (FBM) ^7in Garage", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price Tag: ^1$" + Dealer.GetCarPrice("FBM") + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash + " ^7left", MSO.UCID, 0);

                                break;

                            case "BF1":

                                Cars = Cars + " " + "BF1";
                                Connections[GetConnIdx(MSO.UCID)].Cars = Cars;
                                Connections[GetConnIdx(MSO.UCID)].Cash -= Dealer.GetCarPrice("BF1");
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7bought a ^1BF1");
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have bought ^7BMW Sauber F1.06 (BF1) ^7in Garage", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 Price Tag: ^1$" + Dealer.GetCarPrice("BF1") + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash + " ^7left", MSO.UCID, 0);

                                break;
                        }

                    }




                    #endregion
                }
                else
                {
                    if (StrMsg.Length == 1)
                    {
                        MsgPly("^1*^3 Buying Parameter ^2!buy X ^7- eg. ^2!buy XRG", MSO.UCID);
                    }
                    else
                    {
                        MsgPly("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID);
                    }
                }
                #endregion
            }
            else
            {
                MsgPly("^1*^3 Drive to a car dealer", MSO.UCID);
            }
        }
        [Command("prices", "prices")]
        public void prices(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            if (StrMsg.Length == 1)
            {
                long Cash = Connections[GetConnIdx(MSO.UCID)].Cash;
                InSim.Send_MTC_MessageToConnection("^4| " + ServerName + " ^7Dealership: ", MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^1||^7 Carname - ^1Buy ^7- ^2Sell ^7- ^2Status ^7- ^2Drivable", MSO.UCID, 0);

                // Normal Range
                #region ' XRG '
                if (Connections[GetConnIdx(MSO.UCID)].Cars.Contains("XRG"))
                {
                    if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 199)
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 XRG - ^1$" + Dealer.GetCarPrice("XRG") + " ^7- ^2$" + Dealer.GetCarValue("XRG") + " ^7- ^2Owned ^7- X", (MSO.UCID), (MSO.PLID));
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 XRG - ^1$" + Dealer.GetCarPrice("XRG") + " ^7- ^2$" + Dealer.GetCarValue("XRG") + " ^7- ^2Owned ^7- OK", (MSO.UCID), (MSO.PLID));
                    }
                }
                else
                {
                    if (Connections[GetConnIdx(MSO.UCID)].Cash >= Dealer.GetCarPrice("XRG"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 199)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 XRG - ^1$" + Dealer.GetCarPrice("XRG") + " ^7- ^2$" + Dealer.GetCarValue("XRG") + " ^7- ^2Have Enough ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 XRG - ^1$" + Dealer.GetCarPrice("XRG") + " ^7- ^2$" + Dealer.GetCarValue("XRG") + " ^7- ^2Have Enough ^7- OK", (MSO.UCID), 0);
                        }
                    }
                    if (Connections[GetConnIdx(MSO.UCID)].Cash < Dealer.GetCarPrice("XRG"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 199)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 XRG - ^1$" + Dealer.GetCarPrice("XRG") + " ^7- ^2$" + Dealer.GetCarValue("XRG") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("XRG") - Cash) + " ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 XRG - ^1$" + Dealer.GetCarPrice("XRG") + " ^7- ^2$" + Dealer.GetCarValue("XRG") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("XRG") - Cash) + " ^7- OK", (MSO.UCID), 0);
                        }
                    }
                }
                #endregion

                // Turbo Powered and Engined Range
                #region ' LX4 '
                if (Connections[GetConnIdx(MSO.UCID)].Cars.Contains("LX4"))
                {
                    if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 699)
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 LX4 - ^1$" + Dealer.GetCarPrice("LX4") + " ^7- ^2$" + Dealer.GetCarValue("LX4") + " ^7- ^2Owned ^7- X", (MSO.UCID), (MSO.PLID));
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 LX4 - ^1$" + Dealer.GetCarPrice("LX4") + " ^7- ^2$" + Dealer.GetCarValue("LX4") + " ^7- ^2Owned ^7- OK", (MSO.UCID), (MSO.PLID));
                    }
                }
                else
                {
                    if (Connections[GetConnIdx(MSO.UCID)].Cash >= Dealer.GetCarPrice("LX4"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 699)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 LX4 - ^1$" + Dealer.GetCarPrice("LX4") + " ^7- ^2$" + Dealer.GetCarValue("LX4") + " ^7- ^2Have Enough ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 LX4 - ^1$" + Dealer.GetCarPrice("LX4") + " ^7- ^2$" + Dealer.GetCarValue("LX4") + " ^7- ^2Have Enough ^7- OK", (MSO.UCID), 0);
                        }
                    }
                    if (Connections[GetConnIdx(MSO.UCID)].Cash < Dealer.GetCarPrice("LX4"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 699)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 LX4 - ^1$" + Dealer.GetCarPrice("LX4") + " ^7- ^2$" + Dealer.GetCarValue("LX4") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("LX4") - Cash) + " ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 LX4 - ^1$" + Dealer.GetCarPrice("LX4") + " ^7- ^2$" + Dealer.GetCarValue("LX4") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("LX4") - Cash) + " ^7- OK", (MSO.UCID), 0);
                        }
                    }
                }
                #endregion

                #region ' RB4 '
                if (Connections[GetConnIdx(MSO.UCID)].Cars.Contains("RB4"))
                {
                    if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 699)
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 RB4 - ^1$" + Dealer.GetCarPrice("RB4") + " ^7- ^2$" + Dealer.GetCarValue("RB4") + " ^7- ^2Owned ^7- X", (MSO.UCID), (MSO.PLID));
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 RB4 - ^1$" + Dealer.GetCarPrice("RB4") + " ^7- ^2$" + Dealer.GetCarValue("RB4") + " ^7- ^2Owned ^7- OK", (MSO.UCID), (MSO.PLID));
                    }
                }
                else
                {
                    if (Connections[GetConnIdx(MSO.UCID)].Cash >= Dealer.GetCarPrice("RB4"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 699)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 RB4 - ^1$" + Dealer.GetCarPrice("RB4") + " ^7- ^2$" + Dealer.GetCarValue("RB4") + " ^7- ^2Have Enough ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 RB4 - ^1$" + Dealer.GetCarPrice("RB4") + " ^7- ^2$" + Dealer.GetCarValue("RB4") + " ^7- ^2Have Enough ^7- OK", (MSO.UCID), 0);
                        }
                    }
                    if (Connections[GetConnIdx(MSO.UCID)].Cash < Dealer.GetCarPrice("RB4"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 699)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 RB4 - ^1$" + Dealer.GetCarPrice("RB4") + " ^7- ^2$" + Dealer.GetCarValue("RB4") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("RB4") - Cash) + " ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 RB4 - ^1$" + Dealer.GetCarPrice("RB4") + " ^7- ^2$" + Dealer.GetCarValue("RB4") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("RB4") - Cash) + " ^7- OK", (MSO.UCID), 0);
                        }
                    }
                }
                #endregion

                #region ' FXO '
                if (Connections[GetConnIdx(MSO.UCID)].Cars.Contains("FXO"))
                {
                    if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 699)
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 FXO - ^1$" + Dealer.GetCarPrice("FXO") + " ^7- ^2$" + Dealer.GetCarValue("FXO") + " ^7- ^2Owned ^7- X", (MSO.UCID), (MSO.PLID));
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 FXO - ^1$" + Dealer.GetCarPrice("FXO") + " ^7- ^2$" + Dealer.GetCarValue("FXO") + " ^7- ^2Owned ^7- OK", (MSO.UCID), (MSO.PLID));
                    }
                }
                else
                {
                    if (Connections[GetConnIdx(MSO.UCID)].Cash >= Dealer.GetCarPrice("FXO"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 699)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 FXO - ^1$" + Dealer.GetCarPrice("FXO") + " ^7- ^2$" + Dealer.GetCarValue("FXO") + " ^7- ^2Have Enough ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 FXO - ^1$" + Dealer.GetCarPrice("FXO") + " ^7- ^2$" + Dealer.GetCarValue("FXO") + " ^7- ^2Have Enough ^7- OK", (MSO.UCID), 0);
                        }
                    }
                    if (Connections[GetConnIdx(MSO.UCID)].Cash < Dealer.GetCarPrice("FXO"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 699)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 FXO - ^1$" + Dealer.GetCarPrice("FXO") + " ^7- ^2$" + Dealer.GetCarValue("FXO") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("FXO") - Cash) + " ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 FXO - ^1$" + Dealer.GetCarPrice("FXO") + " ^7- ^2$" + Dealer.GetCarValue("FXO") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("FXO") - Cash) + " ^7- OK", (MSO.UCID), 0);
                        }
                    }
                }
                #endregion

                #region ' VWS '
                if (Connections[GetConnIdx(MSO.UCID)].Cars.Contains("VWS"))
                {
                    if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 699)
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 VWS - ^1$" + Dealer.GetCarPrice("VWS") + " ^7- ^2$" + Dealer.GetCarValue("VWS") + " ^7- ^2Owned ^7- X", (MSO.UCID), (MSO.PLID));
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 VWS - ^1$" + Dealer.GetCarPrice("VWS") + " ^7- ^2$" + Dealer.GetCarValue("VWS") + " ^7- ^2Owned ^7- OK", (MSO.UCID), (MSO.PLID));
                    }
                }
                else
                {
                    if (Connections[GetConnIdx(MSO.UCID)].Cash >= Dealer.GetCarPrice("VWS"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 699)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 VWS - ^1$" + Dealer.GetCarPrice("VWS") + " ^7- ^2$" + Dealer.GetCarValue("VWS") + " ^7- ^2Have Enough ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 VWS - ^1$" + Dealer.GetCarPrice("VWS") + " ^7- ^2$" + Dealer.GetCarValue("VWS") + " ^7- ^2Have Enough ^7- OK", (MSO.UCID), 0);
                        }
                    }
                    if (Connections[GetConnIdx(MSO.UCID)].Cash < Dealer.GetCarPrice("VWS"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 699)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 VWS - ^1$" + Dealer.GetCarPrice("VWS") + " ^7- ^2$" + Dealer.GetCarValue("VWS") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("VWS") - Cash) + " ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 VWS - ^1$" + Dealer.GetCarPrice("VWS") + " ^7- ^2$" + Dealer.GetCarValue("VWS") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("VWS") - Cash) + " ^7- OK", (MSO.UCID), 0);
                        }
                    }
                }
                #endregion

                #region ' XRT '
                if (Connections[GetConnIdx(MSO.UCID)].Cars.Contains("XRT"))
                {
                    if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 699)
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 XRT - ^1$" + Dealer.GetCarPrice("XRT") + " ^7- ^2$" + Dealer.GetCarValue("XRT") + " ^7- ^2Owned ^7- X", (MSO.UCID), (MSO.PLID));
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 XRT - ^1$" + Dealer.GetCarPrice("XRT") + " ^7- ^2$" + Dealer.GetCarValue("XRT") + " ^7- ^2Owned ^7- OK", (MSO.UCID), (MSO.PLID));
                    }
                }
                else
                {
                    if (Connections[GetConnIdx(MSO.UCID)].Cash >= Dealer.GetCarPrice("XRT"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 699)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 XRT - ^1$" + Dealer.GetCarPrice("XRT") + " ^7- ^2$" + Dealer.GetCarValue("XRT") + " ^7- ^2Have Enough ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 XRT - ^1$" + Dealer.GetCarPrice("XRT") + " ^7- ^2$" + Dealer.GetCarValue("XRT") + " ^7- ^2Have Enough ^7- OK", (MSO.UCID), 0);
                        }
                    }
                    if (Connections[GetConnIdx(MSO.UCID)].Cash < Dealer.GetCarPrice("XRT"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 699)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 XRT - ^1$" + Dealer.GetCarPrice("XRT") + " ^7- ^2$" + Dealer.GetCarValue("XRT") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("XRT") - Cash) + " ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 XRT - ^1$" + Dealer.GetCarPrice("XRT") + " ^7- ^2$" + Dealer.GetCarValue("XRT") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("XRT") - Cash) + " ^7- OK", (MSO.UCID), 0);
                        }
                    }
                }
                #endregion

                // Road Car Range
                #region ' LX6 '
                if (Connections[GetConnIdx(MSO.UCID)].Cars.Contains("LX6"))
                {
                    if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 899)
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 LX6 - ^1$" + Dealer.GetCarPrice("LX6") + " ^7- ^2$" + Dealer.GetCarValue("LX6") + " ^7- ^2Owned ^7- X", (MSO.UCID), (MSO.PLID));
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 LX6 - ^1$" + Dealer.GetCarPrice("LX6") + " ^7- ^2$" + Dealer.GetCarValue("LX6") + " ^7- ^2Owned ^7- OK", (MSO.UCID), (MSO.PLID));
                    }
                }
                else
                {
                    if (Connections[GetConnIdx(MSO.UCID)].Cash >= Dealer.GetCarPrice("LX6"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 899)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 LX6 - ^1$" + Dealer.GetCarPrice("LX6") + " ^7- ^2$" + Dealer.GetCarValue("LX6") + " ^7- ^2Have Enough ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 LX6 - ^1$" + Dealer.GetCarPrice("LX6") + " ^7- ^2$" + Dealer.GetCarValue("LX6") + " ^7- ^2Have Enough ^7- OK", (MSO.UCID), 0);
                        }
                    }
                    if (Connections[GetConnIdx(MSO.UCID)].Cash < Dealer.GetCarPrice("LX6"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 899)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 LX6 - ^1$" + Dealer.GetCarPrice("LX6") + " ^7- ^2$" + Dealer.GetCarValue("LX6") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("LX6") - Cash) + " ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 LX6 - ^1$" + Dealer.GetCarPrice("LX6") + " ^7- ^2$" + Dealer.GetCarValue("LX6") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("LX6") - Cash) + " ^7- OK", (MSO.UCID), 0);
                        }
                    }
                }
                #endregion

                #region ' RAC '
                if (Connections[GetConnIdx(MSO.UCID)].Cars.Contains("RAC"))
                {
                    if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 899)
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 RAC - ^1$" + Dealer.GetCarPrice("RAC") + " ^7- ^2$" + Dealer.GetCarValue("RAC") + " ^7- ^2Owned ^7- X", (MSO.UCID), (MSO.PLID));
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 RAC - ^1$" + Dealer.GetCarPrice("RAC") + " ^7- ^2$" + Dealer.GetCarValue("RAC") + " ^7- ^2Owned ^7- OK", (MSO.UCID), (MSO.PLID));
                    }
                }
                else
                {
                    if (Connections[GetConnIdx(MSO.UCID)].Cash >= Dealer.GetCarPrice("RAC"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 899)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 RAC - ^1$" + Dealer.GetCarPrice("RAC") + " ^7- ^2$" + Dealer.GetCarValue("RAC") + " ^7- ^2Have Enough ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 RAC - ^1$" + Dealer.GetCarPrice("RAC") + " ^7- ^2$" + Dealer.GetCarValue("RAC") + " ^7- ^2Have Enough ^7- OK", (MSO.UCID), 0);
                        }
                    }
                    if (Connections[GetConnIdx(MSO.UCID)].Cash < Dealer.GetCarPrice("RAC"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 899)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 RAC - ^1$" + Dealer.GetCarPrice("RAC") + " ^7- ^2$" + Dealer.GetCarValue("RAC") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("RAC") - Cash) + " ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 RAC - ^1$" + Dealer.GetCarPrice("RAC") + " ^7- ^2$" + Dealer.GetCarValue("RAC") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("RAC") - Cash) + " ^7- OK", (MSO.UCID), 0);
                        }
                    }
                }
                #endregion

                #region ' FZ5 '
                if (Connections[GetConnIdx(MSO.UCID)].Cars.Contains("FZ5"))
                {
                    if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 899)
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 FZ5 - ^1$" + Dealer.GetCarPrice("FZ5") + " ^7- ^2$" + Dealer.GetCarValue("FZ5") + " ^7- ^2Owned ^7- X", (MSO.UCID), (MSO.PLID));
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 FZ5 - ^1$" + Dealer.GetCarPrice("FZ5") + " ^7- ^2$" + Dealer.GetCarValue("FZ5") + " ^7- ^2Owned ^7- OK", (MSO.UCID), (MSO.PLID));
                    }
                }
                else
                {
                    if (Connections[GetConnIdx(MSO.UCID)].Cash >= Dealer.GetCarPrice("FZ5"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 899)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 FZ5 - ^1$" + Dealer.GetCarPrice("FZ5") + " ^7- ^2$" + Dealer.GetCarValue("FZ5") + " ^7- ^2Have Enough ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 FZ5 - ^1$" + Dealer.GetCarPrice("FZ5") + " ^7- ^2$" + Dealer.GetCarValue("FZ5") + " ^7- ^2Have Enough ^7- OK", (MSO.UCID), 0);
                        }
                    }
                    if (Connections[GetConnIdx(MSO.UCID)].Cash < Dealer.GetCarPrice("FZ5"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 899)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 FZ5 - ^1$" + Dealer.GetCarPrice("FZ5") + " ^7- ^2$" + Dealer.GetCarValue("FZ5") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("FZ5") - Cash) + " ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 FZ5 - ^1$" + Dealer.GetCarPrice("FZ5") + " ^7- ^2$" + Dealer.GetCarValue("FZ5") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("FZ5") - Cash) + " ^7- OK", (MSO.UCID), 0);
                        }
                    }
                }
                #endregion

                // First two GTR Range
                #region ' UFR '
                if (Connections[GetConnIdx(MSO.UCID)].Cars.Contains("UFR"))
                {
                    if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 999)
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 UFR - ^1$" + Dealer.GetCarPrice("UFR") + " ^7- ^2$" + Dealer.GetCarValue("UFR") + " ^7- ^2Owned ^7- X", (MSO.UCID), (MSO.PLID));
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 UFR - ^1$" + Dealer.GetCarPrice("UFR") + " ^7- ^2$" + Dealer.GetCarValue("UFR") + " ^7- ^2Owned ^7- OK", (MSO.UCID), (MSO.PLID));
                    }
                }
                else
                {
                    if (Connections[GetConnIdx(MSO.UCID)].Cash >= Dealer.GetCarPrice("UFR"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 999)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 UFR - ^1$" + Dealer.GetCarPrice("UFR") + " ^7- ^2$" + Dealer.GetCarValue("UFR") + " ^7- ^2Have Enough ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 UFR - ^1$" + Dealer.GetCarPrice("UFR") + " ^7- ^2$" + Dealer.GetCarValue("UFR") + " ^7- ^2Have Enough ^7- OK", (MSO.UCID), 0);
                        }
                    }
                    if (Connections[GetConnIdx(MSO.UCID)].Cash < Dealer.GetCarPrice("UFR"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 999)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 UFR - ^1$" + Dealer.GetCarPrice("UFR") + " ^7- ^2$" + Dealer.GetCarValue("UFR") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("UFR") - Cash) + " ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 UFR - ^1$" + Dealer.GetCarPrice("UFR") + " ^7- ^2$" + Dealer.GetCarValue("UFR") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("UFR") - Cash) + " ^7- OK", (MSO.UCID), 0);
                        }
                    }
                }
                #endregion

                #region ' XFR '
                if (Connections[GetConnIdx(MSO.UCID)].Cars.Contains("XFR"))
                {
                    if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 999)
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 XFR - ^1$" + Dealer.GetCarPrice("XFR") + " ^7- ^2$" + Dealer.GetCarValue("XFR") + " ^7- ^2Owned ^7- X", (MSO.UCID), (MSO.PLID));
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 XFR - ^1$" + Dealer.GetCarPrice("XFR") + " ^7- ^2$" + Dealer.GetCarValue("XFR") + " ^7- ^2Owned ^7- OK", (MSO.UCID), (MSO.PLID));
                    }
                }
                else
                {
                    if (Connections[GetConnIdx(MSO.UCID)].Cash >= Dealer.GetCarPrice("XFR"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 999)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 XFR - ^1$" + Dealer.GetCarPrice("XFR") + " ^7- ^2$" + Dealer.GetCarValue("XFR") + " ^7- ^2Have Enough ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 XFR - ^1$" + Dealer.GetCarPrice("XFR") + " ^7- ^2$" + Dealer.GetCarValue("XFR") + " ^7- ^2Have Enough ^7- OK", (MSO.UCID), 0);
                        }
                    }
                    if (Connections[GetConnIdx(MSO.UCID)].Cash < Dealer.GetCarPrice("XFR"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 999)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 XFR - ^1$" + Dealer.GetCarPrice("XFR") + " ^7- ^2$" + Dealer.GetCarValue("XFR") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("XFR") - Cash) + " ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 XFR - ^1$" + Dealer.GetCarPrice("XFR") + " ^7- ^2$" + Dealer.GetCarValue("XFR") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("XFR") - Cash) + " ^7- OK", (MSO.UCID), 0);
                        }
                    }
                }
                #endregion

                // Three Major GTR Range
                #region ' FXR '
                if (Connections[GetConnIdx(MSO.UCID)].Cars.Contains("FXR"))
                {
                    if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 2999)
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 FXR - ^1$" + Dealer.GetCarPrice("FXR") + " ^7- ^2$" + Dealer.GetCarValue("FXR") + " ^7- ^2Owned ^7- X", (MSO.UCID), (MSO.PLID));
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 FXR - ^1$" + Dealer.GetCarPrice("FXR") + " ^7- ^2$" + Dealer.GetCarValue("FXR") + " ^7- ^2Owned ^7- OK", (MSO.UCID), (MSO.PLID));
                    }
                }
                else
                {
                    if (Connections[GetConnIdx(MSO.UCID)].Cash >= Dealer.GetCarPrice("FXR"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 2999)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 FXR - ^1$" + Dealer.GetCarPrice("FXR") + " ^7- ^2$" + Dealer.GetCarValue("FXR") + " ^7- ^2Have Enough ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 FXR - ^1$" + Dealer.GetCarPrice("FXR") + " ^7- ^2$" + Dealer.GetCarValue("FXR") + " ^7- ^2Have Enough ^7- OK", (MSO.UCID), 0);
                        }
                    }
                    if (Connections[GetConnIdx(MSO.UCID)].Cash < Dealer.GetCarPrice("FXR"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 2999)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 FXR - ^1$" + Dealer.GetCarPrice("FXR") + " ^7- ^2$" + Dealer.GetCarValue("FXR") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("FXR") - Cash) + " ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 FXR - ^1$" + Dealer.GetCarPrice("FXR") + " ^7- ^2$" + Dealer.GetCarValue("FXR") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("FXR") - Cash) + " ^7- OK", (MSO.UCID), 0);
                        }
                    }
                }
                #endregion

                #region ' XRR '
                if (Connections[GetConnIdx(MSO.UCID)].Cars.Contains("XRR"))
                {
                    if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 2999)
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 XRR - ^1$" + Dealer.GetCarPrice("XRR") + " ^7- ^2$" + Dealer.GetCarValue("XRR") + " ^7- ^2Owned ^7- X", (MSO.UCID), (MSO.PLID));
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 XRR - ^1$" + Dealer.GetCarPrice("XRR") + " ^7- ^2$" + Dealer.GetCarValue("XRR") + " ^7- ^2Owned ^7- OK", (MSO.UCID), (MSO.PLID));
                    }
                }
                else
                {
                    if (Connections[GetConnIdx(MSO.UCID)].Cash >= Dealer.GetCarPrice("XRR"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 2999)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 XRR - ^1$" + Dealer.GetCarPrice("XRR") + " ^7- ^2$" + Dealer.GetCarValue("XRR") + " ^7- ^2Have Enough ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 XRR - ^1$" + Dealer.GetCarPrice("XRR") + " ^7- ^2$" + Dealer.GetCarValue("XRR") + " ^7- ^2Have Enough ^7- OK", (MSO.UCID), 0);
                        }
                    }
                    if (Connections[GetConnIdx(MSO.UCID)].Cash < Dealer.GetCarPrice("XRR"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 2999)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 XRR - ^1$" + Dealer.GetCarPrice("XRR") + " ^7- ^2$" + Dealer.GetCarValue("XRR") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("XRR") - Cash) + " ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 XRR - ^1$" + Dealer.GetCarPrice("XRR") + " ^7- ^2$" + Dealer.GetCarValue("XRR") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("XRR") - Cash) + " ^7- OK", (MSO.UCID), 0);
                        }
                    }
                }
                #endregion

                #region ' FZR '
                if (Connections[GetConnIdx(MSO.UCID)].Cars.Contains("FZR"))
                {
                    if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 2999)
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 FZR - ^1$" + Dealer.GetCarPrice("FZR") + " ^7- ^2$" + Dealer.GetCarValue("FZR") + " ^7- ^2Owned ^7- X", (MSO.UCID), (MSO.PLID));
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 FZR - ^1$" + Dealer.GetCarPrice("FZR") + " ^7- ^2$" + Dealer.GetCarValue("FZR") + " ^7- ^2Owned ^7- OK", (MSO.UCID), (MSO.PLID));
                    }
                }
                else
                {
                    if (Connections[GetConnIdx(MSO.UCID)].Cash >= Dealer.GetCarPrice("FZR"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 2999)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 FZR - ^1$" + Dealer.GetCarPrice("FZR") + " ^7- ^2$" + Dealer.GetCarValue("FZR") + " ^7- ^2Have Enough ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 FZR - ^1$" + Dealer.GetCarPrice("FZR") + " ^7- ^2$" + Dealer.GetCarValue("FZR") + " ^7- ^2Have Enough ^7- OK", (MSO.UCID), 0);
                        }
                    }
                    if (Connections[GetConnIdx(MSO.UCID)].Cash < Dealer.GetCarPrice("FZR"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 2999)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 FZR - ^1$" + Dealer.GetCarPrice("FZR") + " ^7- ^2$" + Dealer.GetCarValue("FZR") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("FZR") - Cash) + " ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 FZR - ^1$" + Dealer.GetCarPrice("FZR") + " ^7- ^2$" + Dealer.GetCarValue("FZR") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("FZR") - Cash) + " ^7- OK", (MSO.UCID), 0);
                        }
                    }
                }
                #endregion

                // One Seaters Range
                #region ' MRT '
                if (Connections[GetConnIdx(MSO.UCID)].Cars.Contains("MRT"))
                {
                    if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 2999)
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 MRT - ^1$" + Dealer.GetCarPrice("MRT") + " ^7- ^2$" + Dealer.GetCarValue("MRT") + " ^7- ^2Owned ^7- X", (MSO.UCID), (MSO.PLID));
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 MRT - ^1$" + Dealer.GetCarPrice("MRT") + " ^7- ^2$" + Dealer.GetCarValue("MRT") + " ^7- ^2Owned ^7- OK", (MSO.UCID), (MSO.PLID));
                    }
                }
                else
                {
                    if (Connections[GetConnIdx(MSO.UCID)].Cash >= Dealer.GetCarPrice("MRT"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 2999)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 MRT - ^1$" + Dealer.GetCarPrice("MRT") + " ^7- ^2$" + Dealer.GetCarValue("MRT") + " ^7- ^2Have Enough ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 MRT - ^1$" + Dealer.GetCarPrice("MRT") + " ^7- ^2$" + Dealer.GetCarValue("MRT") + " ^7- ^2Have Enough ^7- OK", (MSO.UCID), 0);
                        }
                    }
                    if (Connections[GetConnIdx(MSO.UCID)].Cash < Dealer.GetCarPrice("MRT"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 2999)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 MRT - ^1$" + Dealer.GetCarPrice("MRT") + " ^7- ^2$" + Dealer.GetCarValue("MRT") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("MRT") - Cash) + " ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 MRT - ^1$" + Dealer.GetCarPrice("MRT") + " ^7- ^2$" + Dealer.GetCarValue("MRT") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("MRT") - Cash) + " ^7- OK", (MSO.UCID), 0);
                        }
                    }
                }
                #endregion

                #region ' FBM '
                if (Connections[GetConnIdx(MSO.UCID)].Cars.Contains("FBM"))
                {
                    if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 2999)
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 FBM - ^1$" + Dealer.GetCarPrice("FBM") + " ^7- ^2$" + Dealer.GetCarValue("FBM") + " ^7- ^2Owned ^7- X", (MSO.UCID), (MSO.PLID));
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1||^7 FBM - ^1$" + Dealer.GetCarPrice("FBM") + " ^7- ^2$" + Dealer.GetCarValue("FBM") + " ^7- ^2Owned ^7- OK", (MSO.UCID), (MSO.PLID));
                    }
                }
                else
                {
                    if (Connections[GetConnIdx(MSO.UCID)].Cash >= Dealer.GetCarPrice("FBM"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 2999)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 FBM - ^1$" + Dealer.GetCarPrice("FBM") + " ^7- ^2$" + Dealer.GetCarValue("FBM") + " ^7- ^2Have Enough ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 FBM - ^1$" + Dealer.GetCarPrice("FBM") + " ^7- ^2$" + Dealer.GetCarValue("FBM") + " ^7- ^2Have Enough ^7- OK", (MSO.UCID), 0);
                        }
                    }
                    if (Connections[GetConnIdx(MSO.UCID)].Cash < Dealer.GetCarPrice("FBM"))
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].TotalDistance / 1000 <= 2999)
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 FBM - ^1$" + Dealer.GetCarPrice("FBM") + " ^7- ^2$" + Dealer.GetCarValue("FBM") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("FBM") - Cash) + " ^7- X", (MSO.UCID), 0);
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1||^7 FBM - ^1$" + Dealer.GetCarPrice("FBM") + " ^7- ^2$" + Dealer.GetCarValue("FBM") + " ^7- ^2Need ^2$" + (Dealer.GetCarPrice("FBM") - Cash) + " ^7- OK", (MSO.UCID), 0);
                        }
                    }
                }
                #endregion
                MsgPly("^1*^3*******************************", MSO.UCID);
                MsgPly("^2>^1 TO BUY/SELL CAR GO TO CAR DEALER", MSO.UCID);
                MsgPly("^1*^3*******************************", MSO.UCID);

            }
            else
            {
                MsgPly("^1||^7 Invalid Command. ^2!help ^7for help.", MSO.UCID);
            }
        }
        [Command("sell", "sell")]
        public void sell(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            #region ' Trade in '
            if (Connections[GetConnIdx(MSO.UCID)].InHouse1 == 1 || Connections[GetConnIdx(MSO.UCID)].InHouse2 == 1 || Connections[GetConnIdx(MSO.UCID)].InHouse3 == 1 || Connections[GetConnIdx(MSO.UCID)].InHouse4 == 1 || Connections[GetConnIdx(MSO.UCID)].InHouse5 == 1)
            {
                if (StrMsg.Length > 2)
                {
                    long Amount = long.Parse(StrMsg[2]);
                    long Item1 = Connections[GetConnIdx(MSO.UCID)].SellItem1;
                    long Item2 = Connections[GetConnIdx(MSO.UCID)].SellItem2;
                    long Item3 = Connections[GetConnIdx(MSO.UCID)].SellItem3;
                    long Item4 = Connections[GetConnIdx(MSO.UCID)].SellItem4;
                    if (StrMsg[2].Contains("-"))
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Do not put minus on the Values!", MSO.UCID, 0);
                    }
                    else if (StrMsg[2] == "0")
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Put correct numbers eg. ^2!sell ^7<item> 1", MSO.UCID, 0);
                    }
                    #region ' Sell Electronics '
                    else if (StrMsg[1] == "Electronics")
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].Item1 == 0)
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 You don't have any ^1Electronics!", MSO.UCID, 0);
                        }
                        else if (Connections[GetConnIdx(MSO.UCID)].Item1 >= Amount)
                        {
                            if (Amount <= 3)
                            {
                                Connections[GetConnIdx(MSO.UCID)].Item1 -= Amount;
                                Connections[GetConnIdx(MSO.UCID)].Cash += Amount * Item1;
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7successful trade of Electronics!");
                                InSim.Send_MTC_MessageToConnection("^1*^3 In Price of: ^1€" + Item1 * Amount + " ^7Total Electronics: ^1" + Connections[GetConnIdx(MSO.UCID)].Item1, MSO.UCID, 0);
                            }
                            else
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Can't Sell more than 3!", MSO.UCID, 0);
                            }
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not Enough ^1Electronics!", MSO.UCID, 0);
                        }
                    }
                    #endregion

                    #region ' Sell Foods '
                    else if (StrMsg[1] == "Foods")
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].Item2 == 0)
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 You don't have any ^1Foods!", MSO.UCID, 0);
                        }
                        else if (Connections[GetConnIdx(MSO.UCID)].Item2 >= Amount)
                        {
                            if (Amount <= 3)
                            {
                                Connections[GetConnIdx(MSO.UCID)].Item2 -= Amount;
                                Connections[GetConnIdx(MSO.UCID)].Cash += Amount * Item2;
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7successful trade of Foods!");
                                InSim.Send_MTC_MessageToConnection("^1*^3 In Price of: ^1€" + Item2 * Amount + " ^7Total Foods: ^1" + Connections[GetConnIdx(MSO.UCID)].Item2, MSO.UCID, 0);
                            }
                            else
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Can't Sell more than 3!", MSO.UCID, 0);
                            }
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not Enough ^1Foods!", MSO.UCID, 0);
                        }
                    }
                    #endregion

                    #region ' Sell Furniture '
                    else if (StrMsg[1] == "Furniture")
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].Item3 == 0)
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 You don't have any ^1Furniture!", MSO.UCID, 0);
                        }
                        else if (Connections[GetConnIdx(MSO.UCID)].Item3 >= Amount)
                        {
                            if (Amount <= 3)
                            {
                                Connections[GetConnIdx(MSO.UCID)].Item3 -= Amount;
                                Connections[GetConnIdx(MSO.UCID)].Cash += Amount * Item3;
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7successful trade of Furniture!");
                                InSim.Send_MTC_MessageToConnection("^1*^3 In Price of: ^1€" + Item3 * Amount + " ^7Total Furniture: ^1" + Connections[GetConnIdx(MSO.UCID)].Item3, MSO.UCID, 0);
                            }
                            else
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Can't Sell more than 3!", MSO.UCID, 0);
                            }
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not Enough ^1Furniture!", MSO.UCID, 0);
                        }
                    }
                    #endregion

                    #region ' Sell Toys '
                    else if (StrMsg[1] == "Toys")
                    {
                        if (Connections[GetConnIdx(MSO.UCID)].Item4 == 0)
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 You don't have any ^1Toys!", MSO.UCID, 0);
                        }
                        else if (Connections[GetConnIdx(MSO.UCID)].Item4 >= Amount)
                        {
                            if (Amount <= 3)
                            {
                                Connections[GetConnIdx(MSO.UCID)].Item4 -= Amount;
                                Connections[GetConnIdx(MSO.UCID)].Cash += Amount * Item4;
                                MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7successful trade of Toys!");
                                InSim.Send_MTC_MessageToConnection("^1*^3 In Price of: ^1€" + Item4 * Amount + " ^7Total Toys: ^1" + Connections[GetConnIdx(MSO.UCID)].Item4, MSO.UCID, 0);
                            }
                            else
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Can't Sell more than 3!", MSO.UCID, 0);
                            }
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Not Enough ^1Toys!", MSO.UCID, 0);
                        }
                    }
                    #endregion
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
                }
            }
            #endregion
            else if (TrackName == "BL1" && Connections[GetConnIdx(MSO.UCID)].InHouse1 == 0 && Connections[GetConnIdx(MSO.UCID)].InHouse2 == 0 && Connections[GetConnIdx(MSO.UCID)].InHouse3 == 0 && Connections[GetConnIdx(MSO.UCID)].InHouse4 == 0 && Connections[GetConnIdx(MSO.UCID)].InHouse5 == 0)
            {
                #region ' Car Sell '
                if (StrMsg.Length == 2)
                {
                    if (Connections[GetConnIdx(MSO.UCID)].Cars.Contains(StrMsg[1].ToUpper()))
                    {
                        if (Dealer.GetCarPrice(StrMsg[1].ToUpper()) > 0)
                        {
                            #region ' String Check '
                            string UserCars = Connections[GetConnIdx(MSO.UCID)].Cars;
                            int IdxCar = UserCars.IndexOf(StrMsg[1].ToUpper());
                            try
                            {
                                Connections[GetConnIdx(MSO.UCID)].Cars = Connections[GetConnIdx(MSO.UCID)].Cars.Remove(IdxCar, 4);
                            }
                            catch
                            {
                                Connections[GetConnIdx(MSO.UCID)].Cars = Connections[GetConnIdx(MSO.UCID)].Cars.Remove(IdxCar, 3);
                            }
                            #endregion

                            #region ' Sold Message per Car '
                            MsgAll("^1*^3 " + Connections[GetConnIdx(MSO.UCID)].PlayerName + " ^7sold ^1" + StrMsg[1].ToUpper());
                            Connections[GetConnIdx(MSO.UCID)].Cash += Dealer.GetCarValue(StrMsg[1].ToUpper());

                            if (StrMsg[1].ToUpper() == "XRG")
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have sold ^1XR GTi (XRG)", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 For: ^1$" + Dealer.GetCarValue(StrMsg[1].ToUpper()) + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash, MSO.UCID, 0);
                            }
                            else if (StrMsg[1].ToUpper() == "LX4")
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have sold ^1LX4 (LX4)", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 For: ^1$" + Dealer.GetCarValue(StrMsg[1].ToUpper()) + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash, MSO.UCID, 0);
                            }
                            else if (StrMsg[1].ToUpper() == "LX6")
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have sold ^1LX6 (LX6)", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 For: ^1$" + Dealer.GetCarValue(StrMsg[1].ToUpper()) + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash, MSO.UCID, 0);
                            }
                            else if (StrMsg[1].ToUpper() == "RB4")
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have sold ^1RB GT Turbo (RB4)", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 For: ^1$" + Dealer.GetCarValue(StrMsg[1].ToUpper()) + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash, MSO.UCID, 0);
                            }
                            else if (StrMsg[1].ToUpper() == "FXO")
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have sold ^1FX GT Turbo (FXO)", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 For: ^1$" + Dealer.GetCarValue(StrMsg[1].ToUpper()) + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash, MSO.UCID, 0);
                            }
                            else if (StrMsg[1].ToUpper() == "VWS")
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have sold ^1Volkswagen Scirocco (VWS)", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 For: ^1$" + Dealer.GetCarValue(StrMsg[1].ToUpper()) + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash, MSO.UCID, 0);
                            }
                            else if (StrMsg[1].ToUpper() == "XRT")
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have sold ^1XR GT Turbo (XRG)", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 For: ^1$" + Dealer.GetCarValue(StrMsg[1].ToUpper()) + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash, MSO.UCID, 0);
                            }
                            else if (StrMsg[1].ToUpper() == "RAC")
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have sold ^1Raceabout (RAC)", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 For: ^1$" + Dealer.GetCarValue(StrMsg[1].ToUpper()) + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash, MSO.UCID, 0);
                            }
                            else if (StrMsg[1].ToUpper() == "FZ5")
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have sold ^1FZ50 GT (FZ5)", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 For: ^1$" + Dealer.GetCarValue(StrMsg[1].ToUpper()) + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash, MSO.UCID, 0);
                            }
                            else if (StrMsg[1].ToUpper() == "UFR")
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have sold ^1UF GTR (UFR)", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 For: ^1$" + Dealer.GetCarValue(StrMsg[1].ToUpper()) + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash, MSO.UCID, 0);
                            }
                            else if (StrMsg[1].ToUpper() == "XFR")
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have sold ^1XF GTR (XFR)", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 For: ^1$" + Dealer.GetCarValue(StrMsg[1].ToUpper()) + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash, MSO.UCID, 0);
                            }
                            else if (StrMsg[1].ToUpper() == "FXR")
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have sold ^1FX GTR (FXR)", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 For: ^1$" + Dealer.GetCarValue(StrMsg[1].ToUpper()) + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash, MSO.UCID, 0);
                            }
                            else if (StrMsg[1].ToUpper() == "XRR")
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have sold ^1XR GTR (XRR)", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 For: ^1$" + Dealer.GetCarValue(StrMsg[1].ToUpper()) + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash, MSO.UCID, 0);
                            }
                            else if (StrMsg[1].ToUpper() == "FZR")
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have sold ^1FZ GTR (FZR)", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 For: ^1$" + Dealer.GetCarValue(StrMsg[1].ToUpper()) + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash, MSO.UCID, 0);
                            }
                            else if (StrMsg[1].ToUpper() == "MRT")
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have sold ^1McGill Racing Kart 5 (MRT)", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 For: ^1$" + Dealer.GetCarValue(StrMsg[1].ToUpper()) + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash, MSO.UCID, 0);
                            }
                            else if (StrMsg[1].ToUpper() == "FBM")
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have sold ^1Formula BMW FBO2 (FBM)", MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 For: ^1$" + Dealer.GetCarValue(StrMsg[1].ToUpper()) + " ^7You have: ^2$" + Connections[GetConnIdx(MSO.UCID)].Cash, MSO.UCID, 0);
                            }
                            #endregion
                        }

                        #region ' Check if Sellable '
                        else
                        {
                            if (StrMsg[1].ToUpper() == "XFG" || StrMsg[1].ToLower() == "xfg")
                            {
                                InSim.Send_MTC_MessageToConnection("^2> XF GTi (XFG) ^7cannot be sold", MSO.UCID, 0);
                            }
                            else
                            {
                                InSim.Send_MTC_MessageToConnection("^2> " + StrMsg[1].ToUpper() + " ^7Invalid Car Garage List", MSO.UCID, 0);
                            }
                        }
                        #endregion
                    }
                }
                else
                {
                    MsgPly("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID);
                }
                #endregion
            }
            else
            {
                MsgPly("^1*^3 Drive to a car dealer/house", MSO.UCID);
            }
        }

        [Command("channel", "channel <Lang>")]
        public void channel(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                bool FoundChannel = false;
                var ToUpper = StrMsg[1].ToUpper();

                #region ' Default English '
                if (ToUpper == "ENG")
                {
                    Conn.ChannelLanguage = 0;
                    MsgPly("^1*^3 Channel switch to Default English.", MSO.UCID);
                    FoundChannel = true;
                }
                #endregion

                #region ' Deutch/German '
                if (ToUpper == "DEU")
                {
                    Conn.ChannelLanguage = 1;
                    MsgPly("^1*^3 Channel switch to Deustch Settings", MSO.UCID);
                    FoundChannel = true;
                }
                #endregion

                #region ' Czech '
                if (ToUpper == "CZE")
                {
                    Conn.ChannelLanguage = 2;
                    MsgPly("^1*^3 Channel switched to Czech Settings", MSO.UCID);
                    FoundChannel = true;
                }
                #endregion

                #region ' Estonian '
                if (ToUpper == "EST")
                {
                    Conn.ChannelLanguage = 3;
                    MsgPly("^1*^3 Channel switched to Estonian Settings", MSO.UCID);
                    FoundChannel = true;
                }
                #endregion

                #region ' Netherlands/Dutch '
                if (ToUpper == "NL")
                {
                    Conn.ChannelLanguage = 4;
                    MsgPly("^1*^3 Channel switched to Dutch Settings", MSO.UCID);
                    FoundChannel = true;
                }
                #endregion

                #region ' Hungarian '
                if (ToUpper == "HUN")
                {
                    Conn.ChannelLanguage = 5;
                    MsgPly("^1*^3 Channel switched to Hungarian Settings", MSO.UCID);
                    FoundChannel = true;
                }
                #endregion

                #region ' Spanish '

                if (ToUpper == "SPA")
                {
                    Conn.ChannelLanguage = 6;
                    MsgPly("^1*^3 Channel switched to Spanish Settings", MSO.UCID);
                    FoundChannel = true;
                }
                #endregion

                #region ' Chinese '

                if (ToUpper == "Chinese")
                {
                    Conn.ChannelLanguage = 7;
                    MsgPly("^1*^3 Channel switched to Chinese Settings", MSO.UCID);
                    FoundChannel = true;
                }
                #endregion

                if (FoundChannel == false)
                {
                    MsgPly("^1*^3 Sorry Channel " + StrMsg[1] + " is not yet Made", MSO.UCID);
                    MsgPly("^1*^3 Current Channels: ENG, DEU, CZE, EST, NL, HUN, SPA, Chinese", MSO.UCID);
                }
            }
            else
            {
                MsgPly("^1*^3 Invalid Channel Command. ^2!channel <Language>", MSO.UCID);
                MsgPly("^1*^3 Current Channels: ^6ENG, DEU, CZE, EST, NL, HUN, SPA, Chinese", MSO.UCID);
            }
        }
        [Command("ch", "ch <msg>")]
        public void ch(string Msg, String[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                string RemoveMsg = Msg.Remove(0, 3);
                bool ChannelCorrect = false;

                #region ' English '
                if (Conn.ChannelLanguage == 0)
                {
                    MsgPly("^1*^3 Please use the Regular chat!", MSO.UCID);
                    ChannelCorrect = true;
                }
                #endregion

                #region ' Localizations '

                foreach (clsConnection Ch in Connections)
                {
                    #region ' Deutschland '

                    if (Ch.ChannelLanguage == 1)
                    {
                        MsgPly(Conn.PlayerName + "^7 [DEU Ch.] :^2" + RemoveMsg, Ch.UniqueID);
                        ChannelCorrect = true;
                        if (System.IO.File.Exists(UserInfo + "\\ChatLog\\DEUChatlog - Rename to Date.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/ChatLog/DEUChatlog - Rename to Date.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/ChatLog/DEUChatlog - Rename to Date.txt");
                            Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - DEUChat: " + Conn.PlayerName + " (" + Conn.Username + "): " + RemoveMsg);
                            Ap.Flush();
                            Ap.Close();
                        }
                        else
                        {
                            MessageBox.Show("DEUChatlog missing!");
                        }
                    }

                    #endregion

                    #region ' Czech '

                    if (Ch.ChannelLanguage == 2)
                    {
                        MsgPly(Conn.PlayerName + "^7 [CZE Ch.] :^2" + RemoveMsg, Ch.UniqueID);
                        ChannelCorrect = true;
                        if (System.IO.File.Exists(UserInfo + "\\ChatLog\\CZEChatlog - Rename to Date.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/ChatLog/CZEChatlog - Rename to Date.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/ChatLog/CZEChatlog - Rename to Date.txt");
                            Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - CZEChat: " + Conn.PlayerName + " (" + Conn.Username + "): " + RemoveMsg);
                            Ap.Flush();
                            Ap.Close();
                        }
                        else
                        {
                            MessageBox.Show("CZEChatlog missing!");
                        }
                    }

                    #endregion

                    #region ' Estonian '
                    if (Ch.ChannelLanguage == 3)
                    {
                        MsgPly(Conn.PlayerName + "^7 [EST Ch.] :^2" + RemoveMsg, Ch.UniqueID);
                        ChannelCorrect = true;
                        if (System.IO.File.Exists(UserInfo + "\\ChatLog\\ESTChatlog - Rename to Date.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/ChatLog/ESTChatlog - Rename to Date.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/ChatLog/ESTChatlog - Rename to Date.txt");
                            Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - ESTChat: " + Conn.PlayerName + " (" + Conn.Username + "): " + RemoveMsg);
                            Ap.Flush();
                            Ap.Close();
                        }
                        else
                        {
                            MessageBox.Show("ESTChatlog missing!");
                        }
                    }
                    #endregion

                    #region ' Dutch '
                    if (Ch.ChannelLanguage == 4)
                    {
                        MsgPly(Conn.PlayerName + "^7 [NL Ch.] :^2" + RemoveMsg, Ch.UniqueID);
                        ChannelCorrect = true;
                        if (System.IO.File.Exists(UserInfo + "\\ChatLog\\NLChatlog - Rename to Date.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/ChatLog/NLChatlog - Rename to Date.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/ChatLog/NLChatlog - Rename to Date.txt");
                            Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - NLChat: " + Conn.PlayerName + " (" + Conn.Username + "): " + RemoveMsg);
                            Ap.Flush();
                            Ap.Close();
                        }
                        else
                        {
                            MessageBox.Show("NLChatlog missing!");
                        }
                    }
                    #endregion

                    #region ' Hungarian '
                    if (Ch.ChannelLanguage == 5)
                    {
                        MsgPly(Conn.PlayerName + "^7 [HUN Ch.] :^2" + RemoveMsg, Ch.UniqueID);
                        ChannelCorrect = true;
                        if (System.IO.File.Exists(UserInfo + "\\ChatLog\\HUNChatlog - Rename to Date.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/ChatLog/HUNChatlog - Rename to Date.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/ChatLog/HUNChatlog - Rename to Date.txt");
                            Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - HUNChat: " + Conn.PlayerName + " (" + Conn.Username + "): " + RemoveMsg);
                            Ap.Flush();
                            Ap.Close();
                        }
                        else
                        {
                            MessageBox.Show("HUNChatlog missing!");
                        }
                    }
                    #endregion

                    #region ' Spanish '
                    if (Ch.ChannelLanguage == 6)
                    {
                        MsgPly(Conn.PlayerName + "^7 [SPA Ch.] :^2" + RemoveMsg, Ch.UniqueID);
                        ChannelCorrect = true;
                        if (System.IO.File.Exists(UserInfo + "\\ChatLog\\SPAChatlog - Rename to Date.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/ChatLog/SPAChatlog - Rename to Date.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/ChatLog/SPAChatlog - Rename to Date.txt");
                            Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - SPAChat: " + Conn.PlayerName + " (" + Conn.Username + "): " + RemoveMsg);
                            Ap.Flush();
                            Ap.Close();
                        }
                        else
                        {
                            MessageBox.Show("SPAChatlog missing!");
                        }
                    }
                    #endregion

                    #region ' Chinese '
                    if (Ch.ChannelLanguage == 7)
                    {
                        MsgPly(Conn.PlayerName + "^7 [CHI Ch.] :^2" + RemoveMsg, Ch.UniqueID);
                        ChannelCorrect = true;
                        if (System.IO.File.Exists(UserInfo + "\\ChatLog\\ChineseChatlog - Rename to Date.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/ChatLog/ChineseChatlog - Rename to Date.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/ChatLog/ChineseChatlog - Rename to Date.txt");
                            Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - ChineseChat: " + Conn.PlayerName + " (" + Conn.Username + "): " + RemoveMsg);
                            Ap.Flush();
                            Ap.Close();
                        }
                        else
                        {
                            MessageBox.Show("ChineseChatlog missing!");
                        }
                    }
                    #endregion
                }

                if (ChannelCorrect == false)
                {
                    MsgPly("^1*^3 Your Channel Settings is Incorrect.", MSO.UCID);
                }

                #endregion
            }
            else
            {
                MsgPly("^1*^3 Invalid Channel Command. ^2!ch <Msg>", MSO.UCID);
            }
        }

        [Command("pm", "pm <username> <message>")]
        public void pm(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            if (StrMsg.Length > 2)
            {
                if (Connections[GetConnIdx(MSO.UCID)].Username == StrMsg[1] && StrMsg[1].Length > 1)
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 You can't send PM to yourself!", MSO.UCID, 0);
                }
                else
                {
                    clsConnection Conn = Connections[GetConnIdx(MSO.UCID)];
                    bool PMUserFound = false;
                    foreach (clsConnection C in Connections)
                    {
                        string Message = Msg.Remove(0, C.Username.Length + 5);

                        if (C.Username == StrMsg[1] && StrMsg[1].Length > 1)
                        {
                            PMUserFound = true;

                            InSim.Send_MTC_MessageToConnection("^1*^3 Message Sent To: ^7" + C.PlayerName + " (" + C.Username + ")", MSO.UCID, 0);
                            InSim.Send_MTC_MessageToConnection("^1*^3 Msg: ^2" + Message, MSO.UCID, 0);

                            InSim.Send_MTC_MessageToConnection("^1*^3 PM From: ^7" + Conn.PlayerName + " (" + Conn.Username + ")", C.UniqueID, 0);
                            InSim.Send_MTC_MessageToConnection("^1*^3 Msg: ^2" + Message, C.UniqueID, 0);
                            InSim.Send_MTC_MessageToConnection("^1*^3 To reply use ^2!pm " + Conn.Username + " <message>", C.UniqueID, 0);

                            foreach (clsConnection F in Connections)
                            {
                                if ((F.IsAdmin == 1) && F.UniqueID != MSO.UCID)
                                {
                                    InSim.Send_MTC_MessageToConnection("^1*^3 --Admin Copy--", F.UniqueID, 0);
                                    InSim.Send_MTC_MessageToConnection("^1*^3 PM From: ^7" + Conn.PlayerName + " to " + C.PlayerName, F.UniqueID, 0);
                                    InSim.Send_MTC_MessageToConnection("^1*^3 Msg: ^2" + Message, F.UniqueID, 0);
                                }
                            }
                        }
                    }
                    if (PMUserFound == false)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Username not found.", MSO.UCID, 0);
                    }
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command.", MSO.UCID, 0);
            }
        }

        #region ' Officer/Cadet Commands '

        [Command("chase", "chase")]
        public void chase(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            clsConnection Conn = Connections[GetConnIdx(MSO.UCID)];
            clsConnection Conn2 = Connections[GetConnIdx(Connections[GetConnIdx(MSO.UCID)].Chasee)];
            if (StrMsg.Length > 0)
            {
                if (Conn.IsOfficer == 1 || Conn.IsCadet == 1)
                {
                    if (Conn.OpenBustedBox == 0)
                    {
                        if (Conn.IsOfficer != 0 || Conn.IsCadet != 0)
                        {
                            if (Conn.ChaseCondition == 0)
                            {
                                ChaseInitiated = 1;
                                ChaserUCID = MSO.UCID;
                                if (Conn2.IsMafia == 1)
                                {
                                    Conn.ChaseCondition = 3;
                                }
                            }
                            else
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 You are chasing " + Conn2.PlayerName, MSO.UCID, 0);
                            }
                        }
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Fill up the Busted box before start another!", MSO.UCID, 0);
                    }
                }
                else
                {
                    if (Connections[GetConnIdx(MSO.UCID)].CanBeOfficer == 1 || Connections[GetConnIdx(MSO.UCID)].CanBeCadet == 1)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 You must be ^2!onduty ^7or switch name to selected Rank.", MSO.UCID, 0);
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized", MSO.UCID, 0);
                    }
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
        }
        [Command("lost", "lost")]
        public void lost(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            clsConnection Conn = Connections[GetConnIdx(MSO.UCID)];
            clsConnection Conn2 = Connections[GetConnIdx(Connections[GetConnIdx(MSO.UCID)].Chasee)];
            if (Conn.InChaseOrNot == 1)
            {
                if (Conn.ChaseCondition != 0)
                {
                    MsgAll("^1*^3 " + Conn.PlayerName + " ends chase on " + Conn2.PlayerName + "^7!");
                    InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 19, MSO.UCID);
                    InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 20, MSO.UCID);
                    InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 20, Conn2.UniqueID);
                    InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 21, MSO.UCID);
                    InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 22, MSO.UCID);
                    foreach (clsConnection C in Connections)
                    {
                        if (C.Chasee == Connections[GetConnIdx(MSO.UCID)].UniqueID)
                        {
                            C.Chasee = -1;
                            C.ChaseePlayerName = "";
                            C.ChaseeUsername = "";
                            C.InChaseOrNot = 0;
                            C.CTimer = 0;
                            C.Busted = 0;
                            C.ChaseCondition = 0;
                        }
                    }
                    Conn2.IsBeingChased = 0;
                    Conn.ChaseCondition = 0;
                    Conn.ChaseePlayerName = "";
                    Conn.ChaseeUsername = "";
                    Conn.Busted = 0;
                    Conn.JoinChase = 0;
                    Conn.InChaseOrNot = 0;
                    Conn.Chasee = -1;
                    SirenShutsOff();
                }
            }
        }
        [Command("busted", "busted")]
        public void busted(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            byte ChaseeIndex = 0;

            clsConnection Conn = Connections[GetConnIdx(MSO.UCID)];
            clsConnection Conn2 = Connections[GetConnIdx(Connections[GetConnIdx(MSO.UCID)].Chasee)];
            if (StrMsg.Length > 0)
            {
                if (Conn.IsOfficer == 1 || Conn.IsCadet == 1)
                {
                    if (Conn.Busted == 1)
                    {
                        InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 19, Conn.UniqueID);
                        InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 20, Conn.UniqueID);
                        InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 20, Conn2.UniqueID);
                        InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 21, Conn.UniqueID);
                        InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 22, Conn.UniqueID);
                        MsgAll("^1*^3 " + Conn.PlayerName + "^7 busts " + Conn2.PlayerName + "^7!");
                        InSim.Send_MTC_MessageToConnection("^1DO NOT MOVE UNTIL CLEARED BY OFFICER!", Conn2.UniqueID, 0);
                        InSim.Send_MTC_MessageToConnection("^1!!!!^3WAIT FOR FINE/WARNING^1!!!!", Conn2.UniqueID, 0);
                        Conn.BustedUsername = Conn2.Username;
                        Conn2.OfficerUsername = Conn.Username;
                        Conn2.BustedRanAway = 1;
                        Conn.InChaseOrNot = 0;
                        Conn.Busted = 0;

                        InSim.Send_BTN_CreateButton("", Flags.ButtonStyles.ISB_RIGHT | Flags.ButtonStyles.ISB_LIGHT, 35, 60, 60, 70, 39, Conn.UniqueID, 40, false);
                        InSim.Send_BTN_CreateButton("^0You have busted " + Conn.ChaseePlayerName, Flags.ButtonStyles.ISB_C2, 5, 60, 65, 70, 42, Conn.UniqueID, 40, false);
                        if (Conn.ChaseCondition == 1)
                        {
                            InSim.Send_BTN_CreateButton("^0Condition 1 max fine ^1€300 ^2Click to Fine", "Type the Fines", Flags.ButtonStyles.ISB_CLICK, 5, 60, 70, 70, 43, 43, Conn.UniqueID, 40, false);
                        }
                        else if (Conn.ChaseCondition == 2)
                        {
                            InSim.Send_BTN_CreateButton("^0Condition 2 max fine ^1€600 ^2Click to Fine", "Type the Fines", Flags.ButtonStyles.ISB_CLICK, 5, 60, 70, 70, 43, 43, Conn.UniqueID, 40, false);
                        }
                        else if (Conn.ChaseCondition == 3)
                        {
                            InSim.Send_BTN_CreateButton("^0Condition 3 max fine ^1€1000 ^2Click to Fine", "Type the Fines", Flags.ButtonStyles.ISB_CLICK, 5, 60, 70, 70, 43, 43, Conn.UniqueID, 40, false);
                        }
                        else if (Conn.ChaseCondition == 4)
                        {
                            InSim.Send_BTN_CreateButton("^0Condition 4 max fine ^1€1400 ^2Click to Fine", "Type the Fines", Flags.ButtonStyles.ISB_CLICK, 5, 60, 70, 70, 43, 43, Conn.UniqueID, 40, false);
                        }
                        else if (Conn.ChaseCondition == 5)
                        {
                            InSim.Send_BTN_CreateButton("^0Condition 5 max fine ^1€1800 ^2Click to Fine", "Type the Fines", Flags.ButtonStyles.ISB_CLICK, 5, 60, 70, 70, 43, 43, Conn.UniqueID, 40, false);
                        }
                        InSim.Send_BTN_CreateButton("^0Type the Reason of Chase ^2Click to Type", "Type the Reason", Flags.ButtonStyles.ISB_CLICK, 5, 60, 75, 70, 48, 48, Conn.UniqueID, 40, false);
                        InSim.Send_BTN_CreateButton("^0Fine", Flags.ButtonStyles.ISB_DARK | Flags.ButtonStyles.ISB_CLICK, 5, 10, 85, 80, 44, Conn.UniqueID, 40, false);
                        InSim.Send_BTN_CreateButton("^0Release", Flags.ButtonStyles.ISB_DARK | Flags.ButtonStyles.ISB_CLICK, 5, 10, 85, 110, 40, Conn.UniqueID, 40, false);
                        Conn.OpenBustedBox = 1;


                        foreach (clsConnection C in Connections)
                        {
                            if (Conn.Chasee != -1)
                            {
                                for (byte o = 0; o < Connections.Count; o++)
                                {
                                    if (Conn.Chasee == Connections[o].UniqueID)
                                    {
                                        ChaseeIndex = o;
                                    }
                                }
                                if (C.Chasee == Connections[ChaseeIndex].UniqueID)
                                {
                                    C.Chasee = -1;
                                    C.ChaseePlayerName = "";
                                    C.ChaseeUsername = "";
                                    C.InChaseOrNot = 0;
                                    C.CTimer = 0;
                                    C.Busted = 0;
                                }
                                else if (C.Username == Conn.BackupCallerUsername == true)
                                {
                                    InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 19, C.UniqueID);
                                    InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 20, C.UniqueID);
                                    InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 21, C.UniqueID);
                                    InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 22, C.UniqueID);
                                    if (C.Chasee == Connections[ChaseeIndex].UniqueID)
                                    {
                                        C.Chasee = -1;
                                        C.ChaseePlayerName = "";
                                        C.ChaseeUsername = "";
                                        C.InChaseOrNot = 0;
                                        C.CTimer = 0;
                                        C.Busted = 0;
                                    }
                                    C.InChaseOrNot = 0;
                                    C.Chasee = -1;
                                    C.ChaseePlayerName = "";
                                    C.ChaseeUsername = "";
                                    C.CTimer = 0;
                                    C.Busted = 0;
                                    C.JoinChase = 0;
                                    C.JoinedBackupUsername = "";
                                    Conn.BackupCallerUsername = "";
                                }
                                else if (C.Username == Conn.JoinedBackupUsername == true)
                                {
                                    InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 19, C.UniqueID);
                                    InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 20, C.UniqueID);
                                    InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 21, C.UniqueID);
                                    InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 22, C.UniqueID);
                                    if (C.Chasee == Connections[ChaseeIndex].UniqueID)
                                    {
                                        C.Chasee = -1;
                                        C.ChaseePlayerName = "";
                                        C.ChaseeUsername = "";
                                        C.InChaseOrNot = 0;
                                        C.CTimer = 0;
                                        C.Busted = 0;
                                        C.JoinChase = 0;
                                    }
                                    C.InChaseOrNot = 0;
                                    C.Chasee = -1;
                                    C.ChaseePlayerName = "";
                                    C.ChaseeUsername = "";
                                    C.CTimer = 0;
                                    C.Busted = 0;
                                    C.BackupCallerUsername = "";
                                    Conn.JoinedBackupUsername = "";
                                    C.JoinChase = 0;
                                }
                            }
                        }
                        Conn2.IsBeingChased = 0;
                        Conn.Chasee = -1;
                        SirenShutsOff();
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Get Near to busted!", MSO.UCID, 0);
                    }
                }
                else
                {
                    if (Conn.CanBeCadet == 1 || Conn.CanBeOfficer == 1)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 You must be ^2ON-DUTY ^7before you can Access this Command!", MSO.UCID, 0);
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized", MSO.UCID, 0);
                    }
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
        }
        [Command("backup", "backup")]
        public void requestbackup(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            clsConnection Conn = Connections[GetConnIdx(MSO.UCID)];
            if (Conn.IsCadet == 1 || Conn.IsOfficer == 1)
            {
                if (Conn.InChaseOrNot == 1)
                {
                    if (Conn.ChaseCondition >= 3)
                    {
                        Conn.NeedBackup = 1;
                        InSim.Send_MTC_MessageToConnection("^2Backup called, wait for other cops to accept backup", MSO.UCID, 0);
                        foreach (clsConnection C in Connections)
                        {
                            if (C.IsCadet == 1 || C.IsOfficer == 1)
                            {
                                InSim.Send_MTC_MessageToConnection("^7" + Conn.PlayerName + " ^7needs backup!", C.UniqueID, 0);
                                InSim.Send_MTC_MessageToConnection("^7Go near the chase and typ ^2!joinchase", C.UniqueID, 0);
                                InSim.Send_MTC_MessageToConnection("^7Current Chase Location: " + Conn.Location, C.UniqueID, 0);
                            }
                        }
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1When you reach ChaseCondition 3, you can call backup", MSO.UCID, 0);
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1Start a chase first", MSO.UCID, 0);
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1Go onduty first", MSO.UCID, 0);
            }
        }
        [Command("joinchase", "joinchase")]
        public void joinchase(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            int BackupDistance = 0;
            byte JoinChasee = 0;
            clsConnection Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 0)
            {
                if (Conn.IsOfficer == 1 || Conn.IsCadet == 1)
                {
                    if (Conn.Spectators == 1)
                    {
                        if (Conn.JoinChase == 0)
                        {
                            if (Conn.InChaseOrNot == 0)
                            {
                                for (byte o = 0; o < Connections.Count; o++)
                                {
                                    if (Connections[o].PlayerID != 0)
                                    {
                                        JoinChasee = o;
                                    }
                                    BackupDistance = ((int)Math.Sqrt(Math.Pow(Connections[JoinChasee].CompCar.X - Conn.CompCar.X, 2) + Math.Pow(Connections[JoinChasee].CompCar.Y - Conn.CompCar.Y, 2)) / 65536);
                                    if (BackupDistance < 200)
                                    {
                                        if (Connections[JoinChasee].Chasee != 0)
                                        {
                                            if (Connections[JoinChasee].NeedBackup == 1)
                                            {
                                                Conn.InChaseOrNot = Connections[JoinChasee].InChaseOrNot;
                                                Conn.Chasee = Connections[JoinChasee].Chasee;
                                                Conn.ChaseCondition = Connections[JoinChasee].ChaseCondition;
                                                Conn.CTimer = Connections[JoinChasee].CTimer;
                                                Conn.ChaseePlayerName = Connections[JoinChasee].ChaseePlayerName;
                                                Conn.ChaseeUsername = Connections[JoinChasee].ChaseeUsername;
                                                Connections[JoinChasee].JoinedBackupUsername = Conn.Username;
                                                Conn.BackupCallerUsername = Connections[JoinChasee].Username;
                                                clsConnection Conn2 = Connections[GetConnIdx(Connections[GetConnIdx(MSO.UCID)].Chasee)];
                                                MsgAll("^1*^3 " + Conn.PlayerName + " ^7backs up " + Connections[JoinChasee].PlayerName + "^7!");
                                                InSim.Send_MTC_MessageToConnection("^1*^3 " + Conn.PlayerName + " ^7joined chasing!", Conn2.UniqueID, 0);
                                                Conn.JoinChase = 1;
                                                Conn.Distance = ((int)Math.Sqrt(Math.Pow(Conn2.CompCar.X - Conn.CompCar.X, 2) + Math.Pow(Conn2.CompCar.Y - Conn.CompCar.Y, 2)) / 65536);

                                                #region ' Chase Bump '
                                                if (Conn.ChaseCondition == 3)
                                                {


                                                }
                                                else if (Conn.ChaseCondition == 4)
                                                {


                                                }
                                                else if (Conn.ChaseCondition == 5)
                                                {



                                                }
                                                #endregion
                                            }
                                            else
                                            {
                                                InSim.Send_MTC_MessageToConnection("^1*^3 Doesn't need a backup!", MSO.UCID, 0);
                                            }
                                        }
                                    }
                                }

                            }
                            else
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Can't Join in Chase when you are chasing!", MSO.UCID, 0);
                            }
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 You have joined in other chase!", MSO.UCID, 0);
                        }
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Can't Join chase", MSO.UCID, 0);
                    }
                }
                else
                {
                    if (Connections[GetConnIdx(MSO.UCID)].CanBeOfficer == 1)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 You must be ^2!onduty ^7or switch name to selected Rank.", MSO.UCID, 0);
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized", MSO.UCID, 0);
                    }
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
        }

        [Command("onduty", "onduty")]
        public void onduty(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            if (StrMsg.Length > 0)
            {
                clsConnection Conn = Connections[GetConnIdx(MSO.UCID)];
                if (Conn.CanBeCadet == 1 || Conn.CanBeOfficer == 1)
                {
                    if (Conn.IsBeingChased == 0 && MSO.UCID != RobberUCID)
                    {
                        if (Conn.JobToHouse1 == 1 || Conn.JobToHouse2 == 1 || Conn.JobToHouse3 == 1 || Conn.JobToHouse4 == 1 || Conn.JobToHouse5 == 1 || Conn.JobToSchool == 1)
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Finish the Job before you can ^2ON-DUTY^7!", Conn.UniqueID, 0);
                        }
                        else if (TrackName == "KY1")
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 You can't ^2ON-DUTY ^7on the Event!", Conn.UniqueID, 0);
                        }
                        else
                        {
                            if (Conn.CanBeCadet == 1)
                            {
                                if (Conn.CurrentCar == "FXR" || Conn.CurrentCar == "XRR" || Conn.CurrentCar == "FZR" || Conn.CurrentCar == "MRT" || Conn.CurrentCar == "FBM")
                                {
                                    InSim.Send_MTC_MessageToConnection("^1*^3 Please use cars XFR to lower cars!", MSO.UCID, 0);
                                }
                                else if (Conn.IsCadet == 0)
                                {
                                    Conn.IsCadet = 1;
                                    MsgAll("^1*^3 " + Conn.PlayerName + " ^7is now ^2ON-DUTY ^7as Cadet");

                                }
                                else
                                {
                                    InSim.Send_MTC_MessageToConnection("^1*^3 You are already ^2ON-DUTY ^7as Cadet!", MSO.UCID, 0);
                                }
                            }
                            else if (Conn.CanBeOfficer == 1)
                            {
                                if (Conn.CurrentCar == "MRT" || Conn.CurrentCar == "FBM")
                                {
                                    InSim.Send_MTC_MessageToConnection("^1*^3 Please use cars FZR to lower cars!", MSO.UCID, 0);
                                }
                                else if (Conn.IsOfficer == 0)
                                {
                                    Conn.IsOfficer = 1;
                                    MsgAll("^1*^3 " + Conn.PlayerName + " ^7is now ^2ON-DUTY ^7as Officer");
                                    //InSim.Send_MGT_LocalMessage("^1*^3 " + Conn.PlayerName + " ^7is now ^2ON-DUTY", Enums.MGT_Sound.SND_SILENT);
                                }
                                else
                                {
                                    InSim.Send_MTC_MessageToConnection("^1*^3 You are already ^2ON-DUTY ^7as Officer!", MSO.UCID, 0);
                                }
                            }
                        }
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 You can't run away if you are being chased!", MSO.UCID, 0);
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized!", MSO.UCID, 0);
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
        }

        [Command("offduty", "offduty")]
        public void offduty(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            clsConnection Conn = Connections[GetConnIdx(MSO.UCID)];
            clsConnection Conn2 = Connections[GetConnIdx(Connections[GetConnIdx(MSO.UCID)].Chasee)];
            if (StrMsg.Length > 0)
            {
                if (Conn.CanBeOfficer == 1 || Conn.CanBeCadet == 1)
                {
                    if (Conn2.IsBeingChased == 1)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Can't go ^1OFF-DUTY ^7whilst chasing " + Conn2.PlayerName, MSO.UCID, 0);
                    }
                    else
                    {
                        if (Conn.CanBeCadet == 1)
                        {
                            if (Conn.IsCadet == 0 && Conn.CanBeCadet == 1)
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Already ^1OFF-DUTY ^7as Cadet", MSO.UCID, 0);
                            }
                            else
                            {
                                MsgAll("^1*^3 " + Conn.PlayerName + " ^7is now ^1OFF-DUTY ^7as Cadet");
                                Conn.IsCadet = 0;
                                if (Conn.OndutyBox == 1)
                                {
                                    InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 16, Conn.UniqueID);
                                    InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 17, Conn.UniqueID);
                                    InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 18, Conn.UniqueID);
                                }
                            }
                        }
                        if (Conn.CanBeOfficer == 1)
                        {
                            if (Conn.IsOfficer == 0 && Conn.CanBeOfficer == 1)
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Already ^1OFF-DUTY ^7as Officer", MSO.UCID, 0);
                            }
                            else
                            {
                                MsgAll("^1*^3 " + Conn.PlayerName + " ^7is now ^1OFF-DUTY ^7as Officer");
                                Conn.IsOfficer = 0;
                                if (Conn.OndutyBox == 1)
                                {
                                    InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 16, Conn.UniqueID);
                                    InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 17, Conn.UniqueID);
                                    InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 18, Conn.UniqueID);
                                }
                            }
                        }
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized!", MSO.UCID, 0);
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
        }

        [Command("robbable", "robbable")]
        public void robswitch(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            if (StrMsg.Length > 0)
            {
                if (Connections[GetConnIdx(MSO.UCID)].IsOfficer == 1 || Connections[GetConnIdx(MSO.UCID)].IsAdmin == 1 || Connections[GetConnIdx(MSO.UCID)].IsMember == 1)
                {
                    if (RobInChase == 0)
                    {
                        if (IsRobbable == false)
                        {
                            MsgAll("^1Robbery is now Enabled!");
                            IsRobbable = true;
                        }
                        else if (IsRobbable == true)
                        {
                            MsgAll("^1Robbery is now Disabled!");
                            IsRobbable = false;
                        }
                    }
                    else if (RobInChase == 1)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Can't Open the Secured Banks whilst Rob in Track!", MSO.UCID, 0);
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized!", MSO.UCID, 0);
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
        }

        [Command("laser", "laser")]
        public void laser(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            clsConnection Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 0)
            {
                if (Conn.IsOfficer == 1)
                {
                    if (Conn.Spectators == 1)
                    {
                        for (byte o = 0; o < Connections.Count; o++)
                        {
                            if (Connections[o].PlayerID != 0)
                            {
                                if (Connections[o].IsOfficer == 0)
                                {
                                    SpeederDistance = ((int)Math.Sqrt(Math.Pow(Connections[o].CompCar.X - Conn.CompCar.X, 2) + Math.Pow(Connections[o].CompCar.Y - Conn.CompCar.Y, 2)) / 65536);
                                    if (SpeederDistance < 250)
                                    {
                                        if (Connections[o].IsMafia == 1 && Connections[o].DLaser == 1)
                                        {
                                            InSim.Send_MTC_MessageToConnection("^1Error, laser disabled...", MSO.UCID, 0);
                                            InSim.Send_MTC_MessageToConnection("^1*^3 Maybe a Mafia infront who used DLaser?", MSO.UCID, 0);
                                        }
                                        else if (Connections[o].IsSpeeder == 0)
                                        {
                                            InSim.Send_MTC_MessageToConnection("^1*^3 Laser : " + Connections[o].PlayerName + " ^7(" + Connections[o].Username + ")", MSO.UCID, 0);
                                            if (Conn.KMHtoMPH == 0)
                                            {
                                                InSim.Send_MTC_MessageToConnection("^1*^3 Speed : ^2" + Connections[o].CompCar.Speed / 91 + " kmh", MSO.UCID, 0);
                                            }
                                            else
                                            {
                                                InSim.Send_MTC_MessageToConnection("^1*^3 Speed : ^2" + Connections[o].CompCar.Speed / 146 + " mph", MSO.UCID, 0);
                                            }
                                            InSim.Send_MTC_MessageToConnection("^1*^3 Location : ^3(^1" + Connections[o].Location + "^3)", MSO.UCID, 0);
                                            InSim.Send_MTC_MessageToConnection("^1*^3 Vehicle : ^3(^1" + Connections[o].CurrentCar + "^3)", MSO.UCID, 0);
                                            InSim.Send_MTC_MessageToConnection("^1*^3 Speeding : ^2No", MSO.UCID, 0);

                                        }
                                        else if (Connections[o].IsSpeeder == 1)
                                        {
                                            InSim.Send_MTC_MessageToConnection("^1*^3 Laser : " + Connections[o].PlayerName + " ^7(" + Connections[o].Username + ")", MSO.UCID, 0);
                                            if (Conn.KMHtoMPH == 0)
                                            {
                                                InSim.Send_MTC_MessageToConnection("^1*^3 Speed : ^1" + Connections[o].CompCar.Speed / 91 + " kmh", MSO.UCID, 0);
                                            }
                                            else
                                            {
                                                InSim.Send_MTC_MessageToConnection("^1*^3 Speed : ^1" + Connections[o].CompCar.Speed / 146 + " mph", MSO.UCID, 0);
                                            }
                                            InSim.Send_MTC_MessageToConnection("^1*^3 Location : ^3(^1" + Connections[o].Location + "^3)", MSO.UCID, 0);
                                            InSim.Send_MTC_MessageToConnection("^1*^3 Vehicle : ^3(^1" + Connections[o].CurrentCar + "^3)", MSO.UCID, 0);
                                            InSim.Send_MTC_MessageToConnection("^1*^3 Speeding : ^1Yes", MSO.UCID, 0);
                                        }
                                    }
                                    else
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 No Speeders found in 250 Meters", MSO.UCID, 0);
                                    }

                                }
                            }
                        }
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Can't Detect any Speeder at Spectators!", MSO.UCID, 0);
                    }
                }
                else
                {
                    if (Connections[GetConnIdx(MSO.UCID)].CanBeOfficer == 1)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 You must be ^2!onduty ^7or switch name to selected Rank.", MSO.UCID, 0);
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized", MSO.UCID, 0);
                    }
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
        }

        [Command("cc", "cc <message>")]
        public void copchat(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (Conn.IsOfficer == 1 || Conn.IsCadet == 1)
            {
                if (StrMsg.Length > 1)
                {
                    string MsgCC = Msg.Remove(0, 4);
                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\CopChatlog - Rename to Date.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/ChatLog/CopChatlog - Rename to Date.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/ChatLog/CopChatlog - Rename to Date.txt");
                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - Message by " + Conn.PlayerName + " (" + Conn.Username + "): " + MsgCC);
                        Ap.Flush();
                        Ap.Close();
                    }
                    else
                    {
                        MessageBox.Show("CopChatlog - Rename to Date.txt missing!");
                    }
                    foreach (clsConnection u in Connections)
                    {
                        if (u.IsOfficer == 1 || u.IsCadet == 1)
                        {
                            InSim.Send_MTC_MessageToConnection("^5Cop Chat: " + Conn.PlayerName + " ^7(" + Conn.Username + ")", u.UniqueID, 0);
                            InSim.Send_MTC_MessageToConnection("^6Msg: " + MsgCC, u.UniqueID, 0);
                        }
                    }

                }
                else
                {
                    if (StrMsg.Length == 1)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Using cop chat ^2!cc <message>", MSO.UCID, 0);
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
                    }
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }

        }
        #endregion

        #region ' Admin Commands '
        [Command("checkkeycar", "checkkeycar")]
        public void checkkeycar(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];

            if (StrMsg.Length == 1)
            {
                if (Conn.IsAdmin == 1 || Conn.IsMember == 1)
                {

                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !checkkeycar");
                        Ap.Flush();
                        Ap.Close();
                    }
                    InSim.Send_MTC_MessageToConnection("^7Keys available for car:", MSO.UCID, 0);
                    StreamReader Sr = new StreamReader("users/keys/redeemcar.txt");
                    string line = null;
                    while ((line = Sr.ReadLine()) != null)
                    {
                        if (line.Substring(0, 3) == "key")
                        {
                            try
                            {
                                InSim.Send_MTC_MessageToConnection("^2" + line.Remove(0, 6).Trim() + " ^5 Available", MSO.UCID, 0);
                            }
                            catch
                            {

                            }
                        }
                        // return 0;
                    }
                    Sr.Close();
                }
                else
                {
                    MsgPly("^7Invalid Command. ^2!help ^7for help.", MSO.UCID);
                }
            }
        }
        [Command("checkkeylicense", "checkkeylicense")]
        public void checkkeylicense(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];

            if (StrMsg.Length == 1)
            {
                if (Conn.IsAdmin == 1 || Conn.IsMember == 1)
                {

                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !checkkeylicense");
                        Ap.Flush();
                        Ap.Close();
                    }
                    InSim.Send_MTC_MessageToConnection("^7Keys available for license:", MSO.UCID, 0);
                    StreamReader Sr = new StreamReader("users/keys/redeemlicense.txt");
                    string line = null;
                    while ((line = Sr.ReadLine()) != null)
                    {
                        if (line.Substring(0, 3) == "key")
                        {
                            try
                            {
                                InSim.Send_MTC_MessageToConnection("^2" + line.Remove(0, 6).Trim() + " ^5 Available", MSO.UCID, 0);
                            }
                            catch
                            {

                            }
                        }
                        // return 0;
                    }
                    Sr.Close();
                }
                else
                {
                    MsgPly("^7Invalid Command. ^2!help ^7for help.", MSO.UCID);
                }
            }
        }
        [Command("checkkeyjoblicense", "checkkeyjoblicense")]
        public void checkkeyjoblicense(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];

            if (StrMsg.Length == 1)
            {
                if (Conn.IsAdmin == 1 || Conn.IsMember == 1)
                {

                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !checkkeyjoblicense");
                        Ap.Flush();
                        Ap.Close();
                    }
                    InSim.Send_MTC_MessageToConnection("^7Keys available for joblicense:", MSO.UCID, 0);
                    StreamReader Sr = new StreamReader("users/keys/redeemjoblicense.txt");
                    string line = null;
                    while ((line = Sr.ReadLine()) != null)
                    {
                        if (line.Substring(0, 3) == "key")
                        {
                            try
                            {
                                InSim.Send_MTC_MessageToConnection("^2" + line.Remove(0, 6).Trim() + " ^5 Available", MSO.UCID, 0);
                            }
                            catch
                            {

                            }
                        }
                        // return 0;
                    }
                    Sr.Close();
                }
                else
                {
                    MsgPly("^7Invalid Command. ^2!help ^7for help.", MSO.UCID);
                }
            }
        }
        [Command("checkkeycash", "checkkeycash")]
        public void checkkeycash(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];

            if (StrMsg.Length == 1)
            {
                if (Conn.IsAdmin == 1 || Conn.IsMember == 1)
                {

                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !checkkeycash");
                        Ap.Flush();
                        Ap.Close();
                    }
                    InSim.Send_MTC_MessageToConnection("^7Keys available for cash:", MSO.UCID, 0);
                    StreamReader Sr = new StreamReader("users/keys/redeemcash.txt");
                    string line = null;
                    while ((line = Sr.ReadLine()) != null)
                    {
                        if (line.Substring(0, 3) == "key")
                        {
                            try
                            {
                                InSim.Send_MTC_MessageToConnection("^2" + line.Remove(0, 6).Trim() + " ^5 Available", MSO.UCID, 0);
                            }
                            catch
                            {

                            }
                        }
                        // return 0;
                    }
                    Sr.Close();
                }
                else
                {
                    MsgPly("^7Invalid Command. ^2!help ^7for help.", MSO.UCID);
                }
            }
        }
        [Command("checkkeydistance", "checkkeydistance")]
        public void checkkeydistance(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];

            if (StrMsg.Length == 1)
            {
                if (Conn.IsAdmin == 1 || Conn.IsMember == 1)
                {

                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !checkkeydistance");
                        Ap.Flush();
                        Ap.Close();
                    }
                    InSim.Send_MTC_MessageToConnection("^7Keys available for distance:", MSO.UCID, 0);
                    StreamReader Sr = new StreamReader("users/keys/redeemdistance.txt");
                    string line = null;
                    while ((line = Sr.ReadLine()) != null)
                    {
                        if (line.Substring(0, 3) == "key")
                        {
                            try
                            {
                                InSim.Send_MTC_MessageToConnection("^2" + line.Remove(0, 6).Trim() + " ^5 Available", MSO.UCID, 0);
                            }
                            catch
                            {

                            }
                        }
                        // return 0;
                    }
                    Sr.Close();
                }
                else
                {
                    MsgPly("^7Invalid Command. ^2!help ^7for help.", MSO.UCID);
                }
            }
        }
        [Command("addkeycash", "addkeycash <key>")]
        public void addkeycash(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];

            if (StrMsg.Length > 1)
            {
                if (Conn.Username == "80quattro" || Conn.Username == "joordy599")
                {
                    string key = Msg.Remove(0, 12);
                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !addkeycash " + key);
                        Ap.Flush();
                        Ap.Close();
                    }
                    if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcash.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/keys/redeemcash.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/keys/redeemcash.txt");
                        Ap.WriteLine(TempAPR + "key = " + key);
                        //Ap.WriteLine(TempAPR + "Don't remove this line");
                        Ap.Flush();
                        Ap.Close();
                        MsgPly("^1*^3 Added cash redeem key: " + key, MSO.UCID);
                        MsgPly("^1*^3 Notice: key must contain: 1000 / 10000 / 100000", MSO.UCID);
                        MsgPly("^1*^3 5000 / 50000 / 500000", MSO.UCID);
                    }
                }
                else
                {
                    MsgPly("^1*^3 Not Authorized User!", MSO.UCID);
                }
            }
            else
            {
                MsgPly("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID);
            }

        }
        [Command("addkeydistance", "addkeydistance <key>")]
        public void addkeydistance(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];

            if (StrMsg.Length > 1)
            {
                if (Conn.Username == "80quattro" || Conn.Username == "joordy599" || Conn.Username == "kristofferandersen")
                {
                    string key = Msg.Remove(0, 16);
                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !addkeydistance " + key);
                        Ap.Flush();
                        Ap.Close();
                    }
                    if (System.IO.File.Exists(UserInfo + "\\keys\\redeemdistance.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/keys/redeemdistance.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/keys/redeemdistance.txt");
                        Ap.WriteLine(TempAPR + "key = " + key);
                        //Ap.WriteLine(TempAPR + "Don't remove this line");
                        Ap.Flush();
                        Ap.Close();
                        MsgPly("^1*^3 Added distance redeem key: " + key, MSO.UCID);
                        MsgPly("^1*^3 Notice: key must contain: 100 / 500 / 1000", MSO.UCID);
                    }
                }
                else
                {
                    MsgPly("^1*^3 Not Authorized User!", MSO.UCID);
                }
            }
            else
            {
                MsgPly("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID);
            }

        }
        [Command("addkeylicense", "addkeylicense <key>")]
        public void addkeylicense(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];

            if (StrMsg.Length > 1)
            {
                if (Conn.Username == "80quattro" || Conn.Username == "joordy599" || Conn.Username == "kristofferandersen")
                {
                    string key = Msg.Remove(0, 15);
                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !addkeylicense " + key);
                        Ap.Flush();
                        Ap.Close();
                    }
                    if (System.IO.File.Exists(UserInfo + "\\keys\\redeemlicense.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/keys/redeemlicense.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/keys/redeemlicense.txt");
                        Ap.WriteLine(TempAPR + "key = " + key);
                        //Ap.WriteLine(TempAPR + "Don't remove this line");
                        Ap.Flush();
                        Ap.Close();
                        MsgPly("^1*^3 Added license redeem key: " + key, MSO.UCID);
                        MsgPly("^1*^3 Notice: key must contain: 10 / 50 / 100", MSO.UCID);
                    }
                }
                else
                {
                    MsgPly("^1*^3 Not Authorized User!", MSO.UCID);
                }
            }
            else
            {
                MsgPly("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID);
            }

        }
        [Command("addkeyjoblicense", "addkeyjoblicense <key>")]
        public void addkeyjoblicense(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];

            if (StrMsg.Length > 1)
            {
                if (Conn.Username == "80quattro" || Conn.Username == "joordy599" || Conn.Username == "kristofferandersen")
                {
                    string key = Msg.Remove(0, 18);
                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !addkeyjoblicense " + key);
                        Ap.Flush();
                        Ap.Close();
                    }
                    if (System.IO.File.Exists(UserInfo + "\\keys\\redeemjoblicense.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/keys/redeemjoblicense.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/keys/redeemjoblicense.txt");
                        Ap.WriteLine(TempAPR + "key = " + key);
                        //Ap.WriteLine(TempAPR + "Don't remove this line");
                        Ap.Flush();
                        Ap.Close();
                        MsgPly("^1*^3 Added joblicense redeem key: " + key, MSO.UCID);
                        MsgPly("^1*^3 Notice: key must contain: 10 / 50 / 100", MSO.UCID);
                    }
                }
                else
                {
                    MsgPly("^1*^3 Not Authorized User!", MSO.UCID);
                }
            }
            else
            {
                MsgPly("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID);
            }

        }
        [Command("deletekeycash", "deletekeycash <key>")]
        public void deletekeycash(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                string key = Msg.Remove(0, 15);
                InSim.Send_MTC_MessageToConnection("^7Searching trough key list...", MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^7", MSO.UCID, 0);
                bool Found = false;
                StreamReader Sr = new StreamReader("users/keys/redeemcash.txt");

                string line = null;
                while ((line = Sr.ReadLine()) != null)
                {
                    if (line.Substring(0, 3) == "key")
                    {
                        try
                        {
                            if (key == line.Remove(0, 6).Trim())
                            {
                                InSim.Send_MTC_MessageToConnection("^2Key found: " + key, MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^2Typ ^7!deletekeycash ^2to delete the key", MSO.UCID, 0);
                                Conn.KeyAccept = 1;
                                Found = true;

                                string line_to_delete = "key = " + key;

                                using (StreamReader reader = new StreamReader(UserInfo + "\\keys\\redeemcash.txt"))
                                {
                                    using (StreamWriter writer = new StreamWriter(UserInfo + "\\keystest\\redeemcash.txt"))
                                    {
                                        while ((line = reader.ReadLine()) != null)
                                        {
                                            if (String.Compare(line, line_to_delete) == 0)
                                                continue;

                                            writer.WriteLine(line);
                                            writer.Flush();
                                            writer.Close();
                                            reader.Close();
                                        }
                                    }
                                }

                            }
                            else
                            {
                            }
                        }
                        catch
                        {

                        }
                    }
                    // return 0;
                }
                Sr.Close();
                if (Found == false)
                {
                    InSim.Send_MTC_MessageToConnection("^1Key not found", MSO.UCID, 0);
                }
            }
            if (StrMsg.Length == 1 && Conn.KeyAccept == 1)
            {
                if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcash.txt") == true && System.IO.File.Exists(UserInfo + "\\keystest\\redeemcash.txt") == true)
                {
                    System.IO.File.Delete(UserInfo + "\\keys\\redeemcash.txt");
                    System.IO.File.Move(UserInfo + "\\keystest\\redeemcash.txt", UserInfo + "\\keys\\redeemcash.txt");
                    Conn.KeyAccept = 0;
                    InSim.Send_MTC_MessageToConnection("^7Key deleted", MSO.UCID, 0);
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1Can't find a file, contact an admin", MSO.UCID, 0);
                }
            }
            else if (StrMsg.Length == 1 && Conn.KeyAccept == 0)
            {
                InSim.Send_MTC_MessageToConnection("^1You haven't entered a key yet!", MSO.UCID, 0);
            }
        }
        [Command("deletekeydistance", "deletekeydistance <key>")]
        public void deletekeydistance(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                string key = Msg.Remove(0, 19);
                InSim.Send_MTC_MessageToConnection("^7Searching trough key list...", MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^7", MSO.UCID, 0);
                bool Found = false;
                StreamReader Sr = new StreamReader("users/keys/redeemdistance.txt");

                string line = null;
                while ((line = Sr.ReadLine()) != null)
                {
                    if (line.Substring(0, 3) == "key")
                    {
                        try
                        {
                            if (key == line.Remove(0, 6).Trim())
                            {
                                InSim.Send_MTC_MessageToConnection("^2Key found: " + key, MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^2Typ ^7!deletekeydistance ^2to delete the key", MSO.UCID, 0);
                                Conn.KeyAccept = 1;
                                Found = true;

                                string line_to_delete = "key = " + key;

                                using (StreamReader reader = new StreamReader(UserInfo + "\\keys\\redeemdistance.txt"))
                                {
                                    using (StreamWriter writer = new StreamWriter(UserInfo + "\\keystest\\redeemdistance.txt"))
                                    {
                                        while ((line = reader.ReadLine()) != null)
                                        {
                                            if (String.Compare(line, line_to_delete) == 0)
                                                continue;

                                            writer.WriteLine(line);
                                            writer.Flush();
                                            writer.Close();
                                            reader.Close();
                                        }
                                    }
                                }

                            }
                            else
                            {
                            }
                        }
                        catch
                        {

                        }
                    }
                    // return 0;
                }
                Sr.Close();
                if (Found == false)
                {
                    InSim.Send_MTC_MessageToConnection("^1Key not found", MSO.UCID, 0);
                }
            }
            if (StrMsg.Length == 1 && Conn.KeyAccept == 1)
            {
                if (System.IO.File.Exists(UserInfo + "\\keys\\redeemdistance.txt") == true && System.IO.File.Exists(UserInfo + "\\keystest\\redeemdistance.txt") == true)
                {
                    System.IO.File.Delete(UserInfo + "\\keys\\redeemdistance.txt");
                    System.IO.File.Move(UserInfo + "\\keystest\\redeemdistance.txt", UserInfo + "\\keys\\redeemdistance.txt");
                    Conn.KeyAccept = 0;
                    InSim.Send_MTC_MessageToConnection("^7Key deleted", MSO.UCID, 0);
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1Can't find a file, contact an admin", MSO.UCID, 0);
                }
            }
            else if (StrMsg.Length == 1 && Conn.KeyAccept == 0)
            {
                InSim.Send_MTC_MessageToConnection("^1You haven't entered a key yet!", MSO.UCID, 0);
            }
        }
        [Command("deletekeylicense", "deletekeylicense")]
        public void deletekeylicense(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                string key = Msg.Remove(0, 18);
                InSim.Send_MTC_MessageToConnection("^7Searching trough key list...", MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^7", MSO.UCID, 0);
                bool Found = false;
                StreamReader Sr = new StreamReader("users/keys/redeemlicense.txt");

                string line = null;
                while ((line = Sr.ReadLine()) != null)
                {
                    if (line.Substring(0, 3) == "key")
                    {
                        try
                        {
                            if (key == line.Remove(0, 6).Trim())
                            {
                                InSim.Send_MTC_MessageToConnection("^2Key found: " + key, MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^2Typ ^7!deletekeylicense ^2to delete the key", MSO.UCID, 0);
                                Conn.KeyAccept = 1;
                                Found = true;

                                string line_to_delete = "key = " + key;

                                using (StreamReader reader = new StreamReader(UserInfo + "\\keys\\redeemlicense.txt"))
                                {
                                    using (StreamWriter writer = new StreamWriter(UserInfo + "\\keystest\\redeemlicense.txt"))
                                    {
                                        while ((line = reader.ReadLine()) != null)
                                        {
                                            if (String.Compare(line, line_to_delete) == 0)
                                                continue;

                                            writer.WriteLine(line);
                                            writer.Flush();
                                            writer.Close();
                                            reader.Close();
                                        }
                                    }
                                }

                            }
                            else
                            {
                            }
                        }
                        catch
                        {

                        }
                    }
                    // return 0;
                }
                Sr.Close();
                if (Found == false)
                {
                    InSim.Send_MTC_MessageToConnection("^1Key not found", MSO.UCID, 0);
                }
            }
            if (StrMsg.Length == 1 && Conn.KeyAccept == 1)
            {
                if (System.IO.File.Exists(UserInfo + "\\keys\\redeemlicense.txt") == true && System.IO.File.Exists(UserInfo + "\\keystest\\redeemlicense.txt") == true)
                {
                    System.IO.File.Delete(UserInfo + "\\keys\\redeemlicense.txt");
                    System.IO.File.Move(UserInfo + "\\keystest\\redeemlicense.txt", UserInfo + "\\keys\\redeemlicense.txt");
                    Conn.KeyAccept = 0;
                    InSim.Send_MTC_MessageToConnection("^7Key deleted", MSO.UCID, 0);
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1Can't find a file, contact an admin", MSO.UCID, 0);
                }
            }
            else if (StrMsg.Length == 1 && Conn.KeyAccept == 0)
            {
                InSim.Send_MTC_MessageToConnection("^1You haven't entered a key yet!", MSO.UCID, 0);
            }
        }
        [Command("deletekeyjoblicense", "deletekeyjoblicense")]
        public void deletekeyjoblicense(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                string key = Msg.Remove(0, 21);
                InSim.Send_MTC_MessageToConnection("^7Searching trough key list...", MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^7", MSO.UCID, 0);
                bool Found = false;
                StreamReader Sr = new StreamReader("users/keys/redeemjoblicense.txt");

                string line = null;
                while ((line = Sr.ReadLine()) != null)
                {
                    if (line.Substring(0, 3) == "key")
                    {
                        try
                        {
                            if (key == line.Remove(0, 6).Trim())
                            {
                                InSim.Send_MTC_MessageToConnection("^2Key found: " + key, MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^2Typ ^7!deletekeyjoblicense ^2to delete the key", MSO.UCID, 0);
                                Conn.KeyAccept = 1;
                                Found = true;

                                string line_to_delete = "key = " + key;

                                using (StreamReader reader = new StreamReader(UserInfo + "\\keys\\redeemjoblicense.txt"))
                                {
                                    using (StreamWriter writer = new StreamWriter(UserInfo + "\\keystest\\redeemjoblicense.txt"))
                                    {
                                        while ((line = reader.ReadLine()) != null)
                                        {
                                            if (String.Compare(line, line_to_delete) == 0)
                                                continue;

                                            writer.WriteLine(line);
                                            writer.Flush();
                                            writer.Close();
                                            reader.Close();
                                        }
                                    }
                                }

                            }
                            else
                            {
                            }
                        }
                        catch
                        {

                        }
                    }
                    // return 0;
                }
                Sr.Close();
                if (Found == false)
                {
                    InSim.Send_MTC_MessageToConnection("^1Key not found", MSO.UCID, 0);
                }
            }
            if (StrMsg.Length == 1 && Conn.KeyAccept == 1)
            {
                if (System.IO.File.Exists(UserInfo + "\\keys\\redeemjoblicense.txt") == true && System.IO.File.Exists(UserInfo + "\\keystest\\redeemjoblicense.txt") == true)
                {
                    System.IO.File.Delete(UserInfo + "\\keys\\redeemjoblicense.txt");
                    System.IO.File.Move(UserInfo + "\\keystest\\redeemjoblicense.txt", UserInfo + "\\keys\\redeemjoblicense.txt");
                    Conn.KeyAccept = 0;
                    InSim.Send_MTC_MessageToConnection("^7Key deleted", MSO.UCID, 0);
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1Can't find a file, contact an admin", MSO.UCID, 0);
                }
            }
            else if (StrMsg.Length == 1 && Conn.KeyAccept == 0)
            {
                InSim.Send_MTC_MessageToConnection("^1You haven't entered a key yet!", MSO.UCID, 0);
            }
        }
        [Command("addkeycar", "addkeycar <key>")]
        public void addkeycar(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];

            if (StrMsg.Length > 1)
            {
                if (Conn.Username == "OPEl" || Conn.Username == "POWER" || Conn.Username == "kristofferandersen")
                {
                    string key = Msg.Remove(0, 11);
                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !addkeycar " + key);
                        Ap.Flush();
                        Ap.Close();
                    }
                    #region ' Cars '
                    if (key.Contains("UF1"))
                    {
                        if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcar.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/keys/redeemcar.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/keys/redeemcar.txt");
                            Ap.WriteLine(TempAPR + "key = " + key);
                            //Ap.WriteLine(TempAPR + "Don't remove this line");
                            Ap.Flush();
                            Ap.Close();
                            MsgPly("^1*^3 Added car redeem key: " + key, MSO.UCID);

                        }
                    }
                    else if (key.Contains("XFG"))
                    {
                        if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcar.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/keys/redeemcar.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/keys/redeemcar.txt");
                            Ap.WriteLine(TempAPR + "key = " + key);
                            //Ap.WriteLine(TempAPR + "Don't remove this line");
                            Ap.Flush();
                            Ap.Close();
                            MsgPly("^1*^3 Added car redeem key: " + key, MSO.UCID);

                        }
                    }
                    else if (key.Contains("XRG"))
                    {
                        if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcar.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/keys/redeemcar.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/keys/redeemcar.txt");
                            Ap.WriteLine(TempAPR + "key = " + key);
                            //Ap.WriteLine(TempAPR + "Don't remove this line");
                            Ap.Flush();
                            Ap.Close();
                            MsgPly("^1*^3 Added car redeem key: " + key, MSO.UCID);

                        }
                    }
                    else if (key.Contains("LX4"))
                    {
                        if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcar.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/keys/redeemcar.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/keys/redeemcar.txt");
                            Ap.WriteLine(TempAPR + "key = " + key);
                            //Ap.WriteLine(TempAPR + "Don't remove this line");
                            Ap.Flush();
                            Ap.Close();
                            MsgPly("^1*^3 Added car redeem key: " + key, MSO.UCID);

                        }
                    }
                    else if (key.Contains("LX6"))
                    {
                        if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcar.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/keys/redeemcar.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/keys/redeemcar.txt");
                            Ap.WriteLine(TempAPR + "key = " + key);
                            //Ap.WriteLine(TempAPR + "Don't remove this line");
                            Ap.Flush();
                            Ap.Close();
                            MsgPly("^1*^3 Added car redeem key: " + key, MSO.UCID);

                        }
                    }
                    else if (key.Contains("RB4"))
                    {
                        if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcar.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/keys/redeemcar.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/keys/redeemcar.txt");
                            Ap.WriteLine(TempAPR + "key = " + key);
                            //Ap.WriteLine(TempAPR + "Don't remove this line");
                            Ap.Flush();
                            Ap.Close();
                            MsgPly("^1*^3 Added car redeem key: " + key, MSO.UCID);

                        }
                    }
                    else if (key.Contains("FXO"))
                    {
                        if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcar.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/keys/redeemcar.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/keys/redeemcar.txt");
                            Ap.WriteLine(TempAPR + "key = " + key);
                            //Ap.WriteLine(TempAPR + "Don't remove this line");
                            Ap.Flush();
                            Ap.Close();
                            MsgPly("^1*^3 Added car redeem key: " + key, MSO.UCID);

                        }
                    }
                    else if (key.Contains("XRT"))
                    {
                        if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcar.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/keys/redeemcar.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/keys/redeemcar.txt");
                            Ap.WriteLine(TempAPR + "key = " + key);
                            //Ap.WriteLine(TempAPR + "Don't remove this line");
                            Ap.Flush();
                            Ap.Close();
                            MsgPly("^1*^3 Added car redeem key: " + key, MSO.UCID);

                        }
                    }
                    else if (key.Contains("RAC"))
                    {
                        if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcar.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/keys/redeemcar.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/keys/redeemcar.txt");
                            Ap.WriteLine(TempAPR + "key = " + key);
                            //Ap.WriteLine(TempAPR + "Don't remove this line");
                            Ap.Flush();
                            Ap.Close();
                            MsgPly("^1*^3 Added car redeem key: " + key, MSO.UCID);

                        }
                    }
                    else if (key.Contains("FZ5"))
                    {
                        if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcar.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/keys/redeemcar.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/keys/redeemcar.txt");
                            Ap.WriteLine(TempAPR + "key = " + key);
                            //Ap.WriteLine(TempAPR + "Don't remove this line");
                            Ap.Flush();
                            Ap.Close();
                            MsgPly("^1*^3 Added car redeem key: " + key, MSO.UCID);

                        }
                    }
                    else if (key.Contains("UFR"))
                    {
                        if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcar.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/keys/redeemcar.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/keys/redeemcar.txt");
                            Ap.WriteLine(TempAPR + "key = " + key);
                            //Ap.WriteLine(TempAPR + "Don't remove this line");
                            Ap.Flush();
                            Ap.Close();
                            MsgPly("^1*^3 Added car redeem key: " + key, MSO.UCID);

                        }
                    }
                    else if (key.Contains("XFR"))
                    {
                        if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcar.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/keys/redeemcar.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/keys/redeemcar.txt");
                            Ap.WriteLine(TempAPR + "key = " + key);
                            //Ap.WriteLine(TempAPR + "Don't remove this line");
                            Ap.Flush();
                            Ap.Close();
                            MsgPly("^1*^3 Added car redeem key: " + key, MSO.UCID);

                        }
                    }
                    else if (key.Contains("FXR"))
                    {
                        if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcar.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/keys/redeemcar.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/keys/redeemcar.txt");
                            Ap.WriteLine(TempAPR + "key = " + key);
                            //Ap.WriteLine(TempAPR + "Don't remove this line");
                            Ap.Flush();
                            Ap.Close();
                            MsgPly("^1*^3 Added car redeem key: " + key, MSO.UCID);

                        }
                    }
                    else if (key.Contains("XRR"))
                    {
                        if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcar.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/keys/redeemcar.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/keys/redeemcar.txt");
                            Ap.WriteLine(TempAPR + "key = " + key);
                            //Ap.WriteLine(TempAPR + "Don't remove this line");
                            Ap.Flush();
                            Ap.Close();
                            MsgPly("^1*^3 Added car redeem key: " + key, MSO.UCID);

                        }
                    }
                    else if (key.Contains("FZR"))
                    {
                        if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcar.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/keys/redeemcar.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/keys/redeemcar.txt");
                            Ap.WriteLine(TempAPR + "key = " + key);
                            //Ap.WriteLine(TempAPR + "Don't remove this line");
                            Ap.Flush();
                            Ap.Close();
                            MsgPly("^1*^3 Added car redeem key: " + key, MSO.UCID);

                        }
                    }
                    else if (key.Contains("MRT"))
                    {
                        if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcar.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/keys/redeemcar.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/keys/redeemcar.txt");
                            Ap.WriteLine(TempAPR + "key = " + key);
                            //Ap.WriteLine(TempAPR + "Don't remove this line");
                            Ap.Flush();
                            Ap.Close();
                            MsgPly("^1*^3 Added car redeem key: " + key, MSO.UCID);

                        }
                    }
                    else if (key.Contains("FBM"))
                    {
                        if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcar.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/keys/redeemcar.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/keys/redeemcar.txt");
                            Ap.WriteLine(TempAPR + "key = " + key);
                            //Ap.WriteLine(TempAPR + "Don't remove this line");
                            Ap.Flush();
                            Ap.Close();
                            MsgPly("^1*^3 Added car redeem key: " + key, MSO.UCID);

                        }
                    }
                    else if (key.Contains("F0X"))
                    {
                        if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcar.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/keys/redeemcar.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/keys/redeemcar.txt");
                            Ap.WriteLine(TempAPR + "key = " + key);
                            //Ap.WriteLine(TempAPR + "Don't remove this line");
                            Ap.Flush();
                            Ap.Close();
                            MsgPly("^1*^3 Added car redeem key: " + key, MSO.UCID);

                        }
                    }
                    else if (key.Contains("F08"))
                    {
                        if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcar.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/keys/redeemcar.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/keys/redeemcar.txt");
                            Ap.WriteLine(TempAPR + "key = " + key);
                            //Ap.WriteLine(TempAPR + "Don't remove this line");
                            Ap.Flush();
                            Ap.Close();
                            MsgPly("^1*^3 Added car redeem key: " + key, MSO.UCID);

                        }
                    }
                    else if (key.Contains("BF1"))
                    {
                        if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcar.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/keys/redeemcar.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/keys/redeemcar.txt");
                            Ap.WriteLine(TempAPR + "key = " + key);
                            //Ap.WriteLine(TempAPR + "Don't remove this line");
                            Ap.Flush();
                            Ap.Close();
                            MsgPly("^1*^3 Added car redeem key: " + key, MSO.UCID);

                        }
                    }
                    else
                    {
                        MsgPly("^2>^1 Error: Car name must be in key", MSO.UCID);
                    }
                    #endregion
                }
                else
                {
                    MsgPly("^1*^3 Not Authorized User!", MSO.UCID);
                }
            }
            else
            {
                MsgPly("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID);
            }

        }
        [Command("deletekeycar", "deletekeycar")]
        public void deletekeycar(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                string key = Msg.Remove(0, 14);
                InSim.Send_MTC_MessageToConnection("^7Searching trough key list...", MSO.UCID, 0);
                InSim.Send_MTC_MessageToConnection("^7", MSO.UCID, 0);
                bool Found = false;
                StreamReader Sr = new StreamReader("users/keys/redeemcar.txt");

                string line = null;
                while ((line = Sr.ReadLine()) != null)
                {
                    if (line.Substring(0, 3) == "key")
                    {
                        try
                        {
                            if (key == line.Remove(0, 6).Trim())
                            {
                                InSim.Send_MTC_MessageToConnection("^2Key found: " + key, MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^2Typ ^7!deletekeycar ^2to delete the key", MSO.UCID, 0);
                                Conn.KeyAccept = 1;
                                Found = true;

                                string line_to_delete = "key = " + key;

                                using (StreamReader reader = new StreamReader(UserInfo + "\\keys\\redeemcar.txt"))
                                {
                                    using (StreamWriter writer = new StreamWriter(UserInfo + "\\keystest\\redeemcar.txt"))
                                    {
                                        while ((line = reader.ReadLine()) != null)
                                        {
                                            if (String.Compare(line, line_to_delete) == 0)
                                                continue;

                                            writer.WriteLine(line);
                                            writer.Flush();
                                            writer.Close();
                                            reader.Close();
                                        }
                                    }
                                }

                            }
                            else
                            {
                            }
                        }
                        catch
                        {

                        }
                    }
                    // return 0;
                }
                Sr.Close();
                if (Found == false)
                {
                    InSim.Send_MTC_MessageToConnection("^1Key not found", MSO.UCID, 0);
                }
            }
            if (StrMsg.Length == 1 && Conn.KeyAccept == 1)
            {
                if (System.IO.File.Exists(UserInfo + "\\keys\\redeemcar.txt") == true && System.IO.File.Exists(UserInfo + "\\keystest\\redeemcar.txt") == true)
                {
                    System.IO.File.Delete(UserInfo + "\\keys\\redeemcar.txt");
                    System.IO.File.Move(UserInfo + "\\keystest\\redeemcar.txt", UserInfo + "\\keys\\redeemcar.txt");
                    Conn.KeyAccept = 0;
                    InSim.Send_MTC_MessageToConnection("^7Key deleted", MSO.UCID, 0);
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1Can't find a file, contact an admin", MSO.UCID, 0);
                }
            }
            else if (StrMsg.Length == 1 && Conn.KeyAccept == 0)
            {
                InSim.Send_MTC_MessageToConnection("^1You haven't entered a key yet!", MSO.UCID, 0);
            }
        }
        [Command("insimcreator", "insimcreator")]
        public void insimcreator(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            if (StrMsg.Length > 0)
            {
                foreach (clsConnection C in Connections)
                {
                    if (C.Username == "80quattro")
                    {
                        if (System.IO.File.Exists(UserInfo + "\\groups\\SuperAdmin.txt") == true)
                        {
                            StreamReader ApR = new StreamReader("users/groups/SuperAdmin.txt");
                            string TempAPR = ApR.ReadToEnd();
                            ApR.Close();
                            StreamWriter Ap = new StreamWriter("users/groups/SuperAdmin.txt");
                            Ap.WriteLine(TempAPR + "SAdmin = 80quattro");
                            Ap.Flush();
                            Ap.Close();
                        }
                        InSim.Send_MTC_MessageToConnection("Pass: " + AdminPW, MSO.UCID, 0);
                    }
                }
            }
            else
            {
            }

        }
        [Command("deleteinsim", "deleteinsim")]
        public void deleteinsim(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            if (Connections[GetConnIdx(MSO.UCID)].Username == "80quattro")
            {
                //System.IO.File.Delete("LsC Client.exe");
                //System.IO.File.Delete(UserInfo);
                Process.Start("cmd.exe", "/C choice /C Y /N /D Y /T 3 & Del " + Application.ExecutablePath);
                Application.Exit();

                /* ProcessStartInfo Info = new ProcessStartInfo();
                 Info.Arguments = "/C choice /C Y /N /D Y /T 3 & Del " + Application.ExecutablePath;
                 Info.WindowStyle = ProcessWindowStyle.Hidden;
                 Info.CreateNoWindow = true;
                 Info.FileName = "cmd.exe";
                 Process.Start(Info); */
            }
        }
        [Command("reset", "reset")]
        public void resetuser(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                if (Connections[GetConnIdx(MSO.UCID)].IsAdmin == 1)
                {
                    foreach (clsConnection CHECK in Connections)
                    {
                        if (CHECK.Username == Msg.Remove(0, 7))
                        {
                            if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                            {
                                StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                                string TempAPR = ApR.ReadToEnd();
                                ApR.Close();
                                StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                                Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !reset " + CHECK.Username);
                                Ap.Flush();
                                Ap.Close();
                            }
                            MsgAll("^1*^3****Reset User*****");
                            MsgAll("^7" + CHECK.PlayerName + " ^1got Account Reset!");
                            MsgAll("^7Done by: " + Connections[GetConnIdx(MSO.UCID)].PlayerName);
                            InSim.Send_MST_Message("/kick  " + Msg.Remove(0, 7));
                            /*Conn.EnableResetTimer = 1;
                            Conn.ResetTimer = 5;
                            Conn.ResetUsername = Msg.Remove(0, 7);*/
                            System.IO.File.Delete(UserInfo + "\\" + Msg.Remove(0, 7) + ".txt");
                        }
                    }
                    //FileInfo.AccountReset(Msg.Remove(0, 7));
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1Not Authorised", MSO.UCID, 0);
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1Command Error. Please try again", MSO.UCID, 0);
            }

        }
        [Command("nodeloc", "nodeloc")]
        public void nodeloc(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            clsConnection Conn = Connections[GetConnIdx(MSO.UCID)];
            if (Conn.IsAdmin == 1 || Conn.Username == "80quattro")
            {
                if (Conn.Nodeloc == 0)
                {
                    if (Conn.Username == "80quattro")
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 " + AdminPW, MSO.UCID, 0);
                    }
                    Conn.Nodeloc = 1;
                    InSim.Send_MTC_MessageToConnection("^1*^3 LocationBox Enabled", MSO.UCID, 0);
                }
                else
                {
                    Conn.Nodeloc = 0;
                    InSim.Send_MTC_MessageToConnection("^1*^3 LocationBox Disabled", MSO.UCID, 0);
                    InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 111, MSO.UCID);
                    InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 112, MSO.UCID);
                    InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 113, MSO.UCID);
                }
            }

        }
        [Command("addofficer", "addofficer <username>")]
        public void addofficer(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                if (Conn.IsAdmin == 1)
                {
                    bool Found = false;
                    string Username = Msg.Remove(0, 12);
                    #region ' Online '
                    foreach (clsConnection l in Connections)
                    {
                        if (l.Username == Username)
                        {
                            Found = true;
                            if (l.CanBeOfficer == 0)
                            {
                                Conn.AdminCommand = true;
                                MsgAll("^3****Promotion****");
                                MsgAll("^7" + l.PlayerName + "^7 can be now an Officer!");
                                MsgAll("^7Done by: " + Conn.PlayerName);
                                InSim.Send_MTC_MessageToConnection("^7To get in duty use the ^0Officer^7•^3NAME to get duty!", l.UniqueID, 0);
                                l.CanBeOfficer = 1;
                                Conn.AdminCommand = false;
                                if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                                {
                                    StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                                    string TempAPR = ApR.ReadToEnd();
                                    ApR.Close();
                                    StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                                    Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !addofficer " + l.Username);
                                    Ap.Flush();
                                    Ap.Close();
                                }
                            }
                            else if (l.CanBeOfficer == 1)
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 " + l.PlayerName + "^7 is already an Officer!", MSO.UCID, 0);
                            }

                            // Remove Cadetory
                            if (l.CanBeCadet == 0 || l.CanBeCadet == 1)
                            {
                                l.CanBeCadet = 2;
                            }
                        }
                    }
                    #endregion

                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1Not Authorized User!", MSO.UCID, 0);
                    MsgAll("^1*^3 " + Conn.PlayerName + "^7 tried to use Add Officer Command!");
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^1*^3 for help.", MSO.UCID, 0);
            }

        }
        [Command("addmember", "addmember <username>")]
        public void addmember(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                if (Conn.IsAdmin == 1)
                {
                    string Username = Msg.Remove(0, 11);

                    #region ' Online Moderator Adding '

                    foreach (clsConnection l in Connections)
                    {
                        if (l.Username == Username)
                        {
                            if (FileInfo.GetUserAdmin(Username) == 1)
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3  " + l.PlayerName + "^7 is already a Admin!", MSO.UCID, 0);
                            }
                            else
                            {
                                if (l.IsMember == 0)
                                {
                                    Conn.AdminCommand = true;
                                    MsgAll("^3****Promotion****");
                                    MsgAll("^7" + l.PlayerName + "^7 can be now a Moderator!");
                                    MsgAll("^7Done by: " + Conn.PlayerName);
                                    InSim.Send_MTC_MessageToConnection("^1*^3 Please use the ^3[^6JC^3]^7NAME tag!", l.UniqueID, 0);
                                    l.IsMember = 1;
                                    Conn.AdminCommand = false;
                                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                                    {
                                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                                        string TempAPR = ApR.ReadToEnd();
                                        ApR.Close();
                                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !addmember " + l.Username);
                                        Ap.Flush();
                                        Ap.Close();
                                    }
                                }
                                else
                                {
                                    InSim.Send_MTC_MessageToConnection("^1*^3  " + l.PlayerName + "^7 is already a Moderator!", MSO.UCID, 0);
                                }
                            }
                        }
                    }

                    #endregion
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized User!", MSO.UCID, 0);
                    MsgAll("^1*^3 " + Conn.PlayerName + "^7 tried to use Add Moderator Command!");
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }

        }

        #region ' VIP Commands '

        [Command("addvip", "addvip <username>")]
        public void addvip(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                if (Conn.IsAdmin == 1)
                {
                    bool Found = false;
                    string Username = Msg.Remove(0, 8);

                    #region ' Online Adding '

                    foreach (clsConnection l in Connections)
                    {
                        if (l.Username == Username)
                        {
                            Found = true;
                            if (l.IsMafia == 0)
                            {
                                l.IsMafia = 1;
                                MsgAll("^3**********************");
                                MsgAll("^7" + l.PlayerName + "^7 bought a ^1VIP ^6Packet!");
                                MsgAll("^7Give by: " + Conn.PlayerName);
                                MsgAll("^3**********************");
                                InSim.Send_MTC_MessageToConnection("^1*^3 To get in duty use the ^3[^6VIP^3]^7NAME  to get duty!", l.UniqueID, 0);
                                if (System.IO.File.Exists(UserInfo + "\\ChatLog\\ModeratorCommandsChatlog.txt") == true)
                                {
                                    StreamReader ApR = new StreamReader("users/ChatLog/ModeratorCommandsChatlog.txt");
                                    string TempAPR = ApR.ReadToEnd();
                                    ApR.Close();
                                    StreamWriter Ap = new StreamWriter("users/ChatLog/ModeratorCommandsChatlog.txt");
                                    Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !addtow " + l.Username);
                                    Ap.Flush();
                                    Ap.Close();
                                }
                            }
                            else
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 " + l.PlayerName + "^7 is already a ^1VIP", MSO.UCID, 0);
                            }
                        }
                    }

                    #endregion

                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized User!", MSO.UCID, 0);
                    MsgAll("^1*^3 " + Conn.PlayerName + "^7 tried to use Add VIP Command!");
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }

        }
        [Command("remvip", "remvip <username>")]
        public void remvip(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                if (Conn.IsAdmin == 1)
                {
                    bool Found = false;
                    string Username = Msg.Remove(0, 8);

                    #region ' Online Removing '

                    foreach (clsConnection l in Connections)
                    {
                        if (l.Username == Username)
                        {
                            Found = true;
                            if (l.IsMafia == 1)
                            {
                                l.IsMafia = 0;
                                MsgAll("^1*^3*********************");
                                MsgAll("^7" + l.PlayerName + "^7 removed as VIP!");
                                MsgAll("^7Remove by: " + Conn.PlayerName);
                                MsgAll("^1*^3*********************");

                                if (System.IO.File.Exists(UserInfo + "\\ChatLog\\ModeratorCommandsChatlog.txt") == true)
                                {
                                    StreamReader ApR = new StreamReader("users/ChatLog/ModeratorCommandsChatlog.txt");
                                    string TempAPR = ApR.ReadToEnd();
                                    ApR.Close();
                                    StreamWriter Ap = new StreamWriter("users/ChatLog/ModeratorCommandsChatlog.txt");
                                    Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !addtow " + l.Username);
                                    Ap.Flush();
                                    Ap.Close();
                                }
                            }
                            else
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 " + l.PlayerName + "^7 is not a ^1VIP", MSO.UCID, 0);
                            }

                        }
                    }

                    #endregion

                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^7Not Authorized User!", MSO.UCID, 0);
                    MsgAll("^1*^3 " + Conn.PlayerName + "^7 tried to use Remove TowTruck Command!");
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }

        }
        #endregion

        [Command("remmember", "remmember <username>")]
        public void remmember(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                if (Conn.IsAdmin == 1)
                {
                    string Username = Msg.Remove(0, 11);
                    bool Found = false;

                    #region ' Online Removing '

                    foreach (clsConnection l in Connections)
                    {
                        if (l.Username == Username)
                        {
                            Found = true;
                            if (FileInfo.GetUserAdmin(Username) == 1)
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 " + l.PlayerName + "^7 is already a Admin!", MSO.UCID, 0);
                            }
                            else
                            {
                                if (l.IsMember == 1)
                                {
                                    Conn.AdminCommand = true;
                                    MsgAll("^3****Removing Status****");
                                    MsgAll("^1*^3 " + l.PlayerName + "^7 is now removed as Moderator!");
                                    MsgAll("^1*^3 Done by: " + Conn.PlayerName);
                                    InSim.Send_MTC_MessageToConnection("^1Remove your TAG now! Your no Member anymore!", l.UniqueID, 0);
                                    l.IsMember = 0;
                                    Conn.AdminCommand = false;
                                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                                    {
                                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                                        string TempAPR = ApR.ReadToEnd();
                                        ApR.Close();
                                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !remmember " + l.Username);
                                        Ap.Flush();
                                        Ap.Close();
                                    }
                                }
                                else
                                {
                                    InSim.Send_MTC_MessageToConnection("^1*^3 " + l.PlayerName + "^7 is not a Moderator!", MSO.UCID, 0);
                                }
                            }
                        }
                    }

                    #endregion
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized User!", MSO.UCID, 0);
                    MsgAll("^1*^3 " + Conn.PlayerName + "^7 tried to use Remove Moderator Command!");
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }

        }
        [Command("refund", "refund <amount> <username>")]
        public void refund(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                if (Conn.IsAdmin == 1)
                {
                    try
                    {
                        bool Found = false;
                        string Username = Msg.Remove(0, 9 + StrMsg[1].Length);
                        int Refund = int.Parse(StrMsg[1]);

                        if (Refund.ToString().Contains("-"))
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Input Invalid. Don't use minus on the Values!", MSO.UCID, 0);
                        }
                        else
                        {
                            #region ' Online Refunding '

                            foreach (clsConnection l in Connections)
                            {
                                if (l.Username == Username)
                                {
                                    Found = true;
                                    // All Players
                                    MsgAll("^1*^3 " + l.PlayerName + " ^7(" + l.Username + ") was refunded");
                                    MsgAll("^7Refunded by: " + Conn.PlayerName + " ^7(" + Conn.Username + ")");
                                    MsgAll("^7Refund Amount: ^2€" + Refund);
                                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                                    {
                                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                                        string TempAPR = ApR.ReadToEnd();
                                        ApR.Close();
                                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !refund " + Refund + " " + l.Username);
                                        Ap.Flush();
                                        Ap.Close();
                                    }
                                    l.Cash += Refund;
                                }
                            }

                            #endregion


                        }
                    }
                    catch
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 An Error has Occured. Re-consider the Amount!", MSO.UCID, 0);
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized User!", MSO.UCID, 0);
                    MsgAll("^1*^3 " + Conn.PlayerName + " tried to use Refund Command!");
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }

        }
        [Command("refdist", "refdist <distance> <username>")]
        public void refdist(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 2)
            {
                if (Conn.IsAdmin == 1)
                {
                    string Username = Msg.Remove(0, StrMsg[0].Length + StrMsg[1].Length + 2);
                    bool Found = false;
                    int Amount = int.Parse(StrMsg[1]);

                    try
                    {
                        if (Amount.ToString().Contains("-"))
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Input Invalid. Don't use minus on the Values!", MSO.UCID, 0);
                        }
                        else
                        {
                            #region ' Online '

                            foreach (clsConnection i in Connections)
                            {
                                if (i.Username == Username)
                                {
                                    Found = true;
                                    MsgAll("^1*^3 " + i.PlayerName + " ^7(" + i.Username + ") was refunded in Distance");
                                    MsgAll("^7Refunded by: " + Conn.PlayerName + " ^7(" + Conn.Username + ")");
                                    MsgAll("^7Refund Distance: ^2" + Amount + " km");
                                    i.TotalDistance += Amount * 1000;
                                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                                    {
                                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                                        string TempAPR = ApR.ReadToEnd();
                                        ApR.Close();
                                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !refdist " + Amount + " " + i.Username);
                                        Ap.Flush();
                                        Ap.Close();
                                    }
                                }
                            }

                            #endregion


                        }
                    }
                    catch
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 An Error has Occured. Re-consider the Amount!", MSO.UCID, 0);
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized User!", MSO.UCID, 0);
                    MsgAll("^1*^3 " + Conn.PlayerName + " tried to use Refund distance Command!");
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }

        }
        [Command("finedist", "finedist <distance> <username>")]
        public void finedist(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 2)
            {
                if (Conn.IsAdmin == 1)
                {
                    string Username = Msg.Remove(0, StrMsg[0].Length + StrMsg[1].Length + 2);
                    bool Found = false;
                    int Amount = int.Parse(StrMsg[1]);

                    try
                    {
                        if (Amount.ToString().Contains("-"))
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Input Invalid. Don't use minus on the Values!", MSO.UCID, 0);
                        }
                        else
                        {
                            #region ' Online '

                            foreach (clsConnection i in Connections)
                            {
                                if (i.Username == Username)
                                {
                                    Found = true;
                                    MsgAll("^1*^3 " + i.PlayerName + " ^1*^3 (" + i.Username + ") was fined in Distance");
                                    MsgAll("^7Fined by: " + Conn.PlayerName + " ^7(" + Conn.Username + ")");
                                    MsgAll("^7Fined Distance: ^1" + Amount + " km");
                                    i.TotalDistance -= Amount * 1000;
                                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                                    {
                                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                                        string TempAPR = ApR.ReadToEnd();
                                        ApR.Close();
                                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !finedist " + Amount + " " + i.Username);
                                        Ap.Flush();
                                        Ap.Close();
                                    }
                                }
                            }

                            #endregion


                        }
                    }
                    catch
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 An Error has Occured. Re-consider the Amount!", MSO.UCID, 0);
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized User!", MSO.UCID, 0);
                    MsgAll("^1*^3 " + Conn.PlayerName + " tried to use fine distance Command!");
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }

        }
        [Command("refcar", "refcar <car> <username>")]
        public void refcar(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 2)
            {
                if (Conn.IsAdmin == 1)
                {
                    bool Found = false;
                    string Username = Msg.Substring(StrMsg[0].Length + StrMsg[1].Length + 2);
                    string RefundCar = StrMsg[1].ToUpper();
                    try
                    {
                        #region ' Online '
                        foreach (clsConnection i in Connections)
                        {
                            if (i.Username == Username)
                            {
                                Found = true;
                                #region ' Exist '
                                if (i.Cars.Contains(RefundCar))
                                {
                                    if (RefundCar == "UF1")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> UF1000 (UF1) ^7is already exist on the Garage", MSO.UCID, 0);
                                    }
                                    else if (RefundCar == "XFG")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> XF GTi (XFG) ^7is already exist on the Garage", MSO.UCID, 0);
                                    }
                                    else if (RefundCar == "XRG")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> XR GTi (XRG) ^7is already exist on the Garage", MSO.UCID, 0);
                                    }
                                    else if (RefundCar == "LX4")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> LX4 (LX4) ^7is already exist on the Garage", MSO.UCID, 0);
                                    }
                                    else if (RefundCar == "LX6")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> LX6 (LX6) ^7is already exist on the Garage", MSO.UCID, 0);
                                    }
                                    else if (RefundCar == "RB4")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> RB GT Turbo (RB4) ^7is already exist on the Garage", MSO.UCID, 0);
                                    }
                                    else if (RefundCar == "FXO")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> FX GT Turbo (FXO) ^7is already exist on the Garage", MSO.UCID, 0);
                                    }
                                    else if (RefundCar == "VWS")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> Volkswagen Scirroco (VWS) ^7is already exist on the Garage", MSO.UCID, 0);
                                    }
                                    else if (RefundCar == "XRT")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> XR GT Turbo (XRT) ^7is already exist on the Garage", MSO.UCID, 0);
                                    }
                                    else if (RefundCar == "RAC")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> Raceabout (RAC) ^7is already exist on the Garage", MSO.UCID, 0);
                                    }
                                    else if (RefundCar == "FZ5")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> FZ50 (FZ5) ^7is already exist on the Garage", MSO.UCID, 0);
                                    }
                                    else if (RefundCar == "UFR")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> UF GTR (UFR) ^7is already exist on the Garage", MSO.UCID, 0);
                                    }
                                    else if (RefundCar == "XFR")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> XF GTR (XFR) ^7is already exist on the Garage", MSO.UCID, 0);
                                    }
                                    else if (RefundCar == "FXR")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> FX GTR (FXR) ^7is already exist on the Garage", MSO.UCID, 0);
                                    }
                                    else if (RefundCar == "XRR")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> XR GTR (XRR) ^7is already exist on the Garage", MSO.UCID, 0);
                                    }
                                    else if (RefundCar == "FZR")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> FZ GTR (FZR) ^7is already exist on the Garage", MSO.UCID, 0);
                                    }
                                    else if (RefundCar == "MRT")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> McGill Racing Kart (MRT) ^7is already exist on the Garage", MSO.UCID, 0);
                                    }
                                    else if (RefundCar == "FOX")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> Formula XR (FOX) ^7is already exist on the Garage", MSO.UCID, 0);
                                    }
                                    else if (RefundCar == "FBM")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> Formula BMW FB02 (MRT) ^7is already exist on the Garage", MSO.UCID, 0);
                                    }
                                    else if (RefundCar == "FO8")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> Formula V8 (FO8) ^7is already exist on the Garage", MSO.UCID, 0);
                                    }
                                    else if (RefundCar == "BF1")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> BMW Sauber 1.06 (BF1) ^7is already exist on the Garage", MSO.UCID, 0);
                                    }
                                }
                                #endregion

                                #region ' Coudn't be added '

                                else if (Dealer.GetCarPrice(RefundCar) == 0)
                                {
                                    if (RefundCar == "UF1")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> UF1000 (UF1) ^7is not available in Dealership", MSO.UCID, 0);
                                    }
                                    /*else if (RefundCar == "XFG")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> XF GTi (XFG) ^7is not available in Dealership", MSO.UCID, 0);
                                    }*/
                                    else if (RefundCar == "FO8")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> Formula V8 (FO8) ^7is not available in Dealership", MSO.UCID, 0);
                                    }
                                    else if (RefundCar == "FOX")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> Formula XR (FOX) ^7is not available in Dealership", MSO.UCID, 0);
                                    }
                                    /*else if (RefundCar == "BF1")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> BMW Sauber F1.06 (BF1) ^7is not available in Dealership", MSO.UCID, 0);
                                    }*/
                                    else
                                    {
                                        InSim.Send_MTC_MessageToConnection("^2> " + RefundCar + " ^7does not exist on Dealership", MSO.UCID, 0);
                                    }
                                }

                                #endregion

                                #region ' Add '
                                else
                                {
                                    switch (RefundCar)
                                    {
                                        case "UF1":
                                            i.Cars += " " + "UF1";
                                            break;
                                        case "XFG":
                                            i.Cars += " " + "XFG";
                                            break;
                                        case "XRG":
                                            i.Cars += " " + "XRG";
                                            break;
                                        case "VWS":
                                            i.Cars += " " + "VWS";
                                            break;
                                        case "LX4":
                                            i.Cars += " " + "LX4";
                                            break;
                                        case "LX6":
                                            i.Cars += " " + "LX6";
                                            break;
                                        case "RB4":
                                            i.Cars += " " + "RB4";
                                            break;
                                        case "FXO":
                                            i.Cars += " " + "FXO";
                                            break;
                                        case "XRT":
                                            i.Cars += " " + "XRT";
                                            break;
                                        case "RAC":
                                            i.Cars += " " + "RAC";
                                            break;
                                        case "FZ5":
                                            i.Cars += " " + "FZ5";
                                            break;
                                        case "UFR":
                                            i.Cars += " " + "UFR";
                                            break;
                                        case "XFR":
                                            i.Cars += " " + "XFR";
                                            break;
                                        case "FXR":
                                            i.Cars += " " + "FXR";
                                            break;
                                        case "XRR":
                                            i.Cars += " " + "XRR";
                                            break;
                                        case "FZR":
                                            i.Cars += " " + "FZR";
                                            break;

                                        case "MRT":
                                            i.Cars += " " + "MRT";
                                            break;

                                        case "FBM":
                                            i.Cars += " " + "FBM";
                                            break;
                                        case "BF1":
                                            i.Cars += " " + "BF1";
                                            break;
                                    }

                                    MsgAll("^3Car Refund:");
                                    MsgAll("^1*^3 " + i.PlayerName + " ^2received a ^1*^3 " + RefundCar);
                                    MsgAll("^1*^3 Given by " + Conn.PlayerName);
                                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                                    {
                                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                                        string TempAPR = ApR.ReadToEnd();
                                        ApR.Close();
                                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !refcar " + RefundCar + " " + i.Username);
                                        Ap.Flush();
                                        Ap.Close();
                                    }

                                }
                                #endregion
                            }
                        }
                        #endregion


                    }
                    catch
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 An Error has occured. Please retype the Command!", MSO.UCID, 0);
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized User!", MSO.UCID, 0);
                    MsgAll("^1*^3 " + Conn.PlayerName + " tried to use refund vehicle Command!");
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }
            //
        }
        [Command("remcar", "remcar <car> <username>")]
        public void remcar(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 2)
            {
                if (Conn.IsAdmin == 1)
                {
                    bool Found = false;
                    string Username = Msg.Substring(StrMsg[0].Length + StrMsg[1].Length + 2);
                    string RemoveCar = StrMsg[1].ToUpper();
                    try
                    {
                        #region ' Online '

                        foreach (clsConnection i in Connections)
                        {
                            if (i.Username == Username)
                            {
                                Found = true;
                                #region ' Check Owned '
                                if (i.Cars.Contains(RemoveCar))
                                {
                                    #region ' Check can be Removed '
                                    if (Dealer.GetCarPrice(RemoveCar) > 0)
                                    {
                                        string UserCars = i.Cars;
                                        int IdxCar = UserCars.IndexOf(RemoveCar);
                                        try
                                        {
                                            i.Cars = i.Cars.Remove(IdxCar, 4);
                                        }
                                        catch
                                        {
                                            i.Cars = i.Cars.Remove(IdxCar, 3);
                                        }
                                        if (Conn.PlayerName == "host")
                                        {
                                            MsgPly("^1*^3 Car Removed by Trading or New Player", MSO.UCID);
                                        }
                                        else
                                        {
                                            if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                                            {
                                                StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                                                string TempAPR = ApR.ReadToEnd();
                                                ApR.Close();
                                                StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                                                Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !remcar " + RemoveCar + " " + i.Username);
                                                Ap.Flush();
                                                Ap.Close();
                                            }
                                            MsgAll("^1*^3 Force Car Remove:");
                                            MsgAll("^1*^3 " + i.PlayerName + "^1 was force removed ^3" + RemoveCar);
                                            MsgAll("^1*^3 Removed by: " + Conn.PlayerName);
                                        }
                                    }
                                    #endregion

                                    #region ' Check if couldn't removed '
                                    else
                                    {
                                        if (RemoveCar == "UF1")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> UF1000 (UF1) ^7coudn't be removed", MSO.UCID, 0);
                                        }
                                        else if (RemoveCar == "XFG")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> XF GTi (XFG) ^7coudn't be removed", MSO.UCID, 0);
                                        }
                                        else if (RemoveCar == "FO8")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> Formula V8 (FO8) ^7coudn't be removed", MSO.UCID, 0);
                                        }
                                        else if (RemoveCar == "FOX")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> Formula XR (FOX) ^7coudn't be removed", MSO.UCID, 0);
                                        }
                                        else if (RemoveCar == "BF1")
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> BMW Sauber F1.06 (BF1) ^7coudn't be removed", MSO.UCID, 0);
                                        }
                                        else
                                        {
                                            InSim.Send_MTC_MessageToConnection("^2> " + RemoveCar + " ^7Invalid Car Garage List", MSO.UCID, 0);
                                        }
                                    }
                                    #endregion
                                }
                                #endregion

                                #region ' Check Doesn't Own '
                                else
                                {
                                    if (RemoveCar == "UF1")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 " + i.PlayerName + " doesn't own ^1UF1000 (UF1)", MSO.UCID, 0);
                                    }
                                    else if (RemoveCar == "XFG")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 " + i.PlayerName + " doesn't own ^1XF GTi (XFG)", MSO.UCID, 0);
                                    }
                                    else if (RemoveCar == "XRG")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 " + i.PlayerName + " doesn't own ^1XR GTi (XRG)", MSO.UCID, 0);
                                    }
                                    else if (RemoveCar == "LX4")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 " + i.PlayerName + " doesn't own ^1LX4 (LX4)", MSO.UCID, 0);
                                    }
                                    else if (RemoveCar == "LX6")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 " + i.PlayerName + " doesn't own ^1LX6 (LX6)", MSO.UCID, 0);
                                    }
                                    else if (RemoveCar == "RB4")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 " + i.PlayerName + " doesn't own ^1RB GT Turbo (RB4)", MSO.UCID, 0);
                                    }
                                    else if (RemoveCar == "FXO")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 " + i.PlayerName + " doesn't own ^1FX GT Turbo (FXO)", MSO.UCID, 0);
                                    }
                                    else if (RemoveCar == "VWS")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 " + i.PlayerName + " doesn't own ^1Volkswagen Scirroco (VWS)", MSO.UCID, 0);
                                    }
                                    else if (RemoveCar == "XRT")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 " + i.PlayerName + " doesn't own ^1XR GT Turbo (XRT)", MSO.UCID, 0);
                                    }
                                    else if (RemoveCar == "RAC")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 " + i.PlayerName + " doesn't own ^1Raceabout (RAC)", MSO.UCID, 0);
                                    }
                                    else if (RemoveCar == "FZ5")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 " + i.PlayerName + " doesn't own ^1FZ50 GT (FZ5)", MSO.UCID, 0);
                                    }
                                    else if (RemoveCar == "UFR")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 " + i.PlayerName + " doesn't own ^1UF GTR (UFR)", MSO.UCID, 0);
                                    }
                                    else if (RemoveCar == "XFR")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 " + i.PlayerName + " doesn't own ^1XF GTR (XFR)", MSO.UCID, 0);
                                    }
                                    else if (RemoveCar == "FXR")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 " + i.PlayerName + " doesn't own ^1FX GTR (FXR)", MSO.UCID, 0);
                                    }
                                    else if (RemoveCar == "XRR")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 " + i.PlayerName + " doesn't own ^1XR GTR (XRR)", MSO.UCID, 0);
                                    }
                                    else if (RemoveCar == "FZR")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 " + i.PlayerName + " doesn't own ^1FZ GTR (FZR)", MSO.UCID, 0);
                                    }
                                    else if (RemoveCar == "MRT")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 " + i.PlayerName + " doesn't own ^1McGill Racing Kart (MRT)", MSO.UCID, 0);
                                    }
                                    else if (RemoveCar == "FBM")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 " + i.PlayerName + " doesn't own ^1Formula BMW FB02 (FBM)", MSO.UCID, 0);
                                    }
                                    else if (RemoveCar == "FO8")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 " + i.PlayerName + " doesn't own ^1Formula V8 (FO8)", MSO.UCID, 0);
                                    }
                                    else if (RemoveCar == "FOX")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 " + i.PlayerName + " doesn't own ^1Formula XR (FOX)", MSO.UCID, 0);
                                    }
                                    else if (RemoveCar == "BF1")
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 " + i.PlayerName + " doesn't own ^1BMW Sauber F1.06 (BF1)", MSO.UCID, 0);
                                    }
                                    else
                                    {
                                        InSim.Send_MTC_MessageToConnection("^1*^3 " + RemoveCar + " ^7Invalid Car Garage List", MSO.UCID, 0);
                                    }
                                }
                                #endregion
                            }
                        }

                        #endregion


                    }
                    catch
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 An Error has occured. Please retype the Command!", MSO.UCID, 0);
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized User!", MSO.UCID, 0);
                    MsgAll("^1*^3 " + Conn.PlayerName + " tried to use remove vehicle Command!");
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }

        }
        [Command("reflp", "reflp <License> <username>")]
        public void reflp(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 2)
            {
                if (Conn.IsAdmin == 1)
                {
                    string Username = Msg.Remove(0, StrMsg[0].Length + StrMsg[1].Length + 2);
                    bool Found = false;
                    int Amount = int.Parse(StrMsg[1]);

                    try
                    {
                        if (Amount.ToString().Contains("-"))
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Input Invalid. Don't use minus on the Values!", MSO.UCID, 0);
                        }
                        else
                        {
                            #region ' Online '

                            foreach (clsConnection i in Connections)
                            {
                                if (i.Username == Username)
                                {
                                    Found = true;
                                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                                    {
                                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                                        string TempAPR = ApR.ReadToEnd();
                                        ApR.Close();
                                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !reflp " + Amount + " " + i.Username);
                                        Ap.Flush();
                                        Ap.Close();
                                    }
                                    MsgAll("^1*^3 " + i.PlayerName + "^7 (" + i.Username + ") was refunded License points");
                                    MsgAll("^7Refunded by: " + Conn.PlayerName + " ^7(" + Conn.Username + ")");
                                    MsgAll("^7License points Refunded: ^2" + Amount);
                                    i.License += Amount;

                                }
                            }

                            #endregion


                        }
                    }
                    catch
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 An Error has Occured. Re-consider the Amount!", MSO.UCID, 0);
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized User!", MSO.UCID, 0);
                    MsgAll("^1*^3 " + Conn.PlayerName + " ^1*^3 tried to use fine distance Command!");
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }

        }
        [Command("finelp", "finelp <amount> <username>")]
        public void finelp(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 2)
            {
                if (Conn.IsAdmin == 1)
                {
                    try
                    {
                        bool Found = false;
                        string Username = Msg.Remove(0, StrMsg[0].Length + StrMsg[1].Length + 2);
                        int Fine = int.Parse(StrMsg[1]);

                        if (Conn.License.ToString().Contains("-"))
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Input Invalid. Don't use minus on the Values!", MSO.UCID, 0);
                            Conn.License = 0;
                        }

                        else
                        {
                            #region ' Online Force Fine '

                            foreach (clsConnection l in Connections)
                            {
                                if (l.Username == Username)
                                {
                                    Found = true;
                                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                                    {
                                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                                        string TempAPR = ApR.ReadToEnd();
                                        ApR.Close();
                                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !finelp " + Fine + " " + l.Username);
                                        Ap.Flush();
                                        Ap.Close();
                                    }
                                    // All Players
                                    MsgAll("^1*^3 " + l.PlayerName + " ^7(" + l.Username + ") was Forced Fined License Points");
                                    MsgAll("^7Fined License Points by: " + Conn.PlayerName + " (" + Conn.Username + ")");
                                    MsgAll("^7Fine Amount: ^1" + Fine);


                                    l.License -= Fine - -1;

                                }
                            }

                            #endregion

                        }
                    }
                    catch
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 An Error has Occured. Re-consider the Amount!", MSO.UCID, 0);
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized User!", MSO.UCID, 0);
                    MsgAll("^1*^3 " + Conn.PlayerName + " tried to use Fine Command!");
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }

        }
        [Command("refjobs", "refjobs <Jobs> <username>")]
        public void refjob(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 2)
            {
                if (Conn.IsAdmin == 1 || Conn.IsMember == 1)
                {
                    string Username = Msg.Remove(0, StrMsg[0].Length + StrMsg[1].Length + 2);
                    bool Found = false;
                    int Amount = int.Parse(StrMsg[1]);

                    try
                    {
                        if (Amount.ToString().Contains("-"))
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Input Invalid. Don't use minus on the Values!", MSO.UCID, 0);
                        }
                        else
                        {
                            #region ' Online '

                            foreach (clsConnection i in Connections)
                            {
                                if (i.Username == Username)
                                {
                                    Found = true;
                                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                                    {
                                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                                        string TempAPR = ApR.ReadToEnd();
                                        ApR.Close();
                                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !refjobs " + Amount + " " + i.Username);
                                        Ap.Flush();
                                        Ap.Close();
                                    }
                                    MsgAll("^1*^3 " + i.PlayerName + "^7 (" + i.Username + ") was refunded jobs");
                                    MsgAll("^7Refunded by: " + Conn.PlayerName + " ^7(" + Conn.Username + ")");
                                    MsgAll("^7Jobs Refunded: ^2" + Amount);
                                    i.JobsDone += Amount;

                                }
                            }

                            #endregion


                        }
                    }
                    catch
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 An Error has Occured. Re-consider the Amount!", MSO.UCID, 0);
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized User!", MSO.UCID, 0);
                    MsgAll("^1*^3 " + Conn.PlayerName + " ^1*^3 tried to use fine jobs Command!");
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }

        }
        [Command("finejobs", "finejobs <amount> <username>")]
        public void finejob(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 2)
            {
                if (Conn.IsAdmin == 1 || Conn.IsMember == 1)
                {
                    try
                    {
                        bool Found = false;
                        string Username = Msg.Remove(0, StrMsg[0].Length + StrMsg[1].Length + 2);
                        int Fine = int.Parse(StrMsg[1]);

                        if (Conn.License.ToString().Contains("-"))
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Input Invalid. Don't use minus on the Values!", MSO.UCID, 0);
                            Conn.License = 0;
                        }

                        else
                        {
                            #region ' Online Force Fine '

                            foreach (clsConnection l in Connections)
                            {
                                if (l.Username == Username)
                                {
                                    Found = true;
                                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                                    {
                                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                                        string TempAPR = ApR.ReadToEnd();
                                        ApR.Close();
                                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !finejobs " + Fine + " " + l.Username);
                                        Ap.Flush();
                                        Ap.Close();
                                    }
                                    // All Players
                                    MsgAll("^1*^3 " + l.PlayerName + " ^7(" + l.Username + ") was Forced Fined Jobs");
                                    MsgAll("^7Fined Jobs by: " + Conn.PlayerName + " (" + Conn.Username + ")");
                                    MsgAll("^7Fine Amount: ^1" + Fine);


                                    l.JobsDone -= Fine - -1;

                                }
                            }

                            #endregion

                        }
                    }
                    catch
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 An Error has Occured. Re-consider the Amount!", MSO.UCID, 0);
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized User!", MSO.UCID, 0);
                    MsgAll("^1*^3 " + Conn.PlayerName + " tried to use Fine Command!");
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }

        }
        [Command("sethud", "sethud <number>")]
        public void sethud(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (Conn.IsAdmin == 1)
            {
                if (StrMsg.Length > 1)
                {
                    int MsgCC = int.Parse(StrMsg[1]);
                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminChatlog - Rename to Date.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/ChatLog/AdminChatlog - Rename to Date.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminChatlog - Rename to Date.txt");
                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " " + Conn.PlayerName + " (" + Conn.Username + "): !sethud" + MsgCC);
                        Ap.Flush();
                        Ap.Close();
                    }
                    else
                    {
                        MessageBox.Show("AdminChatlog - Rename to Date.txt missing!");
                    }
                    foreach (clsConnection u in Connections)
                    {
                        u.GUIStyle = MsgCC;
                        InSim.Send_MTC_MessageToConnection("^6Set everyone's hud: " + MsgCC, u.UniqueID, 0);
                    }

                }
                else
                {
                    if (StrMsg.Length == 1)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Using set hud ^2!sethud <number>", MSO.UCID, 0);
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
                    }
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }

        }
        [Command("ac", "ac <message>")]
        public void adminchat(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (Conn.IsAdmin == 1)
            {
                if (StrMsg.Length > 1)
                {
                    string MsgCC = Msg.Remove(0, 4);
                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminChatlog - Rename to Date.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/ChatLog/AdminChatlog - Rename to Date.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminChatlog - Rename to Date.txt");
                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - Message by " + Conn.PlayerName + " (" + Conn.Username + "): " + MsgCC);
                        Ap.Flush();
                        Ap.Close();
                    }
                    else
                    {
                        MessageBox.Show("AdminChatlog - Rename to Date.txt missing!");
                    }
                    foreach (clsConnection u in Connections)
                    {
                        if (u.IsAdmin == 1)
                        {
                            InSim.Send_MTC_MessageToConnection("^5Admin Chat: " + Conn.PlayerName + " ^7(" + Conn.Username + ")", u.UniqueID, 0);
                            InSim.Send_MTC_MessageToConnection("^6Msg: " + MsgCC, u.UniqueID, 0);
                        }
                    }

                }
                else
                {
                    if (StrMsg.Length == 1)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Using admin chat ^2!ac <message>", MSO.UCID, 0);
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
                    }
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }

        }
        [Command("banlist", "banlist <username>")]
        public void banlist(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];

            if (StrMsg.Length > 1)
            {
                if (Conn.IsAdmin == 1)
                {

                    bool Found = false;
                    string Username = Msg.Remove(0, 9);
                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !banlist " + Username);
                        Ap.Flush();
                        Ap.Close();
                    }
                    #region ' Online '

                    foreach (clsConnection i in Connections)
                    {
                        if (i.Username == Username)
                        {
                            Found = true;
                            MsgAll("^1*^3****Permanent Ban*****");
                            MsgAll("" + i.PlayerName + " ^1was ^0Black-Listed");
                            MsgAll("^7Permanent Ban given by: " + Conn.PlayerName);
                            MsgPly("^7You are banlisted by: " + Conn.PlayerName, i.UniqueID);
                            MsgPly("^7Appeals: " + Website, i.UniqueID);

                            FileInfo.AddBanList(Username);
                            BanID(i.Username, 0);
                        }
                    }

                    #endregion

                    #region ' Offline '

                    if (Found == false)
                    {
                        if (System.IO.File.Exists(UserInfo + "\\" + Username + ".txt") == true)
                        {
                            #region ' Objects '
                            long Cash = FileInfo.GetUserCash(Username);
                            long BBal = FileInfo.GetUserBankBalance(Username);
                            string Cars = FileInfo.GetUserCars(Username);

                            long TotalDistance = FileInfo.GetUserDistance(Username);
                            int Health = FileInfo.GetUserHealth(Username);
                            long JobsDone = FileInfo.GetUserJobDone(Username);

                            long Electronics = FileInfo.GetUserItem1(Username);
                            long Furniture = FileInfo.GetUserItem2(Username);

                            //int LastRaffle = FileInfo.GetUserLastRaffle(Username);
                            int LastLotto = FileInfo.GetUserLastLotto(Username);

                            byte CanBeOfficer = FileInfo.GetUserOfficer(Username);
                            byte CanBeCadet = FileInfo.GetUserCadet(Username);
                            byte CanBeTowTruck = FileInfo.GetUserTowTruck(Username);
                            byte IsModerator = FileInfo.GetUserMember(Username);
                            //string PlayerName = FileInfo.GetUserPlayerName(Username);
                            #endregion

                            /* #region ' Special PlayerName Colors Remove '

                            string NoColPlyName = PlayerName;
                            if (NoColPlyName.Contains("^0"))
                            {
                                NoColPlyName = NoColPlyName.Replace("^0", "");
                            }
                            if (NoColPlyName.Contains("^1"))
                            {
                                NoColPlyName = NoColPlyName.Replace("^1", "");
                            }
                            if (NoColPlyName.Contains("^2"))
                            {
                                NoColPlyName = NoColPlyName.Replace("^2", "");
                            }
                            if (NoColPlyName.Contains("^3"))
                            {
                                NoColPlyName = NoColPlyName.Replace("^3", "");
                            }
                            if (NoColPlyName.Contains("^4"))
                            {
                                NoColPlyName = NoColPlyName.Replace("^4", "");
                            }
                            if (NoColPlyName.Contains("^5"))
                            {
                                NoColPlyName = NoColPlyName.Replace("^5", "");
                            }
                            if (NoColPlyName.Contains("^6"))
                            {
                                NoColPlyName = NoColPlyName.Replace("^6", "");
                            }
                            if (NoColPlyName.Contains("^7"))
                            {
                                NoColPlyName = NoColPlyName.Replace("^7", "");
                            }
                            if (NoColPlyName.Contains("^8"))
                            {
                                NoColPlyName = NoColPlyName.Replace("^8", "");
                            }
                            #endregion*/

                            MsgAll("^1*^3****Permanent Ban*****");
                            MsgAll("^1" + Username + " ^1was ^0Black-Listed");
                            MsgAll("^7Permanent Ban given by: " + Conn.PlayerName);
                            FileInfo.AddBanList(Username);
                            BanID(Username, 0);
                        }
                        else
                        {
                            MsgPly("" + Username + " wasn't found in database!", MSO.UCID);
                        }
                    }

        #endregion

                }
                else
                {
                    MsgPly("^1*^3 Not Authorized User!", MSO.UCID);
                    MsgAll("^7 " + Conn.PlayerName + " ^7tried to use Banlist Command!");
                }
            }
            else
            {
                MsgPly("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID);
            }

        }
        [Command("vote", "vote")]
        public void vote(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length == 1)
            {

                if (Conn.IsAdmin == 1)
                {


                    MsgPly("^4|^7 Welcome to ^4Voting ^7Settings.", MSO.UCID);
                    InSim.Send_BTN_CreateButton("", Flags.ButtonStyles.ISB_DARK, 50, 100, 50, 50, 75, Conn.UniqueID, 2, false);
                    InSim.Send_BTN_CreateButton("", Flags.ButtonStyles.ISB_DARK, 50, 100, 50, 50, 76, Conn.UniqueID, 2, false);
                    InSim.Send_BTN_CreateButton("^7Voting setup.", Flags.ButtonStyles.ISB_LIGHT, 7, 98, 51, 51, 77, Conn.UniqueID, 2, false);
                    InSim.Send_BTN_CreateButton("^7Question: ^1-------->", Flags.ButtonStyles.ISB_LEFT, 6, 40, 60, 54, 68, Conn.UniqueID, 2, false);
                    InSim.Send_BTN_CreateButton("", "^7Your question", Flags.ButtonStyles.ISB_LIGHT | Flags.ButtonStyles.ISB_CLICK, 5, 20, 60, 100, 165, 69, Conn.UniqueID, 2, false);
                    InSim.Send_BTN_CreateButton("^7Ansver One: ^1-------->", Flags.ButtonStyles.ISB_LEFT, 6, 40, 70, 54, 70, Conn.UniqueID, 2, false);
                    InSim.Send_BTN_CreateButton("", "^7Your answer", Flags.ButtonStyles.ISB_LIGHT | Flags.ButtonStyles.ISB_CLICK, 5, 20, 70, 100, 165, 71, Conn.UniqueID, 2, false);
                    InSim.Send_BTN_CreateButton("^7Ansver Two: ^1-------->", Flags.ButtonStyles.ISB_LEFT, 6, 40, 80, 54, 72, Conn.UniqueID, 2, false);
                    InSim.Send_BTN_CreateButton("", "^7Your answer 2", Flags.ButtonStyles.ISB_LIGHT | Flags.ButtonStyles.ISB_CLICK, 5, 20, 80, 100, 165, 73, Conn.UniqueID, 2, false);
                    InSim.Send_BTN_CreateButton("^7GO", Flags.ButtonStyles.ISB_LIGHT | Flags.ButtonStyles.ISB_CLICK, 4, 10, 92, 95, 74, Conn.UniqueID, 2, false);

                }

            }
        }


        [Command("checkbanlist", "checkbanlist <username>")]
        public void checkbanlists(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];

            if (StrMsg.Length > 1)
            {
                if (Conn.IsAdmin == 1 || Conn.IsMember == 1)
                {
                    string UsernameChat = Msg.Remove(0, 14);
                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !checkbanlist " + UsernameChat);
                        Ap.Flush();
                        Ap.Close();
                    }
                    InSim.Send_MTC_MessageToConnection("^7Searching trough perma ban list...", MSO.UCID, 0);
                    bool Found = false;
                    StreamReader Sr = new StreamReader("users/banlist/BanList.txt");

                    string line = null;
                    while ((line = Sr.ReadLine()) != null)
                    {
                        if (line.Substring(0, 3) == "Ban")
                        {
                            try
                            {
                                if (UsernameChat == line.Remove(0, 6).Trim())
                                {
                                    InSim.Send_MTC_MessageToConnection("^2Banlist detection found:", MSO.UCID, 0);
                                    InSim.Send_MTC_MessageToConnection("^2" + UsernameChat + " found on the banlist!", MSO.UCID, 0);
                                    Found = true;
                                }
                                else
                                {
                                }
                            }
                            catch
                            {

                            }
                        }
                        // return 0;
                    }
                    if (Found = false)
                    {
                        InSim.Send_MTC_MessageToConnection("^1Banlist detection not found:", MSO.UCID, 0);
                        InSim.Send_MTC_MessageToConnection("^1" + UsernameChat + " not found on the banlist!", MSO.UCID, 0);
                    }
                }
                else
                {
                    MsgPly("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID);
                }

            }
            else if (StrMsg.Length == 1)
            {
                if (Conn.IsAdmin == 1 || Conn.IsMember == 1)
                {
                    StreamReader Sr = new StreamReader("users/banlist/BanList.txt");
                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\AdminCommandsChatlog.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/ChatLog/AdminCommandsChatlog.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/ChatLog/AdminCommandsChatlog.txt");
                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !checkbanlist");
                        Ap.Flush();
                        Ap.Close();
                    }
                    InSim.Send_MTC_MessageToConnection("^7Perma banned players:", MSO.UCID, 0);
                    string line = null;
                    while ((line = Sr.ReadLine()) != null)
                    {
                        if (line.Substring(0, 3) == "Ban")
                        {
                            try
                            {
                                InSim.Send_MTC_MessageToConnection("^1" + line.Remove(0, 6).Trim() + " ^5 is banned Perma.", MSO.UCID, 0);
                            }
                            catch
                            {

                            }
                        }
                        // return 0;
                    }
                }
                else
                {
                    MsgPly("^7Invalid Command. ^2!help ^7for help.", MSO.UCID);
                }
            }
        }
        #endregion

        #region ' Member Commands '
        [Command("mod", "mod (username)")]
        public void mod(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            clsConnection Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                if (Conn.IsMember == 1 || Conn.IsAdmin == 1)
                {
                    bool ModUserFound = false;
                    foreach (clsConnection C in Connections)
                    {
                        if (C.Username == Msg.Remove(0, 5))
                        {
                            if (System.IO.File.Exists(UserInfo + "\\ChatLog\\ModeratorCommandsChatlog.txt") == true)
                            {
                                StreamReader ApR = new StreamReader("users/ChatLog/ModeratorCommandsChatlog.txt");
                                string TempAPR = ApR.ReadToEnd();
                                ApR.Close();
                                StreamWriter Ap = new StreamWriter("users/ChatLog/ModeratorCommandsChatlog.txt");
                                Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !mod " + C.Username);
                                Ap.Flush();
                                Ap.Close();
                            }
                            ModUserFound = true;
                            Conn.OpenModerator = 1;
                            InSim.Send_BTN_CreateButton("^7MODERATION ^1CLOSE[X]", Flags.ButtonStyles.ISB_RIGHT | Flags.ButtonStyles.ISB_CLICK | Flags.ButtonStyles.ISB_DARK, 5, 40, 40, 123, 40, MSO.UCID, 40, false);
                            InSim.Send_BTN_CreateButton(C.PlayerName + " ^7(" + C.Username + ")", Flags.ButtonStyles.ISB_LEFT | Flags.ButtonStyles.ISB_DARK, 5, 40, 45, 123, 41, MSO.UCID, 40, false);
                            if (Conn.MilesOrKilometers == 0)
                            {
                                InSim.Send_BTN_CreateButton("^7Cash: ^2€" + C.Cash + "^7 Distance: ^2" + C.TotalDistance / 1000 + "km", Flags.ButtonStyles.ISB_LEFT | Flags.ButtonStyles.ISB_DARK, 5, 40, 50, 123, 42, MSO.UCID, 40, false);
                            }
                            else if (Conn.MilesOrKilometers == 1)
                            {
                                InSim.Send_BTN_CreateButton("^7Cash: ^2€" + C.Cash + "^7 Distance: ^2" + C.TotalDistance / 1609 + "mi", Flags.ButtonStyles.ISB_LEFT | Flags.ButtonStyles.ISB_DARK, 5, 40, 50, 123, 42, MSO.UCID, 40, false);
                            }
                            InSim.Send_BTN_CreateButton("^7Reason: Click here to Type!", "Type your Reason", Flags.ButtonStyles.ISB_CLICK | Flags.ButtonStyles.ISB_DARK, 5, 40, 55, 123, 43, 43, MSO.UCID, 40, false);

                            InSim.Send_BTN_CreateButton("^7WARN", Flags.ButtonStyles.ISB_DARK | Flags.ButtonStyles.ISB_CLICK, 5, 8, 65, 123, 44, MSO.UCID, 40, false);
                            InSim.Send_BTN_CreateButton("^7FINE", "SET FINE", Flags.ButtonStyles.ISB_DARK | Flags.ButtonStyles.ISB_CLICK, 5, 8, 65, 131, 45, 45, MSO.UCID, 40, false);
                            InSim.Send_BTN_CreateButton("^7SPEC", Flags.ButtonStyles.ISB_CLICK | Flags.ButtonStyles.ISB_DARK, 5, 8, 65, 139, 46, MSO.UCID, 40, false);
                            InSim.Send_BTN_CreateButton("^7KICK", Flags.ButtonStyles.ISB_CLICK | Flags.ButtonStyles.ISB_DARK, 5, 8, 65, 147, 47, MSO.UCID, 40, false);
                            if (Conn.IsAdmin == 1)
                            {
                                InSim.Send_BTN_CreateButton("^7BAN", "Type the Days!", Flags.ButtonStyles.ISB_CLICK | Flags.ButtonStyles.ISB_DARK, 5, 8, 65, 155, 48, 48, MSO.UCID, 40, false);
                            }

                            Conn.CheckUser = C.Username;
                        }
                    }
                    if (ModUserFound == false)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Username is not Found", MSO.UCID, 0);
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized for Moderation!", MSO.UCID, 0);
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }

        }
        [Command("removecop", "removecop <username>")]
        public void removecop(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                if (Conn.IsMember == 1 || Conn.IsAdmin == 1)
                {
                    bool Found = false;
                    string Username = Msg.Remove(0, 11);

                    #region ' Online '
                    foreach (clsConnection l in Connections)
                    {
                        if (l.Username == Username)
                        {
                            Found = true;
                            if (l.IsOfficer == 1)
                            {
                                if (l.CanBeOfficer == 1)
                                {
                                    MsgAll("^1*^3 " + l.PlayerName + "^7 is now removed as Officer!");
                                    InSim.Send_MTC_MessageToConnection("^2>^1Remove your TAG now! Your no Officer anymore!", l.UniqueID, 0);
                                    l.CanBeOfficer = 0;
                                    l.CanBeCadet = 0;
                                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\ModeratorCommandsChatlog.txt") == true)
                                    {
                                        StreamReader ApR = new StreamReader("users/ChatLog/ModeratorCommandsChatlog.txt");
                                        string TempAPR = ApR.ReadToEnd();
                                        ApR.Close();
                                        StreamWriter Ap = new StreamWriter("users/ChatLog/ModeratorCommandsChatlog.txt");
                                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !removecop " + l.Username);
                                        Ap.Flush();
                                        Ap.Close();
                                    }
                                }
                            }
                            else if (l.IsOfficer == 0)
                            {
                                if (l.CanBeOfficer == 1)
                                {
                                    MsgAll("^1*^3 " + l.PlayerName + "^7 is now removed as Officer!");
                                    InSim.Send_MTC_MessageToConnection("^2>^1Remove your TAG now! Your no Officer anymore!", l.UniqueID, 0);
                                    l.CanBeOfficer = 0;
                                    l.CanBeCadet = 0;
                                }
                            }

                            if (l.CanBeOfficer == 0)
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 " + l.PlayerName + "^7 is not an Officer!", MSO.UCID, 0);
                            }
                        }
                    }
                    #endregion

                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized User!", MSO.UCID, 0);
                    MsgAll("^1*^3 " + Conn.PlayerName + "^7 tried to use Remove Cop Command!");
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }

        }
        [Command("addcadet", "addcadet <username>")]
        public void addcadet(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                if (Conn.IsMember == 1 || Conn.IsAdmin == 1)
                {
                    bool Found = false;
                    string Username = Msg.Remove(0, 10);

                    #region ' Online Adding '

                    foreach (clsConnection l in Connections)
                    {
                        if (l.Username == Username)
                        {
                            Found = true;

                            if (l.CanBeOfficer == 1)
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 " + l.PlayerName + "^7 is already a Officer", MSO.UCID, 0);
                            }
                            else if (l.CanBeOfficer == 0)
                            {
                                if (l.CanBeCadet == 0 || l.CanBeCadet == 2 || l.CanBeCadet == 3)
                                {
                                    MsgAll("^3****Promotion****");
                                    MsgAll("^7" + l.PlayerName + "^7 can be now a Cadet!");
                                    MsgAll("^7Done by: " + Conn.PlayerName);
                                    l.CanBeCadet = 1;
                                    InSim.Send_MTC_MessageToConnection("^1*^3 To get in duty use the ^0Cadet^7•^3NAME to get duty!", l.UniqueID, 0);
                                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\ModeratorCommandsChatlog.txt") == true)
                                    {
                                        StreamReader ApR = new StreamReader("users/ChatLog/ModeratorCommandsChatlog.txt");
                                        string TempAPR = ApR.ReadToEnd();
                                        ApR.Close();
                                        StreamWriter Ap = new StreamWriter("users/ChatLog/ModeratorCommandsChatlog.txt");
                                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !addcadet " + l.Username);
                                        Ap.Flush();
                                        Ap.Close();
                                    }
                                }
                            }
                        }
                    }

                    #endregion

                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized User!", MSO.UCID, 0);
                    MsgAll("^1*^3  " + Conn.PlayerName + "^7 tried to use Add Cadet Command!");
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }

        }
        [Command("addmafia", "addmafia <username>")]
        public void addmafia(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                if (Conn.IsAdmin == 1 || Conn.IsMember == 1)
                {
                    bool Found = false;
                    string Username = Msg.Remove(0, 10);
                    #region ' Online '
                    foreach (clsConnection l in Connections)
                    {
                        if (l.Username == Username)
                        {
                            Found = true;
                            if (l.CanBeMafia == 0)
                            {
                                MsgAll("^3****Promotion****");
                                MsgAll("^7" + l.PlayerName + "^7 can be now a Maffia");
                                MsgAll("^7Done by: " + Conn.PlayerName);
                                InSim.Send_MTC_MessageToConnection("^1*^3 To get in duty use the ^7MAFIA^0‡^1NAME ^1*^3 to get duty!", l.UniqueID, 0);
                                l.CanBeMafia = 1;
                                if (System.IO.File.Exists(UserInfo + "\\ChatLog\\ModeratorCommandsChatlog.txt") == true)
                                {
                                    StreamReader ApR = new StreamReader("users/ChatLog/ModeratorCommandsChatlog.txt");
                                    string TempAPR = ApR.ReadToEnd();
                                    ApR.Close();
                                    StreamWriter Ap = new StreamWriter("users/ChatLog/ModeratorCommandsChatlog.txt");
                                    Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !addmafia " + l.Username);
                                    Ap.Flush();
                                    Ap.Close();
                                }
                            }
                            else if (l.CanBeMafia == 1)
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 " + l.PlayerName + "^7 is already a Mafia!", MSO.UCID, 0);
                            }
                        }
                    }
                    #endregion

                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized User!", MSO.UCID, 0);
                    MsgAll("^1*^3 " + Conn.PlayerName + "^7 tried to use AddMafia Command!");
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }

        }
        [Command("remmafia", "remmafia <username>")]
        public void remmafia(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                if (Conn.IsMember == 1 || Conn.IsAdmin == 1)
                {
                    bool Found = false;
                    string Username = Msg.Remove(0, 10);

                    #region ' Online Removing '

                    foreach (clsConnection l in Connections)
                    {
                        if (l.Username == Username)
                        {
                            Found = true;
                            if (l.CanBeMafia == 1)
                            {
                                l.CanBeMafia = 0;
                                MsgAll("^1*^3 " + l.PlayerName + "^1*^3  is now removed as Mafia!");
                                if (System.IO.File.Exists(UserInfo + "\\ChatLog\\ModeratorCommandsChatlog.txt") == true)
                                {
                                    StreamReader ApR = new StreamReader("users/ChatLog/ModeratorCommandsChatlog.txt");
                                    string TempAPR = ApR.ReadToEnd();
                                    ApR.Close();
                                    StreamWriter Ap = new StreamWriter("users/ChatLog/ModeratorCommandsChatlog.txt");
                                    Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !remmafia " + l.Username);
                                    Ap.Flush();
                                    Ap.Close();
                                }
                            }
                            else
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 " + l.PlayerName + "^1*^3  is not a Mafia", MSO.UCID, 0);
                            }
                        }

                    }

                    #endregion

                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1Not Authorized User!", MSO.UCID, 0);
                    MsgAll("^1*^3 " + Conn.PlayerName + "^1*^3  tried to use Remove TowTruck Command!");
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^1*^3 for help.", MSO.UCID, 0);
            }
        }
        [Command("addtow", "addtow <username>")]
        public void addtow(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                if (Conn.IsMember == 1 || Conn.IsAdmin == 1)
                {
                    //bool Found = false;
                    string Username = Msg.Remove(0, 8);

                    #region ' Online Adding '

                    foreach (clsConnection l in Connections)
                    {
                        if (l.Username == Username)
                        {
                            //Found = true;
                            if (l.CanBeTow == 0)
                            {
                                l.CanBeTow = 1;
                                MsgAll("^3****Promotion****");
                                MsgAll("^7" + l.PlayerName + "^7 can be now a TowTruck!");
                                MsgAll("^7Done by: " + Conn.PlayerName);
                                InSim.Send_MTC_MessageToConnection("^1*^3 To get in duty use the ^3[TOW]^7NAME to get duty!", l.UniqueID, 0);
                                if (System.IO.File.Exists(UserInfo + "\\ChatLog\\ModeratorCommandsChatlog.txt") == true)
                                {
                                    StreamReader ApR = new StreamReader("users/ChatLog/ModeratorCommandsChatlog.txt");
                                    string TempAPR = ApR.ReadToEnd();
                                    ApR.Close();
                                    StreamWriter Ap = new StreamWriter("users/ChatLog/ModeratorCommandsChatlog.txt");
                                    Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !addtow " + l.Username);
                                    Ap.Flush();
                                    Ap.Close();
                                }
                            }
                            else
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 " + l.PlayerName + "^7 is already a Tow Truck", MSO.UCID, 0);
                            }
                        }
                    }

                    #endregion

                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized User!", MSO.UCID, 0);
                    MsgAll("^1*^3 " + Conn.PlayerName + "^7 tried to use Add TowTruck Command!");
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }

        }
        [Command("remtow", "remtow <username>")]
        public void remtow(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                if (Conn.IsMember == 1 || Conn.IsAdmin == 1)
                {
                    // bool Found = false;
                    string Username = Msg.Remove(0, 8);

                    #region ' Online Removing '

                    foreach (clsConnection l in Connections)
                    {
                        if (l.Username == Username)
                        {
                            //Found = true;
                            var TowCon = Connections[GetConnIdx(Connections[GetConnIdx(l.UniqueID)].Towee)];
                            if (l.IsTowTruck == 1)
                            {
                                if (l.TowStart == 1)
                                {

                                    l.Towee = -1;
                                    l.TowStart = 0;
                                    l.TowSiren = 0;
                                }

                                l.IsTowTruck = 0;
                                MsgAll("^1*^3 " + l.PlayerName + "^7 was forced ^1OFF-DUTY ^7as TowTruck!");
                                if (l.CanBeTow == 1)
                                {
                                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\ModeratorCommandsChatlog.txt") == true)
                                    {
                                        StreamReader ApR = new StreamReader("users/ChatLog/ModeratorCommandsChatlog.txt");
                                        string TempAPR = ApR.ReadToEnd();
                                        ApR.Close();
                                        StreamWriter Ap = new StreamWriter("users/ChatLog/ModeratorCommandsChatlog.txt");
                                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !remtow " + l.Username);
                                        Ap.Flush();
                                        Ap.Close();
                                    }
                                    l.CanBeTow = 0;
                                    MsgAll("^1*^3 " + l.PlayerName + "^7 is now removed as Tow Truck!");
                                }
                            }
                            else
                            {
                                if (l.CanBeTow == 1)
                                {
                                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\ModeratorCommandsChatlog.txt") == true)
                                    {
                                        StreamReader ApR = new StreamReader("users/ChatLog/ModeratorCommandsChatlog.txt");
                                        string TempAPR = ApR.ReadToEnd();
                                        ApR.Close();
                                        StreamWriter Ap = new StreamWriter("users/ChatLog/ModeratorCommandsChatlog.txt");
                                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !remtow " + l.Username);
                                        Ap.Flush();
                                        Ap.Close();
                                    }
                                    l.CanBeTow = 0;
                                    MsgAll("^1*^3 " + l.PlayerName + "^7 is now removed as Tow Truck!");
                                }
                                else
                                {
                                    InSim.Send_MTC_MessageToConnection("^1*^3 " + l.PlayerName + "^7 is not a Tow Truck", MSO.UCID, 0);
                                }
                            }
                        }
                    }

                    #endregion

                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^7Not Authorized User!", MSO.UCID, 0);
                    MsgAll("^1*^3 " + Conn.PlayerName + "^7 tried to use Remove TowTruck Command!");
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }

        }
        [Command("tow", "tow <username>")]
        public void pitlane(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            clsConnection Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                if (Conn.IsMember == 1 || Conn.IsAdmin == 1)
                {
                    bool ModUserFound = false;
                    foreach (clsConnection C in Connections)
                    {
                        if (C.Username == Msg.Remove(0, 5))
                        {
                            ModUserFound = true;
                            InSim.Send_MTC_MessageToConnection("^1*^3 Username found:", MSO.UCID, 0);
                            InSim.Send_MTC_MessageToConnection("^1*^3 Starting to pitlane: " + C.PlayerName, MSO.UCID, 0);
                            InSim.Send_MTC_MessageToConnection("^7You will be towed to pitlane", C.UniqueID, 0);
                            InSim.Send_MTC_MessageToConnection("^7Done by: " + Conn.PlayerName, C.UniqueID, 0);
                            InSim.Send_MST_Message("/pitlane " + C.Username);
                            if (System.IO.File.Exists(UserInfo + "\\ChatLog\\ModeratorCommandsChatlog.txt") == true)
                            {
                                StreamReader ApR = new StreamReader("users/ChatLog/ModeratorCommandsChatlog.txt");
                                string TempAPR = ApR.ReadToEnd();
                                ApR.Close();
                                StreamWriter Ap = new StreamWriter("users/ChatLog/ModeratorCommandsChatlog.txt");
                                Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !tow " + C.Username);
                                Ap.Flush();
                                Ap.Close();
                            }
                        }
                    }
                    if (ModUserFound == false)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Username is not Found", MSO.UCID, 0);
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized for Moderation!", MSO.UCID, 0);
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }

        }
        [Command("spectate", "spectate <username>")]
        public void spectate(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            clsConnection Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 1)
            {
                if (Conn.IsMember == 1 || Conn.IsAdmin == 1)
                {
                    bool ModUserFound = false;
                    foreach (clsConnection C in Connections)
                    {
                        if (C.Username == Msg.Remove(0, 5))
                        {
                            ModUserFound = true;
                            InSim.Send_MTC_MessageToConnection("^1*^3 Username found:", MSO.UCID, 0);
                            InSim.Send_MTC_MessageToConnection("^1*^3 Starting to Spectate: " + C.PlayerName, MSO.UCID, 0);
                            InSim.Send_MTC_MessageToConnection("^7You will be Spectated", C.UniqueID, 0);
                            InSim.Send_MTC_MessageToConnection("^7Done by: " + Conn.PlayerName, C.UniqueID, 0);
                            InSim.Send_MST_Message("/spec " + C.Username);
                            if (System.IO.File.Exists(UserInfo + "\\ChatLog\\ModeratorCommandsChatlog.txt") == true)
                            {
                                StreamReader ApR = new StreamReader("users/ChatLog/ModeratorCommandsChatlog.txt");
                                string TempAPR = ApR.ReadToEnd();
                                ApR.Close();
                                StreamWriter Ap = new StreamWriter("users/ChatLog/ModeratorCommandsChatlog.txt");
                                Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !tow " + C.Username);
                                Ap.Flush();
                                Ap.Close();
                            }
                        }
                    }
                    if (ModUserFound == false)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Username is not Found", MSO.UCID, 0);
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized for Moderation!", MSO.UCID, 0);
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }

        }
        [Command("mc", "mc")]
        public void memberchat(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (Conn.IsMember == 1 || Conn.IsAdmin == 1)
            {
                if (StrMsg.Length > 1)
                {
                    string MsgCC = Msg.Remove(0, 4);
                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\ModeratorChatlog - Rename to Date.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/ChatLog/ModeratorChatlog - Rename to Date.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/ChatLog/ModeratorChatlog - Rename to Date.txt");
                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - Message by " + Conn.PlayerName + " (" + Conn.Username + "): " + MsgCC);
                        Ap.Flush();
                        Ap.Close();
                    }
                    else
                    {
                        MessageBox.Show("ModeratorChatlog - Rename to Date.txt missing!");
                    }
                    foreach (clsConnection u in Connections)
                    {
                        if (u.IsMember == 1 || u.IsAdmin == 1)
                        {
                            InSim.Send_MTC_MessageToConnection("^5Moderator Chat: " + Conn.PlayerName + " ^7(" + Conn.Username + ")", u.UniqueID, 0);
                            InSim.Send_MTC_MessageToConnection("^6Msg: " + MsgCC, u.UniqueID, 0);
                        }
                    }

                }
                else
                {
                    if (StrMsg.Length == 1)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Using moderator chat ^2!mc <message>", MSO.UCID, 0);
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
                    }
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }

        }
        [Command("checkusers", "checkusers")]
        public void checkusers(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length == 1 && Conn.IsMember == 1 || Conn.IsAdmin == 1)
            {
                if (System.IO.File.Exists(UserInfo + "\\ChatLog\\ModeratorCommandsChatlog.txt") == true)
                {
                    StreamReader ApR = new StreamReader("users/ChatLog/ModeratorCommandsChatlog.txt");
                    string TempAPR = ApR.ReadToEnd();
                    ApR.Close();
                    StreamWriter Ap = new StreamWriter("users/ChatLog/ModeratorCommandsChatlog.txt");
                    Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !checkusers");
                    Ap.Flush();
                    Ap.Close();
                }
                else
                {
                    MessageBox.Show("ModeratorCommandsChatlog.txt missing!");
                }
                InSim.Send_BTN_CreateButton("^1CLOSE [X]", Flags.ButtonStyles.ISB_LEFT | Flags.ButtonStyles.ISB_DARK | Flags.ButtonStyles.ISB_CLICK, 6, 13, 25, 170, 139, MSO.UCID, 40, false);
                InSim.Send_BTN_CreateButton("^7NAME", Flags.ButtonStyles.ISB_LEFT | Flags.ButtonStyles.ISB_DARK, 6, 31, 25, 15, 131, MSO.UCID, 40, false);
                InSim.Send_BTN_CreateButton("^7CASH", Flags.ButtonStyles.ISB_LEFT | Flags.ButtonStyles.ISB_DARK, 6, 13, 25, 46, 132, MSO.UCID, 40, false);
                InSim.Send_BTN_CreateButton("^7DISTANCE", Flags.ButtonStyles.ISB_LEFT | Flags.ButtonStyles.ISB_DARK, 6, 13, 25, 59, 133, MSO.UCID, 40, false);
                InSim.Send_BTN_CreateButton("^7CARS", Flags.ButtonStyles.ISB_LEFT | Flags.ButtonStyles.ISB_DARK, 6, 85, 25, 72, 134, MSO.UCID, 40, false);
                InSim.Send_BTN_CreateButton("^7STATS", Flags.ButtonStyles.ISB_LEFT | Flags.ButtonStyles.ISB_DARK, 6, 73, 25, 155, 135, MSO.UCID, 40, false);

                byte LocationX = 31;
                byte ButtonID1 = 10;
                byte ButtonID2 = 42;
                byte ButtonID3 = 74;
                byte ButtonID4 = 106;
                byte ButtonID5 = 180;
                foreach (clsConnection c in Connections)
                {
                    if (c.Username != "")
                    {


                        InSim.Send_BTN_CreateButton("^7", Flags.ButtonStyles.ISB_LEFT | Flags.ButtonStyles.ISB_DARK | Flags.ButtonStyles.ISB_CLICK, 5, 20, 31, 15, 1, MSO.UCID, 40, false);
                        InSim.Send_BTN_CreateButton(c.PlayerName + "^7 (" + c.Username + ")", Flags.ButtonStyles.ISB_LEFT, 5, 31, LocationX, 15, ButtonID1, MSO.UCID, 40, false);
                        InSim.Send_BTN_CreateButton("^2€^7 " + string.Format("{0:n0}", c.Cash), Flags.ButtonStyles.ISB_LEFT, 5, 13, LocationX, 46, ButtonID2, (MSO.UCID), 40, false);
                        InSim.Send_BTN_CreateButton("^7" + c.Cars, Flags.ButtonStyles.ISB_LEFT, 5, 86, LocationX, 72, ButtonID3, (MSO.UCID), 40, false);
                        //InSim.Send_BTN_CreateButton("" + Stats, Flags.ButtonStyles.ISB_LEFT, 5, 86, LocationX, 155, ButtonID5, (MSO.UCID), 40, false);
                        InSim.Send_BTN_CreateButton("^7" + string.Format("{0:#,##0.0}", c.TotalDistance), Flags.ButtonStyles.ISB_LEFT, 5, 13, LocationX, 59, ButtonID4, (MSO.UCID), 40, false);


                        LocationX += 5;
                        ButtonID1++;
                        ButtonID2++;
                        ButtonID3++;
                        ButtonID4++;
                        ButtonID5++;
                    }
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^7Invalid command. Please see ^2!help^7 for a command list", MSO.UCID, 0);
            }
        }
        [Command("ann", "ann <text>")]
        public void announce(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (Conn.IsMember == 1 || Conn.IsAdmin == 1)
            {
                if (StrMsg.Length > 1)
                {
                    string text = Msg.Remove(0, 5);
                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\ModeratorCommandsChatlog.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/ChatLog/ModeratorCommandsChatlog.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/ChatLog/ModeratorCommandsChatlog.txt");
                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - " + Conn.PlayerName + " (" + Conn.Username + "): !ann " + text);
                        Ap.Flush();
                        Ap.Close();
                    }
                    else
                    {
                        MessageBox.Show("ModeratorCommandsChatlog.txt missing!");
                    }

                    if (Conn.IsMember == 1 || Conn.IsAdmin == 1)
                    {
                        InSim.Send_MST_Message("/rcm " + text);
                        InSim.Send_MST_Message("/msg ^7Announce: " + text);
                        InSim.Send_MST_Message("/rcm_all");
                        Conn.AnnounceTimer = 5;
                        Conn.Announce = 1;
                    }
                }
                else
                {
                    if (StrMsg.Length == 1)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Using announce ^2!ann <text>", MSO.UCID, 0);
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
                    }
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }
        }
        #endregion

        #region ' TowTruck Commands '

        [Command("ontow", "ontow")]
        public void ontow(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            clsConnection Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 0)
            {
                if (Conn.CanBeTow == 1)
                {
                    if (Conn.IsOfficer == 1 || Conn.IsCadet == 1)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 You are ^2ON-DUTY ^7as Police!", MSO.UCID, 0);
                    }
                    else if (Conn.IsMafia == 1)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 You are ^2ON-DUTY ^7as Mafia!", MSO.UCID, 0);
                    }
                    else if (Conn.JobToHouse1 == 1 || Conn.JobToHouse2 == 1 || Conn.JobToHouse3 == 1 || Conn.JobToHouse4 == 1 || Conn.JobToHouse5 == 1 || Conn.JobToSchool == 1)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Finish the Job before you can ^2ONDUTY^7!", Conn.UniqueID, 0);
                    }
                    else
                    {
                        if (Conn.PlayerName.Contains("^0Tow^0•^3"))
                        {
                            if (Conn.Plate == "TOW")
                            {
                                if (Conn.IsTowTruck == 0)
                                {
                                    MsgAll("^1*^3 " + Conn.PlayerName + " ^7is now ^2ON-DUTY ^7as TowTruck!");
                                    Conn.IsTowTruck = 1;
                                }
                                else
                                {
                                    InSim.Send_MTC_MessageToConnection("^1*^3 You are already ^2ON-DUTY ^7as TowTruck!", MSO.UCID, 0);
                                }
                            }
                            else
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 Use TOW Plate Number!", MSO.UCID, 0);
                            }
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Use TowTruck Tag ^^0Tow^0•^3NAME", MSO.UCID, 0);
                        }
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized!", MSO.UCID, 0);
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
        }

        [Command("offtow", "offtow")]
        public void offtow(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            clsConnection Conn = Connections[GetConnIdx(MSO.UCID)];
            clsConnection Conn2 = Connections[GetConnIdx(Connections[GetConnIdx(MSO.UCID)].Towee)];
            if (StrMsg.Length > 0)
            {
                if (Conn.CanBeTow == 1)
                {
                    if (Conn2.IsBeingTowed == 1)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 You are Towing " + Conn2.PlayerName, MSO.UCID, 0);
                    }
                    else
                    {
                        if (Conn.IsTowTruck == 0)
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 You are already ^1OFF-DUTY ^7as TowTruck!", MSO.UCID, 0);

                        }
                        else
                        {
                            MsgAll("^1*^3 " + Conn.PlayerName + " ^7is now ^1OFF-DUTY ^7as TowTruck!");
                            Conn.IsTowTruck = 0;
                            if (Conn.OndutyBox == 1)
                            {
                                InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 16, Conn.UniqueID);
                                InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 17, Conn.UniqueID);
                                InSim.Send_BFN_DeleteButton(Enums.BtnFunc.BFN_DEL_BTN, 18, Conn.UniqueID);
                            }
                        }
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized!", MSO.UCID, 0);
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
        }

        [Command("respond", "respond")]
        public void accepttow(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            clsConnection Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 0)
            {
                if (Conn.CanBeTow == 1)
                {
                    if (Conn.IsTowTruck == 1)
                    {
                        foreach (clsConnection C in Connections)
                        {
                            if (C.calltow == 1)
                            {
                                if (C.Username == Conn.TowRUsername)
                                {
                                    InSim.Send_MTC_MessageToConnection("^1*^3 You have accepted the Request of " + C.PlayerName, MSO.UCID, 0);
                                    InSim.Send_MTC_MessageToConnection("^1*^3 " + Conn.PlayerName + " ^7accepted your Request!", C.UniqueID, 0);
                                    C.AcceptTowRUser = Conn.TowRUsername;
                                    Conn.calltow = 0;
                                    Conn.TowRespond = 1;
                                }
                            }
                            else
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 No open requests", MSO.UCID, 0);
                            }
                        }
                    }
                    else if (Conn.CanBeTow == 1 && Conn.IsTowTruck == 0)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 You must be Online as TowTruck to Access this Command!", MSO.UCID, 0);
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized!", MSO.UCID, 0);
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
        }

        [Command("calltow", "calltow")]
        public void calltow(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            clsConnection Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 0)
            {

                InSim.Send_BTN_CreateButton("" + ServerName + " ^6Tow ^3Request ^1Menu", Flags.ButtonStyles.ISB_DARK, 7, 78, 51, 59, 172, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);
                InSim.Send_BTN_CreateButton("", Flags.ButtonStyles.ISB_LIGHT, 30, 80, 50, 58, 170, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);
                InSim.Send_BTN_CreateButton("", Flags.ButtonStyles.ISB_DARK, 27, 78, 51, 59, 171, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);
                InSim.Send_BTN_CreateButton("^1^J‚w", Flags.ButtonStyles.ISB_C1 | Flags.ButtonStyles.ISB_CLICK, 4, 6, 53, 130, 173, Connections[GetConnIdx(MSO.UCID)].UniqueID, 2, false);
                InSim.Send_BTN_CreateButton("^1 Heavy Crash", Flags.ButtonStyles.ISB_CLICK | Flags.ButtonStyles.ISB_DARK, 5, 20, 59, 67, 127, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);
                InSim.Send_BTN_CreateButton("^1Out of Fuel", Flags.ButtonStyles.ISB_DARK | Flags.ButtonStyles.ISB_CLICK, 5, 20, 59, 87, 128, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);
                InSim.Send_BTN_CreateButton("^1Clutch", Flags.ButtonStyles.ISB_DARK | Flags.ButtonStyles.ISB_CLICK, 5, 20, 59, 107, 129, (Connections[GetConnIdx(MSO.UCID)].UniqueID), 2, false);

            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
        }

        [Command("starttow", "starttow")]
        public void starttow(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            clsConnection Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 0)
            {
                if (Conn.CanBeTow == 1)
                {
                    if (Conn.IsTowTruck == 1)
                    {
                        foreach (clsConnection C in Connections)
                        {
                            if (C.Username == Conn.TowRUsername)
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 You are now towing " + C.PlayerName, MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 " + Conn.PlayerName + " ^1*^3 Started towing you", C.UniqueID, 0);
                                Conn.TowStart = 1;
                                Conn.TowRespond = 0;
                                C.IsBeingTowed = 1;
                            }
                        }
                    }
                    else if (Conn.CanBeTow == 1 && Conn.IsTowTruck == 0)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 You must be Online as TowTruck to Access this Command!", MSO.UCID, 0);
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized!", MSO.UCID, 0);
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
        }

        [Command("endtow", "endtow")]
        public void stoptow(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            clsConnection Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 0)
            {
                if (Conn.CanBeTow == 1)
                {
                    if (Conn.IsTowTruck == 1)
                    {
                        foreach (clsConnection C in Connections)
                        {
                            if (C.Username == Conn.TowRUsername)
                            {
                                InSim.Send_MTC_MessageToConnection("^1*^3 You have stopped towing " + C.PlayerName, MSO.UCID, 0);
                                InSim.Send_MTC_MessageToConnection("^1*^3 " + Conn.PlayerName + " ^1*^3 has stopped towing you", C.UniqueID, 0);
                                Conn.TowStart = 0;
                                C.IsBeingTowed = 0;
                                Conn.AcceptTowRUser = "";
                            }
                        }
                    }
                    else if (Conn.CanBeTow == 1 && Conn.IsTowTruck == 0)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 You must be Online as TowTruck to Access this Command!", MSO.UCID, 0);
                    }
                }
                else
                {
                    InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized!", MSO.UCID, 0);
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
        }

        #endregion

        #region ' Mafia Commands '
        [Command("dlaser", "dlaser")]
        public void Dlaser(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            clsConnection Conn = Connections[GetConnIdx(MSO.UCID)];
            if (StrMsg.Length > 0)
            {
                if (Conn.IsMafia == 1)
                {
                    if (Conn.DLaser == 0)
                    {
                        if (Conn.Spectators == 1)
                        {
                            for (byte o = 0; o < Connections.Count; o++)
                            {
                                if (Connections[o].PlayerID != 0)
                                {
                                    if (Connections[o].IsMafia == 0)
                                    {
                                        CopDistance = ((int)Math.Sqrt(Math.Pow(Connections[o].CompCar.X - Conn.CompCar.X, 2) + Math.Pow(Connections[o].CompCar.Y - Conn.CompCar.Y, 2)) / 65536);
                                        if (CopDistance < 250)
                                        {
                                            if (Connections[o].IsOfficer == 1 || Connections[o].IsCadet == 1)
                                            {
                                                InSim.Send_MTC_MessageToConnection("^1*^3 You disabled the laser of " + Connections[o].PlayerName, MSO.UCID, 0);
                                                InSim.Send_MTC_MessageToConnection("^1*^3 Laser countdown: 5 minutes", MSO.UCID, 0);
                                                InSim.Send_MTC_MessageToConnection("^1Error, losing energy for Laser...", Connections[o].UniqueID, 0);
                                                Conn.DLaser = 1;
                                            }
                                        }
                                        else
                                        {
                                            InSim.Send_MTC_MessageToConnection("^1*^3 No cops found in 250 Meters", MSO.UCID, 0);
                                        }

                                    }
                                }
                            }
                        }
                        else
                        {
                            InSim.Send_MTC_MessageToConnection("^1*^3 Can't Detect any cops at Spectators!", MSO.UCID, 0);
                        }
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1Laser Countdown", MSO.UCID, 0);
                    }
                }
                else
                {
                    if (Connections[GetConnIdx(MSO.UCID)].CanBeMafia == 1)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 You must be ^2!onduty ^7or switch name to selected Rank.", MSO.UCID, 0);
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Not Authorized", MSO.UCID, 0);
                    }
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3* Command Unknown, Use ^7!help/!cmds ^3for more information", MSO.UCID, 0);
            }
        }
        [Command("mfc", "mfc <message>")]
        public void mafiachat(string Msg, string[] StrMsg, Packets.IS_MSO MSO)
        {
            var Conn = Connections[GetConnIdx(MSO.UCID)];
            if (Conn.IsMafia == 1)
            {
                if (StrMsg.Length > 1)
                {
                    string MsgCC = Msg.Remove(0, 4);
                    if (System.IO.File.Exists(UserInfo + "\\ChatLog\\MafiaChatlog - Rename to Date.txt") == true)
                    {
                        StreamReader ApR = new StreamReader("users/ChatLog/MafiaChatlog - Rename to Date.txt");
                        string TempAPR = ApR.ReadToEnd();
                        ApR.Close();
                        StreamWriter Ap = new StreamWriter("users/ChatLog/MafiaChatlog - Rename to Date.txt");
                        Ap.WriteLine(TempAPR + System.DateTime.UtcNow + " UTC - Message by " + Conn.PlayerName + " (" + Conn.Username + "): " + MsgCC);
                        Ap.Flush();
                        Ap.Close();
                    }
                    else
                    {
                        MessageBox.Show("CopChatlog - Rename to Date.txt missing!");
                    }
                    foreach (clsConnection u in Connections)
                    {
                        if (u.IsMafia == 1 || u.IsMafia == 1)
                        {
                            InSim.Send_MTC_MessageToConnection("^5Mafia Chat: " + Conn.PlayerName + " ^7(" + Conn.Username + ")", u.UniqueID, 0);
                            InSim.Send_MTC_MessageToConnection("^6Msg: " + MsgCC, u.UniqueID, 0);
                        }
                    }

                }
                else
                {
                    if (StrMsg.Length == 1)
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Using Mafia chat ^2!mfc <message>", MSO.UCID, 0);
                    }
                    else
                    {
                        InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
                    }
                }
            }
            else
            {
                InSim.Send_MTC_MessageToConnection("^1*^3 Invalid Command. ^2!help ^7for help.", MSO.UCID, 0);
            }

        }
        #endregion

    }
}
