using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kartastrof.Classes
{
    public class DatabaseInit
    {
        public DatabaseInit()
        {

        }
    }

    public class FileReader   {
        private string file;

        public FileReader()
        {
        }

        public void ReadFile(string file)    {
             this.file = file;
        }
    }
}