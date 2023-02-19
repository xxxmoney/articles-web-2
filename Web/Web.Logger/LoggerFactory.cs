using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Logger
{
    /// <summary>
    /// Factory for database logger.
    /// </summary>
    public interface ILoggerFactory
    {
        /// <summary>
        /// Creates a new instance of database logger.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        ILogger CreateLogger(Configuration configuration);
    }

    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger(Configuration configuration)
        {
            return new LoggerConfiguration()
                .WriteTo.MSSqlServer(
                    connectionString: configuration.ConnectionString,
                    columnOptions: configuration.ColumnOptions,
                    sinkOptions: new MSSqlServerSinkOptions
                    {
                        AutoCreateSqlTable = configuration.AutoCreateTable,
                        TableName = configuration.TableName,
                        SchemaName = configuration.SchemaName
                    })
                .CreateLogger();

        }
    }
}
