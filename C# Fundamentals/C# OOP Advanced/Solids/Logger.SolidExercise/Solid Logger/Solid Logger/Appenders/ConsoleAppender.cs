﻿namespace Solid_Logger.Appenders
{
    using global::Appenders.Contracts;
    using Layouts.Contracts;
    using Loggers.Enums;
    using System;

    public class ConsoleAppender : Appender
    {
        private readonly ILayout layout;

        public ConsoleAppender(ILayout layout) : base(layout)
        { }

        public ReportLevel ReportLevel { get; set; }

        public int MessagesCount { get; protected set; }

        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                this.MessagesCount++;
                Console.WriteLine(string.Format(this.layout.Format, dateTime, reportLevel, message));
            }
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.layout.GetType().Name}, Report level: " +
                $"{this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessagesCount}";
        }
    }
}
