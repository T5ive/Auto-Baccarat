using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBaccarat
{
    public class CustomInfo
    {
        public string Name { get; set; }

        public string File { get; set; }
        
        public override string ToString()
        {
            return Name;
        }
    }
}