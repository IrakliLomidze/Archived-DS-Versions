using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG.Codex.CodexR4
{
    class CodexFont
    {
        public static bool isGeoABCInstalled()
        {
            var fontsCollection = new InstalledFontCollection();
            foreach (var fontFamiliy in fontsCollection.Families)
            {
                if (fontFamiliy.Name.Trim().ToUpper() == "GEOABC")
                    return true;
            }
            return false;
        }

        public static bool isGeo_ABCInstalled()
        {
            var fontsCollection = new InstalledFontCollection();
            foreach (var fontFamiliy in fontsCollection.Families)
            {
                if (fontFamiliy.Name.Trim().ToUpper() == "GEO ABC")
                    return true;
            }
            return false;
        }


        public static bool isCodexSylfaenFontsInstalled()
        {
            var fontsCollection = new InstalledFontCollection();
            foreach (var fontFamiliy in fontsCollection.Families)
            {
                if (fontFamiliy.Name.Trim().ToUpper() == "Syslfaen")
                    return true;
            }

            return false;

        }

        public static bool isCodexOtherFontsInstalled()
        {

            var fontsCollection = new InstalledFontCollection();
            foreach (var fontFamiliy in fontsCollection.Families)
            {
                if (fontFamiliy.Name.Trim().ToUpper() == "Baltica TD".ToUpper())
                    return true;
            }

            return false;

            //    bool result = false;

            //    try

            //    {
            //        string regval = Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\DevDiv\vc\Servicing\14.0\RuntimeMinimum", "Version", null).ToString();
            //        if (regval.Equals("14.0.23026"))
            //            result = true;
            //        else
            //            result = false;
            //    }
            //    catch
            //    {
            //        result = false;

            //    }
            //    return result;
            //}

        }



    }
}
