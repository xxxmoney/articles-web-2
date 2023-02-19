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
            var columnOptions = configuration.ColumnOptions;

            // Set columns.
            columnOptions.Store.Clear();
            columnOptions.Store.Add(StandardColumn.Id);
            columnOptions.Store.Add(StandardColumn.Message);
            columnOptions.Store.Add(StandardColumn.Level);
            columnOptions.Store.Add(StandardColumn.TimeStamp);
            columnOptions.Store.Add(StandardColumn.Exception);

            // Create logger.
            Log.Logger = new LoggerConfiguration()
                .WriteTo.MSSqlServer(
                    connectionString: configuration.ConnectionString,
                    columnOptions: columnOptions,
                    sinkOptions: new MSSqlServerSinkOptions
                    {
                        AutoCreateSqlTable = configuration.AutoCreateTable,
                        TableName = configuration.TableName,
                        SchemaName = configuration.SchemaName
                    })
                .CreateLogger();
            
            Serilog.Debugging.SelfLog.Enable(msg => Console.WriteLine(msg));

            return Log.Logger;

        }
    }
}
