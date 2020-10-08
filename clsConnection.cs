using System;
using System.Collections;
using System.Collections.Generic;
using LFS_External;
using LFS_External.InSim;

namespace LFS_External_Client
{
    public class StatsAttribute : Attribute
    {
        private string _name = "";
        private bool _update = true;
        public StatsAttribute(string name)
        {
            _name = name;
            _update = true;
        }
        public StatsAttribute(string name, bool update)
        {
            _name = name;
            _update = update;
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public bool Update
        {
            get
            {
                return Update;
            }
            set
            {
                Update = value;
            }
        }
    }

    public class clsConnection
    {

        #region dbCompatibleStats
        protected bool _statsloadedsuccessfully = false;
        /// <summary>
        /// STATS LOAD OK
        /// </summary>
        public bool statsLoadedSuccessfully
        {
            get { return _statsloadedsuccessfully; }
            set { _statsloadedsuccessfully = value; }
        }

        protected int _personalid = 0;
        /// <summary>
        /// id
        /// </summary>
        public int personalId
        {
            get { return _personalid; }
            set { _personalid = value; }
        }

        protected string _accpass = "undefined";
        /// <summary>
        /// acc_pass
        /// </summary>
        public string accPass
        {
            get { return _accpass; }
            set { _accpass = value; }
        }

        protected string _accmasterpass = "undefined";
        /// <summary>
        /// acc_masterpass
        /// </summary>
        public string accMasterPass
        {
            get { return _accmasterpass; }
            set { _accmasterpass = value; }
        }

        protected string _accloggedtill = "0";
        /// <summary>
        /// acc_loggedtill
        /// </summary>
        public string accLoggedTill
        {
            get { return _accloggedtill; }
            set { _accloggedtill = value; }
        }

        protected int _teamid = 0;
        /// <summary>
        /// team_id
        /// </summary>
        public int teamId
        {
            get { return _teamid; }
            set { _teamid = value; }
        }

        protected string _teamname = "_undetected";
        /// <summary>
        /// ----
        /// </summary>
        public string teamName
        {
            get { return _teamname; }
            set { _teamname = value; }
        }

        protected int _teamnumber = 0;
        /// <summary>
        /// team_numb
        /// </summary>
        public int teamNumber
        {
            get { return _teamnumber; }
            set { _teamnumber = value; }
        }

        protected string _teamrank = "_undetected";
        /// <summary>
        /// team_rank
        /// </summary>
        public string teamRank
        {
            get { return _teamrank; }
            set { _teamrank = value; }
        }

        protected bool _teamrankcustom = false;
        /// <summary>
        /// team_rank_custom
        /// </summary>
        public bool teamRankCustom
        {
            get { return _teamrankcustom; }
            set { _teamrankcustom = value; }
        }

        protected string _teamrights = "0";
        /// <summary>
        /// team_rights
        /// </summary>
        public string teamRights
        {
            get { return _teamrights; }
            set { _teamrights = value; }
        }

        protected int _countryid = 0;
        /// <summary>
        /// country_id
        /// </summary>
        public int countryId
        {
            get { return _countryid; }
            set { _countryid = value; }
        }

        protected string _name = "_undetected";
        /// <summary>
        /// name
        /// </summary>
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        protected string _gender = "_undetected";
        /// <summary>
        /// gender
        /// </summary>
        public string gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        protected string _birthdate = "_undetected";
        /// <summary>
        /// birth_date
        /// </summary>
        public string birthDate
        {
            get { return _birthdate; }
            set { _birthdate = value; }
        }

        protected string _email = "_undetected";
        /// <summary>
        /// email
        /// </summary>
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        protected bool _emailhide = true;
        /// <summary>
        /// email_hide
        /// </summary>
        public bool emailHide
        {
            get { return _emailhide; }
            set { _emailhide = value; }
        }

        protected string _rank = "_undetected";
        /// <summary>
        /// rank
        /// </summary>
        public string rank
        {
            get { return _rank; }
            set { _rank = value; }
        }

        protected bool _rankcustom = false;
        /// <summary>
        /// rank_custom
        /// </summary>
        public bool rankCustom
        {
            get { return _rankcustom; }
            set { _rankcustom = value; }
        }

        protected string _rights = "0";
        /// <summary>
        /// rights
        /// </summary>
        public string rights
        {
            get { return _rights; }
            set { _rights = value; }
        }

        protected int _maxwinsinarow = 0;
        /// <summary>
        /// max_wins_row
        /// </summary>
        public int maxWinsInARow
        {
            get { return _maxwinsinarow; }
            set { _maxwinsinarow = value; }
        }

        protected int _pointsbronze = 0;
        /// <summary>
        /// points_bronze
        /// </summary>
        public int pointsBronze
        {
            get { return _pointsbronze; }
            set { _pointsbronze = value; }
        }

        protected int _pointssilver = 0;
        /// <summary>
        /// points_silver
        /// </summary>
        public int pointsSilver
        {
            get { return _pointssilver; }
            set { _pointssilver = value; }
        }

        protected int _pointsgold = 0;
        /// <summary>
        /// points_gold
        /// </summary>
        public int pointsGold
        {
            get { return _pointsgold; }
            set { _pointsgold = value; }
        }

        protected int _pointsplatinum = 0;
        /// <summary>
        /// points_platinum
        /// </summary>
        public int pointsPlatinum
        {
            get { return _pointsplatinum; }
            set { _pointsplatinum = value; }
        }

        protected int _pointsglobal = 0;
        /// <summary>
        /// points_global
        /// </summary>
        public int pointsGlobal
        {
            get { return _pointsglobal; }
            set { _pointsglobal = value; }
        }

        protected int _racessum = 0;
        /// <summary>
        /// races_sum
        /// </summary>
        public int racesSum
        {
            get { return _racessum; }
            set { _racessum = value; }
        }

        protected int _raceswon = 0;
        /// <summary>
        /// races_won
        /// </summary>
        public int racesWon
        {
            get { return _raceswon; }
            set { _raceswon = value; }
        }

        protected int _racesSecond = 0;
        /// <summary>
        /// races_2nd
        /// </summary>
        public int racesSecond
        {
            get { return _racesSecond; }
            set { _racesSecond = value; }
        }

        protected int _racesthird = 0;
        /// <summary>
        /// races_3rd
        /// </summary>
        public int racesThird
        {
            get { return _racesthird; }
            set { _racesthird = value; }
        }

        protected int _racesunfinished = 0;
        /// <summary>
        /// races_unfin
        /// </summary>
        public int racesUnfinished
        {
            get { return _racesunfinished; }
            set { _racesunfinished = value; }
        }

        protected int _lapssum = 0;
        /// <summary>
        /// laps_sum
        /// </summary>
        public int lapsSum
        {
            get { return _lapssum; }
            set { _lapssum = value; }
        }

        protected int _lapsfastest = 0;
        /// <summary>
        /// laps_fastest
        /// </summary>
        public int lapsFastest
        {
            get { return _lapsfastest; }
            set { _lapsfastest = value; }
        }

        protected int _pitlaneentersum = 0;
        /// <summary>
        /// pitlane_enter_sum
        /// </summary>
        public int pitlaneEnterSum
        {
            get { return _pitlaneentersum; }
            set { _pitlaneentersum = value; }
        }

        protected int _pitlanedtsum = 0;
        /// <summary>
        /// pitlane_dt_sum
        /// </summary>
        public int pitlaneDtSum
        {
            get { return _pitlanedtsum; }
            set { _pitlanedtsum = value; }
        }

        protected int _pitlanesgsum = 0;
        /// <summary>
        /// pitlane_sg_sum
        /// </summary>
        public int pitlaneSgSum
        {
            get { return _pitlanesgsum; }
            set { _pitlanesgsum = value; }
        }

        protected int _pitlanenopurposesum = 0;
        /// <summary>
        /// pitlane_nopurp_sum
        /// </summary>
        public int pitlaneNoPurposeSum
        {
            get { return _pitlanenopurposesum; }
            set { _pitlanenopurposesum = value; }
        }

        protected int _pitlanenumsum = 0;
        /// <summary>
        /// pitlane_num_sum
        /// </summary>
        public int pitlaneNumSum
        {
            get { return _pitlanenumsum; }
            set { _pitlanenumsum = value; }
        }

        protected int _pitstopssum = 0;
        /// <summary>
        /// pitstops_sum
        /// </summary>
        public int pitstopsSum
        {
            get { return _pitstopssum; }
            set { _pitstopssum = value; }
        }

        protected int _specsum = 0;
        /// <summary>
        /// spec_sum
        /// </summary>
        public int specSum
        {
            get { return _specsum; }
            set { _specsum = value; }
        }

        protected int _pensum = 0;
        /// <summary>
        /// pen_sum
        /// </summary>
        public int penSum
        {
            get { return _pitlanenumsum; }
            set { _pitlanenumsum = value; }
        }

        protected int _penfromblanksum = 0;
        /// <summary>
        /// pen_from0_sum
        /// </summary>
        public int penFromBlankSum
        {
            get { return _penfromblanksum; }
            set { _penfromblanksum = value; }
        }

        protected int _penfromadminsum = 0;
        /// <summary>
        /// pen_admin_sum
        /// </summary>
        public int penFromAdminSum
        {
            get { return _penfromadminsum; }
            set { _penfromadminsum = value; }
        }

        protected int _penfromadminfromblanksum = 0;
        /// <summary>
        /// pen_admin_from0_sum
        /// </summary>
        public int penFromAdminFromBlankSum
        {
            get { return _penfromadminfromblanksum; }
            set { _penfromadminfromblanksum = value; }
        }

        protected int _penfalsestartsum = 0;
        /// <summary>
        /// pen_fstart_sum
        /// </summary>
        public int penFalseStartSum
        {
            get { return _penfalsestartsum; }
            set { _penfalsestartsum = value; }
        }

        protected int _penfalsestartfromblanksum = 0;
        /// <summary>
        /// pen_fstart_from0_sum
        /// </summary>
        public int penFalseStartFromBlankSum
        {
            get { return _penfalsestartfromblanksum; }
            set { _penfalsestartfromblanksum = value; }
        }

        protected int _penspeedingsum = 0;
        /// <summary>
        /// pen_speeding_sum
        /// </summary>
        public int penSpeedingSum
        {
            get { return _penspeedingsum; }
            set { _penspeedingsum = value; }
        }

        protected int _penspeedingfromblanksum = 0;
        /// <summary>
        /// pen_speeding_from0_sum
        /// </summary>
        public int penSpeedingFromBlankSum
        {
            get { return _penspeedingfromblanksum; }
            set { _penspeedingfromblanksum = value; }
        }

        protected int _penpitstoptoolatesum = 0;
        /// <summary>
        /// pen_stoplate_sum
        /// </summary>
        public int penPitStopTooLateSum
        {
            get { return _penpitstoptoolatesum; }
            set { _penpitstoptoolatesum = value; }
        }

        protected int _penpitstoptoolatefromblanksum = 0;
        /// <summary>
        /// pen_stoplate_from0_sum
        /// </summary>
        public int penPitStopTooLateFromBlankSum
        {
            get { return _penpitstoptoolatefromblanksum; }
            set { _penpitstoptoolatefromblanksum = value; }
        }

        protected int _penpitstoptooshortsum = 0;
        /// <summary>
        /// pen_stopshort_sum
        /// </summary>
        public int penPitStopTooShortSum
        {
            get { return _penpitstoptooshortsum; }
            set { _penpitstoptooshortsum = value; }
        }

        protected int _penpitstoptooshortfromblanksum = 0;
        /// <summary>
        /// pen_stopshort_from0_sum
        /// </summary>
        public int penPitStopTooShortFromBlankSum
        {
            get { return _penpitstoptooshortfromblanksum; }
            set { _penpitstoptooshortfromblanksum = value; }
        }

        protected int _penwrongwaysum = 0;
        /// <summary>
        /// pen_wway_sum
        /// </summary>
        public int penWrongWaySum
        {
            get { return _penwrongwaysum; }
            set { _penwrongwaysum = value; }
        }

        protected int _penwrongwayfromblanksum = 0;
        /// <summary>
        /// pen_wway_from0_sum
        /// </summary>
        public int penWrongWayFromBlankSum
        {
            get { return _penwrongwayfromblanksum; }
            set { _penwrongwayfromblanksum = value; }
        }

        protected int _penunknownsum = 0;
        /// <summary>
        /// pen_unknown_sum
        /// </summary>
        public int penUnknownSum
        {
            get { return _penunknownsum; }
            set { _penunknownsum = value; }
        }

        protected int _pennumsum = 0;
        /// <summary>
        /// pen_num_sum
        /// </summary>
        public int penNumSum
        {
            get { return _pennumsum; }
            set { _pennumsum = value; }
        }

        protected int _flagblackssum = 0;
        /// <summary>
        /// blacks_sum
        /// </summary>
        public int flagBlacksSum
        {
            get { return _flagblackssum; }
            set { _flagblackssum = value; }
        }

        protected int _flagyellowssum = 0;
        /// <summary>
        /// yellows_sum
        /// </summary>
        public int flagYellowsSum
        {
            get { return _flagyellowssum; }
            set { _flagyellowssum = value; }
        }

        protected string _webkey = "_undetected";
        /// <summary>
        /// webkey
        /// </summary>
        public string webKey
        {
            get { return _webkey; }
            set { _webkey = value; }
        }

        protected string _firstseen = "_undetected";
        /// <summary>
        /// firstseen
        /// </summary>
        public string firstSeen
        {
            get { return _firstseen; }
            set { _firstseen = value; }
        }

        protected string _lastseen = "_undetected";
        /// <summary>
        /// lastseen
        /// </summary>
        public string lastSeen
        {
            get { return _lastseen; }
            set { _lastseen = value; }
        }
        #endregion
        //News on cop system
        public byte BusterTimer;
        public byte BustedNow;

        //Deliver Timer
        public byte DeliverTimer;
        public byte Deliver;

        //Smart Phone && Cigarettes
        public byte Phone;
        public byte Cigarettes;

        //Total Connect Time
        public byte TotalConnectTime;
        public byte IsOnline;

        //Vote System
        public byte Vote;
        public string jautajums;
        public string atbilde1;
        public string atbilde2;

        // Drift System
        public int DriftTime;
        public bool IsDrifting;
        public bool ReachedTime;

        //Interface Color System
        public byte ColorRed;
        public byte ColorBlue;
        public int ColorBlack;
        public byte ColorYellow;
        public byte ColorGreen;


        // Cruise Bits
        public int NextSpeedLimit;
        public byte IsInPitZone;
        public byte IsInPitZone2;
        public string Location;
        public string LastSeen;
        public long JobsDone;
        public int TowTimer;
        public int BonusDone;
        public byte IsSpeeder;
        public int BankBonusTimer;
        public long BankBonus;
        public int ParkTicketTimer;

        // System Bits
        public byte KMHtoMPH;
        public int StealTime;
        public byte CarSolded;
        public byte DistanceToTodays;
        public byte MilesOrKilometers;
        public int PitLeave;
        public byte Spam;
        public int SpamTime;
        public byte HideGUIorNOT;
        public int LottoTimer;
        public int AFKTimer;
        public byte IsAFK;
        public int CheckAFKTimer;
        public byte CheckIsAFK;
        public bool welcomeopen;

        // Distance
        public int LastDistanceUpdate;
        public int TotalDistance;
        public int DistanceSincePit;
        public int HealthDist;
        public int TripMeter;
        public int Distance;
        public int DistanceFromOfficer;
        public int License;
        public int UpgradeLicense;
        public int JobDeliveries;

        // VIP Bits
        public byte IsVIP;
        public byte CanBeVIP;

        // Mafia Bits
        public byte CanBeMafia;
        public byte IsMafia;

        // Member Bits
        public byte IsMember;

        // Moderator Box
        public byte OpenModerator;
        public int PublicWarning;
        public string CheckUser;
        public string Message;
        public byte EnableClick;

        // TowTruck Bits
        public byte IsTowTruck;
        public byte CanBeTow;
        public int TowTicket;
        public byte TowRespond;
        public string TowRUsername;
        public string AcceptTowRUser;
        public byte calltow;
        public byte TowSiren;
        public byte TowStart;
        public byte IsBeingTowed;
        public int Towee;
        public int DistanceFromTowTruck;

        // Officer Bits
        public byte OffLocationBox;
        public byte CanBeCadet;
        public byte ParkTicket;
        public byte IsCadet;
        public byte CanBeOfficer;
        public byte IsOfficer;
        public byte SpeedingCadet;
        public byte CadetWarning;
        public byte InChaseOrNot;
        public byte IsBeingChased;
        public int CTimer;
        public byte OndutyBox;
        public byte Busted;
        public byte JoinChase;
        public byte NeedBackup;
        public string JoinedBackupUsername;
        public string BackupCallerUsername;
        public long CopWin;
        public long CopLost;
        public byte RobTimerActiv;
        public byte RobBustedTimer;
        public byte Siren;
        public byte PitEffect;
        public int Chasee;
        public byte ChaseCondition;
        public string ChaseeUsername;
        public string ChaseePlayerName;

        public byte ChasingBoxEffects;

        public byte InTrap;
        public int TrapX;
        public int TrapY;
        public int TrapSpeed;

        // Busted Accept Fine Box
        public string BustedUsername;
        public string OfficerUsername;
        public byte OpenBustedBox;
        public byte AcceptFines;
        public byte BustedRanAway;
        public byte AllowFine;
        public int PayFineSet;

        // Player Info
        public long Cash;
        public decimal Payout;
        public string Cars;
        public long BankBalance;
        public int Health;
        public int KeyAccept;

        // GPS
        public int GPS;
        public string Destination;
        public int GPSToHouse1;
        public int GPSToHouse2;
        public int GPSToHouse3;
        public int GPSToHouse4;
        public int GPSToBank;
        public int GPSToHouse5;
        public int GPSToPoliceStation;
        public int GPSToTicketShop;
        public int GPSToKinderGarten;
        public int GPSToTaxiStation;
        public int GPSToPaidParking;
        public int GPSToLukesMarket;
        public int GPSToCityBank;
        public int GPSToStockDealer;
        public int GPSToPizzaHouse;
        public int GPSToStateBank;
        public int GPSToCasino;
        public int GPSToRaceDealer;
        public int GPSToPlayer2;
        public int GPSToPlayer2D;
        public int Refreshxy;

        // Items
        public long Item1;
        public long Item2;
        public long Item3;
        public long Item4;
        public long SellItem1;
        public long SellItem2;
        public long SellItem3;
        public long SellItem4;

        #region ' House, Establishments, Jobs '

        // Houses \\
        public byte InHouse1;
        public byte InHouse2;
        public byte InHouse3;
        public byte InHouse4;
        public byte InHouse5;
        public int InHouse1Dist;
        public int InHouse2Dist;
        public int InHouse3Dist;
        public int InHouse4Dist;
        public int InHouse5Dist;
        public int InSchoolDist;
        public int InPoliceStationDist;
        public int InTicketShopDist;
        public int InMarketDist;
        public int InBankDist2;
        public int InShoolDist;
        public int InShopDist;
        public int InStoreDist;
        public int InBankDist;
        public int InDealerDist;
        public int InStationDist;
        public int InCarDealerStock;
        public int InCarDealerStockDist;
        public int InCasino;
        public int InCasinoDist;
        public int InCarDealerRace;
        public int InCarDealerRaceDist;
        public byte BankMenuOpen;
        public string LocationBox;
        public string SpeedBox;

        // Job From Houses \\
        public byte JobFromHouse1;
        public byte JobFromHouse2;
        public byte JobFromHouse3;
        public byte JobFromHouse4;
        public byte JobFromHouse5;

        // Job To House \\
        public byte JobToHouse1;
        public byte JobToHouse2;
        public byte JobToHouse3;
        public byte JobToHouse4;
        public byte JobToHouse5;

        // Location Taxi Job \\
        public byte InStation;
        //public byte InStation2;
        //public byte InStation3;

        // Establishments \\
        public byte InShop;
        public byte InTicketShop;
        public byte InPoliceStation;
        public byte InDisco;
        public byte InBank;
        public byte InBank2;
        public byte InSchool;
        public byte InMarket;
        public byte InKY1Shop;

        // Job To \\
        /*public byte JobToShop;
        public byte JobToBank;
        public byte JobToBank2;
        public byte JobToDisco;*/
        public byte JobToSchool;
        //public byte JobToMarket;

        // Job From Establishments \\
        public byte JobFromShop;

        // Taxi Jobs
        public byte JobFromStation;
        //public byte JobFromStation2;
        //public byte JobFromStation3;

        #endregion

        // Player Renting
        public byte Renting;
        public byte Rented;
        public string Renter;
        public string Renterr;
        public string Rentee;

        //Player Bits
        public byte HelpMenuPage;
        public int Keydistance;
        public int Keyjoblicense;
        public int Keylicense;
        public long KeyCash;
        public string KeyCar;
        public bool MenuPanel;
        public bool InMenu;
        public int Locationxy;
        public byte Nodeloc;
        public byte MessageID;
        public byte FailCon;
        public byte DetectAdmin;
        public byte DLaser;
        public int LottoTicket;
        public int CopDistance;
        public byte Spectators;
        public bool Help;
        public string Username;
        public string PlayerName;
        public byte IsAdmin;
        public byte Advert;
        public byte Flags;
        public byte UniqueID;
        public byte MsgID;
        public string CurrentCar;
        public Packets.IS_NPL PlayerPacket;
        public string SkinName;
        public byte PlayerID;
        public int WaitLotto;
        public string Plate;
        public int GUIStyle;
        public byte GIUX;
        public byte GIUY;
        public byte GIUX2;
        public byte GIUY2;
        public long RobWin;
        public long RobLost;
        public int IdxCar;
        public int ResetTimer;
        public int EnableResetTimer;
        public string RedOrBlack;
        public int CasinoTimerRedOrBlack;
        public int CasinoBet;
        public int Announce;
        public int AnnounceTimer;
        public int ChannelLanguage;
        public bool AdminCommand;
        public int GUIStylebackup;
        public byte HideGUIorNOTbackup;
        public string ResetUsername;
        public bool SwearCommand;

        public enum enuPType : byte
        {
            Female = 0,
            AI = 1,
            Remote = 2,
        }

        //CompCar Packet
        public Packets.CompCar CompCar = new Packets.CompCar();
    }
}