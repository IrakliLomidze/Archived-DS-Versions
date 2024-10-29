// Copyright (c) Georgian Microsystems. All rights reserved.
// Version 7.0.100.300
// Modofication Date: 2017.04.09

using ILG.Codex.Cryptography.CodexSafeModule;
using System;
using System.IO;

namespace ILG.Codex.CodexR4.Updater.Live.Update
{
     
    public enum UpdateCOFType
    {
        CUF_Codex = 1,
        CUF_CGL = 2,
        CUF_ICG = 3
    }

    public static class UpdateCOFTypeExtensions
    {
        public static string ToCodexAppName(this UpdateCOFType me)
        {
            switch (me)
            {
                case UpdateCUFType.CUF_Codex:
                    return "Codex";
                case UpdateCUFType.CUF_CGL:
                    return "CGL";
                case UpdateCUFType.CUF_ICG:
                    return "ICG";
                default:
                    return String.Empty;
            }
        }
        public static int Length(this UpdateCUFType me)
        {
            return Enum.GetNames(typeof(UpdateCUFType)).Length;
        }
    }



    class COFFile
    {
        private UpdateCOFType _cufType;
        public COFFile(UpdateCUFType cufType)
        {
            _cufType = cufType;
        }

        public string GetXMLFileNameinZip()
        {
            string result = "";
            switch (_cufType)
            {
                case UpdateCUFType.CUF_Codex: result = "Data_Codex.xml"; break;
                case UpdateCUFType.CUF_CGL: result = "Data_Cgl.xml"; break;
                case UpdateCUFType.CUF_ICG: result = "Data_icg.xml"; break;
            }
            return result;
        }
       
    }

    class COF2007 : ICUF
      {
        private string _cofFileName;
        private string _TemporaryDirectory;
        private COFFile _cufrepo;

        public COF2007(string cofFilename, UpdateCUFType cufType  )
        {
            _TemporaryDirectory = Properties.Settings.Default.TemporaryDir;
            _cofFileName = cofFilename;
            _cofrepo = new COFFile(cufType);
        }

        public bool CheckIfItCUF()
        {
            BinaryReader br;
            if (File.Exists(_cufFileName) == false) return false;
            br = new BinaryReader(File.Open(_cufFileName, FileMode.Open, System.IO.FileAccess.Read));

            bool res = false;
            try
            {
                CUFHeader h = new CUFHeader(0, 0, 0, 0, System.DateTime.Now);
                h.read(br);

                if ((h.Suffix[0] == 0x43) && (h.Suffix[1] == 0x55) && (h.Suffix[2] == 0x46)) res = true;

            }
            catch //(System.Exception ex)
            {
                res = false;
            }
            finally
            {
                br.Close();
            }

            return res;

        }
        
        private String GetTempFileName()
        {
            String TempFilename = "";
            do
            {
                TempFilename = Path.Combine(_TemporaryDirectory, Path.GetRandomFileName());
            }
            while (File.Exists(TempFilename));
            return TempFilename;
        }

        public bool COF2XML(string _outxmlfile) //PickCUFFile
        {
            if (File.Exists(_cufFileName) == false) { return false; }

            fs = new FileStream(_cufFileName, FileMode.Open, FileAccess.Read);
        

            String Temp_zip = GetTempFileName();
            try
            {
                c.IDEADecrypt(Temp_enc, Temp_zip, _cufrepo.GetKey(), "");
            }
            catch //(System.Exception ex)
            { return false; }
            finally
            {
                CodexFile.DeleteIfExists(Temp_enc);
            }
    
            // Unzip That File
            try
            {
                CodexZip.UnZip(Temp_zip,
                               _cufrepo.GetXMLFileNameinZip(),// "Data_icg.xml", 
                               Path.Combine( _TemporaryDirectory, _cufrepo.GetXMLFileNameinZip()));
            }
            catch //(System.Exception ex)
            { return false; }

            CodexFile.DeleteIfExists(Temp_zip);
        
            return true;
        }

    
    }
}
