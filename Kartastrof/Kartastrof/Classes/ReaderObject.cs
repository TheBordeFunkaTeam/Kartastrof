using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kartastrof.Classes
{

    public class ReaderObject
    {
        public string CountryName;
        public string CapitalName;
        public string CapitalLatitude;
        public string CapitalLongitude;
        public string CountryCode;
        public string ContinentName;

        public ReaderObject() {

        }

    }

    public class ReaderObjectList
    {
        public List<ReaderObject> ListWithReaderObjects;

        public ReaderObjectList()   {
            this.ListWithReaderObjects = new List<ReaderObject>();
        }
    }
}