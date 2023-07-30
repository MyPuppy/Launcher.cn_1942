using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KartRider.IO;
using System.Net;
using Set_Data;

namespace KartRider
{
    public static class GameSupport
    {
        public static void PcFirstMessage()
        {
            uint first_val = 2919676295;
            uint second_val = 263300380;
            using (OutPacket outPacket = new OutPacket("PcFirstMessage"))
            {
                outPacket.WriteUShort(SessionGroup.usLocale);
                outPacket.WriteUShort(1);
                outPacket.WriteUShort(Program.Version);
                outPacket.WriteString("http://kart.dn.nexoncdn.co.kr/patch");
                outPacket.WriteUInt(first_val);
                outPacket.WriteUInt(second_val);
                outPacket.WriteByte(SessionGroup.nClientLoc);
                outPacket.WriteString("QyvKvO60jogWDupzJ7gm0kRQdooFjWRjSjlq0gu/x2k=");
                outPacket.WriteHexString("00 00 00 00 00 00 00 00 0F 00 00 00 00 00 00 00 00 2E 31 2E 31 37 2E 36 00 00 00 00 00 00 00");
                outPacket.WriteString("GXQstj1A95XiHvjrOGuPkzdyL+7qxETl/cPlUZk2KA4=");
                RouterListener.MySession.Client.Send(outPacket);
            }
            RouterListener.MySession.Client._RIV = first_val ^ second_val;
            RouterListener.MySession.Client._SIV = first_val ^ second_val;
        }

        public static void OnDisconnect()
        {
            RouterListener.MySession.Client.Disconnect();
        }

        public static void SpRpLotteryPacket()
        {
            using (OutPacket outPacket = new OutPacket("SpRpLotteryPacket"))
            {
                outPacket.WriteHexString("05 00 00 00 00 00 00 00 FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00");
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void ChRpEnterMyRoomPacket()
        {
            if (GameType.EnterMyRoomType == 0)
            {
                using (OutPacket outPacket = new OutPacket("ChRpEnterMyRoomPacket"))
                {
                    outPacket.WriteString(SetRider.Nickname);
                    outPacket.WriteByte(0);
                    outPacket.WriteShort(SetMyRoom.MyRoom);
                    outPacket.WriteByte(SetMyRoom.UseRoomPwd);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(SetMyRoom.UseItemPwd);
                    outPacket.WriteString(SetMyRoom.RoomPwd);
                    outPacket.WriteString("");
                    outPacket.WriteString(SetMyRoom.ItemPwd);
                    outPacket.WriteShort(SetMyRoom.MyRoomKart1);
                    outPacket.WriteShort(SetMyRoom.MyRoomKart2);
                    RouterListener.MySession.Client.Send(outPacket);
                }
            }
            else
            {
                using (OutPacket outPacket = new OutPacket("ChRpEnterMyRoomPacket"))
                {
                    outPacket.WriteString("");
                    outPacket.WriteByte(GameType.EnterMyRoomType);
                    outPacket.WriteShort(0);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(0);
                    outPacket.WriteByte(1);
                    outPacket.WriteString("");//RoomPwd
                    outPacket.WriteString("");
                    outPacket.WriteString("");//ItemPwd 
                    outPacket.WriteShort(0);
                    outPacket.WriteShort(0);
                    RouterListener.MySession.Client.Send(outPacket);
                }
            }
        }

        public static void RmNotiMyRoomInfoPacket()
        {
            using (OutPacket outPacket = new OutPacket("RmNotiMyRoomInfoPacket"))
            {
                outPacket.WriteShort(SetMyRoom.MyRoom);
                outPacket.WriteByte(SetMyRoom.UseRoomPwd);
                outPacket.WriteByte(0);
                outPacket.WriteByte(SetMyRoom.UseItemPwd);
                outPacket.WriteString(SetMyRoom.RoomPwd);
                outPacket.WriteString("");
                outPacket.WriteString(SetMyRoom.ItemPwd);
                outPacket.WriteShort(SetMyRoom.MyRoomKart1);
                outPacket.WriteShort(SetMyRoom.MyRoomKart2);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrGetRiderInfo()
        {
            using (OutPacket outPacket = new OutPacket("PrGetRiderInfo"))
            {
                outPacket.WriteByte(1);
                outPacket.WriteUInt(SetRider.UserNO);
                outPacket.WriteString(SetRider.UserID);
                outPacket.WriteString(SetRider.Nickname);
                outPacket.WriteHexString("3C 9A 17 43");//2008.02.08
                for (int i = 1; i <= Program.MAX_EQP_P; i++)
                {
                    outPacket.WriteShort(0);
                }
                outPacket.WriteByte(0);
                outPacket.WriteString("");
                outPacket.WriteInt(SetRider.RP);
                outPacket.WriteBytes(new byte[29]);
                outPacket.WriteShort(SetRider.Emblem1);
                outPacket.WriteShort(SetRider.Emblem2);
                outPacket.WriteShort(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteString(SetRider.RiderIntro);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                outPacket.WriteInt(0);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void ChRequestChStaticReplyPacket()
        {
            using (OutPacket outPacket = new OutPacket("ChRequestChStaticReplyPacket"))
            {
                outPacket.WriteHexString("01 AA 02 00 00 53 01 63 BC C0 03 21 0B 00 00 78 DA 8D 55 69 4F DB 40 10 7D 25 84 1C 24 76 9C FB E4 3E D3 86 0F FC 03 1B 4A 85 D4 F6 43 E9 F7 0A 9A 40 51 43 40 49 2A DA 7F DF 99 5D 9C D8 CE F8 90 A5 59 7B DE 9B B7 BB B3 EB 99 01 80 5C 91 CC 0C 2F 18 D1 33 C4 35 26 64 1F 71 85 5B F2 CE B1 96 25 F8 91 5E 46 78 C2 77 B2 B7 34 A6 BC 4E 37 62 BD 20 30 5D 99 74 41 88 70 C1 8D 9C 6F 09 6E 6C 26 27 AE 2C 5B 14 D9 AE 58 BE 14 09 8F 94 DD 2C 45 6E 5A 93 0A 56 02 A5 73 14 AD 04 5A E7 30 0C 21 3D 5F 69 7C C5 1D F9 47 30 0D 21 45 5E 42 C9 14 D7 E3 A5 58 A6 B8 16 2F A5 CC 59 7D C0 1F FA 18 2B 50 4F 58 C9 FB DC 4B 8D 2A 4B FE C4 2F 35 D7 0B C1 CF 24 3A C3 97 C5 F6 A6 A8 19 22 E5 1B 8D FF C8 37 46 7D 83 08 77 F4 3A A7 67 4C 31 8D 75 E5 78 26 D6 0C 4D 46 EF E9 E3 89 A6 1F 13 AB 95 55 0E 7E 7D 58 6C B3 ED 75 BA 1B EB F0 AA E7 6F 8C CF 6A E4 3D 8C D0 95 0F 98 C7 7B 1A 27 6A DF 3D F9 AA F8 49 5B 79 E1 DC 3E 51 D0 B6 25 00 1F 29 4A 67 62 42 08 D3 76 36 C5 49 18 DA 35 23 2F 18 53 F6 CA 09 EE 20 13 F7 0D 75 7E 53 35 F3 90 1C 53 5A DB 5F FC 58 AC F0 C0 0C 21 2C D5 0F AD B7 53 F9 4D 96 8F 42 BF 5F 07 EE E4 51 34 CD 5D E3 71 59 A4 DD AC 1C CA 49 1C D1 55 3C 95 6F F7 8D CA F7 90 82 5E D1 97 53 EA A5 BC AF C7 AA F8 6F C0 87 7A AC A6 3F 60 90 A1 80 B1 4A 87 AB 7E B6 74 B9 F1 7D F2 BC 83 54 5E D7 C0 75 19 49 0A 19 5F 4E E2 4B F5 38 C5 50 0A 51 55 99 FF 42 32 51 B5 39 CD 94 34 A2 6B 2E 4F 8F 0D 44 77 12 AE 3B C8 C0 88 54 B2 B5 56 36 40 0B 6A 39 5A 2D 8F 24 75 9C 7F 40 32 C9 AA 39 E7 82 4C B2 9A CE 1B 26 53 4E A4 6C 6B 6D 23 40 0F D3 76 B4 BA 89 24 95 AC CB D4 12 92 D4 B3 1E 53 AD 90 0D FA A9 B6 D6 2D 87 A4 CE 4F 76 B4 72 05 99 40 AD B7 C1 FF 0F AA 2B 80 A3 81 1A E2 3A 23 E3 C4 8D EB 8F FC EB A3 81 F8 2E C9 69 42 13 F1 BD 92 F7 8D 16 E4 8E C9 C7 88 36 C2 FA 66 85 E1 0E E2 BB 67 95 89 5D C4 F5 D0 1A D3 7A 2B 49 BC D2 49 DC 82 B7 A3 36 D8 B5 8D 60 5F 6D B2 7B 07 52 77 6D 31 B4 0B A9 C7 B6 19 DA 43 58 A7 ED 30 BC AF 22 FD 25 CF C6 80 A1 03 01 72 34 74 28 40 17 1A 3A 12 A0 4B 0D 1D 7B 20 77 F9 36 CE 18 3A 11 20 47 43 A7 02 74 A1 A1 BE 00 5D 6A E8 3F 0E E1 BC 64");
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrDynamicCommand()
        {
            using (OutPacket outPacket = new OutPacket("PrDynamicCommand"))
            {
                outPacket.WriteByte(0);
                outPacket.WriteInt(0);
                RouterListener.MySession.Client.Send(outPacket);
            }
        }

        public static void PrLogin()
        {
            using (OutPacket outPacket = new OutPacket("PrLogin"))
            {
                outPacket.WriteInt(0);
                outPacket.WriteHexString(Program.DataTime);
                outPacket.WriteUInt(SetRider.UserNO);
                outPacket.WriteString(SetRider.UserID);
                outPacket.WriteByte(255);
                outPacket.WriteByte(0);
                outPacket.WriteByte(0);
                outPacket.WriteInt(0);
                outPacket.WriteByte(0);
                outPacket.WriteInt(1415577599);
                outPacket.WriteUInt(SetRider.pmap);
                for (int i = 0; i < 18; i++)
                {
                    outPacket.WriteInt(0);
                }
                RouterListener.MySession.Client.Send(outPacket);
            }
        }
    }
}