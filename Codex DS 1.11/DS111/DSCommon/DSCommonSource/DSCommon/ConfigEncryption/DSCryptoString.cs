// *************************************************************************************
// ** DS 1.10 New Configurations
// ** (C) Copyright By 2007-2023 By Irakli Lomidze
// *************************************************************************************
// ** Configurations
// ** Version 1.0
// Date 2023/02/27 
// Date 2023/03/07



using System;
using System.Globalization;
using System.Text;

namespace DS.Config.Encryption
{
    public class DSConfigCryptoString
    {
        private byte[] _data;
        private int _size;
        private string _datastring;

        private static readonly string Header1 = "DS::CRYPT::STR0000";
        private static readonly string Header2 = "DS::CRYPT::STR";

        public DSConfigCryptoString(string inputString)
        {
            if (ParseCryptoString(inputString) == false)
                throw new Exception("WRONG DS Crypto String");
            _datastring = inputString;
        }



        private bool ParseCryptoString(string str)
        {
            if (str.Length < 14) return false;
            if (str.Substring(0, Header2.Length).ToLower() != Header2.ToLower()) return false;

            string v = $"{str.Substring(Header2.Length, 4).ToLower()}";

            int result = 0;
            if (int.TryParse($"{str.Substring(Header2.Length, 4).ToLower()}", NumberStyles.HexNumber, CultureInfo.InvariantCulture, out result) == false) return false;
            if (str.Length != Header1.Length + result * 2) return false;


            int size_x = (Convert.ToInt32($"0x{str.Substring(Header2.Length, 4).ToLower()}", 16));


            string sub = str.Substring(Header1.Length, str.Length - Header1.Length);
            if ((sub.Length % 2) != 0) return false;
            int _size = sub.Length / 2;

            if (size_x != _size) return false;

            _data = new byte[size_x];
            this._size = _size;

            for (int i = 0; i < size_x; i++)
            {
                try
                {
                    _data[i] = Convert.ToByte($"0x{sub.Substring(i * 2, 2)}", 16);
                }
                catch
                {
                    return false;
                }
            }

            return true;
        }



        private void GenerateString()
        {
            string _datastring = $"DS_{String.Format("{0:X4}", _data.Length).ToLower()}_";
            foreach (var b in _data)
            {
                _datastring = _datastring + String.Format("{0:X2}", b).ToLower();
            }
        }
        override public string ToString()
        {
            return _datastring;
        }

        public byte[] GetBytes()
        {
            return _data;
        }

        public int GetSize()
        {
            return _size;

        }

        public static string ByteArrayToDSConfigString(byte[] buffer)
        {
            string header = $"{Header2}{String.Format("{0:X4}", buffer.Length).ToLower()}";
            foreach (var b in buffer)
            {
                header = header + String.Format("{0:X2}", b).ToLower();
            }

            return header;
        }



        public static string EncodeString(string inputstring)
        {
            foreach (var c in inputstring) if (c > 0xFF) return "";
            string _datastring = $"{Header2}{String.Format("{0:X4}", inputstring.Length).ToUpper()}";
            StringBuilder builder = new StringBuilder();

            foreach (var b in inputstring)
            {
                builder.Append(Convert.ToByte(b).ToString("x2").ToUpper());
            }

            return _datastring + builder.ToString();
        }

        public static string DecodeString(string inputstring)
        {

            inputstring = inputstring.ToUpper().Trim();
            if (inputstring.Length < 12) return "";
            if (inputstring.StartsWith(Header2) == false) return "";
            string v = $"{inputstring.Substring(Header2.Length, 4).ToUpper()}";




            int result = 0;
            if (int.TryParse($"{inputstring.Substring(Header2.Length, 4).ToUpper()}", NumberStyles.HexNumber, CultureInfo.InvariantCulture, out result) == false) return "";
            if (inputstring.Length != Header1.Length + result * 2) return "";



            string sx = inputstring.Substring(Header1.Length, inputstring.Length - Header1.Length);


            int size_x = (Convert.ToInt32($"0x{inputstring.Substring(Header2.Length, 4).ToUpper()}", 16));



            StringBuilder cb = new StringBuilder();
            byte _data = 0;
            for (int i = 0; i < size_x; i++)
            {
                try
                {
                    _data = Convert.ToByte($"0x{sx.Substring(i * 2, 2)}", 16);
                    cb.Append(((char)(_data)).ToString());
                }
                catch
                {
                    return "";
                }
            }

            return cb.ToString();
        }





    }




}

