// *************************************************************************************
// ** DS 1.10 New Configurations
// ** (C) Copyright By 2007-2023 By Irakli Lomidze
// *************************************************************************************
// ** Configurations
// ** Version 1.0
// Date 2023/02/27 


namespace DS.Config.Encryption
{
    internal class DSSymetricKey
    {
        public string Id { get; set; }
        public byte[] SecretKey { get; set; }
        public byte[] IV { get; set; }

        public DSSymetricKey()
        {
        }
    }
}
