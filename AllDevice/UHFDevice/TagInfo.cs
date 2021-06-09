using AllDevice.UHFDevice.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AllDevice.UHFDevice
{
    public class TagInfo
    {
        public string EpcId { get; set; }
        public int ReadCount { get; set; }
        public short Rxrssi { get; set; }
        public int AntennaID { get; set; }
        public DateTime ReadTime { get; set; }
        public DateTime LoggedTime { get; set; }
        public String DeviceIp { get; set; }

        public TagInfo()
        {

        }

        public TagInfo(Tag tag)
        {
            EpcId = BitConverter.ToString(tag.epcid);
            ReadCount = 1;
            Rxrssi = tag.rxrssi;
            AntennaID = tag.antID;
            ReadTime = tag.parseTime;
        }

        public String GetAsLabel()
        {
            return String.Format("TAG |epcid:{0} |readcnt:{1} |rxrssi:{2} |antID:{3} |time:{4}", EpcId, ReadCount, Rxrssi, AntennaID, ReadTime);
        }
    }
}
