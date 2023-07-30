using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KartRider.IO;
using KartRider;
using ExcData;

namespace RiderData
{
    public static class RiderSchool
    {
        public static void PrStartRiderSchool()
        {
            using (OutPacket oPacket = new OutPacket("PrStartRiderSchool"))
            {
                oPacket.WriteByte(1);
                oPacket.WriteEncFloat(1f);
                oPacket.WriteEncInt(0);
                oPacket.WriteEncFloat(1f);
                oPacket.WriteEncInt(0);
                oPacket.WriteEncFloat(0f);
                oPacket.WriteEncByte(2);
                oPacket.WriteEncByte(2);
                oPacket.WriteEncByte(1);
                oPacket.WriteEncByte((byte)((true ? 1 : 0)));
                oPacket.WriteEncByte((byte)((false ? 1 : 0)));
                oPacket.WriteEncFloat(100f);
                oPacket.WriteFloat(3f);
                oPacket.WriteFloat(0.6990001f + SpeedPatch.DragFactor);
                oPacket.WriteFloat(2250f + SpeedPatch.ForwardAccelForce);
                oPacket.WriteFloat(1815f);
                oPacket.WriteEncFloat(2070f);
                oPacket.WriteEncFloat(1415f);
                oPacket.WriteEncFloat(10f);
                oPacket.WriteEncFloat(24.05f);
                oPacket.WriteEncFloat(5f);
                oPacket.WriteEncFloat(5f);
                oPacket.WriteEncFloat(0.2f);
                oPacket.WriteEncFloat(0.2f);
                oPacket.WriteEncFloat(0.2f);
                oPacket.WriteEncFloat(2750f + SpeedPatch.DriftEscapeForce);
                oPacket.WriteEncFloat(0.225f + SpeedPatch.CornerDrawFactor);
                oPacket.WriteEncFloat(0.07f);
                oPacket.WriteEncFloat(0.01f);
                oPacket.WriteEncFloat(4300f + SpeedPatch.DriftMaxGauge);
                oPacket.WriteEncFloat(3000f);
                oPacket.WriteEncFloat(3000f);
                oPacket.WriteEncFloat(4500f);
                oPacket.WriteEncFloat(4000f);
                oPacket.WriteEncFloat(3500f);
                oPacket.WriteEncFloat(1.4955f + SpeedPatch.TransAccelFactor);
                oPacket.WriteEncFloat(1.494f + SpeedPatch.BoostAccelFactor);
                oPacket.WriteEncFloat(1000f);
                oPacket.WriteEncFloat(1000f);
                oPacket.WriteEncFloat(2250f + SpeedPatch.StartForwardAccelForceItem);
                oPacket.WriteEncFloat(2250f + SpeedPatch.StartForwardAccelForceSpeed);
                oPacket.WriteEncFloat(0f);
                oPacket.WriteEncByte((byte)((false ? 1 : 0)));
                oPacket.WriteEncFloat(1.5f);
                oPacket.WriteEncFloat(0f);
                oPacket.WriteEncFloat(1f);
                RouterListener.MySession.Client.Send(oPacket);
            }
        }
    }
}