using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG.Codex.CodexR4
{
    public static class CodexFile
    {
        public static void DeleteIfExists(string FileName)
        {
            if (File.Exists(FileName) == true) File.Delete(FileName);
        }
    }
}
