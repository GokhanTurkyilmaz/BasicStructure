using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AllDevice.UHFDevice.CommandsPackage
{
    public class CalculateCommands
    {
        ArrayList arraylist = new ArrayList();
        public T[] ConcatArrays<T>(params T[][] args)////////For Array Copy//////////////
        {
            if (args == null)
                throw new ArgumentNullException();

            var offset = 0;
            var newLength = args.Sum(arr => arr.Length);
            var newArray = new T[newLength];

            foreach (var arr in args)
            {
                Buffer.BlockCopy(arr, 0, newArray, offset, arr.Length);
                offset += arr.Length;
            }

            return newArray;
        }
        public byte[] ConvertHexStringToByteArray(string hexString)
        {
            //if (hexString.Length % 2 != 0)
            //{
            //    throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            //}

            byte[] data = new byte[hexString.Length / 2];
            for (int index = 0; index < data.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return data;
        }
        public string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();

        }
        public byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }
        public string FromHextoAsciString(string hexString)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hexString.Length; i += 2)
            {
                string hs = hexString.Substring(i, 2);
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hexString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
            }

            return sb.ToString();
        }
        public byte[] HexStringToByteArray2(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        //public byte[] getIpBytesFromMaskedText(MaskedTextBox txt)
        //{
        //    return IPAddress.Parse(txt.Text
        //        .Replace(" ", "")//Boşluk varsa boşluksuz yapar
        //        .Replace(",", ".")//, varsa . yap
        //        .Replace("_", "")).GetAddressBytes();//_ varsa sil boşluksuz yap.
        //}
        public int CheckCRC(string s)
        {
            int i, j;
            int current_crc_value;
            byte crcL, crcH;
            byte[] data = HexStringToByteArray(s);
            current_crc_value = 0xFFFF;
            for (i = 0; i <= (data.Length - 1); i++)
            {
                current_crc_value = current_crc_value ^ (data[i]);
                for (j = 0; j < 8; j++)
                {
                    if ((current_crc_value & 0x01) != 0)
                        current_crc_value = (current_crc_value >> 1) ^ 0x8408;
                    else
                        current_crc_value = (current_crc_value >> 1);
                }
            }
            crcL = Convert.ToByte(current_crc_value & 0xFF);
            crcH = Convert.ToByte((current_crc_value >> 8) & 0xFF);

            return current_crc_value;

        }
        public string DecToHex(int x)
        {
            string result = " ";

            while (x != 0)
            {
                if ((x % 16) < 10)
                    result = x % 16 + result;
                else
                {
                    string temp = "";

                    switch (x % 16)
                    {
                        case 10: temp = "A"; break;
                        case 11: temp = "B"; break;
                        case 12: temp = "C"; break;
                        case 13: temp = "D"; break;
                        case 14: temp = "E"; break;
                        case 15: temp = "F"; break;
                    }

                    result = temp + result;
                }

                x /= 16;
            }

            return result;
        }
        public byte[] CRCMethod(byte[] byt)
        {
            string tem;
            tem = ByteArrayToHexString(byt);
            int a;
            byte[] b;
            a = Convert.ToInt32(CheckCRC(tem));
            b = HexStringToByteArray(DecToHex(a));
            foreach (byte item in b)
            {
                arraylist.Add(item);
            }
            int y1, y2;
            y1 = arraylist.Count - 1;
            y2 = arraylist.Count - 2;
            byte[] m1 = { Convert.ToByte(arraylist[y1]) };
            byte[] m2 = { Convert.ToByte(arraylist[y2]) };
            byte[] calculetedCommand = ConcatArrays(byt, m1, m2);
            return calculetedCommand;
        }
    }
}
