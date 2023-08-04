using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG.Codex.CodexR4.History
{
    public class HistoryListModelEntry
    {
        public int ID { get; set; }
        public string HistoryTitle { get; set; }
        public string Caption { get; set; }
        public int HistoryStatusField { get; set; }
        public int DocumentFormat { get; set; }
        public bool HasAttachment { get; set; }

    }

    public class HistoryListModel
    {
        public List<HistoryListModelEntry> Items = new List<HistoryListModelEntry>();
        public HistoryListModel()
        {
            Items = new List<HistoryListModelEntry>();
        }
    }

}
