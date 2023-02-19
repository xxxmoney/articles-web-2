using Microsoft.Identity.Client;
using Serilog.Context;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Events;
using Serilog.Core;
using System.Runtime.CompilerServices;
using Serilog;

namespace Web.Logger
{
    /// <summary>
    /// Logger with class and method name logging.
    /// </summary>
    public interface ILogger
    {
        void Debug(Exception ex, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
        void Debug(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
        void Debug(string message, Exception ex, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
        void Error(Exception ex, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
        void Error(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
        void Error(string message, Exception ex, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
        void Fatal(Exception ex, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
        void Fatal(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
        void Fatal(string message, Exception ex, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
        void Info(Exception ex, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
        void Info(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
        void Info(string message, Exception ex, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
        void Verbose(Exception ex, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
        void Verbose(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
        void Verbose(string message, Exception ex, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
        void Warn(Exception ex, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
        void Warn(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
        void Warn(string message, Exception ex, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0);
    }

    /// <summary>
    /// Wraps Serilog logger with class and method name logging capabilities.
    /// </summary>
    public class Logger : ILogger
    {
        private readonly Serilog.ILogger logger;

        public Logger(Serilog.ILogger logger)
        {
            this.logger = logger;
        }

        public void Verbose(
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            this.logger.Verbose(
                message
                    .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
                );
        }

        public void Verbose(
            string message,
            Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            this.logger.Verbose(
                message
                    .FormatForException(ex)
                    .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
                );
        }

        public void Verbose(
            Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {

            this.logger.Verbose(
                (ex != null ? ex.ToString() : "")
                    .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
                );
        }

        public void Debug(
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            this.logger.Debug(
                message
                    .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
                );
        }

        public void Debug(
            string message,
            Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            this.logger.Debug(
                message
                    .FormatForException(ex)
                    .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
                );
        }

        public void Debug(
            Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {

            this.logger.Debug(
                (ex != null ? ex.ToString() : "")
                    .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
                );
        }

        public void Info(
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            this.logger.Information(
                message
                    .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
                );
        }

        public void Info(
            string message,
            Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {

            this.logger.Information(
                message
                    .FormatForException(ex)
                    .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
                );
        }

        public void Info(
            Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {

            this.logger.Information(
                (ex != null ? ex.ToString() : "")
                    .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
                );
        }

        public void Warn(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {

            this.logger.Warning(
                message
                    .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
                );
        }

        public void Warn(
            string message,
            Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {

            this.logger.Warning(
                message
                    .FormatForException(ex)
                    .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
                );
        }

        public void Warn(
            Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {

            this.logger.Warning(
                (ex != null ? ex.ToString() : "")
                    .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
                );
        }

        public void Error(
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {

            this.logger.Error(
                message
                    .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
                );
        }

        public void Error(
            string message,
            Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {

            this.logger.Error(
                message
                    .FormatForException(ex)
                    .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
                );
        }

        public void Error(
            Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {

            this.logger.Error(
                (ex != null ? ex.ToString() : "")
                    .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
                );
        }

        public void Fatal(
            string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            FatalAction();

            this.logger.Error(
                message
                    .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
                );
        }

        public void Fatal(
            string message,
            Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            FatalAction();

            this.logger.Error(
                message
                    .FormatForException(ex)
                    .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
                );
        }

        public void Fatal(
            Exception ex,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            FatalAction();

            this.logger.Error(
                (ex != null ? ex.ToString() : "")
                    .FormatForContext(memberName, sourceFilePath, sourceLineNumber)
                );
        }

        private void FatalAction()
        {
            Environment.ExitCode = -1;
        }
    }
}
