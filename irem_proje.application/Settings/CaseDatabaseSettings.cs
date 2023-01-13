using irem_proje.application.Settings.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace irem_proje.application.Settings
{
    public class CaseDatabaseSettings : ICaseDatabaseSettings
    {
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
    }
}
