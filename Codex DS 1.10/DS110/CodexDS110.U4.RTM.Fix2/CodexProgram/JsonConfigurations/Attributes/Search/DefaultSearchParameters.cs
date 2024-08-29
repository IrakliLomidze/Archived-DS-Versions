using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILG.Codex.CodexR4.JsonConfigurations.Attributes.Search
{
    public class DefaultSearchParameters
    {
        public List<int> Status { get; set; }
        public List<int> AuthorAttributes { get; set; }
        public List<int> TypeAttributes { get; set; }

        public List<int> SubjectAttributes { get; set; }
        public List<int> CategoryAttributes { get; set; }

        public List<int> KeyWordsAttributes { get; set; }


        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }

        public String SearchText { get; set; }
        public bool IsInText { get; set; }
        public String DocumentNumber { get; set; }

        public String DocumentComments { get; set; }
        public String AdditianlAttributes { get; set; }


        public DefaultSearchParameters()
        {
            Status = new List<int>();
            AuthorAttributes = new List<int>();
            TypeAttributes = new List<int>();

            SubjectAttributes = new List<int>();
            CategoryAttributes = new List<int>();

            KeyWordsAttributes = new List<int>();

    }
}
}
