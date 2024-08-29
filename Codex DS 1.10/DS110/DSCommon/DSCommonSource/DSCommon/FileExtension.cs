// *************************************************************************************
// ** DS 1.10 
// ** (C) Copyright By 2007-2023 By Irakli Lomidze
// *************************************************************************************
// ** Date: 2023-04-05
// ** Version 1.1


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG.DS.IO
{
    public static class DSFile
    {
        public static void DeleteIfExists(string FileName)
        {
            if (File.Exists(FileName) == true) File.Delete(FileName);
        }
    }
}
