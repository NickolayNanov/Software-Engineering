namespace Solid_Logger.Appenders
{
    using global::Appenders.Contracts;
    using Solid_Logger.Layouts.Contracts;
    using Solid_Logger.Loggers.Enums;

    public abstract class Appender : IAppender
    {
        private readonly ILayout layout;

        protected Appender(ILayout layout)
        {
            this.layout = layout;
        }

        protected ILayout Layout => this.layout;

        public ReportLevel ReportLevel { get; set ; }

        public int MessagesCount { get; protected set; }

        public abstract void Append(string dateTime, ReportLevel errorLevel, string message);
    }
}
