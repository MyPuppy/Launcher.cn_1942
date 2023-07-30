using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KartRider;
using KartRider.IO;
using RiderData;

namespace ExcData
{
    public static class KartExcData
    {
        public static void Kart_ExcData()
        {
            int TuneCount = NewRider.Kart_Old_Cut;
            int PlantCount = NewRider.Kart_Old_Cut;
            int KartLevelCount = NewRider.Kart_Old_Cut;
            short KartSN = Launcher.KartOld_SN;

            if (Program.UseKartTune)
            {
                using (OutPacket oPacket = new OutPacket("LoRpGetRiderExcDataPacket"))
                {
                    oPacket.WriteByte(1);
                    oPacket.WriteByte(0);
                    oPacket.WriteByte(0);
                    oPacket.WriteInt(TuneCount);
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
                            oPacket.WriteShort(KartSN);
                            oPacket.WriteShort(0);
                            oPacket.WriteShort(0);
                            oPacket.WriteShort(603);
                            oPacket.WriteShort(703);
                            oPacket.WriteShort(903);
                            oPacket.WriteShort(0);
                            oPacket.WriteShort(0);
                            oPacket.WriteShort(0);
                            oPacket.WriteShort(0);
                        }
                    }
                    oPacket.WriteInt(0);
                    oPacket.WriteInt(0);
                    RouterListener.MySession.Client.Send(oPacket);
                }
            }
            if (Program.UseKartPlant)
            {
                using (OutPacket oPacket = new OutPacket("LoRpGetRiderExcDataPacket"))
                {
                    oPacket.WriteByte(0);
                    oPacket.WriteByte(1);
                    oPacket.WriteByte(0);
                    oPacket.WriteInt(0);
                    oPacket.WriteInt(PlantCount);
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
                            oPacket.WriteShort(i);
                            oPacket.WriteShort(KartSN);
                            oPacket.WriteInt(4);
                            oPacket.WriteShort(43);
                            oPacket.WriteShort(23);
                            oPacket.WriteShort(44);
                            oPacket.WriteShort(2);
                            oPacket.WriteShort(45);
                            oPacket.WriteShort(23);
                            oPacket.WriteShort(46);
                            oPacket.WriteShort(1);
                        }
                    }
                    oPacket.WriteInt(0);
                    RouterListener.MySession.Client.Send(oPacket);
                }
            }
            if (Program.UseKartLevel)
            {
                using (OutPacket oPacket = new OutPacket("LoRpGetRiderExcDataPacket"))
                {
                    oPacket.WriteByte(0);
                    oPacket.WriteByte(0);
                    oPacket.WriteByte(1);
                    oPacket.WriteInt(0);
                    oPacket.WriteInt(0);
                    oPacket.WriteInt(KartLevelCount);
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
                            oPacket.WriteShort(i);
                            oPacket.WriteShort(KartSN);
                            oPacket.WriteShort(5);
                            oPacket.WriteShort(0);
                            oPacket.WriteShort(10);
                            oPacket.WriteShort(5);
                            oPacket.WriteShort(10);
                            oPacket.WriteShort(10);
                            if (i <= 292 || i == 358 || i == 420 || i == 501 || i == 837 || i == 838 || i == 843 || i == 845 || i == 847 || i == 853 ||
                                i == 856 || i == 863 || i == 873 || i == 880)
                            {
                                oPacket.WriteShort(0);
                            }
                            else
                            {
                                oPacket.WriteShort(6); //코팅
                            }
                        }
                    }
                    RouterListener.MySession.Client.Send(oPacket);
                }
            }
        }
    }
}