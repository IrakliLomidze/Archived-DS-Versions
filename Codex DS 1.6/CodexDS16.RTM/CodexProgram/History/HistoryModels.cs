using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG.Codex.CodexR4.History
{
    public class HistoryMenuModelEntry
    {
        public int ID { get; set; }
        public string Caption { get; set; }
    }

    public class HistoryMenuModel
    {
        public List<HistoryMenuModelEntry> Items = new List<HistoryMenuModelEntry>();
        public HistoryMenuModel()
        {
            Items = new List<HistoryMenuModelEntry>();
        }
    }

}
