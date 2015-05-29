using System;
using System.Collections;
using System.Linq;
using System.Web;

namespace Kartastrof.Models
{
    public class CapitalInfo
    {
        public int pageid { get; set; }
        public int ns { get; set; }
        public string title { get; set; }
        public string extract { get; set; }

        public ArrayList clues = new ArrayList();

        public CapitalInfo()
        {
        }
    }
}