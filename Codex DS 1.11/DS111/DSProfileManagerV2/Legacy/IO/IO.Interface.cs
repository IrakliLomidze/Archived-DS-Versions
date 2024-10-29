using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodexR4.Operations.Update.IO
{
    public interface ICodexUpdateIOCommon
    {
        void GenerateCUF(String OutputPath, bool TimeZoneConsidiration, ref bool isCorrected);
        void PickUpCUFProcess();
  
    }


}
