using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proekt
{
    public class ImaVlog
    {
        public int vlog { get; set; }
        public string dugme { get; set; }

        public ImaVlog(int n, string dugme)
        {
            this.vlog = n;
            this.dugme = dugme;
        }
    }
}
