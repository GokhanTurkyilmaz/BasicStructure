using System;
using System.Collections.Generic;
using System.Text;

namespace AllDevice.UHFDevice.Models
{
    public class Tag
    {
        public Tag()
        {
            epcid = new byte[12];
        }
        public Tag(int epcLength)
        {
            epcid = new byte[epcLength];
        }
        public Tag(byte[] epc, int rcnt, short rssi, int id)
        {
            epcid = epc;
            readcnt = rcnt;
            rxrssi = rssi;
            antID = id;
        }
        public short pc;
        public byte[] epcid;
        public string tid;
        public int readcnt;
        public short rxrssi;
        public int antID;
        public DateTime parseTime;

        public String GetAsLabel()
        {
            return String.Format("TAG |epcid:{0} |readcnt:{1} |rxrssi:{2} |antID:{3} |time:{4}", BitConverter.ToString(epcid) + tid, readcnt, rxrssi, antID, parseTime);
        }
    }
}
