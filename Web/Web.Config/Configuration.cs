using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Logger;

namespace Web.Ioc
{
    public class Configuration
    {
        public bool UseLogger { get; set; }
        public Logger.LoggerConfiguration Logger { get; set; }
        public Dictionary<string, string> ConnectionStrings { get; set; }
        public string Secret { get; set; }

    }
}
