using Solid_Logger.Loggers.Enums;

namespace Appenders.Contracts
{
    public interface IAppender
    {
        ReportLevel ReportLevel { get; set; }

        void Append(string dateTime, ReportLevel errorLevel, string message);
        int MessagesCount { get; }
    }
}
