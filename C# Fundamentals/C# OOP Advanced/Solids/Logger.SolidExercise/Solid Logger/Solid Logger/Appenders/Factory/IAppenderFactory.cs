namespace Solid_Logger.Appenders.Factory
{
    using global::Appenders.Contracts;
    using Layouts.Contracts;
    interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout);
    }
}
