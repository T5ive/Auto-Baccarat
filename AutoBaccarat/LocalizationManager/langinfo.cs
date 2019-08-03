using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBaccarat
{
    public class LangInfo
    {
        public string Name { get; set; }

        public string File { get; set; }

        public string Version { get; set; }

        public string RightToLeft { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
