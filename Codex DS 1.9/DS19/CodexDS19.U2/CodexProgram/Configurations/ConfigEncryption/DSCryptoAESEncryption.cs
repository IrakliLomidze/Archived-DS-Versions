// *************************************************************************************
// ** DS 1.10 New Configurations
// ** (C) Copyright By 2007-2023 By Irakli Lomidze
// *************************************************************************************
// ** Configurations
// ** Version 1.0
// Date 2023/02/27 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

namespace DS.Config.Encryption
{
    internal class DSCryptoAESEncryption
    {
        private static byte[] EncryptStringToBytes_Aes(byte[] data, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (data == null || data.Length <= 0)
                throw new ArgumentNullException("input");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Mode = CipherMode.CBC;

                aesAlg.KeySize = 256;
                aesAlg.BlockSize = 128;
                aesAlg.FeedbackSize = 128;
                aesAlg.Padding = PaddingMode.Zeros;

                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(data, 0, data.Length);
                        csEncrypt.FlushFinalBlock();


                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return encrypted;
        }
        private static byte[] DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            byte[] plaindata = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.KeySize = 256;
                aesAlg.BlockSize = 128;
                aesAlg.FeedbackSize = 128;
                aesAlg.Padding = PaddingMode.Zeros;

                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write))
                    {
                        csDecrypt.Write(cipherText, 0, cipherText.Length);
                        csDecrypt.FlushFinalBlock();


                        plaindata = msDecrypt.ToArray();
                    }
                }
            }


            return plaindata;
        }

        private byte[] FromHexString(string hexstring)
        {
            hexstring = hexstring.Trim().ToLower();
            if ((hexstring.Length % 2) != 0) throw new Exception("Bad Format for Key");
            int size_x = hexstring.Length / 2;
            byte[] _data = new byte[size_x];


            for (int i = 0; i < size_x; i++)
            {
                try
                {
                    _data[i] = Convert.ToByte($"0x{hexstring.Substring(i * 2, 2)}", 16);
                }
                catch
                {
                    throw new Exception($"A bad character in the hex string key at {(i * 2)}");
                }
            }
            return _data;
        }


        public String AESEncryptString(String inputString, byte[] keystr, byte[] IVstr)
        {

            if (inputString == null || inputString.Length == 0)
                throw new ArgumentNullException("input");


            if (keystr.Length != 32) throw new ArgumentException("Wrong Key Size hex string");


            if (IVstr.Length != 16) throw new ArgumentException("Wrong IV Size hex string");


            byte[] Key = keystr;
            byte[] IV = IVstr;
            byte[] input = Encoding.UTF8.GetBytes(inputString);

            byte[] result = EncryptStringToBytes_Aes(input, Key, IV);


            return DSConfigCryptoString.ByteArrayToDSConfigString(result);
        }

        public String AESDecryptString(String inputString, byte[] keystr, byte[] IVstr)
        {

            if (keystr.Length != 32) throw new ArgumentException("Wrong Key Size hex string");


            if (IVstr.Length != 16) throw new ArgumentException("Wrong IV Size hex string");


            DSConfigCryptoString c = new DSConfigCryptoString(inputString);

            byte[] endata = c.GetBytes();
            byte[] Key = keystr;
            byte[] IV = IVstr;


            byte[] result = DecryptStringFromBytes_Aes(endata, Key, IV);

            int size_x = c.GetSize();

            string str = "";
            for (int i = 0; (i < result.Length) && (i < size_x); i++)
            {
                str += Convert.ToChar(result[i]);
            }

            str = str.Replace("\0", string.Empty);

            return str;

        }
    }


}
