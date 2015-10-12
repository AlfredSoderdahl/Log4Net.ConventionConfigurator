using System.Text;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;

namespace Log4Net.ConventionConfigurator {
    public static class AppenderFactory {
        public static IAppender CreateRollingFileAppender(Level threshold) {
            var layout = new PatternLayout("%date %-5level %logger - %message%newline");
            layout.ActivateOptions();

            var appender = new RollingFileAppender {
                File = $@"\Logs\{threshold}.log",
                Encoding = Encoding.UTF8,
                Threshold = threshold,
                Layout = layout
            };

            appender.ActivateOptions();

            return appender;
        }

        public static IAppender CreateColoredConsoleAppender(Level threshold) {
            var layout = new PatternLayout("%date %-5level %logger - %message%newline");
            layout.ActivateOptions();

            var appender = new ColoredConsoleAppender() {
                Threshold = threshold,
                Layout = layout
            };

            appender.ActivateOptions();

            return appender;
        }

        public static IAppender CreateDebugAppender(Level threshold) {
            var layout = new PatternLayout("%date %-5level %logger - %message%newline");
            layout.ActivateOptions();

            var appender = new DebugAppender() {
                Threshold = threshold,
                Layout = layout
            };

            appender.ActivateOptions();

            return appender;
        }
    }
}