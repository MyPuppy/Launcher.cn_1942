using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KartRider.IO;
using KartRider;
using ExcData;
using Set_Data;

namespace RiderData
{
    public static class NewRider
    {
        public static short Value1 = 30000;
        public static short Value2 = 1;

        public static short Kart_Old_Cut = 0;

        public static short MaxKart = 0;

        public static void LoadItemData()
        {
            NewRider.Kart();
            NewRider.Pet();
            NewRider.FlyingPet();
            NewRider.Character();
            NewRider.BonusCard();
            NewRider.HandGearL();
            NewRider.HeadBand();
            NewRider.Goggle();
            NewRider.Balloon();
            NewRider.SlotItem();
            NewRider.MyRoom();
            NewRider.RenameRid();
            NewRider.ReplayTicket();
            NewRider.LucciBag();
            NewRider.Uniform();
            NewRider.Plate();
            NewRider.RidColor();
            NewRider.SkidMark();
            NewRider.Aura();
            NewRider.Paint();
            KartExcData.Kart_ExcData();
            NewRider.NewRiderData();//라이더 인식
            Launcher.OpenGetItem = true;
        }

        public static void NewRiderData()
        {
            using (OutPacket oPacket = new OutPacket("PrGetRider"))
            {
                oPacket.WriteByte(1);
                oPacket.WriteString(SetRider.Nickname);
                oPacket.WriteShort(0);
                oPacket.WriteShort(0);
                oPacket.WriteShort(SetRider.Emblem1);
                oPacket.WriteShort(SetRider.Emblem2);
                oPacket.WriteShort(0);
                oPacket.WriteShort(SetRiderItem.Set_Character);
                oPacket.WriteShort(SetRiderItem.Set_Paint);
                if (Launcher.KartOld_SN == SetRiderItem.Set_KartSN)
                {
                    oPacket.WriteShort(SetRiderItem.Set_Kart);
                }
                else
                {
                    oPacket.WriteShort(0);
                }
                oPacket.WriteShort(SetRiderItem.Set_Plate);
                oPacket.WriteShort(SetRiderItem.Set_Goggle);
                oPacket.WriteShort(SetRiderItem.Set_Balloon);
                oPacket.WriteShort(0);
                oPacket.WriteShort(SetRiderItem.Set_HeadBand);
                oPacket.WriteShort(0);
                oPacket.WriteShort(SetRiderItem.Set_HandGearL);
                oPacket.WriteShort(0);
                oPacket.WriteShort(SetRiderItem.Set_Uniform);
                oPacket.WriteShort(0);
                oPacket.WriteShort(SetRiderItem.Set_Pet);
                oPacket.WriteShort(SetRiderItem.Set_FlyingPet);
                oPacket.WriteShort(SetRiderItem.Set_Aura);
                oPacket.WriteShort(SetRiderItem.Set_SkidMark);
                oPacket.WriteShort(0);
                oPacket.WriteShort(SetRiderItem.Set_RidColor);
                oPacket.WriteShort(SetRiderItem.Set_BonusCard);
                oPacket.WriteShort(0);
                if (SetRiderItem.Set_KartSN == Launcher.KartOld_SN)
                {
                    if (Program.UseKartPlant)
                    {
                        oPacket.WriteShort(23);
                        oPacket.WriteShort(23);
                        oPacket.WriteShort(2);
                        oPacket.WriteShort(1);
                    }
                    else
                    {
                        oPacket.WriteShort(0);
                        oPacket.WriteShort(0);
                        oPacket.WriteShort(0);
                        oPacket.WriteShort(0);
                    }
                }
                else
                {
                    oPacket.WriteShort(0);
                    oPacket.WriteShort(0);
                    oPacket.WriteShort(0);
                    oPacket.WriteShort(0);
                }
                if (SetRiderItem.Set_KartSN == Launcher.KartOld_SN)
                {
                    oPacket.WriteShort(Launcher.KartOld_SN);
                    if (Program.UseKartLevel)
                    {
                        if (SetRiderItem.Set_Kart <= 292 || SetRiderItem.Set_Kart == 358 || SetRiderItem.Set_Kart == 420 || SetRiderItem.Set_Kart == 501 || SetRiderItem.Set_Kart == 837 ||
                            SetRiderItem.Set_Kart == 838 || SetRiderItem.Set_Kart == 843 || SetRiderItem.Set_Kart == 845 || SetRiderItem.Set_Kart == 847 || SetRiderItem.Set_Kart == 853 ||
                            SetRiderItem.Set_Kart == 856 || SetRiderItem.Set_Kart == 863 || SetRiderItem.Set_Kart == 873 || SetRiderItem.Set_Kart == 880)
                        {
                            oPacket.WriteByte(0);
                        }
                        else
                        {
                            oPacket.WriteByte(7);
                        }
                    }
                    else
                    {
                        oPacket.WriteByte(0);
                    }
                }
                else
                {
                    oPacket.WriteShort(0);
                    oPacket.WriteByte(0);
                }
                oPacket.WriteString("");
                oPacket.WriteUInt(SetRider.Lucci);
                oPacket.WriteInt(SetRider.RP);
                for (int i = 0; i < 25; i++)
                {
                    oPacket.WriteInt(0);
                }
                RouterListener.MySession.Client.Send(oPacket);
            }
        }

        public static void KartSN()
        {
            NewRider.Kart_Old_Cut = 172;
            NewRider.MaxKart = 903;

            Launcher.KartOld_SN = 1;
            Launcher.KartSN = 1000;
        }

        public static void Kart()
        {
            int All_Kart = NewRider.Kart_Old_Cut;
            using (OutPacket oPacket = new OutPacket("LoRpGetRiderItemPacket"))
            {
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                oPacket.WriteInt(All_Kart);
                //-----------------------------------------------------------------------------------------------------------------
                for (short i = 1; i <= NewRider.MaxKart; i++)
                {
                    if (i <= 25 || i == 27 || i == 29 || i == 45 || i == 54 || i == 59 ||
                        i == 63 || i == 70 || i == 82 || i == 95 || i == 101 || i == 103 || i == 111 || i == 114 || i == 117 || i == 219 || i == 220 || i == 265 || i == 285 || i == 292 || i == 302 ||
                        i == 311 || i == 326 || i == 357 || i == 361 || i == 371 || i == 378 || i == 420 || i == 429 || i == 433 || i == 436 || i == 440 || i == 445 || i == 453 || i == 458 || i == 459 ||
                        i == 461 || i == 473 || i == 474 || i == 475 || i == 481 || i == 483 || i == 484 || i == 489 || i == 500 || i == 501 || i == 517 || i == 526 || i == 531 || i == 543 || i == 544 ||
                        i == 550 || i == 559 || i == 564 || i == 570 || i == 574 || i == 579 || i == 580 || i == 582 || i == 587 || i == 602 || i == 604 || i == 606 || i == 611 || i == 619 || i == 620 ||
                        i == 624 || i == 630 || i == 636 || i == 639 || i == 643 || i == 644 || i == 666 || i == 671 || i == 684 || i == 683 || i == 685 || i == 701 || i == 706 || i == 721 || i == 739 ||
                        i == 788 || i == 750 || i == 757 || i == 764 || i == 787 || i == 794 || i == 795 || i == 796 || i == 797 || i == 800 || i == 805 || i == 806 || i == 811 || i == 813 || i == 824 ||
                        i == 827 || i == 828 || i == 829 || i == 830 || i == 831 || i == 832 || i == 833 || i == 835 || i == 837 || i == 838 || i == 839 || i == 840 || i == 841 || i == 843 || i == 844 ||
                        i == 845 || i == 846 || i == 847 || i == 849 || i == 850 || i == 852 || i == 853 || i == 854 || i == 855 || i == 856 || i == 857 || i == 858 || i == 859 || i == 863 || i == 864 ||
                        i == 865 || i == 866 || i == 867 || i == 868 || i == 869 || i == 872 || i == 873 || i == 874 || i == 875 || i == 877 || i == 878 || i == 879 || i == 880 || i == 882 || i == 883 ||
                        i == 884 || i == 885 || i == 887 || i == 888 || i == 891 || i == 896 || i == 900)
                    {
                        oPacket.WriteShort(3);
                        oPacket.WriteShort(i);
                        oPacket.WriteShort(Launcher.KartOld_SN);
                        oPacket.WriteShort(NewRider.Value2);
                        oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                        oPacket.WriteByte(0);
                        oPacket.WriteShort(-1);
                        oPacket.WriteShort(0);
                    }
                }
                RouterListener.MySession.Client.Send(oPacket);
            }
        }

        public static void Paint()
        {
            using (OutPacket oPacket = new OutPacket("LoRpGetRiderItemPacket"))
            {
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                int Paint = 49;
                oPacket.WriteInt(Paint - 18);
                for (short i = 1; i <= Paint; i++)
                {
                    if (i == 18 || i == 19 || i == 21 || i == 25 || i == 33 || i == 34 || i == 35 || i == 37 || i == 38 || i == 39 ||
                        i == 45 || i == 47 || i == 14 || i == 15 || i == 16 || i == 22 || i == 26 || i == 43)
                    {
                    }
                    else
                    {
                        oPacket.WriteShort(2);
                        oPacket.WriteShort(i);
                        oPacket.WriteShort(0);
                        oPacket.WriteShort(NewRider.Value2);
                        oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                        oPacket.WriteByte(0);
                        oPacket.WriteShort(-1);
                        oPacket.WriteShort(0);
                    }
                }
                RouterListener.MySession.Client.Send(oPacket);
            }
        }

        public static void Character()
        {
            using (OutPacket oPacket = new OutPacket("LoRpGetRiderItemPacket"))
            {
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                int Character = 163;
                oPacket.WriteInt(Character - 26 - 32);
                for (short i = 1; i <= Character; i++)//Character
                {
                    if (i == 47 || i == 48 || i == 116 || i == 117 || i == 124 || i == 128 || i == 130 || i == 134 || i == 137 || i == 144 || 
                        i == 147 || i == 149 || i == 159 || i == 22 || i == 60 || i == 65 || i == 66 || i == 67 || i == 96 || i == 103 || 
                        i == 109 || i == 113 || i == 114 || i == 115 || i == 127 || i == 26 ||

                        i == 33 || i == 34 || i == 35 || i == 36 || i == 38 || i == 39 || i == 40 || i == 41 || i == 42 || i == 43 ||
                        i == 45 || i == 56 || i == 70 || i == 84 || i == 97 || i == 98 || i == 99 || i == 100 || i == 105 || i == 106 ||
                        i == 107 || i == 108 || i == 110 || i == 112 || i == 123 || i == 132 || i == 133 || i == 150 || i == 156 || i == 157 ||
                        i == 158 || i == 161)
                    {
                    }
                    else
                    {
                        oPacket.WriteShort(1);
                        oPacket.WriteShort(i);
                        oPacket.WriteShort(0);
                        oPacket.WriteShort(NewRider.Value2);
                        oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                        oPacket.WriteByte(0);
                        oPacket.WriteShort(-1);
                        oPacket.WriteShort(0);
                    }
                }
                RouterListener.MySession.Client.Send(oPacket);
            }
        }

        public static void Pet()
        {
            using (OutPacket oPacket = new OutPacket("LoRpGetRiderItemPacket"))
            {
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                int Pet = 113;
                oPacket.WriteInt(Pet + 8 - 19);
                for (short i = 30000; i <= 30008; i++)
                {
                    if (i == 30001)
                    {
                    }
                    else
                    {
                        oPacket.WriteShort(21);
                        oPacket.WriteShort(i);
                        oPacket.WriteShort(0);
                        oPacket.WriteShort(NewRider.Value2);
                        oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                        oPacket.WriteByte(0);
                        oPacket.WriteShort(-1);
                        oPacket.WriteShort(0);
                    }
                }
                for (short i = 1; i <= Pet; i++)
                {
                    if (i == 1 || i == 4 || i == 7 || i == 9 || i == 12 || i == 36 || i == 40 || i == 73 || i == 92 || i == 94 ||
                        i == 96 || i == 106 || i == 29 || i == 54 || i == 60 || i == 71 || i == 76 || i == 79 || i == 88)
                    {
                    }
                    else
                    {
                        oPacket.WriteShort(21);
                        oPacket.WriteShort(i);
                        oPacket.WriteShort(0);
                        oPacket.WriteShort(NewRider.Value2);
                        oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                        oPacket.WriteByte(0);
                        oPacket.WriteShort(-1);
                        oPacket.WriteShort(0);
                    }
                }
                RouterListener.MySession.Client.Send(oPacket);
            }
        }

        public static void FlyingPet()
        {
            using (OutPacket oPacket = new OutPacket("LoRpGetRiderItemPacket"))
            {
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                int FlyingPet = 32;
                oPacket.WriteInt(FlyingPet - 6);
                for (short i = 1; i <= FlyingPet; i++)
                {
                    if (i == 19 || i == 20 || i == 21 || i == 22 || i == 23 || i == 24)
                    {
                    }
                    else
                    {
                        oPacket.WriteShort(52);
                        oPacket.WriteShort(i);
                        oPacket.WriteShort(0);
                        oPacket.WriteShort(NewRider.Value2);
                        oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                        oPacket.WriteByte(0);
                        oPacket.WriteShort(-1);
                        oPacket.WriteShort(0);
                    }
                }
                RouterListener.MySession.Client.Send(oPacket);
            }
        }

        public static void Uniform()
        {
            using (OutPacket oPacket = new OutPacket("LoRpGetRiderItemPacket"))
            {
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                int Uniform = 108;
                oPacket.WriteInt(Uniform - 76);
                for (short i = 1; i <= Uniform; i++)
                {
                    if (i == 1 || i == 2 || i == 3 || i == 4 || i == 5 || i == 6 || i == 7 || i == 8 || i == 9 || i == 10 ||
                        i == 11 || i == 15 || i == 16 || i == 18 || i == 20 || i == 21 || i == 23 || i == 26 || i == 28 || i == 31 ||
                        i == 32 || i == 33 || i == 34 || i == 40 || i == 41 || i == 42 || i == 43 || i == 44 || i == 45 || i == 46 ||
                        i == 47 || i == 48 || i == 50 || i == 51 || i == 53 || i == 54 || i == 55 || i == 56 || i == 57 || i == 58 ||
                        i == 59 || i == 61 || i == 62 || i == 63 || i == 64 || i == 65 || i == 66 || i == 67 || i == 68 || i == 69 ||
                        i == 70 || i == 71 || i == 73 || i == 74 || i == 75 || i == 76 || i == 82 || i == 86 || i == 87 || i == 88 ||
                        i == 90 || i == 91 || i == 92 || i == 93 || i == 94 || i == 95 || i == 96 || i == 97 || i == 99 || i == 100 ||
                        i == 101 || i == 102 || i == 103 || i == 104 || i == 107 || i == 108)
                    {
                    }
                    else
                    {
                        oPacket.WriteShort(18);
                        oPacket.WriteShort(i);
                        oPacket.WriteShort(0);
                        oPacket.WriteShort(NewRider.Value2);
                        oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                        oPacket.WriteByte(0);
                        oPacket.WriteShort(-1);
                        oPacket.WriteShort(0);
                    }
                }
                RouterListener.MySession.Client.Send(oPacket);
            }
        }

        public static void Aura()
        {
            using (OutPacket oPacket = new OutPacket("LoRpGetRiderItemPacket"))
            {
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                int Aura = 52;
                oPacket.WriteInt(Aura + 1 - 4);
                oPacket.WriteShort(26);
                oPacket.WriteShort(30000);
                oPacket.WriteShort(0);
                oPacket.WriteShort(NewRider.Value2);
                oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                oPacket.WriteByte(0);
                oPacket.WriteShort(-1);
                oPacket.WriteShort(0);
                for (short i = 1; i <= Aura; i++)
                {
                    if (i == 17 || i == 35 || i == 36 || i == 40)
                    {
                    }
                    else
                    {
                        oPacket.WriteShort(26);
                        oPacket.WriteShort(i);
                        oPacket.WriteShort(0);
                        oPacket.WriteShort(NewRider.Value2);
                        oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                        oPacket.WriteByte(0);
                        oPacket.WriteShort(-1);
                        oPacket.WriteShort(0);
                    }
                }
                RouterListener.MySession.Client.Send(oPacket);
            }
        }

        public static void SkidMark()
        {
            using (OutPacket oPacket = new OutPacket("LoRpGetRiderItemPacket"))
            {
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                int SkidMark = 25;
                oPacket.WriteInt(SkidMark - 5);
                for (short i = 1; i <= SkidMark; i++)
                {
                    if (i == 12 || i == 13 || i == 20 || i == 22 || i == 24)
                    {
                    }
                    else
                    {
                        oPacket.WriteShort(27);
                        oPacket.WriteShort(i);
                        oPacket.WriteShort(0);
                        oPacket.WriteShort(NewRider.Value2);
                        oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                        oPacket.WriteByte(0);
                        oPacket.WriteShort(-1);
                        oPacket.WriteShort(0);
                    }
                }
                RouterListener.MySession.Client.Send(oPacket);
            }
        }

        public static void Plate()
        {
            using (OutPacket oPacket = new OutPacket("LoRpGetRiderItemPacket"))
            {
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                int Plate = 234;
                oPacket.WriteInt(Plate + 2 - 95);
                for (short i = 30000; i <= 30001; i++)
                {
                    oPacket.WriteShort(4);
                    oPacket.WriteShort(i);
                    oPacket.WriteShort(0);
                    oPacket.WriteShort(NewRider.Value2);
                    oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                    oPacket.WriteByte(0);
                    oPacket.WriteShort(-1);
                    oPacket.WriteShort(0);
                }
                for (short i = 1; i <= Plate; i++)
                {
                    if (i == 27 || i == 28 || i == 36 || i == 38 || i == 39 || i == 42 || i == 43 || i == 44 || i == 45 || i == 46 ||
                        i == 47 || i == 48 || i == 49 || i == 50 || i == 51 || i == 52 || i == 53 || i == 54 || i == 55 || i == 56 ||
                        i == 59 || i == 62 || i == 64 || i == 69 || i == 70 || i == 71 || i == 74 || i == 76 || i == 78 || i == 79 ||
                        i == 84 || i == 85 || i == 86 || i == 92 || i == 93 || i == 95 || i == 96 || i == 98 || i == 99 || i == 103 ||
                        i == 104 || i == 107 || i == 110 || i == 111 || i == 115 || i == 118 || i == 119 || i == 120 || i == 122 || i == 124 ||
                        i == 125 || i == 126 || i == 127 || i == 130 || i == 131 || i == 135 || i == 136 || i == 137 || i == 138 || i == 142 ||
                        i == 147 || i == 150 || i == 151 || i == 152 || i == 186 || i == 187 || i == 188 || i == 192 || i == 193 || i == 195 ||
                        i == 198 || i == 201 || i == 207 || i == 208 || i == 211 || i == 212 || i == 214 || i == 215 || i == 218 || i == 222 ||
                        i == 223 || i == 225 || i == 226 || i == 231 || i == 60 || i == 61 || i == 73 || i == 77 || i == 94 || i == 117 || 
                        i == 132 || i == 199 || i == 202 || i == 221 || i == 232)
                    {
                    }
                    else
                    {
                        oPacket.WriteShort(4);
                        oPacket.WriteShort(i);
                        oPacket.WriteShort(0);
                        oPacket.WriteShort(NewRider.Value2);
                        oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                        oPacket.WriteByte(0);
                        oPacket.WriteShort(-1);
                        oPacket.WriteShort(0);
                    }
                }
                RouterListener.MySession.Client.Send(oPacket);
            }
        }

        public static void Balloon()
        {
            using (OutPacket oPacket = new OutPacket("LoRpGetRiderItemPacket"))
            {
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                oPacket.WriteInt(5 + 70 + 50);
                for (short i = 30009; i <= 30013; i++)
                {
                    oPacket.WriteShort(9);
                    oPacket.WriteShort(i);
                    oPacket.WriteShort(0);
                    oPacket.WriteShort(NewRider.Value1);
                    oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                    oPacket.WriteByte(0);
                    oPacket.WriteShort(-1);
                    oPacket.WriteShort(0);
                }
                for (short i = 1; i <= 1061; i++)
                {
                    if (i == 71 || i == 74 || i == 118 || i == 125 || i == 139 || i == 142 || i == 149 || i == 162 || i == 182 || i == 187 ||
                        i == 195 || i == 196 || i == 199 || i == 210 || i == 211 || i == 214 || i == 223 || i == 224 || i == 266 || i == 272 ||
                        i == 279 || i == 296 || i == 298 || i == 299 || i == 304 || i == 305 || i == 310 || i == 311 || i == 385 || i == 432 ||
                        i == 433 || i == 536 || i == 537 || i == 538 || i == 539 || i == 540 || i == 541 || i == 542 || i == 544 || i == 545 ||
                        i == 623 || i == 798 || i == 817 || i == 957 || i == 959 || i == 960 || i == 1000 || i == 1001 || i == 1002 || i == 1003 ||
                        i == 1004 || i == 1008 || i == 1009 || i == 1010 || i == 1038 || i == 1039 || i == 1040 || i == 1041 || i == 1042 || i == 1044 ||
                        i == 1046 || i == 1047 || i == 1049 || i == 1050 || i == 1053 || i == 1056 || i == 1057 || i == 1058 || i == 1059 || i == 1061 ||

                        i == 1 || i == 2 || i == 3 || i == 4 || i == 11 || i == 12 || i == 13 || i == 56 || i == 68 || i == 78 ||
                        i == 84 || i == 103 || i == 140 || i == 225 || i == 265 || i == 445 || i == 446 || i == 447 || i == 448 || i == 449 ||
                        i == 450 || i == 512 || i == 599 || i == 600 || i == 602 || i == 603 || i == 683 || i == 685 || i == 689 || i == 690 ||
                        i == 691 || i == 692 || i == 705 || i == 745 || i == 746 || i == 747 || i == 756 || i == 768 || i == 790 || i == 791 ||
                        i == 794 || i == 795 || i == 796 || i == 822 || i == 823 || i == 824 || i == 828 || i == 882 || i == 883 || i == 970)
                    {
                        oPacket.WriteShort(9);
                        oPacket.WriteShort(i);
                        oPacket.WriteShort(0);
                        oPacket.WriteShort(NewRider.Value1);
                        oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                        oPacket.WriteByte(0);
                        oPacket.WriteShort(-1);
                        oPacket.WriteShort(0);
                    }
                }
                RouterListener.MySession.Client.Send(oPacket);
            }
        }

        public static void Goggle()
        {
            using (OutPacket oPacket = new OutPacket("LoRpGetRiderItemPacket"))
            {
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                int Goggle = 156;
                oPacket.WriteInt(Goggle + 10 - 48);
                for (short i = 30000; i <= 30009; i++)
                {
                    oPacket.WriteShort(8);
                    oPacket.WriteShort(i);
                    oPacket.WriteShort(0);
                    oPacket.WriteShort(NewRider.Value2);
                    oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                    oPacket.WriteByte(0);
                    oPacket.WriteShort(-1);
                    oPacket.WriteShort(0);
                }
                for (short i = 1; i <= Goggle; i++)
                {
                    if (i == 9 || i == 10 || i == 18 || i == 25 || i == 26 || i == 28 || i == 29 || i == 39 || i == 40 || i == 67 ||
                        i == 70 || i == 73 || i == 81 || i == 84 || i == 85 || i == 86 || i == 88 || i == 92 || i == 104 || i == 106 ||
                        i == 108 || i == 109 || i == 111 || i == 114 || i == 115 || i == 117 || i == 122 || i == 127 || i == 128 || i == 131 ||
                        i == 132 || i == 133 || i == 136 || i == 137 || i == 138 || i == 139 || i == 141 || i == 145 || i == 146 || i == 154 ||
                        i == 14 || i == 24 || i == 33 || i == 52 || i == 56 || i == 59 || i == 79 || i == 112)
                    {
                    }
                    else
                    {
                        oPacket.WriteShort(8);
                        oPacket.WriteShort(i);
                        oPacket.WriteShort(0);
                        oPacket.WriteShort(NewRider.Value2);
                        oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                        oPacket.WriteByte(0);
                        oPacket.WriteShort(-1);
                        oPacket.WriteShort(0);
                    }
                }
                RouterListener.MySession.Client.Send(oPacket);
            }
        }

        public static void HeadBand()
        {
            using (OutPacket oPacket = new OutPacket("LoRpGetRiderItemPacket"))
            {
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                int HeadBand = 503;
                oPacket.WriteInt(HeadBand + 14 - 235);
                for (short i = 30000; i <= 30016; i++)
                {
                    if (i == 30008 || i == 30009 || i == 30015)
                    {
                    }
                    else
                    {
                        oPacket.WriteShort(11);
                        oPacket.WriteShort(i);
                        oPacket.WriteShort(0);
                        oPacket.WriteShort(NewRider.Value2);
                        oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                        oPacket.WriteByte(0);
                        oPacket.WriteShort(-1);
                        oPacket.WriteShort(0);
                    }
                }
                for (short i = 1; i <= HeadBand; i++)
                {
                    if (i == 1 || i == 2 || i == 5 || i == 6 || i == 13 || i == 14 || i == 32 || i == 37 || i == 38 || i == 39 ||
                        i == 41 || i == 43 || i == 46 || i == 48 || i == 51 || i == 52 || i == 55 || i == 64 || i == 72 || i == 75 ||
                        i == 86 || i == 89 || i == 100 || i == 102 || i == 109 || i == 110 || i == 115 || i == 133 || i == 134 || i == 137 ||
                        i == 138 || i == 139 || i == 148 || i == 155 || i == 159 || i == 160 || i == 170 || i == 173 || i == 174 || i == 176 ||
                        i == 182 || i == 185 || i == 186 || i == 187 || i == 188 || i == 190 || i == 194 || i == 195 || i == 197 || i == 199 ||
                        i == 200 || i == 201 || i == 204 || i == 206 || i == 207 || i == 208 || i == 213 || i == 214 || i == 217 || i == 220 ||
                        i == 221 || i == 222 || i == 223 || i == 224 || i == 227 || i == 231 || i == 233 || i == 235 || i == 237 || i == 240 ||
                        i == 242 || i == 243 || i == 248 || i == 250 || i == 253 || i == 256 || i == 257 || i == 258 || i == 262 || i == 265 ||
                        i == 266 || i == 268 || i == 271 || i == 273 || i == 274 || i == 279 || i == 280 || i == 281 || i == 282 || i == 283 ||
                        i == 287 || i == 288 || i == 289 || i == 290 || i == 293 || i == 294 || i == 295 || i == 296 || i == 299 || i == 300 ||
                        i == 301 || i == 302 || i == 303 || i == 304 || i == 305 || i == 306 || i == 309 || i == 310 || i == 311 || i == 312 ||
                        i == 316 || i == 317 || i == 318 || i == 323 || i == 324 || i == 325 || i == 326 || i == 328 || i == 329 || i == 330 ||
                        i == 333 || i == 335 || i == 336 || i == 338 || i == 340 || i == 341 || i == 343 || i == 345 || i == 350 || i == 351 ||
                        i == 353 || i == 354 || i == 355 || i == 356 || i == 357 || i == 358 || i == 360 || i == 361 || i == 362 || i == 363 ||
                        i == 364 || i == 365 || i == 366 || i == 367 || i == 368 || i == 369 || i == 370 || i == 371 || i == 372 || i == 373 ||
                        i == 374 || i == 375 || i == 381 || i == 382 || i == 383 || i == 384 || i == 385 || i == 386 || i == 387 || i == 388 ||
                        i == 389 || i == 390 || i == 391 || i == 393 || i == 394 || i == 395 || i == 396 || i == 398 || i == 399 || i == 400 ||
                        i == 401 || i == 402 || i == 403 || i == 405 || i == 406 || i == 407 || i == 408 || i == 409 || i == 411 || i == 414 ||
                        i == 418 || i == 419 || i == 420 || i == 437 || i == 438 || i == 443 || i == 444 || i == 445 || i == 446 || i == 447 ||
                        i == 448 || i == 450 || i == 452 || i == 453 || i == 454 || i == 456 || i == 457 || i == 458 || i == 460 || i == 461 ||
                        i == 462 || i == 463 || i == 464 || i == 470 || i == 472 || i == 473 || i == 474 || i == 490 || i == 495 || i == 498 ||
                        i == 500 || i == 12 || i == 28 || i == 36 || i == 66 || i == 71 || i == 84 || i == 90 || i == 123 || i == 232 ||
                        i == 264 || i == 267 || i == 334 || i == 347 || i == 392 || i == 404 || i == 416 || i == 417 || i == 436 || i == 455 ||
                        i == 459 || i == 467 || i == 482 || i == 499 || i == 502)
                    {
                    }
                    else
                    {
                        oPacket.WriteShort(11);
                        oPacket.WriteShort(i);
                        oPacket.WriteShort(0);
                        oPacket.WriteShort(NewRider.Value2);
                        oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                        oPacket.WriteByte(0);
                        oPacket.WriteShort(-1);
                        oPacket.WriteShort(0);
                    }
                }
                RouterListener.MySession.Client.Send(oPacket);
            }
        }

        public static void HandGearL()
        {
            using (OutPacket oPacket = new OutPacket("LoRpGetRiderItemPacket"))
            {
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                int HandGearL = 319;
                oPacket.WriteInt(HandGearL + 11 - 150);
                for (short i = 30000; i <= 30011; i++)
                {
                    if (i == 30008)
                    {
                    }
                    else
                    {
                        oPacket.WriteShort(16);
                        oPacket.WriteShort(i);
                        oPacket.WriteShort(0);
                        oPacket.WriteShort(NewRider.Value2);
                        oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                        oPacket.WriteByte(0);
                        oPacket.WriteShort(-1);
                        oPacket.WriteShort(0);
                    }
                }
                for (short i = 1; i <= HandGearL; i++)
                {
                    if (i == 3 || i == 4 || i == 6 || i == 7 || i == 8 || i == 9 || i == 11 || i == 12 || i == 13 || i == 14 ||
                        i == 16 || i == 17 || i == 19 || i == 22 || i == 23 || i == 26 || i == 28 || i == 31 || i == 34 || i == 35 ||
                        i == 37 || i == 38 || i == 47 || i == 49 || i == 52 || i == 57 || i == 58 || i == 63 || i == 73 || i == 86 ||
                        i == 88 || i == 91 || i == 92 || i == 93 || i == 106 || i == 109 || i == 111 || i == 112 || i == 116 || i == 119 ||
                        i == 120 || i == 121 || i == 122 || i == 125 || i == 126 || i == 129 || i == 131 || i == 132 || i == 134 || i == 135 ||
                        i == 136 || i == 139 || i == 141 || i == 142 || i == 143 || i == 144 || i == 149 || i == 155 || i == 157 || i == 163 ||
                        i == 166 || i == 167 || i == 168 || i == 169 || i == 173 || i == 176 || i == 180 || i == 181 || i == 182 || i == 183 ||
                        i == 186 || i == 187 || i == 189 || i == 196 || i == 198 || i == 204 || i == 206 || i == 211 || i == 212 || i == 214 ||
                        i == 215 || i == 216 || i == 217 || i == 218 || i == 219 || i == 220 || i == 221 || i == 222 || i == 223 || i == 225 ||
                        i == 226 || i == 231 || i == 232 || i == 233 || i == 235 || i == 236 || i == 238 || i == 239 || i == 242 || i == 243 ||
                        i == 245 || i == 247 || i == 249 || i == 251 || i == 255 || i == 256 || i == 257 || i == 258 || i == 259 || i == 260 ||
                        i == 263 || i == 265 || i == 266 || i == 268 || i == 272 || i == 273 || i == 274 || i == 277 || i == 278 || i == 281 ||
                        i == 282 || i == 290 || i == 293 || i == 295 || i == 296 || i == 297 || i == 300 || i == 307 || i == 310 || i == 313 ||
                        i == 315 || i == 1 || i == 25 || i == 50 || i == 84 || i == 85 || i == 98 || i == 108 || i == 146 || i == 209 ||
                        i == 224 || i == 230 || i == 234 || i == 261 || i == 262 || i == 267 || i == 269 || i == 275 || i == 303 || i == 314)
                    {
                    }
                    else
                    {
                        oPacket.WriteShort(16);
                        oPacket.WriteShort(i);
                        oPacket.WriteShort(0);
                        oPacket.WriteShort(NewRider.Value2);
                        oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                        oPacket.WriteByte(0);
                        oPacket.WriteShort(-1);
                        oPacket.WriteShort(0);
                    }
                }
                RouterListener.MySession.Client.Send(oPacket);
            }
        }

        public static void MyRoom()
        {
            using (OutPacket oPacket = new OutPacket("LoRpGetRiderItemPacket"))
            {
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                int MyRoom = 26;
                oPacket.WriteInt(MyRoom + 1 - 12);
                oPacket.WriteShort(28);
                oPacket.WriteShort(30000);
                oPacket.WriteShort(0);
                oPacket.WriteShort(NewRider.Value2);
                oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                oPacket.WriteByte(0);
                oPacket.WriteShort(-1);
                oPacket.WriteShort(0);
                for (short i = 1; i <= MyRoom; i++)
                {
                    if (i == 1 || i == 4 || i == 5 || i == 8 || i == 10 || i == 11 || i == 12 || i == 14 || i == 16 || i == 19 ||
                        i == 21 || i == 24)
                    {
                    }
                    else
                    {
                        oPacket.WriteShort(28);
                        oPacket.WriteShort(i);
                        oPacket.WriteShort(0);
                        oPacket.WriteShort(NewRider.Value2);
                        oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                        oPacket.WriteByte(0);
                        oPacket.WriteShort(-1);
                        oPacket.WriteShort(0);
                    }
                }
                RouterListener.MySession.Client.Send(oPacket);
            }
        }

        public static void RidColor()
        {
            using (OutPacket oPacket = new OutPacket("LoRpGetRiderItemPacket"))
            {
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                int RidColor = 6;
                oPacket.WriteInt(RidColor);
                for (short i = 1; i <= RidColor; i++)
                {
                    oPacket.WriteShort(31);
                    oPacket.WriteShort(i);
                    oPacket.WriteShort(0);
                    oPacket.WriteShort(NewRider.Value2);
                    oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                    oPacket.WriteByte(0);
                    oPacket.WriteShort(-1);
                    oPacket.WriteShort(0);
                }
                RouterListener.MySession.Client.Send(oPacket);
            }
        }

        public static void BonusCard()
        {
            using (OutPacket oPacket = new OutPacket("LoRpGetRiderItemPacket"))
            {
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                int BonusCard = 6;
                oPacket.WriteInt(BonusCard - 2);
                for (short i = 1; i <= BonusCard; i++)
                {
                    if (i == 3 || i == 6)
                    {
                    }
                    else
                    {
                        oPacket.WriteShort(32);
                        oPacket.WriteShort(i);
                        oPacket.WriteShort(0);
                        oPacket.WriteShort(NewRider.Value2);
                        oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                        oPacket.WriteByte(0);
                        oPacket.WriteShort(-1);
                        oPacket.WriteShort(0);
                    }
                }
                RouterListener.MySession.Client.Send(oPacket);
            }
        }

        public static void SlotItem()
        {
            using (OutPacket oPacket = new OutPacket("LoRpGetRiderItemPacket"))
            {
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                oPacket.WriteInt(2);
                short Value = 0;
                for (short i = 1; i <= 2; i++)
                {
                    oPacket.WriteShort(7);
                    oPacket.WriteShort(i);
                    oPacket.WriteShort(0);
                    if (i == 1)
                    {
                        Value = SetRider.SlotChanger;
                    }
                    else
                    {
                        Value = NewRider.Value1;
                    }
                    oPacket.WriteShort(Value);
                    oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                    oPacket.WriteByte(0);
                    oPacket.WriteShort(-1);
                    oPacket.WriteShort(0);
                }
                RouterListener.MySession.Client.Send(oPacket);
            }
        }

        public static void RenameRid()
        {
            using (OutPacket oPacket = new OutPacket("LoRpGetRiderItemPacket"))
            {
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                oPacket.WriteShort(23);
                oPacket.WriteShort(1);
                oPacket.WriteShort(0);
                oPacket.WriteShort(NewRider.Value1);
                oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                oPacket.WriteByte(0);
                oPacket.WriteShort(-1);
                oPacket.WriteShort(0);
                RouterListener.MySession.Client.Send(oPacket);
            }
        }

        public static void ReplayTicket()
        {
            using (OutPacket oPacket = new OutPacket("LoRpGetRiderItemPacket"))
            {
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                oPacket.WriteShort(13);
                oPacket.WriteShort(1);
                oPacket.WriteShort(0);
                oPacket.WriteShort(NewRider.Value2);
                oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                oPacket.WriteByte(0);
                oPacket.WriteShort(-1);
                oPacket.WriteShort(0);
                RouterListener.MySession.Client.Send(oPacket);
            }
        }

        public static void LucciBag()
        {
            using (OutPacket oPacket = new OutPacket("LoRpGetRiderItemPacket"))
            {
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                oPacket.WriteInt(1);
                oPacket.WriteShort(23);
                oPacket.WriteShort(3);
                oPacket.WriteShort(0);
                oPacket.WriteShort(NewRider.Value2);
                oPacket.WriteByte((byte)((Program.PreventItem ? 1 : 0)));
                oPacket.WriteByte(0);
                oPacket.WriteShort(-1);
                oPacket.WriteShort(0);
                RouterListener.MySession.Client.Send(oPacket);
            }
        }
    }
}