using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Logger
{

    /// <summary>
    /// Configuration for Serilog database logger.
    /// </summary>
    public class Configuration
    {
        public string ConnectionString { get; set; }
        public ColumnOptions ColumnOptions { get; set; }
        public bool AutoCreateTable { get; set; }
        public string TableName { get; set; }
        public string SchemaName { get; set; }
    }

}
