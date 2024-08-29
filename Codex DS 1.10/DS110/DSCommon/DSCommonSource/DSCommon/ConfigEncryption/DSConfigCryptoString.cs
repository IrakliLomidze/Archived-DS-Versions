// *************************************************************************************
// ** DS 1.10 New Configurations
// ** (C) Copyright By 2007-2023 By Irakli Lomidze
// *************************************************************************************
// ** Configurations
// ** Version 1.0
// Date 2023/02/27 


using System;
using System.Security.Cryptography;
using System.Text;

namespace DS.Config.Encryption
{
    public class DSCryptoString
    {

        private static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string HashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString().ToUpper();
        }

        public static string EncryptString(string inputString)
        {
            var random = new Random(Seed: DateTime.Now.Millisecond);
            var Index = random.Next(0, 127);
            DSSymetricKeystrictconfRange keys = new DSSymetricKeystrictconfRange();
            string keyiddshash = HashString(HashString(keys.KeyList[Index].Id.ToString()));
            DSCryptoAESEncryption en = new DSCryptoAESEncryption();
            return (en.AESEncryptString(inputString, keys.KeyList[Index].SecretKey, keys.KeyList[Index].IV) +
                keyiddshash).ToUpper();
        }

        public static string DecryptString(string inputString)
        {
            if (string.IsNullOrEmpty(inputString)) throw new Exception("String could not be empty");
            if (inputString.Length <= 64) throw new Exception("String is too short");
            string h = inputString.Substring(inputString.Length - 64, 64);
            DSSymetricKeystrictconfRange keys = new DSSymetricKeystrictconfRange();
            int Index = -1;
            for (int i = 0; i < keys.KeyList.Count; i++)
            {
                if (h == HashString(HashString(keys.KeyList[i].Id.ToString())))
                {
                    Index = i; break;
                }
            }
            if (Index == -1) throw new Exception("Wrong Strict String");
            string s = inputString.Substring(0, inputString.Length - 64);
            DSCryptoAESEncryption en = new DSCryptoAESEncryption();
            return en.AESDecryptString(s, keys.KeyList[Index].SecretKey, keys.KeyList[Index].IV);
        }
    }
}